using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    // A helper class to store information about each task
    class TaskInfo
    {
        public Task<long> Task { get; set; } // The task itself
        public long Length { get; set; } // The length of the subset of numbers assigned to the task
    }

    // Computes the sum of the numbers between start and end, inclusive
    static long ComputeSum(long start, long end)
    {
        long sum = 0;
        for (long i = start; i <= end; i++)
        {
            sum += i;
        }
        return sum;
    }

    static void Main(string[] args)
    {
        long n = 1000000000; // The upper bound for the sum
        int numThreads = 4; // The number of threads to use
        long chunkSize = n / numThreads; // The size of each subset of numbers

        // Create a list of TaskInfo objects to store information about each task
        List<TaskInfo> taskInfos = new List<TaskInfo>();

        // Create a task for each subset of numbers
        for (int i = 0; i < numThreads; i++)
        {
            long start = i * chunkSize + 1;
            long end = (i + 1) * chunkSize;
            if (i == numThreads - 1)
            {
                end = n;
            }
            taskInfos.Add(new TaskInfo
            {
                Task = new Task<long>(() => ComputeSum(start, end)), // Create a task that computes the sum of the subset
                Length = end - start + 1 // Store the length of the subset
            });
        }

        // Sort the tasks by their lengths (shortest job next)
        taskInfos = taskInfos.OrderBy(t => t.Length).ToList();

        // Start the tasks in sorted order
        foreach (var taskInfo in taskInfos)
        {
            taskInfo.Task.Start();
        }

        // Wait for all tasks to complete
        Task.WaitAll(taskInfos.Select(t => t.Task).ToArray());

        // Add up the results from each task
        long totalSum = 0;
        for (int i = 0; i < numThreads; i++)
        {
            totalSum += taskInfos[i].Task.Result;
        }
        Console.WriteLine(totalSum);
    }
}

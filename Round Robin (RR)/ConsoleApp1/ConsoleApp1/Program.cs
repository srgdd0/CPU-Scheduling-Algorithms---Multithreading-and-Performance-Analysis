using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

class Program
{
    // Computes the sum of numbers between start and end, where the computation is split into timeQuantum-sized chunks
    static long ComputeSum(ref long start, long end, long timeQuantum)
    {
        long sum = 0;
        long maxEnd = Math.Min(start + timeQuantum, end); // Compute the end point for this chunk
        for (long i = start; i <= maxEnd; i++)
        {
            sum += i; // Compute the sum of this chunk
        }
        start = maxEnd + 1; // Update the starting point for the next chunk
        return sum;
    }

    static async Task Main(string[] args)
    {
        long n = 1000000000; // The number up to which we want to calculate the sum
        int numThreads = 4; // The number of threads to use for the computation
        long chunkSize = n / numThreads; // The chunk size for each thread
        long timeQuantum = 10000; // The time quantum for each chunk

        Queue<TaskCompletionSource<long>> tasksQueue = new Queue<TaskCompletionSource<long>>(numThreads); // A queue to hold the tasks
        long[] taskStarts = new long[numThreads]; // An array to hold the starting point of each chunk
        long[] taskEnds = new long[numThreads]; // An array to hold the ending point of each chunk

        // Create tasks for each chunk of numbers and add them to the tasksQueue
        for (int i = 0; i < numThreads; i++)
        {
            long start = i * chunkSize + 1;
            long end = (i + 1) * chunkSize;
            if (i == numThreads - 1)
            {
                end = n;
            }
            taskStarts[i] = start;
            taskEnds[i] = end;
            tasksQueue.Enqueue(new TaskCompletionSource<long>());
        }

        long totalSum = 0;
        // Process tasks in the tasksQueue until all tasks have completed
        while (tasksQueue.Count > 0)
        {
            var tcs = tasksQueue.Dequeue();
            int taskIndex = Array.IndexOf(tasksQueue.ToArray(), tcs); // Get the index of the current task in the task queue
            long start = taskStarts[taskIndex];
            long end = taskEnds[taskIndex];

            if (start <= end)
            {
                long sum = ComputeSum(ref start, end, timeQuantum); // Compute the sum for this chunk
                taskStarts[taskIndex] = start;
                totalSum += sum;

                if (start <= end)
                {
                    tasksQueue.Enqueue(tcs); // Enqueue the task for the next chunk
                }
                else
                {
                    tcs.SetResult(sum); // Set the task result if all chunks have been processed
                }
            }
            else
            {
                tcs.SetResult(0); // Set the task result to 0 if the chunk is empty
            }
        }

        await Task.WhenAll(tasksQueue.Select(tcs => tcs.Task).ToArray()); // Wait for all tasks to complete
        Console.WriteLine(totalSum); // Print the total sum to the console
    }
}

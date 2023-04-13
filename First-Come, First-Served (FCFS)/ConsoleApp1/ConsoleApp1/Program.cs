using System;
using System.Collections.Concurrent; // For ConcurrentQueue
using System.Threading; // For ManualResetEvent and Interlocked
using System.Threading.Tasks; // For Task

class Program
{
    // Computes the sum of all numbers between start and end (inclusive)
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
        long n = 1000000000; // The number up to which we want to calculate the sum
        int numThreads = 4; // The number of threads we want to use to perform the computation
        long chunkSize = n / numThreads; // The chunk size for each thread

        ConcurrentQueue<Task<long>> tasksQueue = new ConcurrentQueue<Task<long>>(); // A thread-safe queue to hold the tasks
        ManualResetEvent tasksCompleted = new ManualResetEvent(false); // An event to signal when all tasks have completed
        int completedTasks = 0; // A counter to keep track of how many tasks have completed

        // Create numThreads tasks, each of which computes the sum of a chunk of numbers
        for (int i = 0; i < numThreads; i++)
        {
            long start = i * chunkSize + 1;
            long end = (i + 1) * chunkSize;
            if (i == numThreads - 1)
            {
                end = n;
            }
            // Add the task to the queue using Task.Run to start it on a separate thread
            tasksQueue.Enqueue(Task.Run(() =>
            {
                long sum = ComputeSum(start, end);
                // Increment the completedTasks counter atomically
                Interlocked.Increment(ref completedTasks);
                // If all tasks have completed, signal tasksCompleted by calling its Set method
                if (completedTasks == numThreads)
                {
                    tasksCompleted.Set();
                }
                return sum;
            }));
        }

        // Wait for tasksCompleted to be signaled using its WaitOne method, which blocks until the event is signaled
        tasksCompleted.WaitOne();

        long totalSum = 0;
        // Retrieve the results of each task from the tasksQueue using TryDequeue and add them up to get the total sum
        while (tasksQueue.TryDequeue(out Task<long> task))
        {
            totalSum += task.Result;
        }
        Console.WriteLine(totalSum); // Print the total sum to the console
    }
}

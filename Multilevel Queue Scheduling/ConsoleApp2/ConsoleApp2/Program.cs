using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    // Computes the sum of numbers between start and end
    static long ComputeSum(long start, long end)
    {
        long sum = 0;
        for (long i = start; i <= end; i++)
        {
            sum += i;
        }
        return sum;
    }

    static async Task Main(string[] args)
    {
        long n = 1000000000; // The number up to which we want to calculate the sum
        int numThreads = 4; // The number of threads to use for the computation
        long chunkSize = n / numThreads; // The chunk size for each thread

        Queue<Task<long>>[] taskQueues = new Queue<Task<long>>[2]; // Two queues to hold the tasks
        taskQueues[0] = new Queue<Task<long>>(); 
        taskQueues[1] = new Queue<Task<long>>(); 

        // Create tasks for each chunk of numbers and add them to the appropriate queue based on the thread index
        for (int i = 0; i < numThreads; i++)
        {
            long start = i * chunkSize + 1;
            long end = (i + 1) * chunkSize;
            if (i == numThreads - 1)
            {
                end = n;
            }
            Task<long> task = new Task<long>(() => ComputeSum(start, end)); // Create a new task for this chunk
            if (i % 2 == 0)
            {
                taskQueues[0].Enqueue(task); // Add the task to the even queue
            }
            else
            {
                taskQueues[1].Enqueue(task); // Add the task to the odd queue
            }
        }

        // Start tasks in multilevel queue order
        foreach (var queue in taskQueues)
        {
            while (queue.Count > 0)
            {
                var task = queue.Dequeue();
                task.Start(); // Start the task
                await task; // Wait for the task to complete
            }
        }

        // Compute the total sum by dequeuing tasks from the queues and adding their results
        long totalSum = 0;
        for (int i = 0; i < numThreads; i++)
        {
            int queueIndex = i % 2; // Determine the index of the queue to dequeue from based on the thread index
            if (taskQueues[queueIndex].Count > 0)
            {
                totalSum += taskQueues[queueIndex].Dequeue().Result; // Dequeue the task and add its result to the total sum
            }
        }
        Console.WriteLine(totalSum); // Print the total sum to the console
    }
}

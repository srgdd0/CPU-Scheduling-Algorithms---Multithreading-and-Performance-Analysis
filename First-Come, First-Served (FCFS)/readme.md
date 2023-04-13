# First-Come, First-Served (FCFS)

---

This C# program demonstrates how to compute the sum of numbers from 1 to n using multiple threads to speed up the computation. It uses the Task Parallel Library (TPL) to distribute the work among different threads and a ConcurrentQueue to hold the tasks.

The program begins by setting the value of n, the number up to which we want to calculate the sum, and the number of threads to use for the computation. It then divides the computation into chunks, where each chunk represents a subset of numbers that a thread can work on.

Next, the program creates a thread-safe queue to hold the tasks, a ManualResetEvent to signal when all tasks have completed, and an integer to keep track of how many tasks have completed.

The program then creates several tasks, each of which computes the sum of a chunk of numbers. It assigns each task to a thread by adding it to the tasks queue using Task.Run to start each task on a separate thread. The program uses Interlocked.Increment method to atomically increment the counter of completed tasks, and it checks whether all tasks have completed. If all tasks have completed, it signals tasksCompleted by calling its Set method.

The program waits for tasksCompleted to be signaled using its WaitOne method, which blocks until the event is signaled.

Finally, the program retrieves the results of each task from the tasks queue using TryDequeue and adds them up to get the total sum. The total sum is then printed to the console.

Overall, this program showcases the benefits of parallel computing and demonstrates how to use the TPL to achieve parallelism in C#. However, writing parallel code can be tricky and requires careful attention to avoid issues such as race conditions and deadlocks. Therefore, it is important to use thread-safe data structures and synchronization mechanisms when writing parallel code.

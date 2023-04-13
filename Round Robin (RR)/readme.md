# Round Robin (RR)

---

This C# program calculates the sum of numbers from 1 to n using multiple threads and a round-robin scheduling algorithm. The program uses the Task Parallel Library (TPL) to manage the tasks and a queue to hold them.

The program begins by setting the value of n, the number up to which we want to calculate the sum, the number of threads to use for the computation, the chunk size, and the time quantum for each chunk. It then creates a queue to hold the tasks and two arrays to store the starting and ending points of each chunk.

The program processes the tasks in a loop until all tasks have completed. It dequeues a task from the queue, computes the sum for the corresponding chunk of numbers, updates the starting point for the next chunk, and enqueues the task back into the queue if there are more chunks to compute. If there are no more chunks to compute, the program sets the task result and moves on to the next task.

Round-robin scheduling is used in this program to distribute the work among different threads and prevent any one thread from hogging the CPU for too long. Each task is assigned a time quantum, which is the maximum number of iterations it can execute before it is preempted and another task is scheduled. The program uses the taskStarts and taskEnds arrays to keep track of the starting and ending points of each chunk. The starting point of each chunk is passed to the ComputeSum method by reference and is updated at the end of each iteration to reflect the starting point of the next chunk.

Round-robin scheduling is a widely used algorithm in operating systems and multi-tasking systems to schedule tasks in a way that ensures fairness and prevents starvation. It can be used to distribute work among different threads, to prevent thread starvation, and to ensure that each task gets a fair share of the CPU time.

In summary, this program showcases how the TPL and round-robin scheduling can be used to achieve parallelism in C#. It demonstrates how round-robin scheduling can be used to distribute work among different threads and to ensure that each task gets a fair share of the CPU time.

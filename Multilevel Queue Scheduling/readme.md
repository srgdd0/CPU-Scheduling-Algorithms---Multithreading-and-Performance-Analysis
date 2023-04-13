# Multilevel Queue Scheduling

---

This C# program is designed to calculate the sum of numbers from 1 to n using multiple threads and a multilevel queue scheduling algorithm. The program uses the Task Parallel Library (TPL) to create and manage the tasks, and two queues to hold them.

At the start of the program, the value of n, the number of threads to use, and the chunk size for each thread are set. Two queues are then created to hold the tasks, and initialized with Task objects equal to the number of threads.

For each thread, a task is created for each chunk of numbers and added to the appropriate queue based on the thread index. The multilevel queue scheduling algorithm is then used to schedule the tasks. The algorithm uses two queues, one for even-indexed threads and one for odd-indexed threads. The tasks in the even queue are executed before tasks in the odd queue to ensure fair distribution of the workload.

The tasks are then started in multilevel queue order. Each task is dequeued from the appropriate queue, started, and awaited until completion. This process is repeated for all tasks in both queues to ensure that each thread is allotted a fair share of the CPU time.

Finally, the program computes the total sum by dequeuing tasks from the queues and adding their results. The index of each thread is used to determine which queue to dequeue from, and the result is added to the total sum.

Multilevel queue scheduling is a common scheduling algorithm used in operating systems and multitasking systems to schedule tasks in a way that prioritizes certain tasks over others while ensuring fairness and preventing starvation. In this program, multilevel queue scheduling is used to distribute the workload among the threads, prevent thread starvation, and prioritize tasks in the even queue over tasks in the odd queue.

In conclusion, this program highlights how the TPL and multilevel queue scheduling can be used to achieve parallelism in C#. It showcases how multilevel queue scheduling can be used to distribute the workload among threads, prioritize certain tasks over others, and prevent thread starvation, thus improving the overall performance of the program.

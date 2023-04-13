# Priority Scheduling

---

This project aims to explore the use of Priority Scheduling in a multithreaded program to compute the sum of a large range of numbers. When computing the sum of numbers from 1 to a large number, a sequential approach can be time-consuming and computationally expensive. By using Priority Scheduling, we can optimize the use of resources when assigning tasks to threads and speed up the computation time.

Program Description:
The program is written in C# and uses the System.Threading.Tasks library to create and manage multiple threads. To divide the task of computing the sum of numbers from 1 to a large number into smaller tasks, the program creates four threads, where each thread is responsible for computing the sum of a quarter of the numbers from 1 to the specified large number.

The program defines the upper bound of the sum (n), the number of threads to use (numThreads), and the size of each subset of numbers (chunkSize). It then creates a list of TaskInfo objects to store information about each task. Each TaskInfo object contains a Task object, which represents the task itself, and a priority value to determine the order in which the task should be executed.

For each subset of numbers, the program creates a task and assigns a priority to it based on its size. The larger the subset, the lower the priority value. The program then sorts the tasks in descending order of priority (highest priority first) to optimize the use of resources. The program starts each task in the order specified by the sorted list of tasks and waits for all tasks to complete using the WaitAll method of the Task class. Finally, the program adds up the results from each task to compute the total sum and prints it to the console.

Priority Scheduling:
Priority Scheduling is a scheduling algorithm in which tasks are assigned priorities to determine the order in which they should be executed. In this program, we assign priorities based on the size of the subsets of numbers. This approach ensures that the smaller tasks are executed first, which minimizes the idle time of threads and ensures that the available resources are used efficiently.

Conclusion:
In conclusion, this project demonstrates the effectiveness of Priority Scheduling in reducing the time required to compute the sum of a large range of numbers using multithreading. By dividing the task into smaller subsets and assigning them to separate threads, and by using Priority Scheduling to assign priorities based on subset size, the program is able to perform the computation much more quickly than on a single thread. This approach can be easily adapted to use a different number of threads or to compute the sum of numbers to a different upper bound. The use of Priority Scheduling can be beneficial in a variety of applications where a sequential approach to computation is inefficient or not feasible.

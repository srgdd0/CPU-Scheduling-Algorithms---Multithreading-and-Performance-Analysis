# Shortest Job Next (SJN)

---

In this project, we explore the use of multithreading to compute the sum of a large range of numbers. When computing the sum of numbers from 1 to a large number, a sequential approach can be time-consuming and computationally expensive. Multithreading is an effective way to reduce the time required for computation by dividing the work among multiple threads.

Program Description:
The program is written in Python and uses the concurrent.futures module to create and manage multiple threads. The program divides the task of computing the sum of numbers from 1 to a large number into smaller tasks, each of which is assigned to a separate thread. Specifically, the program creates four threads, where each thread is responsible for computing the sum of a quarter of the numbers from 1 to the specified large number.

The program first defines the upper bound of the sum (n), the number of threads to use (num_threads), and the size of each subset of numbers (chunk_size). It then creates a ThreadPoolExecutor with the specified number of threads and submits a task for each subset of numbers using the executor's submit method. The program uses a lambda function to define the computation function, which takes the start and end numbers of a subset and returns the sum of that subset.

The program then waits for all tasks to complete using the as_completed method of the concurrent.futures module. Finally, the program adds up the results from each task to compute the total sum and prints it to the console.

Conclusion:
In conclusion, this project demonstrates the effectiveness of multithreading in reducing the time required to compute the sum of a large range of numbers. By dividing the task into smaller subsets and assigning them to separate threads, the program is able to perform the computation much more quickly than on a single thread. The program can be easily adapted to use a different number of threads or to compute the sum of numbers to a different upper bound. This technique of multithreading can be useful in a variety of applications where a sequential approach to computation is inefficient or not feasible.

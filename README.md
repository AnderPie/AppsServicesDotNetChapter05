The following is work undertaken to learn C# through use of Mark Price's C#12 and .NET 8 Modern Cross-Platform Development Fundamentals.  
# Exercise 5.1 - Test your knowledge

## What information can you find out about a process?
 System.Diagnostics.Process.GetCurrentProcess() can be used to retrieve a process, and
 from there you can extract loads of information such as:
 * cpu time
 * memory usage
 * Number of active threads
 * and more
 You can also get information about a thread a process is running on with
 Thread.CurrentThread, such as the thread's Id, priority, etc.
## How accurate is the stopwatch class?
The accuracy of the stopwatch varies with the hardware of the computer running it, but
it is probably reliably accurate within 10s of nanoseconds.
## By convention what suffix should be applied to a method that reutrns Task or Task<T>
Async. So for instance, GetInformationAsync() would allow another developer to easily see that
this returns a Task or Task<T>.
## To use the await keyword inside a method, what keyword must be applied to the method declaration?
Async.
## How do you create a child task?
Use Task.Factory.StartNew(YourChildTask, TaskCreationOptions.AttachedToParent) within the method
calling its child.
```c#
Task parentTask = Task.Factory.StartNew(() =>
{
    Console.WriteLine("Parent task starting.");

    // Create a child task
    Task.Factory.StartNew(() =>
    {
        Console.WriteLine("Child task running.");
        Task.Delay(1000).Wait(); // Simulating some work
        Console.WriteLine("Child task completed.");
    }, TaskCreationOptions.AttachedToParent);

    Console.WriteLine("Parent task finished.");
});

parentTask.Wait(); // Wait for the parent task and its child to complete
Console.WriteLine("All tasks completed.");
```
## Why should you avoid the lock keyword?
You can create deadlocked scenarios where your program cannot advance. Imagine that you have two tasks and two objects, Task A has locked Object A, and Task B has locked Object B. Task A needs access to Object B
in order to complete its task, and Task B needs access to Object A. Neither Task can finish and unlock its
object, so you have created a deadlock. It is OK to use the lock keyword, but you need to be careful and 
be absolutely sure a deadlock can't go. 
## When should you use the Interlocked class
If you share an object between classes and want to conduct atomic operations on the shared object.
Imagine you have TaskA and TaskB, and they share ObjectA, an integer initially set to 0. 
Without interlocking, 
TaskA might increment ObjectA by one. 
TaskB might increment ObjectA by one.
An (non-Interlocked) increment operation actually consists of THREE operations: read the value, increment
the value, store the value in the instance. 
So TaskA could read ObjectA, TaskB reads objectA, increments objectA, and overwrite ObjectA, but then
TaskA increments its old image of ObjectA and overwrites it. Despite two increment operations running, 
only one has been recorded. Imagine that happens with a bank account of rocket!
## When should you use Mutex instead of Monitor?
https://www.albahari.com/threading/threading.pdf is a great resource
Mutex can spawn app domains, but is a heavier than Monitor.Enter/Monitor.Exit, taking about 1000 ns
compared to 20ns. Admittedly, 1000NS is just .001 millisecond.

## What is the benefit of using Async and Await in a website or web service
You don't want to have your whole web service or website freeze up while your client is waiting for a
response from the server. Running tasks provides a lightweight way to make requests and await responses
while still allowing the user total control over their experience.
## Can you cancel a task? If so, how?
Absolutely. 
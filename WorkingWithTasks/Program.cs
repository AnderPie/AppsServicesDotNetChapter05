using System.Diagnostics;

OutputThreadInfo();
Stopwatch timer = Stopwatch.StartNew();

#region Synchronously running methods on one thread
/*
SectionTitle("Running methods synchronously on one thread");
MethodA();
MethodB();
MethodC();
WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
*/
#endregion
#region Asynchronously running tasks on multiple threads
SectionTitle("Running methods asynchronously on multiple threads");
Task taskA = new(MethodA);
taskA.Start();
Task taskB = Task.Factory.StartNew(MethodB);
Task taskC = Task.Run(MethodC);
Task[] tasks = { taskA, taskB, taskC };
Task.WaitAll(tasks);
WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed");
#endregion
#region Continuation tasks
timer.Restart();
SectionTitle("Passing the result of one task as an input into another");
Task<string> taskServiceThenSProc = Task.Factory
    .StartNew(CallWebService) // Returns Task<Decimal>
    .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));
WriteLine($"Result: {taskServiceThenSProc.Result}");
WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
#endregion
#region Nested tasks
OuterMethod();
#endregion
#region Wrapping tasks around other objects
/*
 * Sometimes you have a method you want to be asynchronous, but the result to be returned is not a task itself.
 * You can wrap the return value in a completed task, return an exception, or indicate that the task was canceled by using
 * one of the the Task static methods
 * FromResult<TResult>)(TResult)  Creates a Task<TResult> object whose Result property is the non-task result and whose status property is RanToCompletion
 * FromException<TResult>(Exception) 
 * FromCanceled<TResult>(CancellationToken) 
 */
#endregion
#region Synchronizing access to shared resources
// Monitor: An object that can be used by multiple threads to check if they should access a shared resource within the same process
// Interlocked: An object for manipulating simple numeric types at the CPU level.
#endregion

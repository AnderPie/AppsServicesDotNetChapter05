using SynchronizingResourceAccess;
using System.Diagnostics; // To use Stopwatch
WriteLine("Please wait for the tasks to complete.");
Stopwatch watch = Stopwatch.StartNew();
Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);

Task.WaitAll(new Task[] { a, b });
WriteLine();
WriteLine($"Results: {SharedObjects.Message}.");
WriteLine($"{SharedObjects.Counter} string modifications.");
WriteLine($"{watch.ElapsedMilliseconds:N0} elapsed milliseconds.");

#region Notes: Applying other types of synchronization
/* |==========================================================================================|
 * | Type                 | Description                                                       |
 * |----------------------|-------------------------------------------------------------------|
 * |ReadWriterLock,       | These allow multiple threads to be in read mode, one thread       |
 * |ReadWriterLockSlim    | to be in write modewith exclusive ownership of the write          |
 * |                      | lock, and one thread that has read access to be in uprgradeable   |
 * |                      | read mode from which the thread can upgrade to write mode without |
 * |                      | having to relinquish its read access to the resource.             |
 * |------------------------------------------------------------------------------------------|
 * |Mutex                 | Like Monitor, this provides exclusive access to a shared resource,|
 * |                      | except it is used for inter-process synchronization.              |
 * |----------------------|-------------------------------------------------------------------|
 * |Semaphore,            | These limit the number of threads that can access a resource or   |
 * |SemaphoreSlim         | pool of resources concurrently by defining slots. This is known as|
 * |                      | resource throttling rather than resource locking.                 |
 * |----------------------|-------------------------------------------------------------------|
 * |AutoResetEvent        | Event wait handles allow threads to synchronize activities by     |
 * |ManualResetEvent      | signaling each other and by waiting for each other's signals.     |
 * |__________________________________________________________________________________________|
 */
#endregion


partial class Program
{
    private static void MethodA() 
    {
        TaskTitle("Starting Method A...");
        OutputThreadInfo();
        Thread.Sleep(3000);
        TaskTitle("Finished Method A");
    }
    private static void MethodB() 
    {
        TaskTitle("Starting Method B...");
        OutputThreadInfo();
        Thread.Sleep(2000); // Simulate 2 seconds of work
        TaskTitle("Finished Method B");
    }
    private static void MethodC() 
    {
        TaskTitle("Starting Method C...");
        OutputThreadInfo();
        Thread.Sleep(1000);
        TaskTitle("Finished Method C");
    }
    /// <summary>
    /// Simulates call to a web service and retrieval of a monetary amount.
    /// Used to demonstration ordering tasks with continuation policies.
    /// </summary>
    /// <returns>Decimal representing USD</returns>
    private static decimal CallWebService() 
    {
        TaskTitle("Starting call to web service...");
        OutputThreadInfo();
        Thread.Sleep(Random.Shared.Next(2000, 4000));
        TaskTitle("Finished call to web service");
        return 89.99M;
    }
    private static string CallStoredProcedure(decimal amount)
    {
        TaskTitle("Starting call to stored procedure...");
        OutputThreadInfo();
        Thread.Sleep(Random.Shared.Next(2000, 4000));
        TaskTitle("Finished call to stored procedure.");
        return $"12 products cost more than {amount:C}";
    }
    
    private static void OuterMethod()
    {
        TaskTitle("Outer method starting...");
        Task innerTask = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent); // Without AttachedToParent, outermethod can finish before child method does.
        TaskTitle("Outer method finished.");
    }

    private static void InnerMethod()
    {
        TaskTitle("Inner method starting...");
        Thread.Sleep(2000);
        TaskTitle("Inner method finished.");
    }
    /*
    public interface IValidation
    {
        Task<bool> IsValidXmlTagAsync(this string input);
    }
    */


}
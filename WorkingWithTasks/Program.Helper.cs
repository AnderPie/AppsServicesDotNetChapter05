partial class Program
{
    private static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"*** {title}");
        ForegroundColor = previousColor;
    }

    private static void TaskTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"{title}");
        ForegroundColor = previousColor;
    }

    private static void OutputThreadInfo()
    {
        Thread t = Thread.CurrentThread;
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine($"Thread ID: {t.ManagedThreadId}, Priority: {t.Priority}, Background: {t.IsBackground}, Name: {t.Name ?? "null"}");
        ForegroundColor = previousColor;
    }
}
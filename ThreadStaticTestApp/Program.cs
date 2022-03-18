using System.Text;

class Program
{
    //[ThreadStatic] static StringBuilder stringBuilder;
    static ThreadLocal<StringBuilder> stringBuilderWrapper = new ThreadLocal<StringBuilder>(() => new StringBuilder());

    public static void Main(string[] args)
    {
        Task.Run(Print);
        Print();
    }

    private static void Print()
    {
        var stringBuilder = stringBuilderWrapper.Value!;
        
        stringBuilder.Append("hello *" + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine(stringBuilder.ToString());
    }
}
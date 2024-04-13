class MyException : Exception
{
    public MyException() : base("строка пустая")
    {
    }
}
public class Process
{
    public void Go(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new MyException();
        }
        else
        {
            Console.WriteLine(str);
        }
    }

}
internal class Program
{
    private static void Main(string[] args)
    {
        var pro = new Process();
        try
        {
            Console.WriteLine("введите строку");
            string st = Console.ReadLine();

            pro.Go(st);
        }
        catch (MyException ex)
        {
            Console.WriteLine($"возникла ошибка {ex}");
        }
    }
}
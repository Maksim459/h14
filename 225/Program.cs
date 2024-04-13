
using System.Runtime.InteropServices;

class Numbers
{ 
  
  public void Num()
  {
        //1
        Flag1:
     
        Console.WriteLine("введите 1 число от 0 до 225");
        string num1 = Console.ReadLine();
       
        int numb1 = -1;
        try
        {
           numb1= int.Parse(num1);

        }
        catch (FormatException n)
        { 
           Console.WriteLine($"вызвано исключение {n}");
        }

        try
        {
            if (numb1 < 0 || numb1 > 225)
            {
                throw new Exception("введенное число не входит в рамки");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"general error{ex}");
            Console.Clear();
            goto Flag1;
        }
      
        //2
        Flag2:
     
        Console.WriteLine("введите 2 число от 0 до 225");
        string num2 = Console.ReadLine();

        int numb2 = -1;
        try
        {
           numb2= int.Parse(num2);

        }
        catch (FormatException n)
        { 
           Console.WriteLine($"вызвано исключение {n}");
        }
        try
        {
            if (numb2 < 0 || numb2 > 225)
            {
                throw new Exception("введенное число не входит в рамки");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"general error{ex}");
            Console.Clear();
            goto Flag2;
        }
       
        //Console.WriteLine(numb2);

        //
        int numbfinal = 0;
        try
        {
             numbfinal = numb1 / numb2;
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine($"вызвано исключение {ex}");
        }

        if (numbfinal != 0)
        { 
         Console.WriteLine(numbfinal);
        }
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Numbers numbers = new Numbers();
        numbers.Num();
    }
}
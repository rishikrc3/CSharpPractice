using System;

public abstract class Discount
{
    public abstract decimal ApplyDiscount(decimal Num);
}

public class D1 : Discount
{
    public override decimal ApplyDiscount(decimal Num)
    {
        return Num - 10;
    }
}

public class D2 : Discount
{
    public override decimal ApplyDiscount(decimal Num)
    {
        return Num - 20;
    }
}

public class Prog()
{
    public static void Main(string[] args)
    {
        Discount d1 = new D1();
        Discount d2 = new D2();
        Console.WriteLine(d1.ApplyDiscount(100));
        Console.WriteLine(d2.ApplyDiscount(100));
    }

}
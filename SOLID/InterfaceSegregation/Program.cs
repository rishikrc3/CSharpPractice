using System;
interface IBad
{
    public void Work();
    public void Eat();
}

interface IWork
{
    public void Work();
}

interface IEat
{
    public void Eat();
}

public class Robot: IWork
{
    public void Work()
    {
        Console.WriteLine("Robot work");
    }
}

class Prog
{
    public static void Main(string[] args)
    {
        Robot robot = new Robot();
        robot.Work();
    }
}
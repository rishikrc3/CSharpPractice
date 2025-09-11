using System;

public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is Flying");
    }
}

public class Eagle: Bird
{
    public override void Fly()
    {
        Console.WriteLine("Eagle is Flying");
    }
}

public class Penguin: Bird
{
    public override void Fly()
    {
        throw new Exception("Penguins can't fly");
    }
}
public class BirdTrainer
{
    public static void TrainBird(Bird bird)
    {
        Console.WriteLine("Training bird to fly...");
        bird.Fly(); 
    }
}


public class Prog
{
    public static void Main(string[] args)
    {
        Bird eagle = new Eagle();
        
        BirdTrainer.TrainBird(eagle);
    }
}
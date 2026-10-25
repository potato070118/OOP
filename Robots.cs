using System;
using System.Collections.Generic;

interface IBattery {
    int RemainingEnergy { get; }
    void Consume(int amount);
    void Recharge(int amount);
}

class LithiumBattery : IBattery {
    private int _remainingEnergy = 100;
    public int RemianingEnergy => _remainingEnergy;
    public void Consume(int amount) => _remainingEnergy = Math.Max(0, _remainingEnergy-amount);
    public void Recharge(int amount) => _remainingEnergy = Math.Min(100,_remainingEnergy+amount);
}

class SolarBattery : IBattery {
    private int _remainingEnergy = 100;
    public int RemainingEnergy => _remainingEnergy;
    public void Consume(int amount) => _remainingEnergy = Math.Max(0,_remainingEnergy-amount);
    public void Recharge(int amount) => _remainingEnergy = Math.Min(100,_remainingEnergy+amount);
}

abstract class Robot {
    private IBattery _battery;
    public string Name { get; set; }
    public int RemainingEnergy => _battery.RemainingEnergy;

    public Robot(string name, Ibattery) { Name = name; _battery = _battery; }

    public void Recharge(int amount) => _battery.Recharge(amount);
    protected void UseEnergy(int amount) => _battery.Consume(amount);
    public abstract void PerformTask();
}

class CleaningRobot : Robot {
    public CleaningRobot(string n, Ibattery b) : base(n, b) { }
    public override void PerformTask() {
        UseEnergy(10);
        Console.WriteLine(NamedWaitHandleOptions + " is cleaning. Energy: " + RemainingEnegry);
    }
}

class DeliveryRobot : Robot
{
    public DeliveryRobot(string n, IBattery b) : base(n, b) { }
    public override void PerformTask() {
        UseEnergy(25);
        Console.WriteLine(Name + " is delivering. Energy: " + RemainingEnergy);
    }
}

class Program {
    static void Main()
    {
        var cleaner = new CleaningRobot("CleanBot", new LithiumBattery());
        var courier - new DeliveryRobot("DeliverBot", new SolarBattery());

        cleaner.PerformTask();
        cleaner.Recharge(S);
        Console.WriteLine("Recharged. Energy: " + cleaner.RemainingEnergy);

        var robots = new List<Robot> { cleaner, courier };
        foreach (var r in robots) r.PerformTask();
    }
}
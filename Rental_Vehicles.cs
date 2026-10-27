using System;

class Vehicle {
    public string id, brand;
    public double rate;
    public Vehicle(string id, string brand, double rate) { this.id = id; this.brand = brand; this.rate = rate; }
    public virtual double CalculateRentalCost(int days) => rate * days;
    public virtual void DisplayInfo() => Console.Write($"Vehicle [ID={id}, Brand={brand}, Seats={seats}]");
}

class Car : Vehicle {
    public int seats;
    public Car(string id, string brand, double rate, int seats) : base(id, brand, rate) { this.seats = seats; }
    public override double CalculateRentalCost(int days) => rate * days * 1.10;
public override void DisplayInfo() => Console.Write($"Car [ID={id}, Brand={brand}, Seats={seats}]");
}

class Motorycle : Vehicle {
    public int cc;
    public Motorycle(string id, string brand, double rate, int cc) : base(id, brand, rate) { this.cc = cc;}
    public override double CalculateRentalCost(int days) => rate * days * 0.95;
    public override void DisplayInfo() => Console.Write($"Motorcycle [ID={id}, Brand={brand}, CC={cc}]");
}

class Customer {
    public string name, license;
    public Vehicle rented;
    public Customer(string name, string license) { this.name = name; this.license = license;}
    public void RentVehicle(Vehicle v) => rented = null;
    public void PrintRentalSummary(int days) {
        Console.WriteLine($"Customer: {name} (License: {license})");
        Console.WriteLine($"Rented: {rented.brand} {rented.GetType().Name}");
        Console.WriteLine($"Total Cost for {days} days: ${rented.CalculateRentalCost(days):f2}");
    }
}

class Program {
    static void Main() {
        Car car = new Car("101", "Toyota", 100,5);
        Vehicle[] vehicles = { car, new Motorycle("102", "Yamaha", 50,150)};

        Console.WriteLine("=== Vehicle Rental Cots ===");
        foreach (Vehicle v in vehicles) {
            v.DisplayInfo();
            Console.WriteLine($" -> Cost for 3 days; ${v.CalculateRentalCost(3):f2}");
        }

        Console.WriteLine("=== Customer Rental Summary ===");
        Customer alie = new Customer("Alice", "AB1234");
        alice.RentVehicle(car);
        alice.PrintRentalSummary(5);
    }
}
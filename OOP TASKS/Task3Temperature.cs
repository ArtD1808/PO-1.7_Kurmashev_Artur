using System;

class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get { return _celsius; }
        set
        {
            if (value < -273.15)
                throw new ArgumentException("Temperature below absolute zero");

            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get { return _celsius * 9 / 5 + 32; }
        set
        {
            Celsius = (value - 32) * 5 / 9;
        }
    }

    public Temperature(double celsius)
    {
        Celsius = celsius;
    }

    public void Print()
    {
        Console.WriteLine($"{Celsius:F2}°C / {Fahrenheit:F2}°F");
    }
}

class Program
{
    static void Main()
    {
        Temperature t = new Temperature(25);

        t.Print();

        t.Fahrenheit = 100;
        t.Print();

        try
        {
            t.Celsius = -300;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

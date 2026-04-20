using System;

class Student
{
    public string Name;
    public int Grade1;
    public int Grade2;
    public int Grade3;

    public Student(string name, int grade1, int grade2, int grade3)
    {
        Name = name;
        Grade1 = grade1;
        Grade2 = grade2;
        Grade3 = grade3;
    }
    public double GetAverage()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }
    public string GetLetterGrade()
    {
        double avg = GetAverage();

        if (avg >= 90) return "A";
        else if (avg >= 75) return "B";
        else if (avg >= 60) return "C";
        else return "F";
    }
    public void Print()
    {
        Console.WriteLine($"{Name} | Average: {GetAverage():F2} | Grade: {GetLetterGrade()}");
    }
}

class Program
{
    static void Main()
    {
        Student[] roster = new Student[]
        {
            new Student("Nur", 90, 85, 88),
            new Student("Art", 100, 95, 98),
            new Student("Ars", 60, 70, 65),
            new Student("Ilnur", 80, 78, 82)
        };

        foreach (Student s in roster)
        {
            s.Print();
        }

        Student best = roster[0];

        foreach (Student s in roster)
        {
            if (s.GetAverage() > best.GetAverage())
            {
                best = s;
            }
        }

        Console.WriteLine("\nBest student:");
        best.Print();
    }
}

// See https://aka.ms/new-console-template for more information

// Name: LOVELY SHARMA
// Batch: 4
// UID: 22BCS11001
class Program
{
    static void Main(string[] args)
    {
        
        // Exercise 1
        int attendedDays = 78;
        int totalDays = 90;
        double percentage = (double)attendedDays / totalDays * 100;
        int displayPercentage = (int)Math.Round(percentage);

        // Exercise 2
        int totalMarks = 400;
        int subjects = 5;

        double average = totalMarks / (double)subjects;
        double roundedAvg = Math.Round(average, 2);
        int scholarshipScore = (int)Math.Floor(roundedAvg);

        // Exercise 3
        decimal finePerDay = 2.50m;
        int daysLate = 7;
        decimal totalFine = finePerDay * daysLate;
        double analyticsFine = (double)totalFine;

        // Exercise 4
        decimal balance = 100000m;
        float rate = 5.5f;
        decimal interestRate = (decimal)rate / 100;
        decimal interest = balance * interestRate / 12;
        balance += interest;

        // Exercise 5
        double cartTotal = 999.99;
        decimal taxRate = 0.18m;

        decimal total = (decimal)cartTotal;
        decimal tax = total * taxRate;
        decimal finalAmount = total + tax;

        // Exercise 6
        short sensorValue = 325;
        double celsius = sensorValue / 10.0;

        int displayTemp = (int)Math.Round(celsius);


        // Exercise 7
        double finalScore = 86.4;
        byte grade;

        if (finalScore >= 90)
        {
            grade = 1;
        }
        else if (finalScore >= 80)
        {
            grade = 2;
        }
        else if (finalScore >= 70)
        {
            grade = 3;
        }
        else
        {
            grade = 4;
        }


        // Exercise 8
        long bytesUsed = 4368709120;

        double gb = bytesUsed / (1024.0 * 1024 * 1024);
        int roundedGB = (int)Math.Round(gb);

        // Exercise 9
        int items = 500;
        ushort maxCapacity = 600;

        if (items >= maxCapacity)
        {
            Console.WriteLine("Cant store anymore");
        }

        // Exercise 10
        int basic = 30000;
        double allowance = 5230.75;
        double deduction = 1800.25;

        decimal netSalary = basic + (decimal)allowance - (decimal)deduction;
    }
} 




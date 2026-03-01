
using System.Diagnostics.CodeAnalysis;

namespace Week3DotNet
{
    internal class OutMethod
    {
        static void Main(string[] args)
        {
            int num = 5;
            int square;
            int cube;

            //GetSquareAndCube(num, out square, out cube);
            //Console.WriteLine($"The sq and cube of {num} is {square} and {cube}");
            Console.WriteLine($"Total Bill: {GymMembership(false,false, false):F2}"); //f9 toggle



            //TryParse
            bool flag = false;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out int age);
                if (flag)
                {
                    Console.WriteLine(age);
                }
                else
                {
                    Console.WriteLine($"wrong entry input is:{age}");
                }
            } while (!flag);
        }

        static void GetSquareAndCube(int num, out int square, out int cube)
        {
            square = Convert.ToInt32(Math.Pow(num, 2));
            cube = Convert.ToInt32(Math.Pow(num, 3));
        }

        static int GetDoubleSquareAndCube(int num, out int square, out int cube)
        {
            square = Convert.ToInt32(Math.Pow(num, 2));
            cube = Convert.ToInt32(Math.Pow(num, 3));
            return num*2;
        }

        public static double GymMembership(bool treadmill, bool weightLifting, bool zumba)
        {
            double bill = 1000.0;
            if(treadmill || weightLifting || zumba)
            {
                if (treadmill)
                {
                    bill += 300;
                }
                if (weightLifting)
                {
                    bill += 500;
                }
                if (zumba)
                {
                    bill += 250;
                }
            }
            else
            {
                bill += 200;
            }
            bill += bill * 5 / 100;   //GST
            return bill;

        }
        
    }
}


namespace Week3DotNet
{
    internal class Day_13_Gym
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Total Bill: {GymMembership(false, false, false):F2}");

        }
        public static double GymMembership(bool treadmill, bool weightLifting, bool zumba)
        {
            double bill = 1000.0;
            if (treadmill || weightLifting || zumba)
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

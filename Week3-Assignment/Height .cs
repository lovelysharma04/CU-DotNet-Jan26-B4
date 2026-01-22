using System.Security.Cryptography;

namespace Week3DotNet
{
    internal class Height
    {
        public int Feet { get; set; }
        public double Inches { get; set; }

        public Height()
        {
            Feet = 0; Inches=0.0;
        }

        public Height(int Feet,double Inches)
        {
            this.Feet = Feet;
            this.Inches = Inches;
        }

        public Height(double Inches)
        {
            this.Feet = (int)Inches / 12;
            this.Inches = Inches%12;
        }

        public Height AddHeights(Height h2)
        {
            //Height a = new Height();
            int totalFeet = this.Feet + h2.Feet;
            double totalInches = this.Inches + h2.Inches;

            if (totalInches >= 12)
            {
                totalFeet += (int)totalInches / 12;
                totalInches = totalInches % 12;
            }

            return new Height(totalFeet,totalInches);
        }

        public override string ToString()
        {
            return $"Height - {Feet} feet {Inches:F2} inches";
        }

        static void Main(string[] args)
        {
            Height h1 = new Height(5,0.6);
            Height h2 = new Height(6, 0.7);
            Console.WriteLine(h2.AddHeights(h1));
            Height h3 = new Height(60);
            Console.WriteLine(h3);
            
        }
    }
}

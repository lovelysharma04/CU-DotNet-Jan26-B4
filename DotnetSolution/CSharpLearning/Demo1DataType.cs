namespace CSharpLearning
{
    internal class Demo1DataType
    {
        static void Main(string[] args)
        {
            ////Boxing
            //int num1 = 26;
            //Object obj = num1;

            ////Unboxing
            //int num2 = (int) obj;
            //Console.WriteLine($"Boxing : {obj}  Unboxing: {num2}");

            //get the age of a person=========================================================================================
            //Console.Write("Enter your name: ");
            //string name = Console.ReadLine();
            //Console.Write("Enter your age: ");
            //int age = int.Parse(Console.ReadLine());

            //if (age >= 18)
            //{
            //    Console.WriteLine($"{name} you are Eligible to vote!");
            //}
            //else
            //{
            //    Console.WriteLine($"{name} you are Not Eligible to vote!");
            //}

            //for( int i = 0; i <2 ; i=i+2) {
            //    Console.Write( i + " " );
            //}

            //single readline======================================================================================================
            Console.WriteLine("Enter name, age and city(seperate by ,): ");
            string[] arr = Console.ReadLine().Split(",");
            string name2 = arr[0];
            int age2 = int.Parse(arr[1]);
            string city = arr[2];

            Console.WriteLine($"Name : {name2}\tAge: {age2}\t\tCity: {city}");
           





        }
    }
}

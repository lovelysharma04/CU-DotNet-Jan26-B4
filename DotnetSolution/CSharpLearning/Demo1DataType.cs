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
            //Console.WriteLine("Enter name, age and city(seperate by ,): ");
            //string[] arr = Console.ReadLine().Split(",");
            //string name2 = arr[0];
            //int age2 = int.Parse(arr[1]);
            //string city = arr[2];

            //Console.WriteLine($"Name : {name2}\tAge: {age2}\t\tCity: {city}");


            //for (int i = 1; i <= 5; i++)
            //{  
            //    Console.Write($"{i} {6-i} ");

            //}

            //string[] fruits = new string[10];
            //string cityNames = "Delhi,CHD;Gwalior Noida";

            ////create an array of separators characters
            //char[] separators = { ',' , ';' , ' '};

            //string[] cities = cityNames.Split(separators); 
            //for (int i = 0; i < cities.Length; i++){
            //    Console.WriteLine(cities[i]);
            //}

            for (int row = 0; row < 5; row++){
                for (int spaces = 0; spaces < 5-row-1; spaces++)
                {
                    Console.Write(" ");

                }
                for (int col = 0; col <= row; col++)
                {
                    Console.Write($"{(char)('A'+col),-4}");
                }
                Console.WriteLine();
            }

        }
    }
}

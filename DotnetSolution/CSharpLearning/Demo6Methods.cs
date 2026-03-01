namespace CSharpLearning
{
    internal class Demo6Methods
    {
        static void Main(string[] args)
        {
            //SayHello();
            //SayHello("Lovely");
            //DemoMethods.CallAnotherClassMethod();
            //int square = GetSquare(10);
            //Console.WriteLine($"Square of {10} is {square}");

            //int[] result = GetOddNumbers(10);
            //Console.WriteLine(string.Join(",", result));

            string[] names = new string[5];
            int[] marks = new int[5];

            //validate
            #region validate
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write($"Enter name of student {i+1}: ");
                names[i] = Console.ReadLine();
            }

            Console.WriteLine(string.Join(",", names));

            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"Enter marks of student {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());

                if (marks[i] < 0 || marks[i] > 100)
                {
                    i--;
                    Console.WriteLine("Re-enter the marks!");
                }

            }
            Console.WriteLine(string.Join(",", marks));
            #endregion
            string topper = GetNameOfTopper(names, marks);
            Console.WriteLine($"Topper is {topper}");

        }
        // method can have access specifier (static) returnType NameOfFunction(parameters)
        // arguments will be passed while calling method  //  method default specifier is private!
        // class default specifier is internal!

        //Method with return type
        //static int GetSquare(int num)
        //{
        //    return num * num;
        //}

        ////return array of integer
        //static int[] GetOddNumbers(int num)
        //{
        //    int size = num%2 == 0 ? (num / 2) : (num / 2) + 1;
        //    Console.WriteLine(size);
        //    int[] arr = new int[size];
        //    int index = 0;
        //    for(int i = 1; i<=num; i=i+2)
        //    {
        //        arr[index++] = i;
        //    }
        //    return arr;
        //}

        ////ref
        //public static void SayHello()
        //{
        //    Console.WriteLine("Hello Everyone");
        //}
        ////Method Overloading
        //public static void SayHello(string name)
        //{
        //    Console.WriteLine($"Hello {name}");
        //}
        //create 2 arrays to store 5 student names
        //and to store 5 student marks respectively
        //create a method to get student name with max marks

        static string GetNameOfTopper(string[] names, int[] marks)
        {
            int highestMarks = marks.Max();
            int position = Array.IndexOf(marks, highestMarks);
            return names[position];
        }
    }
    //class DemoMethods
    //{
    //    public static void CallAnotherClassMethod()
    //    {
    //        //Demo6Methods classobj = new Demo6Methods();
    //        //classobj.SayHello();
    //        //Demo6Methods.SayHello();


    //    }
    //}    
}

using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Week5Started
{
    class InvalidStudentAgeException: Exception
    {
        public InvalidStudentAgeException(string message):base(message){ }
    }
    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string message):base(message){ }
    }
    internal class ExceptionHandling
    {
        static void Main(string[] args)
        {
            //===========================================================================================
            try
            {
                Console.Write("Enter First Number: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Enter Second Number: ");
                int y = int.Parse(Console.ReadLine());
                int div = x / y;
                Console.WriteLine($"{x} divide by {y}= {div}");
            }
            catch(DivideByZeroException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            //===========================================================================================

            try
            {
                Console.Write("Enter an integer: ");
                int num = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            //===========================================================================================

            try
            {
                int[] arr = { 1, 2, 3, 4, 5 };
                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine("Value = " + arr[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Exception: Index is outside the array range.");
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            //===========================================================================================

            do
            {
                try
                {
                    Console.Write("Enter Age of student: ");
                    int age = int.Parse(Console.ReadLine());
                    if (!(age >= 18 && age <= 60))
                    {
                        throw new InvalidStudentAgeException("Age is out of range!");
                    }
                    break;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }while (true);

            //===========================================================================================

            //do
            //{
            //    try
            //    {
            //        Console.Write("Enter Full Name of Student: ");
            //        string fullName = Console.ReadLine();
            //        bool validFullName = Regex.IsMatch(fullName, @"^[A-Z]{1}[a-z]{2,}[ ]{1}[A-Z]{1}[a-z]{2,}$");
            //        if (!validFullName)
            //        {
            //            throw new InvalidStudentNameException("You Have Entered Invalid Name!");
            //        }
            //        break;

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //} while (true);
            while (true)
            {
                try
                {
                    try
                    {
                        Console.Write("Enter Full Name of Student: ");
                        string fullName = Console.ReadLine();

                        bool valid = Regex.IsMatch(fullName,@"^[A-Z]{1}[a-z]{2,} [A-Z]{1}[a-z]{2,}$");

                        if (!valid)
                            throw new InvalidStudentNameException("Invalid student name format");
                    }
                    catch (InvalidStudentNameException ex)
                    {
                        throw new Exception("Student name validation failed", ex);
                    }

                    break;
                }
                //============================================================================================
                catch (Exception ex)
                {
                    

                    Console.WriteLine("\n================ Exception Details ================");

                    Console.Write("\nMessage: ");
                    Console.WriteLine(ex.Message);

                    Console.Write("\nStackTrace: ");
                    Console.WriteLine(ex.StackTrace);

                    Console.Write("\nInnerException: ");
                    if (ex.InnerException != null)
                        Console.WriteLine(ex.InnerException.Message);
                    else
                        Console.WriteLine("None");

                    Console.WriteLine("\n-------------- RE-ENTER --------------");
                }
            }


        }
    }
}

namespace Week5Started
{
    class SalaryOutOfRangeException : Exception
    { 
        public SalaryOutOfRangeException(string message): base(message) { }
    }
    internal class TryCatchDemo2
    {
        static void CheckException()
        {
            try
            {
                Console.WriteLine("trying to use finally");
                throw new DivideByZeroException("Can't divide by Zero..");
                //return;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("In catch block");
            }
            //catch(SalaryOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            catch
            {
                Console.WriteLine("exception");
            }
            finally
            {
                Console.WriteLine("inside checkException finally");
            }
            Console.WriteLine("After finally in checkexception"); //will never be executed
        }
        static int GetDiv(int x, int y)
        {
            int[] arr = { 1, 2, 3, 4 };
            try
            {
                return arr[5];
            }
            catch (IndexOutOfRangeException ex) // exception is not handled in called method so it will be passed to calling method
            {
                Console.WriteLine("IndexOutOfRangeException");
            }
            finally
            {
                Console.WriteLine("finally of method");
            }
            return 0;
        }
        static void Main(string[] args)
        {
            try
            {
                int salary = 123456;
                if (salary > 10000)
                {
                    throw new SalaryOutOfRangeException("High salary");
                }
                CheckException();
                //int result = GetDiv(15, 0);
                //int[] arr = { 1, 2, 3, 4 };
                //Console.WriteLine(arr[5]);//index out of bound exception
            }
            catch (DivideByZeroException ex) // generic catch
            {
                Console.WriteLine("DivideByZeroException- " + ex.Message); //printing the object
            }
            catch (SalaryOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)   //most generic catch
            {
                Console.WriteLine("Generic Exception in main " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Inside Finally");
            }
            Console.WriteLine("Done");
        }
    }
}

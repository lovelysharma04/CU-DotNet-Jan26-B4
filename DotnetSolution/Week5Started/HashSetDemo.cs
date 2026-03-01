using System.Collections;

namespace Week5Started
{
    static class MyString
    {
        public static int GetWordCount(this string str)
        {
            int count = str.Split().Count();
            return count;
        }
    }
    internal class HashSetDemo
    {
        static void Main(string[] args)
        {
            ArrayList a1 = new ArrayList();
            Console.WriteLine(a1.Capacity);
            a1.Add(123);
            Console.WriteLine(a1.Capacity);
            a1.Add("abc");
            a1.Add('a');
            a1.Add(false);
            a1.Add(3.33);
            Console.WriteLine(a1.Capacity);
            Console.WriteLine(a1.Count);

            foreach (object item in a1)
            {
                //Console.WriteLine(item.GetType());   // reflection
                //Console.WriteLine(item.GetType().Name);
                //Type type= item.GetType();
                // type.GetMethods().Count();         
                if (item is int)
                {
                    Console.WriteLine(item); 
                }
            }

            HashSet<int> pincode = new HashSet<int>(); //generic //no duplicate
            pincode.Add(140150); //bool type
            pincode.Add(100001);
            pincode.Add(409701);

            //========== LINQ =================================================

            int[] arr = { 11, 21, 56, 78, 56, 78, 89, 95, 65 };
            var result1= arr
                        .Where(x => x % 2 == 1)
                        .OrderBy(x => x)
                        .ToArray<int>();
           
            Console.WriteLine(string.Join(", ", result1));

            string sen = "This is a car";
            Console.WriteLine(sen.GetWordCount());

            //========== HashTable ==================
            Hashtable ht =new Hashtable();
            ht.Add(1, "sdsd");
            ht.Add(2, "sdsdv");
            ht.Add(3, "mknk");

            //=============== Stack ===================
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());

            //=============== Queue ====================
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            Console.WriteLine(q.Dequeue());

            //================ SortedDictionary =============

            SortedDictionary<int, string> sd = new SortedDictionary<int, string>();
            sd.Add(5, "five");
            sd.Add(2, "two");
            sd.Add(1, "one");

            foreach (var item in sd)
            {
                Console.WriteLine(item);
            }
            



        }
    }
}

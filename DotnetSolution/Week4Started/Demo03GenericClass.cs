namespace Week4Started
{
    class MyArray<T>              //Generic class
    { 
        public T[] arr = new T[5];
        

        public T this[int index]
        {
            get { return (T)arr[index]; }
            set { arr[index] = (T)value; }
        }

    }
    internal class Demo03GenericClass
    {
        static void Main(string[] args)
        {
            MyArray<int> arr1 = new MyArray<int>();
            arr1.arr[0] = 1;
            arr1[1] = 2;     //possible because of indexer
            Console.WriteLine(string.Join(",",arr1.arr));
            Console.WriteLine(arr1[1]);

            MyArray<string> arr2 = new MyArray<string>();
            arr2.arr[0] = "sdsdfsf";
            
        }
    }
}

namespace Week7Started
{
    class Base
    {
        public int publicData = 10;                        // accessible everywhere
        protected int protectedData = 14;
        private protected int privateProtectedData = 20; // only in derived classes in SAME assembly
        private int privateData = 30;                   // only inside Base

        public readonly int t;

        public Base(int r)
        {
            t = r;
        }
        public void ShowBase()
        {
            Console.WriteLine(publicData);
            Console.WriteLine(protectedData);
            Console.WriteLine(privateProtectedData);
            Console.WriteLine(privateData);
        }
    }

    class Derived : Base
    {
        public Derived(int r) : base(r)
        {
        }

        public void ShowDerived()
        {
            Console.WriteLine(publicData);            
            Console.WriteLine(privateProtectedData);
            Console.WriteLine(protectedData);
                                                               
        }
    }
    internal class Demo5PrivatePublicProtected
    {
        static void Main(string[] args)
        {
            //static int j = 90;
            const int x=9;
            Type t = typeof(int);
            Console.WriteLine(t);
            Type h = x.GetType();
            Console.WriteLine(h);

            Base b = new Base(7);
            Derived d = new Derived(5);
            //Console.WriteLine(b.publicData);
            b.ShowBase();
            Console.WriteLine("-----------------------");
            d.ShowDerived();

        }
    }
}

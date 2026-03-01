namespace Week3DotNet
{
    class Person : Object //--------super class is object class of all classes--------
    {
        //data members
        string name = string.Empty;  //field----data member should be private

        //method
        public void SetName(string name)
        {
            this.name = name;
        }
        public void GetName()
        {
            Console.WriteLine($"{name}");

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }

        public string FullNmae
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public override string ToString()
        {
            return $"Name: {FullNmae}  Department: {Department} ";
        }
        //Compare Department....method
        public bool IsDepartmentSame(Person ps) {
            if (this.Department == ps.Department) {
                return true;
            }
            else
                return false;
        }
        public Person()
        {
            FirstName = "New";
            LastName = "Employee";
            //FullNmae = "dffdgdfh"; //Read only get-----not set
            Department = "IT";
        }

        //PROPERTIES // Propfull
        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 && value < 100)
                    age = value;
            }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        //PROPERTIES // Prop----------auto implemented property
        public string Mobile { get; set; }

    }

    internal class OOPSLearning
    {
        static void Main(string[] args)
        {
            Console.WriteLine("oops started!");
            Person p = new Person();
            Console.WriteLine(p); // when we try to display the object it will not give properties and it will give Projectfile.className.......... 
            p.SetName("Person1");
            p.GetName();
            p.Age = 23;
            Console.WriteLine(p.Age);
            p.City = "Mumbai";
            Console.WriteLine(p.City);
            p.Age = -1000;
            Console.WriteLine(p.Age);
            p.Mobile = "9876653245";
            Console.WriteLine(p.Mobile);

            p.FirstName = "Lovely";
            p.LastName = "Sharma";
            Console.WriteLine(p.FullNmae);

            Console.WriteLine(p); //Now it will display the data of emp

            Person p2 = new Person()
            {
                FirstName = "dgfh",
                LastName = "gfhfh",
                Age = 50,
                Department = "HR",
                City = "Delhi",
                Mobile = "9897521356" //sab kuch display nhi hoga.....jo ToString me hoga wohi hoga.... 
            };
            Console.WriteLine(p2);

            bool deprtSame = p2.IsDepartmentSame(p);
            Console.WriteLine(deprtSame);

        }
    }
}

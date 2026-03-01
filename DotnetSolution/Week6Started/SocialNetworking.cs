namespace Week6Started
{
    class Person
    {
        public string Name { get; set; }
        public List<Person> Friends = new List<Person>();
        public Person(string name)
        {
            Name = name;
        }
        //public void AddFriend(Person friend)
        //{
        //    if (!Friends.Contains(friend))
        //    {
        //        Friends.Add(friend);
        //        friend.Friends.Add(this);
        //    }
        //}
    }
    class SocialNetwork
    {
        private List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        {
            _members.Add(member);
        }
        public void AddFriend(Person friend1, Person friend2)
        {
            if(!(_members.Contains(friend1) && _members.Contains(friend2)))
            {
                Console.WriteLine($"Any of the Friends {friend1.Name} {friend2.Name} are not on Social Platform");
            }
            else
            {
                if (!friend1.Friends.Contains(friend2))
                {
                    friend1.Friends.Add(friend2);
                    friend2.Friends.Add(friend1);
                }
            }
        }
        public void ShowMember()
        {
            foreach (var member in _members)
            {
                Console.Write(member.Name + " -> ");
                List<string> friends = new List<string>();
                foreach (var friend in member.Friends)
                {
                    friends.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(", ", friends)}");
            }
        }
    }
    internal class SocialNetworking
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();

            Person p1 = new Person("Aman");
            Person p2 = new Person("Bhaskar");
            Person p3 = new Person("Kashish");
            Person p4 = new Person("Priya");
            Person p5 = new Person("Eena");

            network.AddMember(p1);
            network.AddMember(p2);
            network.AddMember(p3);
            network.AddMember(p4);
            
            network.AddFriend(p1 , p2);
            network.AddFriend(p1, p3);
            network.AddFriend(p2, p3);
            network.AddFriend(p4, p2);
            network.AddFriend(p1, p5);
            
            //p1.AddFriend(p2);
            //p1.AddFriend(p3);
            //p2.AddFriend(p3);
            //p4.AddFriend(p2);

            network.ShowMember();

        }
    }
}

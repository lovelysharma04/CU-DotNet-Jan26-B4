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
        public void AddFriend(Person friend)
        {
            if (!Friends.Contains(friend))
            {
                Friends.Add(friend);
                friend.Friends.Add(this);
            }
        }
    }
    class SocialNetwork
    {
        private List<Person> _members = new List<Person>();
        public void AddMember(Person member)
        {
            _members.Add(member);
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

            network.AddMember(p1);
            network.AddMember(p2);
            network.AddMember(p3);
            network.AddMember(p4);

            p1.AddFriend(p2);
            p1.AddFriend(p3);
            p2.AddFriend(p3);
            p4.AddFriend(p2);

            network.ShowMember();

        }
    }
}

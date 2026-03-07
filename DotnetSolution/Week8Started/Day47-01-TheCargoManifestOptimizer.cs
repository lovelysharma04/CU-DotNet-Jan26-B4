namespace Week8Started
{
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }

        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }

    public class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }

        public Container(string id, List<Item> items)
        {
            ContainerID = id;
            Items = items;
        }
    }

    public class CargoManager
    {
        private List<List<Container>> cargoBay = new List<List<Container>>();

        public CargoManager(List<List<Container>> cargoBay)
        {
            this.cargoBay = cargoBay;
        }

        // Task A: Deep Search
        
        public List<string> FindHeavyContainers(double weightThreshold)
        {
            return cargoBay
                ?.Where(row => row != null)
                .SelectMany(row => row) // flatten rows → containers
                .Where(container =>
                    container?.Items != null &&
                    container.Items.Sum(i => i?.Weight ?? 0) > weightThreshold)
                .Select(container => container.ContainerID)
                .ToList()
                ?? new List<string>();
        }

       
        // Task B: Category Audit
      
        public Dictionary<string, int> GetItemCountsByCategory()
        {
            return cargoBay
                ?.Where(row => row != null)
                .SelectMany(row => row)
                .Where(c => c?.Items != null)
                .SelectMany(c => c.Items)
                .Where(i => i != null)
                .GroupBy(i => i.Category)
                .ToDictionary(g => g.Key, g => g.Count())
                ?? new Dictionary<string, int>();
        }

        
        // Task C: Flatten + Sort
        
        public List<Item> FlattenAndSortShipment()
        {
            return cargoBay
                ?.Where(row => row != null)
                .SelectMany(row => row)
                .Where(c => c?.Items != null)
                .SelectMany(c => c.Items)
                .Where(i => i != null)
                .GroupBy(i => i.Name) // remove duplicates
                .Select(g => g.First())
                .OrderBy(i => i.Category)
                .ThenByDescending(i => i.Weight)
                .ToList()
                ?? new List<Item>();
        }
    }

    internal class Day47_01_TheCargoManifestOptimizer
    {
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                // ROW 0
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"),
                        new Item("Cables", 1.2, "Tech")
                    })
                },

                // ROW 1
                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                // ROW 2
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>())
                },

                // ROW 3
                new List<Container>()
            };

            var manager = new CargoManager(cargoBay);

            // Task A 
            Console.WriteLine("Heavy Containers (>10):");
            var heavy = manager.FindHeavyContainers(10);
            heavy.ForEach(Console.WriteLine);

            // Task B 
            Console.WriteLine("\nCategory Counts:");
            var counts = manager.GetItemCountsByCategory();
            foreach (var kv in counts)
                Console.WriteLine($"{kv.Key} -> {kv.Value}");

            // Task C 
            Console.WriteLine("\nFlattened & Sorted Items:");
            var items = manager.FlattenAndSortShipment();
            foreach (var i in items)
                Console.WriteLine($"{i.Category} | {i.Name} | {i.Weight}");
        }
    }
}
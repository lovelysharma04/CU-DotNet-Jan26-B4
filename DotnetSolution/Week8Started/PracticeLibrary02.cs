namespace Week8Started
{
    public interface IBook
    {
        int Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Category { get; set; }
        int Price { get; set; }
    }

    public interface ILibrarySystem
    {
        void AddBook(IBook book, int quantity);
        void RemoveBook(IBook book, int quantity);
        int CalculateTotal();
        List<(string, int)> CategoryTotalPrice();
        List<(string, int, int)> BooksInfo();
        List<(string, string, int)> CategoryAndAuthorWithCount();
    }

    public class Book : IBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Author, Category, Price);
        }
        public override bool Equals(object? obj)
        {
            return obj is Book b && Id==b.Id;
        }
    }
    public class LibrarySystem : ILibrarySystem
    {
        private Dictionary<IBook, int> _book = new Dictionary<IBook, int>();
        public void AddBook(IBook book, int quantity)
        {
            if (_book.ContainsKey(book))
            {
                _book[book] = quantity; 
            }
            else
            {
                _book.Add(book, quantity);
            }
        }

        public List<(string, int, int)> BooksInfo()
        {
            var bookInfo = _book.Select(x => (x.Key.Title, x.Value, x.Key.Price))
                                .ToList();
            return bookInfo;
        }

        public int CalculateTotal()
        {
            int total = 0;
            foreach (var book in _book) {
                total += book.Key.Price * book.Value;
            }
            return total;
        }

        public List<(string, string, int)> CategoryAndAuthorWithCount()
        {
            var CatAuth = _book.GroupBy(g => new { g.Key.Category, g.Key.Author })
                               .Select(a=>(a.Key.Category, a.Key.Author, a.Sum(s=>s.Value)))
                               .ToList();
            return CatAuth;
                              
        }

        public List<(string, int)> CategoryTotalPrice()
        {
            var categoryWisePrice = _book.GroupBy(x =>  x.Key.Category)
                                         .Select(g=>(g.Key, g.Sum(s=>s.Value*s.Key.Price)))
                                         .ToList();
            return categoryWisePrice;                                        
        }

        public void RemoveBook(IBook book, int quantity)
        {
            if (_book.ContainsKey(book))
            {
                _book[book] -= quantity;

                if (_book[book] <= 0)
                {
                    _book.Remove(book);
                }
            }
        }
    }

    internal class PracticeLibrary02
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new
                StreamWriter(@"../../../library.txt", false);

            ILibrarySystem librarySystem = new LibrarySystem();

            //int bCount = Convert.ToInt32(Console.ReadLine().Trim());
            //for (int i = 1; i <= bCount; i++)
            //{
            //    var a = Console.ReadLine().Trim().Split(" ");

            //    IBook e = new Book();
            //    e.Id = Convert.ToInt32(a[0]);
            //    e.Title = a[1];
            //    e.Author = a[2];
            //    e.Category = a[3];
            //    e.Price = Convert.ToInt32(a[4]);

            //    librarySystem.AddBook(e, Convert.ToInt32(a[5]));
            //}

            // Initialize the Library System [cite: 43]

            // Sample Data based on provided test cases
            var sampleBooks = new[]
                {
            new { Id = 1, Title = "Title-1", Author = "Author-1", Category = "Category-4", Price = 206, Qty = 14 },
            new { Id = 2, Title = "Title-2", Author = "Author-2", Category = "Category-2", Price = 527, Qty = 23 },
            new { Id = 3, Title = "Title-3", Author = "Author-2", Category = "Category-2", Price = 734, Qty = 6 },
            new { Id = 4, Title = "Title-4", Author = "Author-1", Category = "Category-1", Price = 58,  Qty = 29 },
            new { Id = 1, Title = "Title-1", Author = "Author-1", Category = "Category-4", Price = 206, Qty = 15 },
        };

            foreach (var data in sampleBooks)
            {
                // Create new Book instance and implement IBook [cite: 31, 48]
                IBook e = new Book();
                e.Id = data.Id;
                e.Title = data.Title;
                e.Author = data.Author;
                e.Category = data.Category;
                e.Price = data.Price;

                // Register the book with the specified quantity [cite: 24, 54]
                librarySystem.AddBook(e, data.Qty);
            }

            IBook b1 = new Book { Id = 4, Title = "Title-4", Author = "Author-1", Category = "Category-1", Price = 58 };
            librarySystem.RemoveBook(b1, 5);

            IBook b2 = new Book { Id = 3, Title = "Title-3", Author = "Author-2", Category = "Category-2", Price = 734 };
            librarySystem.RemoveBook(b2, 7);

            textWriter.WriteLine("Book Info:");

            var booksInfo = librarySystem.BooksInfo();
            foreach (var (title, quantity, price) in booksInfo.OrderBy(a => a.Item1))
            {
                textWriter.WriteLine($"Book Name:{title}, Quantity:{quantity},Price:{price}");
            }

            textWriter.WriteLine("Category Total Price:");
            var categoryTotalPrice = librarySystem.CategoryTotalPrice();
            foreach (var (category, totalPrice) in categoryTotalPrice.OrderBy(a => a.Item1))
            {
                textWriter.WriteLine($"Category:{category}, Total Price:{totalPrice}");
            }
            List<(string, string, int)> categoryAndAuthorWithCount = librarySystem.CategoryAndAuthorWithCount();
            textWriter.WriteLine("Category And Author With Count:");
            foreach (var (category, author, count) in categoryAndAuthorWithCount.OrderBy(a => a.Item1))
            {
                textWriter.WriteLine($"Category:{category}, Author:{author},Count:{count}");
            }

            int total = librarySystem.CalculateTotal();
            textWriter.WriteLine($"Total Price: {total}");

            textWriter.Flush();
            textWriter.Close();
        }

    }
}

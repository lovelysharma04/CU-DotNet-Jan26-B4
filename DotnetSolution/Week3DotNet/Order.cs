namespace Week3DotNet
{
    internal class Order
    {
        bool disc=true;
        private int _orderId;
        string orderStatus;

        public int OrderId
        {
            get { return _orderId; }
        }

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (!string.IsNullOrEmpty(_customerName))
                {
                    _customerName = value;
                }
            }
        }

        private decimal _totalAmount;

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }

        public Order() 
        {
            DateTime today = DateTime.Now;
            orderStatus = "NEW";
            Console.WriteLine($"Current Date: {today:dd/MM/yyyy}");
            
        }
        public Order(int orderId, string customerName)
        {
            this._orderId = orderId;
            this._customerName = customerName;
            orderStatus="NEW";
        }
        public void AddItem(decimal price)
        {
            _totalAmount+=price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if(percentage >=1 && percentage <=30 && disc==true)
            {
                disc = false;
                _totalAmount = _totalAmount - (_totalAmount * percentage / 100);
            }
            else
            {
                Console.WriteLine("Discount is already applied!");
            }
        }
        public void GetOrderSummary()
        {
            Console.WriteLine($"Order Id: {_orderId}");
            Console.WriteLine($"Customer: {_customerName}");
            Console.WriteLine($"Total Amount: {_totalAmount}");
            Console.WriteLine($"Status:{orderStatus}");
        }
        static void Main(string[] args)
        {

            Order order1 = new Order(101, "Rahul");
            Order order2 = new Order();
            order1.AddItem(500);
            order1.AddItem(300);
            order1.ApplyDiscount(10);
            order1.ApplyDiscount(10);
            order1.GetOrderSummary();
            //Console.WriteLine();
            //order2.AddItem(900);
            //order2.AddItem(400);
            //order2.ApplyDiscount(20);
            //order2.GetOrderSummary();
        }
    }
}

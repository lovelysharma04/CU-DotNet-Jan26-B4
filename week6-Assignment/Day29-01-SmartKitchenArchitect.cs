using System.Threading.Channels;

namespace Week6Started
{
    interface ITimer
    {
        public void SetTimer(double seconds);
    }
    interface ISmart
    {
        public bool ConnectToWifi();
    }
    abstract class KitchenElecAppliances
    {
        public double Watts { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public bool IsSmart { get; set; }
        public abstract void cook();
        public virtual void PreHeat(double temp) { }
    }

    //class Kettle : KitchenElecAppliances
    //{
    //    public override void cook()
    //    {
    //        Console.WriteLine("Cooking in Kettle");
    //    }
    //}
    class AirFryer : KitchenElecAppliances
    {
        public override void cook()
        {
            Console.WriteLine("Cooking in Air Fryer");
        }
      
    }
    class ElectricOven : KitchenElecAppliances, ITimer, ISmart
    {
        public override void PreHeat(double temp)
        {
            base.PreHeat(temp);
            Console.WriteLine("Pre-Heating the oven to "+ temp+ " °C");
        }
        public bool ConnectToWifi()
        {
            return true;         
        }
        public override void cook()
        {
            Console.WriteLine("Cooking in Electric Oven"); ;
        }
        public void SetTimer(double seconds)
        {
            Console.WriteLine("Cooking Time set for " + seconds + " seconds..");
            for (int i = 1; i <= seconds; i++)
            {
                if (i == seconds)
                {
                    Console.WriteLine("Cooking Done!");
                    break;
                }
            }
        }
    }

    class Microwave : KitchenElecAppliances, ITimer
    {
        public override void cook()
        {
            Console.WriteLine("Cooking in Microwave");
        }

        public void SetTimer(double seconds)
        {
            Console.WriteLine("Cooking Time set for "+seconds+" seconds..");
            for (int i = 1; i <= seconds; i++)
            {
                if (i == seconds)
                {
                    Console.WriteLine("Cooking Done!");
                    break;
                }
            }
        }
    }

    internal class PracticeDay1
    {
        static void Main(string[] args)
        {
            List<KitchenElecAppliances> list = new List<KitchenElecAppliances>();
            list.Add(new AirFryer {
                Watts=1000.4,
                ModelName="Pegion",
                Price=780,
                IsSmart=false
            });
            list.Add(new Microwave
            {
                Watts = 1200.5,
                ModelName = "LG",
                Price = 8000,
                IsSmart = false
            });
            list.Add(new ElectricOven
            {
                Watts = 2000,
                ModelName = "Wonderchef",
                Price = 12000,
                IsSmart = true
            });
            
            foreach (var item in list)
            {
                Console.WriteLine($"{item.ModelName}");
                item.cook();
                item.PreHeat(120);
                
                //if(item is ITimer t)
                //{
                //    t.SetTimer(50);
                //}
                if (item is ITimer)
                {
                    var t = (ITimer)item;
                    t.SetTimer(50);
                }
                if (item.IsSmart)
                {
                    if(item is ISmart s)
                    {
                        Console.Write("Connected to WiFi? ");
                        Console.WriteLine(s.ConnectToWifi()); 
                    }
                }
                Console.WriteLine("-----------------------------------------------------");

            }


        }
    }
}

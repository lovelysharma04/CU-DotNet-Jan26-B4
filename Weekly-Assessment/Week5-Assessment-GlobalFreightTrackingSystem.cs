namespace Week5Started
{
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message) { }

    }
    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message) { }

    }
    interface ILoggable
    {
        void SaveLog(string message);
    }
    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool Fragile { get; set; }
        public bool Reinforced { get; set; }
        public abstract void ProcessShipment();
    }
    class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Weight must be greater than zero.");

            if (Destination.Equals("North Pole") || Destination.Equals("Unknown Island"))
                throw new RestrictedDestinationException("We do not ship to \"Restricted Zones\"!");

            if (Fragile && !Reinforced)
                throw new InsecurePackagingException("Fragile item not reinforced.");

            Console.WriteLine("Express shipment processed...");
        }
    }
    class HeavyFreight : Shipment
    {
        public bool DoYouHaveHeavyLiftPermit { get; set; }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Weight must be greater than zero.");

            if (Destination == "North Pole" || Destination == "Unknown Island")
                throw new RestrictedDestinationException("We do not ship to \"Restricted Zones\"!");

            if (Fragile && !Reinforced)
                throw new InsecurePackagingException("Fragile item not reinforced.");

            if (Weight > 1000 && !DoYouHaveHeavyLiftPermit)
                throw new Exception("Heavy Lift permit required.");

            Console.WriteLine("Checked for the \"Heavy Lift\" permit... Done!");
        }
    }
    class LogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            string file = @"../../../shipment_audit.log";
            using StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine(DateTime.Now +": "+ message);
        }
    }
   
    internal class Week5_Assessment_GlobalFreightTrackingSystem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSwiftRoute\n");
            Console.WriteLine("-------------------------------------------");
            List<Shipment> shipments = new List<Shipment>();
            shipments.Add(new ExpressShipment          //valid shipment
            {
                TrackingId = "SH001",
                Weight = 700,
                Destination = "Dubai",
                Fragile = false,
                Reinforced = false
            });
            shipments.Add(new ExpressShipment{          //Restricted Zone
                TrackingId = "SH002",
                Weight = 500,
                Destination = "North Pole",
                Fragile = false,
                Reinforced = false
            });
            shipments.Add(new ExpressShipment{          //Weight 0 or negative
                TrackingId = "SH003",
                Weight = 0,
                Destination = "India",
                Fragile = false,
                Reinforced = false
            });
            shipments.Add(new ExpressShipment{        // Fragile but not reinforced 
                TrackingId = "SH004",
                Weight = 200,
                Destination = "Japan",
                Fragile = true,
                Reinforced = false
            });
            shipments.Add(new HeavyFreight {          //Heavy Weight ---- Yes have permit valid
                TrackingId = "SH005",
                Weight = 1300,
                Destination = "Kuwait",
                Fragile = false,
                Reinforced = false,
                DoYouHaveHeavyLiftPermit = true

            });
            shipments.Add(new HeavyFreight {          //Heavy Weight ---- Do not have permit
                TrackingId = "SH006",
                Weight = 2000,
                Destination = "Australia",
                Fragile = false,
                Reinforced = false,
                DoYouHaveHeavyLiftPermit = false

            });
            LogManager lm = new LogManager();
            foreach (var sh in shipments)
            {
                try
                {
                    sh.ProcessShipment();
                    lm.SaveLog("SUCCESS: Shipment processed Successfully for ID " + sh.TrackingId);
                }
                catch (RestrictedDestinationException ex)
                {
                    lm.SaveLog("SECURITY ALERT: " + sh.TrackingId + " blocked for this location " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    lm.SaveLog("DATA ENTRY ERROR: " + sh.TrackingId + " " + ex.Message);
                }
                catch (InsecurePackagingException ex)
                {
                    lm.SaveLog("PACKAGING ERROR: " + sh.TrackingId + " " + ex.Message);
                }
                catch (Exception ex)
                {
                    lm.SaveLog("GENERAL ERROR: " + sh.TrackingId + " " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Processing attempt finished for ID: " + sh.TrackingId);
                }
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nCheck shipment_audit.log");

        }
    }
}

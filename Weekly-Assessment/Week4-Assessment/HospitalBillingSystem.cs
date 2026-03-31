using System.Text;

namespace Week4Started
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }
        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
        
    }
    class Inpatient: Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }

        public override decimal CalculateFinalBill()
        {
            return base.CalculateFinalBill()+ (DaysStayed * DailyRate);
        }

    }
    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }
        public override decimal CalculateFinalBill()
        {
            return base.CalculateFinalBill() + (ProcedureFee);
        }
    }
    class EmergencyPatient : Patient
    {
        private int severityLevel;

        public int SeverityLevel
        {
            get { return severityLevel; }
            set { 
                if(value>=1 || value <= 5) {  severityLevel = value; }
                severityLevel = value=1;  
            }
        }
        public override decimal CalculateFinalBill()
        {
            return base.CalculateFinalBill()*SeverityLevel;
        }

    }
    class HospitalBilling
    {
        private List<Patient> patients = new List<Patient>();
        //1
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }
        //2
        public void GenerateDailyReport()
        {
            
            foreach (Patient pat  in patients)
            {
                decimal bill = pat.CalculateFinalBill();
                Console.WriteLine($"{pat.Name}: \t₹{bill}");
            }
        }
        //3
        public decimal CalculateTotalRevenue()
        {
            decimal sum = 0;
            foreach (Patient pat in patients)
            {
                sum += pat.CalculateFinalBill();
            }
            return sum;
        }
        //4
        public int GetInpatientCount()
        {
            int count = 0;
            foreach (Patient pat in patients)
            {
                if(pat is Inpatient)
                {
                    count++;
                }
            }
            return count;
        }
    }
    internal class HospitalBillingSystem
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            HospitalBilling h=new HospitalBilling();
            h.AddPatient(new Patient {Name="Lovely", BaseFee=100});
            h.AddPatient(new Inpatient
            {
                Name = "Nisha Sharma",
                BaseFee = 200,
                DaysStayed = 3,
                DailyRate = 1500
            });

            h.AddPatient(new Outpatient
            {
                Name = "Ram Verma",
                BaseFee = 300,
                ProcedureFee = 1200
            });

            h.AddPatient(new EmergencyPatient
            {
                Name = "Amit Singh",
                BaseFee = 500,
                SeverityLevel = 4
            });
            Console.WriteLine("======================= Daily Report =======================");
            h.GenerateDailyReport();
            Console.WriteLine("============================================================");
            Console.WriteLine($"Total Revenue: ₹{h.CalculateTotalRevenue()}");
            Console.WriteLine($"Inpatient Count: {h.GetInpatientCount()}");
        }
    }
}

namespace EmployeeAnnualPerformanceBonusCalculationLibrary
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0m;

                if (AttendancePercentage < 0 || AttendancePercentage > 100)
                    throw new InvalidOperationException("Attendance must be between 0 and 100.");

                decimal baseBonusPercent = 0m;

                if (PerformanceRating == 5)
                    baseBonusPercent = 0.25m;
                else if (PerformanceRating == 4)
                    baseBonusPercent = 0.18m;
                else if (PerformanceRating == 3)
                    baseBonusPercent = 0.12m;
                else if (PerformanceRating == 2)
                    baseBonusPercent = 0.05m;
                else if (PerformanceRating == 1)
                    baseBonusPercent = 0.00m;
                else
                    throw new InvalidOperationException("Invalid rating.");

                decimal bonus = BaseSalary * baseBonusPercent;

                // Experience bonus
                if (YearsOfExperience > 10)
                    bonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5)
                    bonus += BaseSalary * 0.03m;

                //Attendance penalty
                if (AttendancePercentage < 85)
                    bonus *= 0.80m;

                //Department multiplier
                bonus *= DepartmentMultiplier;

                //The total bonus before tax must not exceed: 40 % of BaseSalary
                //If exceeded, cap it to 40 %.

                decimal cap = BaseSalary * 0.40m;
                if (bonus > cap)
                    bonus = cap;

                // Tax deduction
                decimal taxRate;

                if (bonus <= 150000m)
                    taxRate = 0.10m;
                else if (bonus >150000m & bonus <= 300000m )
                    taxRate = 0.20m;
                else
                    taxRate = 0.30m;
                decimal finalBonus = bonus * (1 - taxRate);

                //Final Output
                return Math.Round(finalBonus, 2);
            }
        }
    }
}



using EmployeeAnnualPerformanceBonusCalculationLibrary;

namespace Week8_EmployeeAnnualPerformance
{
    //Testing
    public class Tests
    {
        private EmployeeBonus emp;

        [SetUp]
        public void Setup()
        {
            emp = new EmployeeBonus();
        }

        // Normal Calculation Case
        [Test]
        public void NormalHighPerformer_NoCap()
        {
            emp.BaseSalary = 500000m;
            emp.PerformanceRating = 5;
            emp.YearsOfExperience = 6;
            emp.DepartmentMultiplier = 1.1m;
            emp.AttendancePercentage = 95;

            Assert.AreEqual(123200.00m, emp.NetAnnualBonus);
        }

        // Attendance Penalty
        [Test]
        public void AttendancePenalty_Applied()
        {
            emp.BaseSalary = 400000m;
            emp.PerformanceRating = 4;
            emp.YearsOfExperience = 8;
            emp.DepartmentMultiplier = 1.0m;
            emp.AttendancePercentage = 80;

            Assert.AreEqual(60480.00m, emp.NetAnnualBonus);
        }

        // Cap Rule
        [Test]
        public void CapTriggered()
        {
            emp.BaseSalary = 1000000m;
            emp.PerformanceRating = 5;
            emp.YearsOfExperience = 15;
            emp.DepartmentMultiplier = 1.5m;
            emp.AttendancePercentage = 95;

            Assert.AreEqual(280000.00m, emp.NetAnnualBonus);
        }

        // Zero Salary Case
        [Test]
        public void ZeroSalary_ReturnsZero()
        {
            emp.BaseSalary = 0m;
            emp.PerformanceRating = 5;
            emp.YearsOfExperience = 10;
            emp.DepartmentMultiplier = 1.2m;
            emp.AttendancePercentage = 100;

            Assert.AreEqual(0.00m, emp.NetAnnualBonus);
        }

        // Low Performer
        [Test]
        public void LowPerformer_Rating2()
        {
            emp.BaseSalary = 300000m;
            emp.PerformanceRating = 2;
            emp.YearsOfExperience = 3;
            emp.DepartmentMultiplier = 1.0m;
            emp.AttendancePercentage = 90;

            Assert.AreEqual(13500.00m, emp.NetAnnualBonus);
        }

        // Tax Boundary
        [Test]
        public void TaxBoundary_150k()
        {
            emp.BaseSalary = 600000m;
            emp.PerformanceRating = 3;
            emp.YearsOfExperience = 0;
            emp.DepartmentMultiplier = 1.0m;
            emp.AttendancePercentage = 100;

            Assert.AreEqual(64800.00m, emp.NetAnnualBonus);
        }

        // High Tax Slab
        [Test]
        public void HighTaxSlab_Over300k()
        {
            emp.BaseSalary = 900000m;
            emp.PerformanceRating = 5;
            emp.YearsOfExperience = 11;
            emp.DepartmentMultiplier = 1.2m;
            emp.AttendancePercentage = 100;

            Assert.AreEqual(226800.00m, emp.NetAnnualBonus);
        }

        // Rounding Precision
        [Test]
        public void RoundingPrecision_Test()
        {
            emp.BaseSalary = 555555m;
            emp.PerformanceRating = 4;
            emp.YearsOfExperience = 6;
            emp.DepartmentMultiplier = 1.13m;
            emp.AttendancePercentage = 92;

            Assert.AreEqual(118649.88m, emp.NetAnnualBonus);
        }

        // Invalid Rating
        [Test]
        public void InvalidRating_ThrowsException()
        {
            emp.BaseSalary = 500000m;
            emp.PerformanceRating = 6;
            emp.YearsOfExperience = 5;
            emp.DepartmentMultiplier = 1.0m;
            emp.AttendancePercentage = 90;

            Assert.Throws<InvalidOperationException>(() =>
            {
                var _ = emp.NetAnnualBonus;
            });
        }
    }
}
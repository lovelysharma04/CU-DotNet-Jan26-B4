
using System.Collections;

namespace Week5Started
{
    internal class Day24_01_TheLegacyEmployeeDirectory
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101,"Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            if (!employeeTable.ContainsKey(105))
            {
                employeeTable.Add(105, "Edward");
            }
            else
            {
                Console.WriteLine("Id Already Exists..");
            }
            string s1 = employeeTable[102].ToString();
            Console.WriteLine(s1);

            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"Id: {item.Key}  Name: {item.Value}");
            }
            Console.WriteLine("Removing ID: 103 ..."); 
            employeeTable.Remove(103);
            int total = employeeTable.Count;
            Console.WriteLine($"Total count of remaining employees: {total}");
            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"Id: {item.Key}  Name: {item.Value}");
            }
        }
    }
}

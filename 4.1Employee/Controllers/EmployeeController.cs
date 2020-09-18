using _4._1Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4._1Employee.Controllers
{
    public class EmployeeController
    {
        public Employee GetEmployeeByID(int employeeID)
        {
            Employee toReturn = null;

            try
            {
                using (EmployeeContext context = new EmployeeContext())
                {
                    // Single will throw an Exception if there is not only one item in a collection.
                    // SingleOrDefault will return null if there is not only one.
                    toReturn = context.Employees.Where(x => x.ID == employeeID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Employee Control Exception: " + e.Message);
            }

            return toReturn;
        }


        public Employee GetEmployeeByName(string firstName, string lastName)
        {
            // Declare Output
            Employee toReturn = null;

            // Obtain Output
            try
            {
                using (EmployeeContext context = new EmployeeContext())
                {
                    // Single will throw an Exception if there is not only one item in a collection.
                    // SingleOrDefault will return null if there is not only one.
                    toReturn = context.Employees.Where(x => x.FirstName == firstName && x.LastName == lastName).Single();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Employee Control Exception: " + e.Message);
            }

            // Return Output
            return toReturn;
        }
    }
}

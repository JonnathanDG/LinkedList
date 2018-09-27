using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Employee : IComparable<Employee>
    {
        //class variables
        public int EmployeeID { get; }
        public string FirstName { get; }
        public string LastName { get; }

        //Constructor
        public Employee(int employeeId, string name = null, string lastName = null)
        {
            this.EmployeeID = employeeId;
            this.FirstName = name;
            this.LastName = lastName;
        }

        //Compares to Employees using the id 
        public int CompareTo(Employee otherEmployee)
        {
            //Employee otherEmployee = other;

            return this.EmployeeID.CompareTo(otherEmployee.EmployeeID);
        }

        //Creates an string representation of Employee
        public override string ToString()
        {
            return this.EmployeeID + " " + (this.FirstName == null ? "null" : this.FirstName) + " " + (this.LastName == null ? "null" : this.LastName);
        }
    }
}

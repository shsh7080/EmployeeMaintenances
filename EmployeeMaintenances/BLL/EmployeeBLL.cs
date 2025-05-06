using System.Collections.Generic;
using EmployeeMaintenances.DAL;
using EmployeeMaintenances.Models;

namespace EmployeeMaintenance.BLL
{
    public class EmployeeBLL
    {
        private EmployeeDAL employeeDAL = new EmployeeDAL();

        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.GetAllEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new System.Exception("Name cannot be left blank.");

            employeeDAL.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new System.Exception("Name cannot be empty.");

            employeeDAL.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int employeeID)
        {
            employeeDAL.DeleteEmployee(employeeID);
        }
    }
}
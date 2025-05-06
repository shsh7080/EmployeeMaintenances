using EmployeeMaintenances.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EmployeeMaintenances.DAL
{
    public class EmployeeDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        Name = reader["Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        Address1 = reader["Address1"].ToString(),
                        Earnings = Convert.ToDecimal(reader["Earnings"]),
                        Deduction = Convert.ToDecimal(reader["Deduction"]),
                        Qualification = reader["Qualification"].ToString()
                    });
                }
            }
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (Name, Address, Address1, Earnings, Deduction, Qualification) " +
                               "VALUES (@Name, @Address, @Address1, @Earnings, @Deduction, @Qualification)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@Address1", employee.Address1);
                cmd.Parameters.AddWithValue("@Earnings", employee.Earnings);
                cmd.Parameters.AddWithValue("@Deduction", employee.Deduction);
                cmd.Parameters.AddWithValue("@Qualification", employee.Qualification);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employees SET Name=@Name, Address=@Address, Address1=@Address1, " +
                               "Earnings=@Earnings, Deduction=@Deduction, Qualification=@Qualification WHERE EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@Address1", employee.Address1);
                cmd.Parameters.AddWithValue("@Earnings", employee.Earnings);
                cmd.Parameters.AddWithValue("@Deduction", employee.Deduction);
                cmd.Parameters.AddWithValue("@Qualification", employee.Qualification);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}
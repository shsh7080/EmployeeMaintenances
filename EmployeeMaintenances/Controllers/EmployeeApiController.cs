using System.Collections.Generic;
using System.Web.Http;
using EmployeeMaintenances.Models;
using EmployeeMaintenance.BLL;

namespace EmployeeMaintenances.Controllers
{
    public class EmployeeApiController : ApiController
    {
        private EmployeeBLL bll = new EmployeeBLL();

        // GET api/employeeapi
        public IEnumerable<Employee> Get()
        {
            return bll.GetAllEmployees();
        }

        // GET api/employeeapi/5
        public Employee Get(int id)
        {
            return bll.GetAllEmployees().Find(e => e.EmployeeID == id);
        }

        // POST api/employeeapi
        public IHttpActionResult Post([FromBody] Employee emp)
        {
            bll.AddEmployee(emp);
            return Ok("Employee added successfully");
        }

        // PUT api/employeeapi/5
        public IHttpActionResult Put(int id, [FromBody] Employee emp)
        {
            emp.EmployeeID = id;
            bll.UpdateEmployee(emp);
            return Ok("Employee updated successfully");
        }

        // DELETE api/employeeapi/5
        public IHttpActionResult Delete(int id)
        {
            bll.DeleteEmployee(id);
            return Ok("Employee deleted successfully");
        }
    }
}

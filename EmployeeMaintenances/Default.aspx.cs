using EmployeeMaintenance.BLL;
using EmployeeMaintenances.Models;
using System;
using System.Web.UI.WebControls;

namespace EmployeeMaintenance
{
    public partial class Default : System.Web.UI.Page
    {
        private EmployeeBLL employeeBLL = new EmployeeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            gvEmployees.DataSource = employeeBLL.GetAllEmployees();
            gvEmployees.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee
                {
                    Name = txtName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Address1 = txtAddress1.Text.Trim(),
                    Earnings = Convert.ToDecimal(txtEarnings.Text),
                    Deduction = Convert.ToDecimal(txtDeduction.Text),
                    Qualification = txtQualification.Text.Trim()
                };

                employeeBLL.AddEmployee(employee);
                LoadEmployees();
                ClearFields();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee
                {
                    EmployeeID = Convert.ToInt32(txtEmployeeID.Text),
                    Name = txtName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Address1 = txtAddress1.Text.Trim(),
                    Earnings = Convert.ToDecimal(txtEarnings.Text),
                    Deduction = Convert.ToDecimal(txtDeduction.Text),
                    Qualification = txtQualification.Text.Trim()
                };

                employeeBLL.UpdateEmployee(employee);
                LoadEmployees();
                ClearFields();

                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.NewEditIndex].Value);
            Employee employee = employeeBLL.GetAllEmployees().Find(emp => emp.EmployeeID == id);

            if (employee != null)
            {
                txtEmployeeID.Text = employee.EmployeeID.ToString();
                txtName.Text = employee.Name;
                txtAddress.Text = employee.Address;
                txtAddress1.Text = employee.Address1;
                txtEarnings.Text = employee.Earnings.ToString();
                txtDeduction.Text = employee.Deduction.ToString();
                txtQualification.Text = employee.Qualification;

                btnAdd.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
                employeeBLL.DeleteEmployee(id);
                LoadEmployees();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearFields()
        {
            txtEmployeeID.Text = "";
            txtName.Text = "";
            txtAddress.Text = ""; 
            txtAddress1.Text = "";
            txtEarnings.Text = "";
            txtDeduction.Text = "";
            txtQualification.Text = "";

            btnAdd.Visible = true;
            btnUpdate.Visible = false;
        }
    }
}

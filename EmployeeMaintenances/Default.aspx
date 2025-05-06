<%@ Page Title="Employee Maintenance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeMaintenance.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h2>Employee Maintenance</h2>

        <!-- Employee Form -->
        <div class="form-group">
            <asp:Label ID="lblEmployeeID" runat="server" Text="Employee ID" Visible="false"></asp:Label>
            <asp:TextBox ID="txtEmployeeID" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                ErrorMessage="Name is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblAddress1" runat="server" Text="Address1"></asp:Label>
            <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblEarnings" runat="server" Text="Earnings"></asp:Label>
            <asp:TextBox ID="txtEarnings" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblDeduction" runat="server" Text="Deduction"></asp:Label>
            <asp:TextBox ID="txtDeduction" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
            <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add Employee" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Employee" CssClass="btn btn-warning" OnClick="btnUpdate_Click" Visible="false"/>
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
        </div>

        <hr />

        <!-- Employee GridView -->
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            DataKeyNames="EmployeeID" OnRowEditing="gvEmployees_RowEditing" OnRowDeleting="gvEmployees_RowDeleting">
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Address1" HeaderText="Address1" />
                <asp:BoundField DataField="Earnings" HeaderText="Earnings" />
                <asp:BoundField DataField="Deduction" HeaderText="Deduction" />
                <asp:BoundField DataField="Qualification" HeaderText="Qualification" />

                <asp:CommandField ShowEditButton="True" EditText="Edit" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" />
            </Columns>
        </asp:GridView>

    </main>

</asp:Content>

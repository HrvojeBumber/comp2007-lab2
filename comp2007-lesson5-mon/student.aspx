<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2007_lesson5_mon.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Student Details</h1>

    <div class="form-group">
        <label for="txtfirstName" class="col-sm-3">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" required="true" MaxLength="50" />
    </div>

    <div class="form-group">
        <label for="txtlastName" class="col-sm-3">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" required="true" MaxLength="50" />
    </div>

    <div class="form-group">
        <label for="txtenrollmentDate" class="col-sm-3">Enrollment Date:</label>
        <asp:TextBox ID="txtEnrollmentDate" runat="server" required="true" MaxLength="22" />
        <asp:RangeValidator runat="server" ControlToValidate="txtEnrollmentDate" CssClass="label label-danger" ErrorMessage="Must be between 2005 and 2015"
            minimumValue="2002-05-12" MaximumValue="2015-05-12" Type="Date" />
    </div>

    <div class="col-sm-offset-3">
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click1" />
    </div>
    
</asp:Content>

<%@ Page Title="Contoso University-Students" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="comp2007_lesson5_mon.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Students</h1>
    <a href="student.aspx">Add Student</a>
    <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" OnRowDeleting="grdStudents_RowDeleting" 
        DataKeyNames="StudentID">
        <Columns>
            <asp:BoundField DataField="StudentID" Visible="false" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:c}" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="~/student.aspx" Text="Edit" DataNavigateUrlFields="StudentID" 
                DataNavigateUrlFormatString="student.aspx?StudentID={0}" />
            <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>

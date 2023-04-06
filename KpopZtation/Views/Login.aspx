<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Guest.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KpopZtation.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Login</h1>
    </div>
    <div>
        <asp:Label ID="lblcemail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtcemail" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblcpassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtcpassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="cbxcremember" runat="server" Text="Remember Me" />
    </div>
    <div>
        <asp:Label ID="lblcvalidation" runat="server" Text="" Visible="False"></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnclogin" runat="server" Text="Login" OnClick="btnclogin_Click"/>
    </div>
</asp:Content>

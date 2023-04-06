<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Guest.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KpopZtation.Views.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Register</h1>
    </div>
    <div>
        <div>
            <asp:Label ID="lblcname" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtcname" runat="server"></asp:TextBox>
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
            <asp:Label ID="lblcgender" runat="server" Text="Gender: "></asp:Label>
            <asp:RadioButtonList ID="rblcgender" runat="server"></asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="lblcaddress" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="txtcaddress" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblcvalidation" runat="server" Text="" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btncregister" runat="server" Text="Register" OnClick="btncregister_Click"/>
        </div>
    </div>
</asp:Content>

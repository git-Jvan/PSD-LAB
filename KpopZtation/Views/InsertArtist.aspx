<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="KpopZtation.Views.InsertArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Insert Artist</h1>
    </div>
    <div>
        <div>
            <asp:Label ID="lblaname" runat="server" Text="Artist's Name: "></asp:Label>
            <asp:TextBox ID="txtaname" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblaimage" runat="server" Text="Artist's Image: "></asp:Label>
            <asp:FileUpload ID="fuaimage" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblavalidation" runat="server" Text="" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnainsert" runat="server" Text="Insert" OnClick="btnainsert_Click" />
        </div>
    </div>
</asp:Content>

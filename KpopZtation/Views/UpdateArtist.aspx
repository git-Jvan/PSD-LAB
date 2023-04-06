<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZtation.Views.UpdateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Update Artist</h1>
    </div>
    <div>
        <div>
            <asp:Label ID="lblaname" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtaname" runat="server"></asp:TextBox>
        </div>
        <div>
            <div>
                <asp:Label ID="lblaimage" runat="server" Text="Image: "></asp:Label>
            </div>
            <div>
                <asp:Image ID="imga" runat="server" />
            </div>
            <div>
                <asp:FileUpload ID="fuaimage" runat="server" />
            </div>
        </div>
        <div>
            <asp:Label ID="lblavalidation" runat="server" Text="" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnaupdate" runat="server" Text="Update" OnClick="btnaupdate_Click" />
        </div>
    </div>
</asp:Content>

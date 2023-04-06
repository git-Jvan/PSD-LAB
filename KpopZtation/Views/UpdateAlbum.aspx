<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateAlbum.aspx.cs" Inherits="KpopZtation.Views.UpdateAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <h1>Update Album</h1>
    </div>
    <div>
        <div>
            <asp:Label ID="lblalname" runat="server" Text="Album's Name: "></asp:Label>
            <asp:TextBox ID="txtalname" runat="server"></asp:TextBox>
        </div>
        <div>
            <div>
                <asp:Label ID="lblalimage" runat="server" Text="Album's Image: "></asp:Label>
            </div>
            <div>
                <asp:Image ID="imgal" runat="server" />
            </div>
            <div>
                <asp:FileUpload ID="fualimage" runat="server" />
            </div>
        </div>
        <div>
            <asp:Label ID="lblalprice" runat="server" Text="Album's Price: "></asp:Label>
            <asp:TextBox ID="txtalprice" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblalstock" runat="server" Text="Album's Stock: "></asp:Label>
            <asp:TextBox ID="txtalstock" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblaldescription" runat="server" Text="Album's Description: "></asp:Label>
            <asp:TextBox ID="txtaldescription" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblalvalidation" runat="server" Text="" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnalupdate" runat="server" Text="Insert" OnClick="btnalupdate_Click" />
        </div>
    </div>
</asp:Content>

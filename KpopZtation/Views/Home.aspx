<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Home</h1>
    </div>
    <div>
        <asp:Repeater ID="rartist" runat="server" OnItemDataBound="rartist_ItemDataBound" >
            <ItemTemplate>
                <table>
                    <tr id="artistrow" runat="server">
                        <td><img src="../Assets/Artists/<%# Eval("ArtistImage") %>" /></td>
                        <td><%# Eval("ArtistName") %></td>
                        <td><asp:Button ID="btnadelete" runat="server" Text="Delete" CommandArgument='<%# Eval("ArtistID") %>' OnCommand="btnadelete_Command" /></td>
                        <td><asp:Button ID="btnaupdate" runat="server" Text="Update" CommandArgument='<%# Eval("ArtistID") %>' OnCommand="btnaupdate_Command" /></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="insertartist" runat="server">
        <div>
            <h1>Insert Artist</h1>
        </div>
        <div>
            <asp:Button ID="btninsert" runat="server" Text="Insert" OnClick="btninsert_Click" />
        </div>
    </div>
</asp:Content>

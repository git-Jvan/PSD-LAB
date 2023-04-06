<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Customer.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="KpopZtation.Views.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h1>Cart Page</h1>
        </div>
        <div>
            <asp:Label ID="lblcnone" runat="server" Text="Customer's Cart is Empty!"></asp:Label>
            <asp:Repeater ID="rcart" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><img src="../Assets/Albums/<%# Eval("Album.AlbumImage") %>" /></td>
                            <td><%# Eval("Album.AlbumName") %></td>
                            <td><%# Eval("Qty") %></td>
                            <td><%# Eval("Album.AlbumPrice") %></td>
                            <td><%# String.Format("{0}", Convert.ToInt32(Eval("Album.AlbumPrice")) * Convert.ToInt32(Eval("Qty"))) %></td>
                            <td><asp:Button ID="btncdelete" runat="server" Text="Delete" CommandArgument='<%# Eval("AlbumID") %>' OnCommand="btncdelete_Command" /></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="btncheckout" runat="server">
            <asp:Button ID="btnccheckout" runat="server" Text="Checkout" OnClick="btnccheckout_Click" />
        </div>
    </div>
</asp:Content>

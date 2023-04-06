<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Customer.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="KpopZtation.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h1>Transaction History</h1>
        </div>
        <div>
            <asp:Repeater ID="rtransactionheader" runat="server" OnItemDataBound="rtransactionheader_ItemDataBound">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><%# Eval("TransactionID") %></td>
                            <td><%# Eval("TransactionDate", "{0:dd MMMM yyyy}") %></td>
                            <td><%# Eval("Customer.CustomerName") %></td
                        </tr>
                        <asp:Repeater ID="rtransactiondetail" runat="server">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td><img src="../Assets/Albums/<%# Eval("Album.AlbumImage") %>" /></td>
                                        <td><%# Eval("Album.AlbumName") %></td>
                                        <td><%# Eval("Qty") %></td>
                                        <td><%# Eval("Album.AlbumPrice") %></td>
                                        <td><%# String.Format("{0}", Convert.ToInt32(Eval("Qty")) * Convert.ToInt32(Eval("Album.AlbumPrice"))) %></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

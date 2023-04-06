<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="KpopZtation.Views.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h1>Album Detail</h1>
        </div>
        <div>
            <asp:Repeater ID="ralbumdetail" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><img src="../Assets/Albums/<%# Eval("AlbumImage") %>" /></td>
                            <td><%# Eval("AlbumName") %></td>
                            <td><%# Eval("AlbumDescription") %></td>
                            <td><%# Eval("AlbumStock") %></td>
                            <td><%# Eval("AlbumPrice") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="addcart" runat="server">
        <div>
            <h1>Cart</h1>
        </div>
        <div>
            <asp:Label ID="lblcquantity" runat="server" Text="Quantity: "></asp:Label>
            <asp:TextBox ID="txtcquantity" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblcvalidation" runat="server" Text="" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btncadd" runat="server" Text="Add to Cart" OnClick="btncadd_Click" />
        </div>
    </div>
</asp:Content>

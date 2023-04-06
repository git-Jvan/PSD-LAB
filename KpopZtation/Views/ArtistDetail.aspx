<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Admin.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KpopZtation.Views.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Artist's Detail</h1>
    </div>
    <div>
        <asp:Repeater ID="rartistdetail" runat="server">
            <ItemTemplate>
                <div>
                    <div>
                        <img src="../Assets/Artists/<%# Eval("ArtistImage") %>" />
                    </div>
                    <div>
                        <h3><%# Eval("ArtistName") %></h3>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
        <div>
            <h1>All Albums</h1>
        </div>
        <div>
            <asp:Label ID="lblalnone" runat="server" Text="Artist Doesn't Have Any Albums!"></asp:Label>
            <asp:Repeater ID="ralbum" runat="server" OnItemDataBound="ralbum_ItemDataBound">
                <ItemTemplate>
                    <table>
                        <tr id="albumrow" runat="server">
                            <td><img src="../Assets/Albums/<%# Eval("AlbumImage") %>" /></td>
                            <td><%# Eval("AlbumName") %></td>
                            <td><%# Eval("AlbumPrice") %></td>
                            <td><%# Eval("AlbumDescription") %></td>
                            <td><asp:Button ID="btnaldelete" runat="server" Text="Delete" CommandArgument='<%# Eval("AlbumID") %>' OnCommand="btnaldelete_Command" /></td>
                            <td><asp:Button ID="btnalupdate" runat="server" Text="Update" CommandArgument='<%# Eval("AlbumID") %>' OnCommand="btnalupdate_Command" /></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="insertalbum" runat="server">
            <div>
                <h1>Insert Album</h1>
            </div>
            <div>
                <asp:Button ID="btninsert" runat="server" Text="Insert" OnClick="btninsert_Click" />
            </div>
        </div>
    </div>
</asp:Content>

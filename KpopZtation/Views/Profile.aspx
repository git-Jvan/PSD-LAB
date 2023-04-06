<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Customer.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="KpopZtation.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Repeater ID="rprofile" runat="server" OnItemDataBound="rprofile_ItemDataBound">
            <ItemTemplate>
                <div id="customerrow">
                    <div>
                        <h2>Name: </h2>
                        <h3><%# Eval("CustomerName") %></h3>
                    </div>
                    <div>
                        <h2>Email: </h2>
                        <h3><%# Eval("CustomerEmail") %></h3>
                    </div>
                    <div>
                        <h2>Password: </h2>
                        <div>
                            <h3 id="passwordtext" runat="server"><%# Eval("CustomerPassword") %></h3>
                            <asp:Button ID="btntogglepassword" runat="server" Text="Show" OnClick="btntogglepassword_Click" />
                        </div>
                    </div>
                    <div>
                        <h2>Gender: </h2>
                        <h3><%# Eval("CustomerGender") %></h3>
                    </div>
                    <div>
                        <h2>Address: </h2>
                        <h3><%# Eval("CustomerAddress") %></h3>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
        <div>
            <h1>Delete Account</h1>
        </div>
        <div>
            <asp:Button ID="btncdelete" runat="server" Text="Delete" OnClick="btncdelete_Click" />
        </div>
    </div>
    <div>
        <div>
            <h1>Update Profile</h1>
        </div>
        <div>
            <asp:Button ID="btncupdate" runat="server" Text="Update" OnClick="btncupdate_Click" />
        </div>
    </div>
</asp:Content>

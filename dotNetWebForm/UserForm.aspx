<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="dotNetWebForm.UserForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>User Name:</td>
                <td>
                    <asp:TextBox ID="txtuserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Country:</td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>State:</td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>City:</td>
                <td>
                    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true"></asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:GridView ID="gVUser" runat="server" AutoGenerateColumns="false" OnRowCommand="gVUser_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("userName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <%#Eval("countryName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="State">
                            <ItemTemplate>
                                <%#Eval("stateName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <%#Eval("cityName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="deleteCmd" CommandArgument='<%#Eval("userId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="editCmd" CommandArgument='<%#Eval("userId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView></td>
            </tr>
        </table>
    </div>
</asp:Content>

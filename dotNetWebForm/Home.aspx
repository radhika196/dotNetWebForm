<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="dotNetWebForm.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <h1>WELCOME HOME</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvHomePage" runat="server" AutoGenerateColumns="false" OnRowCommand="gvHomePage_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id">
                                <ItemTemplate>
                                    <%#Eval("emailId") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password">
                                <ItemTemplate>
                                    <%#Eval("password") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <%#Eval("image") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

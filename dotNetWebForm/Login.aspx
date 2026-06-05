<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="dotNetWebForm.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>Email Id:</td>
                <td>
                    <asp:TextBox ID="txtLoginEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtLoginPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID ="labelLogin" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="true" ></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="dotNetWebForm.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>Old Password :</td>
                <td>
                    <asp:TextBox ID="txtOldPassword" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>New Password :</td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Confirm New Password :</td>
                <td>
                    <asp:TextBox ID="txtCnfNewPassword" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnChangepass" runat="server" Text="Change Password" OnClick="btnChangepass_Click" Font-Bold="true" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                   <asp:Label ID="lblChangePass" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="dotNetWebForm.StudentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 176px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>Student Name:</td>
                <td>
                    <asp:TextBox ID="txtStudName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Student Gender:</td>
                <td>
                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatColumns="3">
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td>Student Course:</td>
                <td>
                    <asp:DropDownList ID="ddlCourse" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Student City:</td>
                <td>
                    <asp:DropDownList ID="ddlCity" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"></asp:Button></td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" OnRowCommand="gvStudent_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <%#Eval("studentName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Gender">
                                <ItemTemplate>
                                    <%#Eval("genderName")  %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Course">
                                <ItemTemplate>
                                    <%#Eval("courseName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student City">
                                <ItemTemplate>
                                    <%#Eval("cityName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDel" runat="server" Text="Delete" CommandName="deleteBtn" CommandArgument='<%#Eval("studentId") %>'>
                                    </asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="editBtn" CommandArgument='<%#Eval("studentId") %>'>
                                    </asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

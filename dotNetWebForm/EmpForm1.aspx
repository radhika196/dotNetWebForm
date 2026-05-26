<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmpForm1.aspx.cs" Inherits="dotNetWebForm.EmpForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>Employee Name:</td>
                <td>
                    <asp:TextBox ID="empTxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Employee Salary:</td>
                <td>
                    <asp:TextBox ID="salaryTxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Employee Department:</td>
                <td>
                    <asp:TextBox ID="deptTxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Employee Age:</td>
                <td>
                    <asp:TextBox ID="ageTxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:button id="submitBtn" runat="server" text="Submit" OnClick="submitBtn_Click"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <columns>
                            <asp:TemplateField HeaderText="Employee Name">
                                <itemtemplate>
                                    <%#Eval("empName") %>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary">
                                <itemtemplate>
                                    <%#Eval("empSalary") %>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <itemtemplate>
                                    <%#Eval("department") %>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Age">
                                <itemtemplate>
                                    <%#Eval("empAge") %>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <itemtemplate>
                                    <asp:LinkButton ID="deleteBtn" runat="server" Text="Delete" CommandArgument='<%#Eval("id") %>' CommandName="deleteCmd">
                                    </asp:LinkButton>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <itemtemplate>
                                    <asp:LinkButton ID="editBtn" runat="server" Text="Edit" CommandName="editCmd" CommandArgument='<%#Eval("id") %>'>
                                    </asp:LinkButton>
                                </itemtemplate>
                            </asp:TemplateField>
                        </columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

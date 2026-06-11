<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EmpForm1.aspx.cs" Inherits="dotNetWebForm.EmpForm1" %>

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
                <td>
                    <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:DropDownList ID="ddlEmplChoice" runat="server">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Name" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Salary" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Department" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Age" Value="4"></asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <td>

                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </td>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <%#Eval("empName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary">
                                <ItemTemplate>
                                    <%#Eval("empSalary") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <%#Eval("department") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Age">
                                <ItemTemplate>
                                    <%#Eval("empAge") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="deleteBtn" runat="server" Text="Delete" CommandArgument='<%#Eval("id") %>' CommandName="deleteCmd">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="editBtn" runat="server" Text="Edit" CommandName="editCmd" CommandArgument='<%#Eval("id") %>'>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
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

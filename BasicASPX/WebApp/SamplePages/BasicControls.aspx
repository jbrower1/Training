<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" style="width: 80%; border: 1px solid #000000; background-color: #33CCFF">
        <tr>
            <td align="right">Textbox</td>
            <td>
                <asp:TextBox ID="TextBoxNumberChoice" runat="server" ToolTip="Enter a choice of 1 to 4"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="SubmitButtonChoice" runat="server" Text="Submit Choice" OnClick="SubmitButtonChoice_Click" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Choice (Radio Button List):" Font-Size="Medium" ForeColor="#33CC33" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">COMP1008</asp:ListItem>
                    <asp:ListItem Value="2">CPCS1517</asp:ListItem>
                    
                    <asp:ListItem Value="3">DMIT2018</asp:ListItem>
                    <asp:ListItem Value="4">DMIT1508</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Literal ID="Literal1" runat="server" Text="Choice (CheckBox):"></asp:Literal>
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxChoice" runat="server" Font-Bold="true" Text ="Programming Course if active"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="Display Label:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DisplayReadOnly" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Text="View Collection:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="CollectionList" runat="server">
                </asp:DropDownList>

                <asp:Button ID="DropDownChoice" runat="server" Text="Submit List" OnClick ="DropDownList_Click"/>
            </td>
        </tr>
        <tr>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="MessageLabel" runat="server"></asp:Label></td>
        
        </tr>
    </table>
</asp:Content>

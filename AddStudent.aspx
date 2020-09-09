<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab7.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <h1>Students</h1>
            <div>
                Student Name:
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" ControlToValidate="txtName" runat="server" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <br />
                Student Type :
                <asp:DropDownList ID="dpdStudentType" runat="server">
                    <asp:ListItem Selected="True" Value=""> Select... </asp:ListItem>
                    <asp:ListItem Value="1">Full Time</asp:ListItem>
                    <asp:ListItem Value="2">Part Time</asp:ListItem>
                    <asp:ListItem Value="3">Coop</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStudentType" ControlToValidate="dpdStudentType" ForeColor="Red" runat="server" ErrorMessage="Must select one!" InitialValue="" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                <br />
                <br />
            </div>

            <div id="details" runat="server">

                <table class="table">
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                    <% for (int i = 0; i < registeredStudent.Count; i++)
                        {%>
                      <tr>
                        <td><%=registeredStudent[i].Id %></td>
                        <td><%=registeredStudent[i].Name %></td>
                    </tr>
                    <% } %>
                    <tr id="warn" runat="server">
                        <th ></th>
                        <th style="color:red">No Student Yet!</th> 
                    </tr>
                </table>
            </div>

        </div>
        <br />
        <a><asp:HyperLink ID="HyperLink1" runat="server" href="RegisterCourse.aspx">Register Courses</asp:HyperLink></a>
    </form>
</body>
</html>

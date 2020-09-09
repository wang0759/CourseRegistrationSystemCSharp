<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab7.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Registration</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Registrations </h1>
            <p>Student : 
                <asp:DropDownList AutoPostBack="true" style="margin-left:40px" height="25px" width="300px" ID="drpStudent" runat="server" OnSelectedIndexChanged="drpStudent_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStudent" ControlToValidate="drpStudent" ForeColor="Red" runat="server" ErrorMessage="Must select one!" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
            </p>

            <p>
                 <asp:Label ID="studentCoursesLabel" runat="server" Text="" ForeColor="Blue"></asp:Label>
            </p>
           
            <div id="pnlInfo" runat="server">
                 <p>
                    <asp:Label ID="alert1" runat="server" Text="" ForeColor="Red"></asp:Label>
                </p>

                <h3 style="height: 19px">Following courses are currently available for registration</h3>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                </asp:CheckBoxList>
            </div>  

        <br />
        <br />
        <asp:Button style="margin-left: 10px"  ID="btnSave" BorderStyle="Solid" BorderColor="Red" width="80px" height ="25px" runat="server" Text="Save" OnClick="Main" />
        <br /> <br />
            <asp:HyperLink style="margin-left:10px" href="AddStudent.aspx" ID ="hplkAddStudents" runat="server">Add Students</asp:HyperLink>
            <br /> <br />
        </div>
        
    </form>
</body>
</html>

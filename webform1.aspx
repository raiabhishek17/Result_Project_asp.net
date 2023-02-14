<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Day1_Task1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Result</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>    
            <tr>
                <td style="color:red;">    
                    Upload the Student Details File    
                </td>    
                <td>    
                    <asp:FileUpload ID="FileUpload1" runat="server" />    
                </td>
                <td>
                     <asp:Label ID="lblResult" runat="server" Text="Upload .xlsx file" style="color:green"/>
                 </td>
             </tr>
             <tr>
                <td>    
                </td>    
                <td>    
                    <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="UploadFile1" />    
                </td>
            </tr>
                <tr>
                <td style="color:red;">    
                    Upload the Subject Details File    
                </td>    
                <td>    
                    <asp:FileUpload ID="FileUpload2" runat="server" />    
                </td>
                <td>
                     <asp:Label ID="Label1" runat="server" Text="Upload .xlsx file" style="color:green"/>
                 </td>
             </tr>
             <tr>
                <td>    
                </td>    
                <td>    
                    <asp:Button ID="Button2" runat="server" Text="Upload" OnClick="UploadFile2" />    
                </td>
            </tr>    
                

        </table>  
        </div>
    </form>
</body>
</html>

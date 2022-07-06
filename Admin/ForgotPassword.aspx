<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Şifrəni bərpa et</title>
    <!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="LoginCSS/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginCSS/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginCSS/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginCSS/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginCSS/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="LoginCSS/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginCSS/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginCSS/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="LoginCSS/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginCSS/css/util.css">
	<link rel="stylesheet" type="text/css" href="LoginCSS/css/main.css">
    <script src="UsersStyle/bootstrap.min.js"></script>
    <script src="UsersStyle/jquery.min.js"></script>
    <link href="UsersStyle/bootstrap.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
 <div class="container-login100">
			<div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-50">
                 <div class="wrap-input100 validate-input" data-validate = "email ünvan tələb olunur: ex@abc.xyz">
                        <%--<asp:TextBox ID="TextBox1" TextMode="Email" runat="server"   placeholder="Email"></asp:TextBox>--%>
                    <asp:DropDownList ID="DDlTeshkilat" runat="server" class="input100 form-control" OnSelectedIndexChanged="DDlTeshkilat_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>
                <div class="clearfix" style="height:10px;"></div>
                <div class="wrap-input100 validate-input" data-validate = "email ünvan tələb olunur: ex@abc.xyz">
                        <%--<asp:TextBox ID="TextBox1" TextMode="Email" runat="server"   placeholder="Email"></asp:TextBox>--%>
                    <asp:DropDownList ID="DDLALTTeshkilat" runat="server" class="input100 form-control" OnSelectedIndexChanged="DDLALTTeshkilat_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>
                <div class="clearfix" style="height:10px;"></div>
                <div class="wrap-input100 validate-input" data-validate = "email ünvan tələb olunur: ex@abc.xyz">
                        <%--<asp:TextBox ID="TextBox1" TextMode="Email" runat="server"   placeholder="Email"></asp:TextBox>--%>
                    <asp:DropDownList ID="DDLElmiMuessise" runat="server" class="input100 form-control">
                    </asp:DropDownList>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>
                <div class="clearfix" style="height:10px;"></div>
                <div class="wrap-input100 validate-input" data-validate = "email ünvan tələb olunur: ex@abc.xyz">
                        <asp:TextBox ID="EmailText" TextMode="Email" runat="server" class="input100"  placeholder="Email"></asp:TextBox>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>
                <div class="container-login100-form-btn m-t-20">
						<button type="submit" class="login100-form-btn" id="btnLogIn"  onserverclick="btnLogIn_ServerClick" runat="server">
							Təsdiqləyin</button>          
					</div>
                <div class="container-login100-form-btn m-t-20">
                    <asp:Label ID="lblMSG" Font-Bold="true" ForeColor="Green" Font-Size="13" runat="server"></asp:Label>       
					</div>
                <div class="container-login100-form-btn m-t-20">
                    <a href="Login.aspx">Sistemin giriş səhifəsinə keçid</a>       
					</div>
            </div>
               
        </div>
    </form>
</body>
</html>

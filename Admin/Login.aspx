<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

	<title>Login</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="../LoginCSS/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../LoginCSS/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../LoginCSS/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../LoginCSS/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../LoginCSS/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="../LoginCSS/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../LoginCSS/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../LoginCSS/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="../LoginCSS/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../LoginCSS/css/util.css">
	<link rel="stylesheet" type="text/css" href="../LoginCSS/css/main.css">
<!--===============================================================================================-->
</head>
<body>

<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-50">
				<form class="login100-form validate-form" runat="server">
					<span class="login100-form-title p-b-33">
                        <img src="../Images/LOGO.png" style="margin-top:-60px;" height="100" width="100" />
						<h6 style="font-family:'Times New Roman'; font-weight:bold; padding-top:10px;">CƏRRAHİYYƏ PLATFORMASI</h6>      
					</span>

					<div class="wrap-input100 validate-input" data-validate = "email ünvan tələb olunur: ex@abc.xyz">
						<%--<input  type="text" name="email" id="EmailText" runat="server">--%>
                        <asp:TextBox ID="EmailText" TextMode="Email" runat="server" class="input100"  placeholder="Email"></asp:TextBox>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>

					<div class="wrap-input100 rs1 validate-input" data-validate="Şifrə yanlışdır">
                        <asp:TextBox ID="PassText" TextMode="Password" class="input100" placeholder="Şifrə" runat="server"></asp:TextBox>
						<span class="focus-input100-1"></span>
						<span class="focus-input100-2"></span>
					</div>
                  
					<div class="container-login100-form-btn m-t-20">
						<button type="submit" class="login100-form-btn" id="btnLogIn"  onserverclick="Button1_Click" runat="server">
							Daxil olun
						</button>            
        
					</div>
				 </form>
			</div>
		</div>
	</div>
	
                       
	
<!--===============================================================================================-->
	<script src="../LoginCSS/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="../LoginCSS/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="../LoginCSS/vendor/bootstrap/js/popper.js"></script>
	<script src="../LoginCSS/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="../LoginCSS/vendor/daterangepicker/moment.min.js"></script>
	<script src="../LoginCSS/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="../LoginCSS/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="../LoginCSS/js/main.js"></script>

</body>
</html>

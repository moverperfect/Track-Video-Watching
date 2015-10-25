<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Track_Video_Watching.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
<nav class="navbar navbar-inverse">
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>                        
            </button>
            <a class="navbar-brand" href="Default.aspx">Track Video Watching</a>
        </div>
        <div class="collapse navbar-collapse" id="myNavbar">
            <ul class="nav navbar-nav">
                <li>
                    <a href="/Default.aspx">Home</a>
                </li>
                <li>
                    <a href="/AddNewVideo.aspx">Add a New Video</a>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li class="active">
                    <a class="dropdown-toggle" data-toggle="dropdown" id="account" runat="server" href="#" Visible="False"></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="Login.aspx"><span class="glyphicon glyphicon-log-out"></span> Log Out</a>
                        </li>
                    </ul>
                    <a id="loginButton" runat="server" href="/Login.aspx"><span class="glyphicon glyphicon-log-in"></span> Login</a>
                </li>
                <li>
                    <a id="registerButton" runat="server" href="/Register.aspx"><span class="glyphicon glyphicon-register"></span> Register</a>
                </li>
            </ul>
        </div>
    </div>
</nav>
<div class="alert alert-danger fade in" visible="false" runat="server" id="incorrectPassword">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> Incorrect password!
</div>
<div class="alert alert-danger fade in" visible="false" runat="server" id="incorrectUser">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> This user does not exist!
</div>
<form id="form1" runat="server">
    <div class="form-group col-xs-12 col-sm-4  col-sm-offset-4 col-md-2 col-md-offset-5">
        <p>
            Username<br/>

        </p>
        <input type="text" class="form-control" id="txtUsername" runat="server"/>
        <p>
            Password<br/>
        </p>
        <input type="password" class="form-control" id="txtPassword" runat="server"/>
        <br/>
    </div>
    <div class="clearfix"></div>
    <div style="text-align: center;">
        <asp:Button class="btn btn-primary" ID="cmdLogin" runat="server" Text="Login" OnClick="cmdLogin_Click"/>
        <br/>
        <br/>
        <a type="button" class="btn btn-info" id="cmdRegister" href="Register.aspx">Register</a>
    </div>
</form>
</body>
</html>
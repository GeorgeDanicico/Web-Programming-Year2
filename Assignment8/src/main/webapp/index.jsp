<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" language="java" %>
<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <style>
        html, body {
            height: 100%;
        }
        html {
            display: table;
            margin: auto;
        }
        body {
            display: table-cell;
            vertical-align: middle;
            background-color: white;
            font-family: "Arial", sans-serif;
        }
        .button {
            width: 80px;
            height: 50px;
            border-radius: 8px;
            color: white;
            background-color: blue;
        }
    </style>
</head>
<body>
<h3>Login</h3>
<%
    if(session.getAttribute("fail") != null && session.getAttribute("fail").equals(true)) {
%>
<p>Login failed, please try again.</p>
<%
    }
%>
<form action="LoginController" method="post">
    <p>Username</p>
    <input type="text" name="username"> <br>

    <p>Password</p>
    <input type="password" name="password"> <br>
    <br>
    <input class="button" type="submit" value="Login"/>
</form>
</body>
</html>
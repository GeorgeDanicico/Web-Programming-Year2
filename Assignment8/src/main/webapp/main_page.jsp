<%--
  Created by IntelliJ IDEA.
  User: georg
  Date: 5/14/2022
  Time: 6:26 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page import="web.assignment8.domain.User" %>
<%@ page import="web.assignment8.domain.Grid" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Battlefield</title>
    <style>
        .table {
            width: 125px;
        }
    </style>
</head>
<body>
    <div>
        <% 
            out.println("<h3>Welcome, " + ((User) request.getSession().getAttribute("user")).getUsername() + "! </h3>");
        %>
        <form action="LogoutController" method="get">
            <input type="submit" id="logout" value="Logout">
        </form>

        <form action="MainPageController" method="get">
            <input type="submit" id="startgame" value="Start Game">
        </form>

    </div>

    <div class="table">
        <br>
        My ships
        <br>

        <%
            if (session.getAttribute("lose") != null) {
                out.println("You lost the game!");
            }
        %>

        <%
            if (session.getAttribute("grid") != null) {
                out.print(((Grid) session.getAttribute("grid")).getMap());
        %>
            <form action="AttackController" method="post">
                <br>
                Attack:
                <p>Row</p>
                <input type="text" name="row"> <br>

                <p>Column</p>
                <input type="text" name="column"> <br>

                <input type="submit" value="Attack">
            </form>

            <form action="ReceiveAttackController" method="get">
                <input type="submit" value="Receive attack">
            </form>
        <%
        }
        %>
    </div>

</body>
</html>

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
            display: flex;
        }

        .my-ships {
            width: 125px;
        }

        .enemy-ships {
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

        <div class="my-ships">
        <%
            if (session.getAttribute("lose") != null) {
                out.println("You lost the game!");
            }
        %>

        <%
            if (session.getAttribute("won") != null) {
                out.println("You won the game!");
            }
        %>

        <%
            if (session.getAttribute("grid") != null) {
                out.println("<br>My ships: <br>");
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

        <div class="enemy-ships">
            <%
                if (session.getAttribute("enemyGrid") != null) {
                    out.println("<br>Enemy ships: <br>");
                    out.print(((Grid) session.getAttribute("enemyGrid")).getMap());
                }
            %>
        </div>
        </div>
    </div>

</body>
</html>

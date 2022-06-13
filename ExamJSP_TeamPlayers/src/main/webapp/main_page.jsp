<%@ page import="com.example.examjsp_teamplayers.domain.Team" %>
<%@ page import="java.util.List" %><%--
  Created by IntelliJ IDEA.
  User: georg
  Date: 6/12/2022
  Time: 6:18 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Player</title>
</head>
<body>
<%
    out.println("<h3>Welcome, " + (request.getSession().getAttribute("user")) + "! </h3>");
%>

<%
    List<Team> Teams = (List<Team>) request.getSession().getAttribute("allTeams");
    if (Teams != null) {
        int i = 0;
        int n = Teams.size();
        out.println("<h3>Teams: </h3><br>");
%>
<table style="text-align:center; width: 500px;">
    <thead>
    <tr>
        <th>ID</th>
        <th>CAPTAINID</th>
        <th>NAME</th>
        <th>DESCRIPTION</th>
        <th>MEMBERS</th>
    </tr>
    </thead>
    <tbody>

    <% while(i < n) {
    %>
    <tr>
        <td><%=Teams.get(i).getId()%></td>
        <td><%=Teams.get(i).getCaptainId()%></td>
        <td><%=Teams.get(i).getName()%></td>
        <td><%=Teams.get(i).getDescription()%></td>
        <td><%=Teams.get(i).getMembers().toString()%></td>
    </tr>
    <%
            i++; }
    %>
    </tbody>
</table><br>
<%
    }
%>

        <%
    List<Team> userTeams = (List<Team>) request.getSession().getAttribute("userTeams");
    if (userTeams != null) {
        int j = 0;
        int m = userTeams.size();
        out.println("<h3>Your teams: </h3><br>");
%>
    <table style="text-align:center; width: 500px;">
        <thead>
        <tr>
            <th>ID</th>
            <th>CAPTAINID</th>
            <th>NAME</th>
            <th>DESCRIPTION</th>
        </tr>
        </thead>
        <tbody>

        <% while(j < m) {
        %>
        <tr>
            <td><%=userTeams.get(j).getId()%></td>
            <td><%=userTeams.get(j).getCaptainId()%></td>
            <td><%=userTeams.get(j).getName()%></td>
            <td><%=userTeams.get(j).getDescription()%></td>
        </tr>
        <%
                j++; }
        %>


        </tbody>
</table><br>
<%
    }
%>

<form method="post" action="TeamController">
    <p>Assign player to team</p>
    <input placeholder="Player name" name="playerName">
    <input placeholder="Team name" name="teamNames">

    <button type="submit">Assign</button>
</form>

</body>
</html>

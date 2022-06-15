<%--
  Created by IntelliJ IDEA.
  User: georg
  Date: 6/15/2022
  Time: 12:26 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
  <head>
    <title>Title</title>
  </head>
  <body>
  <%
    out.println("<h3>Welcome, " + (request.getSession().getAttribute("user")) + "! </h3>");
  %>

  </body>
</html>

<%@ page import="com.example.examjsp1.domain.Article" %>
<%@ page import="java.util.List" %><%--
  Created by IntelliJ IDEA.
  User: georg
  Date: 6/12/2022
  Time: 12:45 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Exam</title>

    <script type="text/javascript">
        var msg ='<%=request.getSession().getAttribute("Alert")%>';
        console.log(msg);
        if (msg !== "null" && msg !== "noalert") {
            alert("New updates found: "+msg);
        }
    </script>
</head>
<body>
    <%
        out.println("<h3>Welcome, " + (request.getSession().getAttribute("user")) + "! </h3>");
    %>

    <form method="get" action="NotificationController">
        <p>Fetch updates</p>
        <button type="submit">Fetch</button>

        <%

        %>

    </form>

    <form method="get" action="ArticleController">
        <p>Get articles from journal:</p>
        <input type="text" placeholder="journalid" name="journalid">
        <button type="submit">Get</button>

        <%
            List<Article> articles = (List<Article>) request.getSession().getAttribute("articles");
            if (articles != null) {
                int i = 0;
                int n = articles.size();

                out.println("<h3>Your articles are: </h3><br>");
        %>
        <table style="text-align:center; width: 500px;">
            <thead>
            <tr>
                <th>summary</th>
                <th>user</th>
                <th>journalid</th>
                <th>date</th>
            </tr>
            </thead>
            <tbody>

            <% while(i < n) {
                %>
            <tr>
                <td><%=articles.get(i).getSummary()%></td>
                <td><%=articles.get(i).getUser()%></td>
                <td><%=articles.get(i).getJournalid()%></td>
                <td><%=articles.get(i).getDate()%></td>
            </tr>
            <%
                i++; }
            %>

            </tbody>
        </table><br>
        <%
            }
        %>
    </form>

    <form method="post" action="ArticleController">
        <p>Add new article to journal:</p>
        <input type="text" placeholder="journal name" name="journalname">
        <input type="text" placeholder="summary" name="summary">
        <button type="submit">Add</button>
    </form>

</body>
</html>

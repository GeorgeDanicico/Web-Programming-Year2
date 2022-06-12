package com.example.examjsp1.controller;

import com.example.examjsp1.domain.Article;
import com.example.examjsp1.model.DBManager;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.util.List;

@WebServlet(name = "ArticleController", value = "/ArticleController")
public class ArticleController extends HttpServlet {

    public ArticleController(){
        super();
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException {
        String journalName = request.getParameter("journalname");
        String summary = request.getParameter("summary");
        String user = (String) request.getSession().getAttribute("user");
        RequestDispatcher rd = null;

        try {
            DBManager dbManager = new DBManager();

            int journalid = dbManager.checkIfJournalExists(journalName);
            dbManager.addNewArticle(user, journalid, summary);

            response.sendRedirect("main_page.jsp");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException {

        int journalid = Integer.parseInt(request.getParameter("journalid"));
        String user = (String) request.getSession().getAttribute("user");
        RequestDispatcher rd = null;

        try {

            DBManager dbManager = new DBManager();
            List<Article> articles = dbManager.fetchArticles(user, journalid);
            request.getSession().setAttribute("articles", articles);
            response.sendRedirect("main_page.jsp");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

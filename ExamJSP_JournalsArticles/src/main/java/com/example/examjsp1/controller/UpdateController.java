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

@WebServlet(name = "UpdateController", value = "/UpdateController")
public class UpdateController extends HttpServlet {

    public UpdateController(){
        super();
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException {
        String journalName = request.getParameter("journalname");
        String summary = request.getParameter("summary");
        int articleId = Integer.parseInt(request.getParameter("id"));
        String user = (String) request.getSession().getAttribute("user");

        RequestDispatcher rd = null;

        try {
            DBManager dbManager = new DBManager();

            int journalid = dbManager.checkIfJournalExists(journalName);
            dbManager.updateArticle(articleId, user, journalid, summary);

            response.sendRedirect("main_page.jsp");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

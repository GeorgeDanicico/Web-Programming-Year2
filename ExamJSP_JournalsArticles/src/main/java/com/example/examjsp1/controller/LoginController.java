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

@WebServlet(name = "LoginController", value = "/LoginController")
public class LoginController extends HttpServlet {

    public LoginController(){
        super();
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException {
        String user = request.getParameter("user");
        RequestDispatcher rd = null;

        HttpSession session = request.getSession();
        session.setAttribute("user",user);
        //rd = request.getRequestDispatcher("/index.jsp");
        try {

            DBManager dbManager = new DBManager();
            List<Article> otherArticle = dbManager.fetchOtherArticles(user);
            session.setAttribute("otherArticles", otherArticle);
            response.sendRedirect("main_page.jsp");
        } catch (IOException e) {
            e.printStackTrace();
        }


    }
}

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
import java.io.PrintWriter;
import java.util.List;

@WebServlet(name = "NotificationController", value = "/NotificationController")
public class NotificationController extends HttpServlet {

    public NotificationController(){
        super();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException {
        DBManager dbManager = new DBManager();
        String user = (String) request.getSession().getAttribute("user");

        try {
            PrintWriter out = response.getWriter();

            List<Article> newList = dbManager.fetchOtherArticles(user);
            List<Article> oldList = ((List<Article>) request.getSession().getAttribute("otherArticles"));
            System.out.println(newList.size() + ", "+  oldList.size());
            if (newList.size() != oldList.size()) {
                request.getSession().setAttribute("otherArticles", newList);
                String updates = "";
                for(Article a : newList) {
                    if (!oldList.contains(a)) {
                        updates += a + " // ";
                    }
                }
                System.out.println(updates);
                request.getSession().setAttribute("Alert", updates);
            } else {
                request.getSession().setAttribute("Alert", "noalert");
            }

            response.sendRedirect("main_page.jsp");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

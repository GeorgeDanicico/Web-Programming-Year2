package com.example.examjsp_teamplayers.controller;

import com.example.examjsp_teamplayers.model.DBManager;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.util.List;

@WebServlet(name = "PlayerController", value = "/PlayerController")
public class PlayerController extends HttpServlet {

    public PlayerController(){
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
            response.sendRedirect("main_page.jsp");
        } catch (IOException e) {
            e.printStackTrace();
        }


    }
}

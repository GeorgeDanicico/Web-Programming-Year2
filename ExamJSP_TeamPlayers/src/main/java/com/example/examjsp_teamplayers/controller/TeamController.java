package com.example.examjsp_teamplayers.controller;

import com.example.examjsp_teamplayers.domain.Player;
import com.example.examjsp_teamplayers.domain.Team;
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

@WebServlet(name = "TeamController", value = "/TeamController")
public class TeamController extends HttpServlet {

    public TeamController(){
        super();
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException {
        String playerName = request.getParameter("playerName");
        String teamNames = request.getParameter("teamNames");
        String user = (String) request.getSession().getAttribute("user");
        RequestDispatcher rd = null;

        String[] teams = teamNames.split(";");
        HttpSession session = request.getSession();
        //rd = request.getRequestDispatcher("/index.jsp");

        try {
            DBManager dbManager = new DBManager();
            Player p = dbManager.getPlayer(playerName);
            for (String teamName : teams) {
                if (p != null) {
                    dbManager.addNewPlayer(p, teamName);
                }
            }
            List<Team> allTeams = dbManager.fetchAllTeams();
            List<Team> userTeams = dbManager.fetchUserTeams(user);
            request.getSession().setAttribute("allTeams", allTeams);
            request.getSession().setAttribute("userTeams", userTeams);
            response.sendRedirect("main_page.jsp");
        } catch (IOException e) {
            e.printStackTrace();
        }


    }
}

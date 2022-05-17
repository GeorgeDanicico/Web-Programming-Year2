package web.assignment8.controller;

import web.assignment8.domain.Grid;
import web.assignment8.domain.Point;
import web.assignment8.domain.User;
import web.assignment8.model.DBManager;
import javax.servlet.*;
import javax.servlet.http.*;
import org.json.JSONArray;
import org.json.JSONObject;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class MainPageController extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBManager dbManager = new DBManager();

        int userId = ((User) request.getSession().getAttribute("user")).getId();
        int enemyUserId = dbManager.getEnemyUserId(userId);

        List<Point> myBattleships = dbManager.getUserBattleships(userId);
        List<Point> enemyBattleships = dbManager.getUserBattleships(enemyUserId);

        Grid grid = new Grid();
        Grid enemyGrid = new Grid(true);

        grid.setBattleships(myBattleships);
        enemyGrid.setBattleships(enemyBattleships);

        request.getSession().setAttribute("grid", grid);
        request.getSession().setAttribute("enemyGrid", enemyGrid);


        response.sendRedirect("main_page.jsp");
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
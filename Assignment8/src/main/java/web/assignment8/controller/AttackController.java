package web.assignment8.controller;

import web.assignment8.domain.Grid;
import web.assignment8.domain.User;
import web.assignment8.model.DBManager;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class AttackController extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String row = request.getParameter("row");
        String column = request.getParameter("column");
        int userId = ((User) request.getSession().getAttribute("user")).getId();

        int r = Integer.parseInt(row);
        int c = Integer.parseInt(column);


        DBManager dbManager = new DBManager();
        dbManager.addAttack(userId, r, c);

        Grid myGrid = (Grid) request.getSession().getAttribute("grid");
        Grid enemyGrid = (Grid) request.getSession().getAttribute("enemyGrid");

        myGrid.attack(enemyGrid, r, c);

        request.getSession().setAttribute("grid", myGrid);
        request.getSession().setAttribute("enemyGrid", enemyGrid);

        if (enemyGrid.areShipsDestroyed()) {
            request.getSession().setAttribute("won", true);
        }

        response.sendRedirect("main_page.jsp");
    }
}

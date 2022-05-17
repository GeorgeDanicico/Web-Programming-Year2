package web.assignment8.controller;

import web.assignment8.domain.Grid;
import web.assignment8.domain.Point;
import web.assignment8.domain.User;
import web.assignment8.model.DBManager;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.List;

public class ReceiveAttackController extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBManager dbManager = new DBManager();
        int userId = ((User) request.getSession().getAttribute("user")).getId();
        Grid myGrid = (Grid) request.getSession().getAttribute("grid");

        int enemyUserId = dbManager.getEnemyUserId(userId);

        List<Point> points = dbManager.getEnemyAttacks(enemyUserId);
        points.forEach(point -> myGrid.receiveAttack(point.getX(), point.getY()));

        if (myGrid.areShipsDestroyed()) {
            request.getSession().setAttribute("lose", true);
        }

        response.sendRedirect("main_page.jsp");
    }
}

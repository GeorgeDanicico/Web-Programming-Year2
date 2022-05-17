package web.assignment8.controller;

import web.assignment8.model.DBManager;
import javax.servlet.*;
import javax.servlet.http.*;
import org.json.JSONArray;
import org.json.JSONObject;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class BattleshipController extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        System.out.println(request.getSession().getAttribute("user"));
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
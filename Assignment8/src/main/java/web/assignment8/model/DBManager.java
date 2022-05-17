package web.assignment8.model;

import web.assignment8.domain.Point;
import web.assignment8.domain.User;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class DBManager {
    private Statement stmt;
    private static Connection connection;

    public DBManager() {
        connect();
    }

    public static void connect() {
        if(connection == null) {
            String url = "jdbc:mysql://localhost:3306/battleships";
            try{
                Class.forName( "com.mysql.jdbc.Driver" );
                connection = DriverManager.getConnection( url, "root", "" );
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    public static Connection getConnection() {
        if(connection == null)
            connect();
        return connection;
    }

    public User authenticate(String username, String password) {
        User u = null;
        try {
            String sql = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();
            if (rs.next()) {
                u = new User(rs.getInt("id"), rs.getString("username"), rs.getString("password"));
            }
            rs.close();
            connection = null;

        } catch(SQLException e) {
            e.printStackTrace();
        }
        return u;
    }

    public void deleteUserFromSession(int userId) {
        try {
            String sql = "DELETE FROM session WHERE user_id=" + userId;

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            stmt.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void addUserToSession(int id, int userId) {
        try {
            String sql = "INSERT INTO session VALUES (" + id + ", " + userId + ")";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            stmt.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void addAttack(int userId, int row, int column) {
        try {
            String sql = "INSERT INTO attacks(userId, pos_x, pos_y) VALUES (" + userId + ", " + row + ", " + column + ")";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            stmt.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public List<Point> getEnemyAttacks(int userId) {
        try {
            String sql = "SELECT * FROM attacks where userId =" + userId;

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();

            List<Point> enemyAttacks = new ArrayList<>();

            while (rs.next()) {
                int x = rs.getInt(3);
                int y = rs.getInt(4);

                Point p = new Point(x, y);
                enemyAttacks.add(p);
            }

            rs.close();
            connection = null;

            return enemyAttacks;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public int getEnemyUserId(int userId) {
        try {
            String sql = "SELECT user_id FROM session where user_id <>" + userId;

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();
            int value = 0;
            if (rs.next())
                value = rs.getInt(1);
            rs.close();
            connection = null;

            return value;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return 0;
    }

    public int getSessionCount() {
        try {
            String sql = "SELECT COUNT(*) FROM session";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();
            int value = 0;
            if (rs.next())
                value = rs.getInt(1);
            rs.close();
            connection = null;

            return value;
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return 0;
    }



}

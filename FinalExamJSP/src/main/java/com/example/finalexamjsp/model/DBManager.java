package com.example.finalexamjsp.model;

import java.util.Date;
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
            String url = "jdbc:mysql://localhost:3306/exam";
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

//    public List<Article> fetchOtherArticles(String user) {
//        try {
//            String sql = "SELECT Distinct * FROM articles where user <>'" + user + "'";
//
//            PreparedStatement stmt = getConnection().prepareStatement(sql);
//            ResultSet rs = stmt.executeQuery();
//
//            List<Article> articles = new ArrayList<>();
//
//
//            while (rs.next()) {
//                int id = rs.getInt(1);
//                String artUser = rs.getString(2);
//                int jid = rs.getInt(3);
//                String summary = rs.getString(4);
//                Date date = rs.getDate(5);
//
//                Article article = new Article(id, artUser, jid, summary, date);
//                articles.add(article);
//            }
//
//            rs.close();
//            connection = null;
//
//            return articles;
//        } catch (SQLException e) {
//            e.printStackTrace();
//        }
//        return null;
//    }

//    public List<Article> fetchArticles(String user, int journalid) {
//        try {
//            String sql = "SELECT Distinct * FROM articles where user ='" + user + "' and journalid =" + journalid;
//
//            PreparedStatement stmt = getConnection().prepareStatement(sql);
//            ResultSet rs = stmt.executeQuery();
//
//            List<Article> articles = new ArrayList<>();
//
//
//            while (rs.next()) {
//                int id = rs.getInt(1);
//                String artUser = rs.getString(2);
//                int jid = rs.getInt(3);
//                String summary = rs.getString(4);
//                Date date = rs.getDate(5);
//
//                Article article = new Article(id, artUser, jid, summary, date);
//                articles.add(article);
//            }
//
//            rs.close();
//            connection = null;
//
//            return articles;
//        } catch (SQLException e) {
//            e.printStackTrace();
//        }
//        return null;
//    }

//    public int checkIfJournalExists(String journalName) {
//        try {
//
//            String sql = "SELECT *  FROM journals where name='" + journalName + "'";
//
//            PreparedStatement stmt = getConnection().prepareStatement(sql);
//            ResultSet rs = stmt.executeQuery();
//            if (rs.next()) {
//                return rs.getInt(1);
//            } else {
//                int newId= this.getNextJournal();
//
//                String sql1 = "INSERT INTO journals (id, name) values (" + newId + ", '" + journalName + "')";
//
//                PreparedStatement stmt1 = getConnection().prepareStatement(sql1);
//                stmt1.executeUpdate();
//
//                return newId;
//            }
//
//        } catch (SQLException e) {
//            e.printStackTrace();
//        }
//        return 1;
//    }

//    public void addNewArticle(String user, int journalid, String summary) {
//        int articleId = getNextArticleId();
//        Date date = new Date();
//        java.sql.Date sqlDate = new java.sql.Date(date.getTime());
//        System.out.println(sqlDate);
//        try {
//            String sql = "INSERT INTO articles (id, user, journalid, summary, date) values (" +
//                    + articleId + ", '" + user + "', " + journalid + ", '" + summary + "', '" +
//                    sqlDate + "')";
//
//            PreparedStatement stmt = getConnection().prepareStatement(sql);
//            stmt.executeUpdate();
//
//        } catch (SQLException e) {
//            e.printStackTrace();
//        }
//    }


//    public void updateArticle(int articleId, String user, int journalid, String summary) {
//        Date date = new Date();
//        java.sql.Date sqlDate = new java.sql.Date(date.getTime());
//        System.out.println(sqlDate);
//        try {
//            String sql = "update articles set user='" + user + "', journalid=" + journalid + ", summary='" + summary + "', date='" +
//                    sqlDate + "' where id=" + articleId;
//
//            PreparedStatement stmt = getConnection().prepareStatement(sql);
//            stmt.executeUpdate();
//
//        } catch (SQLException e) {
//            e.printStackTrace();
//        }
//    }
}
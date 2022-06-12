package com.example.examjsp_teamplayers.model;

import com.example.examjsp_teamplayers.domain.Player;
import com.example.examjsp_teamplayers.domain.Team;

import java.util.Date;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

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

    public List<Team> fetchAllTeams() {
        try {
            String sql = "SELECT Distinct * FROM teams";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();

            List<Team> teams = new ArrayList<>();

            while (rs.next()) {
                int id = rs.getInt(1);
                Integer captainId = rs.getInt(2);
                String name = rs.getString(3);
                String description = rs.getString(4);
                String members = rs.getString(5);

                List<Player> teamMembers = new ArrayList<>();
                String[] splitMembers = members.split("/");

                for (String member : splitMembers) {
                    String[] splitMember = member.split(";");
                    int memberId = Integer.parseInt(splitMember[0]);
                    String memberName = splitMember[1];
                    int age = Integer.parseInt(splitMember[2]);

                    Player player = new Player(memberId, memberName, age);
                    teamMembers.add(player);
                }

                Team team = new Team(id, captainId, name, description, teamMembers);
                teams.add(team);
            }

            rs.close();
            connection = null;

            return teams;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public Player getPlayer(String user) {
        try {
            String sql = "SELECT * FROM players where name='" + user + "'";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();
            int id = 0;
            int age = 0;
            String name = user;
            if (rs.next()) {
                id = rs.getInt(1);
                age = rs.getInt(3);
            }
            Player player = new Player(id, user, age);


            rs.close();
            connection = null;

            return player;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public List<Team> fetchUserTeams(String user) {
        List <Team> teams = fetchAllTeams();
        Player p = this.getPlayer(user);

        List<Team> filteredteams = teams.stream().filter(team -> {
            List<Player> players = team.getMembers();
            return players.contains(p);
        }).collect(Collectors.toList());

        return filteredteams;
    }

    private int getNextTeamId() {
        try {
            String sql = "SELECT MAX(id) as max_id FROM teams";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();
            int id = 0;
            if (rs.next()) {
                id = 1 + rs.getInt("max_id");
            }

            rs.close();
            connection = null;

            return id;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return 1;
    }

    public int checkIfTeamExists(String teamName, String playerName) {
        try {

            String sql = "SELECT *  FROM teams where name='" + teamName + "'";

            PreparedStatement stmt = getConnection().prepareStatement(sql);
            ResultSet rs = stmt.executeQuery();
            if (rs.next()) {
                String members = rs.getString(5);
                if (members.contains(";" + playerName + ";"))
                    return -1;

                return rs.getInt(1);
            } else {
                int newId= this.getNextTeamId();

                String sql1 = "INSERT INTO teams (id, name) values (" + newId + ", '" + teamName + "')";

                PreparedStatement stmt1 = getConnection().prepareStatement(sql1);
                stmt1.executeUpdate();

                return newId;
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }
        return 1;
    }


    public void addNewPlayer(Player player, String teamName) {
        int teamId = checkIfTeamExists(teamName, player.getName());

        if (teamId != -1) {
            try {

                String sql = "SELECT *  FROM teams where name='" + teamName + "'";

                PreparedStatement stmt = getConnection().prepareStatement(sql);
                ResultSet rs = stmt.executeQuery();
                if (rs.next()) {
                    String members = rs.getString(5);
                    if (members == null)
                        members = player.getId() + ";" + player.getName() + ";" + player.getAge();
                    else
                        members = members + "/" + player.getId() + ";" + player.getName() + ";" + player.getAge();
                    String sql1 = "update teams set members='" + members + "' where id=" + teamId;

                    PreparedStatement stmt1 = getConnection().prepareStatement(sql1);
                    stmt1.executeUpdate();
                }

            } catch (SQLException e) {
                e.printStackTrace();
            }
        }


    }
}

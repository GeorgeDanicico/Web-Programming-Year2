package com.example.examjsp_teamplayers.domain;

import java.util.List;

public class Team {
    private int id;
    private int captainId;
    private String name;

    public Team(int id, int captainId, String name, String description, List<Player> members) {
        this.id = id;
        this.captainId = captainId;
        this.name = name;
        this.description = description;
        this.members = members;
    }

    private String description;
    private List<Player> members;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getCaptainId() {
        return captainId;
    }

    public void setCaptainId(int captainId) {
        this.captainId = captainId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public List<Player> getMembers() {
        return members;
    }

    public void setMembers(List<Player> members) {
        this.members = members;
    }
}

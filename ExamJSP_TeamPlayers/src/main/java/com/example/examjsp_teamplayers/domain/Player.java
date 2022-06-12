package com.example.examjsp_teamplayers.domain;

public class Player {
    private int id;
    private String name;
    private int age;


    public Player(int id, String name, int age) {
        this.id = id;
        this.name = name;
        this.age = age;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public boolean equals(Object o) {
        if (!(o instanceof Player)) return false;

        Player tp = (Player) o;
        return this.getId() == (tp.getId());
    }
}

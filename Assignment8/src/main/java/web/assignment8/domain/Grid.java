package web.assignment8.domain;

import java.util.ArrayList;
import java.util.List;

public class Grid {
    private int[][] map;
    private boolean isEnemy;
    private int hitCount;

    public Grid() {
        this.map = new int[10][10];
        this.isEnemy = false;
        hitCount = 0;
    }

    public Grid(boolean _isEnemy) {
        this.map = new int[10][10];
        this.isEnemy = true;
        hitCount = 0;
    }

    public void setBattleships(List<Point> battleships) {
        battleships.forEach((point) ->
                this.map[point.getX()][point.getY()] = 1);
    }

    public boolean hit(int x, int y) {
        return this.map[x][y] == 1;
    }

    public void attack(Grid enemyGrid, int x, int y) {
        enemyGrid.receiveAttack(x, y);
    }

    public String getMap() {
        String result = "";

        for (int[] row : map) {
            for (int value : row) {
                if (value == 1 && isEnemy) result += '0';
                else result += value;


                result += " ";
            }
            result += '\n';
        }

        return result;
    }

    public boolean receiveAttack(int x, int y) {
        Point p = new Point(x, y);

        if (this.map[x][y] == 1) {
            this.hitCount ++;
            this.map[x][y] = 3;
            return true;
        }
        if (this.map[x][y] != 3)
            this.map[x][y] = 2;
        return false;
    }

    public boolean areShipsDestroyed() {
        return this.hitCount == 8;
    }

}

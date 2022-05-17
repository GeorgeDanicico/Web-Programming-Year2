package web.assignment8.domain;

import java.util.ArrayList;
import java.util.List;

public class Grid {
    private int[][] map;
    private Battleship b1;
    private Battleship b2;

    public Grid() {
        this.map = new int[10][10];
        b1 = new Battleship();
        b2 = new Battleship();
        this.generateBattleship();
    }

    private void generateBattleship() {
        List<Point> positions = new ArrayList<>();

        for(int i = 0; i < 4; i++) {
            Point p = new Point(0, i);
            positions.add(p);
            this.map[0][i] = 1;
        }
        b1.setBattleshipPosition(positions);

        List<Point> positions1 = new ArrayList<>();

        for(int i = 0; i < 4; i++) {
            Point p = new Point(3, i+4);
            positions1.add(p);
            this.map[3][i+4] = 1;
        }
        b2.setBattleshipPosition(positions1);
    }

    public String getMap() {
        String result = "";

        for (int[] row : map) {
            for (int value : row) {
                result += value + " ";
            }
            result += '\n';
        }

        return result;
    }

    public boolean receiveAttack(int x, int y) {
        Point p = new Point(x, y);

        if (b1.hitPosition(p)) {
            this.map[x][y] = 3;
            return true;
        }

        if (b2.hitPosition(p)) {
            this.map[x][y] = 3;
            return true;
        }

        this.map[x][y] = 2;
        return false;
    }

    public boolean areShipsDestroyed() {
        return b1.checkIfShipIsDestroyed() && b2.checkIfShipIsDestroyed();
    }

}

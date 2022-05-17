package web.assignment8.domain;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Battleship {
    private List<Point> positions;
    private List<Point> hit_positions;

    public Battleship() {
        this.positions = new ArrayList<>();
        this.hit_positions = new ArrayList<>();
    }

    public List<Point> getBattleshipPosition() {
        return this.positions;
    }

    public List<Point> getHitPosition() {
        return this.hit_positions;
    }

    public void setBattleshipPosition(List<Point> new_positions) {
        this.positions = new_positions;
    }

    public boolean checkIfShipIsDestroyed() {
        System.out.println(hit_positions.size() + ", " + positions.size());
        return hit_positions.size() == positions.size();
    }

    public boolean hitPosition(Point point) {
        List<Point> list = positions.stream().filter((p) -> p.getX() == point.getX() & p.getY() == point.getY()).collect(Collectors.toList());

        if (list.size() == 1) {
            hit_positions.add(point);
            return true;
        }

        return false;
    }
}

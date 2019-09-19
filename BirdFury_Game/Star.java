
import java.awt.Color;

public class Star {
	private static final int SLOW = -1;
	private static final int MEDIUM = -3;
	private static final int FAST = -5;
	double velocity;
	Location location;
	private Color type;

	public Star(Location loc, GameModel field) {
		int starColor = (int) (Math.random() * 7.0D);
		if (starColor <= 3) {
			this.type = Color.WHITE;
		} else if (starColor == 4) {
			this.type = Color.BLUE;
		} else if (starColor == 5) {
			this.type = Color.YELLOW;
		} else if (starColor == 6) {
			this.type = Color.RED;
		}

		int speedID = (int) (Math.random() * 3.0D);
		if (speedID == 0) {
			this.velocity = -1.0D;
		} else if (speedID == 1) {
			this.velocity = -3.0D;
		} else if (speedID == 2) {
			this.velocity = -5.0D;
		}

		this.location = loc;
	}

	public void act() {
		this.location.setLocation((int) ((double) this.location.getX() + this.velocity), this.location.getY());
	}

	public Location getLocation() {
		return this.location;
	}

	public Color getColor() {
		return this.type;
	}
}
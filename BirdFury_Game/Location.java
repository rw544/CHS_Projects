
public class Location {
	private int xPos;
	private int yPos;

	public Location(int xPos, int yPos) {
		this.xPos = xPos;
		this.yPos = yPos;
	}

	public int getX() {
		return this.xPos;
	}

	public int getY() {
		return this.yPos;
	}

	public void setLocation(int x, int y) {
		this.xPos = x;
		this.yPos = y;
	}

	public boolean equals(Object other) {
		Location loc = (Location) other;
		return loc.getX() == this.xPos && loc.getY() == this.yPos;
	}
}
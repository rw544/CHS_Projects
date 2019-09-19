//This class checks for collision

public class ScoreArea {
	private Location loc;
	private int x;
	private int y;


	public ScoreArea(Location location, int width, int height) {
		this.loc = location;
		this.x = width - 1;
		this.y = height - 1;
	}

	public void changeLocation(int x, int y) {
		this.loc.setLocation(x, y);
	}

	public int getWidth() {
		return this.x;
	}

	public int getHeight() {
		return this.y;
	}

  //passing another ScoreArea (other) to this class and check if other scorearea's x and y location collides with the current scorearea object
   //for e.g. if this is a bird scorearea object, and if other is a bullet, it checks if bullet score area collided with the bird and returns
   //true or false
	public boolean checkCollision(ScoreArea other) {
		return this.betweenX(other) && this.betweenY(other);
	}

 	private boolean betweenX(ScoreArea other) {
		int xMin = this.loc.getX();
		int xMax = this.loc.getX() + this.getWidth();
		int oxMin = other.loc.getX();
		int oxMax = other.loc.getX() + other.getWidth();
		return (xMin <= oxMin || xMin >= oxMax) && (xMax <= oxMin || xMax >= oxMax)
				? oxMin > xMin && oxMin < xMax || oxMax > xMin && oxMax < xMax : true;
	}

	private boolean betweenY(ScoreArea other) {
		int yMin = this.loc.getY();
		int yMax = this.loc.getY() + this.getHeight();
		int oyMin = other.loc.getY();
		int oyMax = other.loc.getY() + other.getHeight();
		return (yMin <= oyMin || yMin >= oyMax) && (yMax <= oyMin || yMax >= oyMax)
				? oyMin > yMin && oyMin < yMax || oyMax > yMin && oyMax < yMax : true;
	}
}
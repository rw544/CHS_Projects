
import java.awt.Image;
import javax.swing.ImageIcon;


public class GameCharacter {
	private Location location;
	private double xSpeed;
	private double ySpeed;
	private GameModel gameModel;
	private ScoreArea hitbox;
	private Image img;

	public GameCharacter() {
	}

	public GameCharacter(Location loc, int xVel, int yVel, GameModel model, int width, int height) {
		this.location = loc;
		this.xSpeed = (double) xVel;
		this.ySpeed = (double) yVel;
		this.gameModel = model;
		this.hitbox = new ScoreArea(loc, width, height);
	}

	public void act() {
		this.move();

	}

	public void move() {
		double xVal = (double) this.location.getX();
		double yVal = (double) this.location.getY();
		xVal += this.xSpeed;
		yVal += this.ySpeed;
		this.location.setLocation((int) xVal, (int) yVal);
		this.hitbox.changeLocation((int) xVal, (int) yVal);
	}

	public void shoot() {
		Location loc = this.getLocation();
		BirdShoot b = new BirdShoot(new Location(loc.getX() - 1, loc.getY() + this.hitbox.getHeight() / 2), false);
		this.getGameModel().addToModel(b);
	}

	public void setLocation(Location loc) {
		this.location = loc;
	}

	public Location getLocation() {
		return this.location;
	}

	public void changeVelocity() {
	}


	public void setXVel(double velocity) {
		this.xSpeed = velocity;
	}

	public double getXVel() {
		return this.xSpeed;
	}

	public void setYVel(double velocity) {
		this.ySpeed = velocity;
	}

	public double getYVel() {
		return this.ySpeed;
	}


	public void setGameModel(GameModel gameModel) {
		this.gameModel = gameModel;
	}

	public GameModel getGameModel() {
		return this.gameModel;
	}

	public void setHitbox(ScoreArea h) {
		this.hitbox = h;
	}

	public ScoreArea getHitBox() {
		return this.hitbox;
	}

	public void setImg(String path) {
		this.img = (new ImageIcon(this.getClass().getClassLoader().getResource(path))).getImage();
	}

	public Image getImg() {
		return this.img;
	}

	public int getScore() {
		return 50;
	}
}
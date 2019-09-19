
public class Shooter2 extends GameCharacter {
	private int timer;

	public Shooter2(Location loc, GameModel gameModel) {
		super(loc, -15, 5, gameModel, 31, 32);
      this.setImg("1archer2.gif");
		this.timer = 60;
	}

	public void act() {
		if (this.getXVel() < 0.0D) {
			this.setXVel(this.getXVel() + 0.7D);
			this.timer = 60;
		}

		if (this.getLocation().getY() >= 536 || this.getLocation().getY() <= 64) {
			this.changeVelocity();
		}

		this.move();
		if (this.timer == 0) {
			this.shoot();
			this.timer = 60;
		} else {
			--this.timer;
		}

	}

	public void changeVelocity() {
		if (this.getLocation().getY() >= 536) {
			this.setYVel(-5.0D);
		} else if (this.getLocation().getY() <= 64) {
			this.setYVel(5.0D);
		}

	}

	public int getScore() {
		return 75;
	}
}
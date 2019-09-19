
public class Shooter extends GameCharacter {
	private int timer;

	public Shooter(Location loc, GameModel gameModel) {
		super(loc, -15, 0, gameModel, 62, 44);
      this.setImg("shooter.gif");
		this.timer = 60;
	}

	public void act() {
		this.move();
		if (this.getXVel() < 0.0D) {
			this.setXVel(this.getXVel() + 0.7D);
			this.timer = 60;
		}

		--this.timer;
		if (this.timer <= 0) {
			this.shoot();
			this.timer = 60;
		}

	}

	public int getScore() {
		return 25;
	}
}
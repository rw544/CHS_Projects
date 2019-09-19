

public class BirdShoot extends GameCharacter {

	public BirdShoot(Location loc, boolean firedByBird) {
		this.setHitbox(new ScoreArea(loc, 10, 8));
		this.setLocation(loc);
		if (firedByBird) {
			this.setXVel(10.0D);
			this.setImg("bullet.png");
		} else {
			this.setXVel(-10.0D);
			this.setImg("enemy_bullet.png");
		}

	}

	public void act() {
		this.move();
	}
}
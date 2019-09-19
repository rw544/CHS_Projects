
public class ShootingBall extends GameCharacter {


	public ShootingBall(Location loc, GameModel gameModel) {
		super(loc, 0, 0, gameModel, 50, 32);
      this.setImg("ball2.png");
	}

	public void act() {
		//this.setXVel(this.getXVel() + -0.5D);
      this.setXVel(this.getXVel() + -0.3D);
		this.move();
	}

	public int getScore() {
		return 100;
	}
}
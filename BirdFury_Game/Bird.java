
public class Bird extends GameCharacter {

	public Bird(Location loc, int xVel, int yVel, GameModel model) {
		super(loc, xVel, yVel, model, 64, 44);
		this.setImg("player.png");
      //this.setImg("player.gif");

   }

	public void act() {
		if (this.getXVel() > 0.0D) {
		  this.setXVel(this.getXVel() - 2.0D);
		} else {
			this.setYVel(this.getYVel() + 0.8D);
			if (this.getLocation().getY() <= 44) {
				this.setLocation(new Location(this.getLocation().getX(), this.getHitBox().getHeight() + 1));
				this.setYVel(1.0D);
			}
		}
    
		this.move();
	}

	public void bounce() {
      //set bird to jump up (-15)
		this.setYVel(-15.0D);
	}

	public void shoot() {
		Location loc = this.getLocation();
      //loads BirdShoot object at current bird location
		BirdShoot b = new BirdShoot(new Location(loc.getX() + 64, loc.getY() + 22), true);
		this.getGameModel().addBirdShootToModel(b);
	}
}
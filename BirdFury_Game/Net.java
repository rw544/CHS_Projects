
public class Net extends GameCharacter {

	public Net(Location loc, GameModel gameModel) {
   
      //54, 52 is width and height of the object used that as a boundary for collision.
		super(loc, (int) (-(5.0D + Math.random() * 5.0D)), (int) (-2.0D + Math.random() * 5.0D), gameModel, 54, 52);
     	this.setImg("net.png");
	}

	public void act() {
		this.move();
	}
}
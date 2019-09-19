
public class Eagle extends GameCharacter {

	public Eagle(Location loc, GameModel gameModel) {
		super(loc, -10, 0, gameModel, 54, 60);
      this.setImg("eagle.gif");
	}

	public void act() {
		this.move();
	}

	public int getScore() {
		return 50;
	}
}
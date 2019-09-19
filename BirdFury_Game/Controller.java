
import java.util.ArrayList;


//This is a Controller class which is a bridge between BirdView and GameModel
//Any request from user from BirdView routed to Controller and Controller passes that request to GameModel
//and updated character information including its location which is refreshed from GameModel back on to screen via Controller to BirdView

public class Controller {
	private BirdView birdView;
	private GameModel gameModel;
	private boolean inPlayMode = false;

	//setter method of BirdBiew object
	public void setView(BirdView birdView) {
		this.birdView = birdView;
	}

	//BirdView getter method
	public BirdView getView() {
		return this.birdView;
	}

	//refresh View or screen
	public void updateView() {
		this.birdView.repaint();
	}

	//initializes GameModel class. This is the game starting point. This method is called when user clicks 'Start Game' button
	public void initModel() {
   
      //allows a particular component gains the focus the first time a window is activated, 
		this.birdView.requestFocusInWindow();
		this.gameModel = new GameModel(this); //passes this controller object to GameModel as a reference;
		this.inPlayMode = true; //indicates you are in a play mode
	}

	//on game over, the methods gets score and call displayGameOver method of BirdView which shows
	//and refreshes score on screen
   //This method is called from GameModel's CheckHit method which checks if Bird is collided with shooter's bullet or an eagle
	public void onGameOver() {
		this.inPlayMode = false; //no longer in play mode. Bird is shot down
		int score = this.gameModel.getScore();
		int objectDestroyed = this.gameModel.getObjectsDestroyed();
		this.birdView.displayGameOver(score, objectDestroyed);
	}

	//Calls step method of gameModel which steps through each characters and act on each character by calling
	//act method of each character which basically moves each object or perform action.
	public void step() {
		this.gameModel.step();
	}
	//gets list of all characgters
	public ArrayList<GameCharacter> getCharacterList() {
		return this.gameModel.getGameCharacters();
	}

	//gets BirdShoot objects
	public ArrayList<BirdShoot> getBirdShootList() {
		return this.gameModel.getPlayerBullets();
	}
  

	public ArrayList<Boom> getBoomList() {
		return this.gameModel.getExplosions();
	}

   
   //when user presses up button, this method is called from BirdView class
	public void onPressUp() {
      //calls bounce() method of Bird object returned by gameModel
		this.gameModel.getBird().bounce();
	}

   //when user presses spacebar, this method is called from BirdView class
	public void onPressSpace() {
      //calls shoot() method of Bird object returned by gameModel
		this.gameModel.getBird().shoot();
	}

   //checks if user is alive and in play mode
	public boolean isInPlay() {
		return this.inPlayMode;
	}

   //returns GameModel object
	public GameModel getGameModel() {
		return this.gameModel;
	}
}
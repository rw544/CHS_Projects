
import java.util.ArrayList;
import java.util.Iterator;


public class GameModel {
	private ArrayList<GameCharacter> gameCharacters;
	private ArrayList<BirdShoot> birdShoots;
	private ArrayList<Boom> booms;
	private Bird bird;
	private int score;
	private int objectsDestroyed;
	private int shotsFired;
	private int time;
	private Controller control;
	private int loadRate;

   //Loads game characters randomly and checkes if bird is collided or hit by shooter's bullet or an eagle
   //This class is managed via Controller class and provides game characters details back to Controller
	public GameModel(Controller controller) {
		this.control = controller;
		this.gameCharacters = new ArrayList();
		this.birdShoots = new ArrayList();
		this.booms = new ArrayList();
		this.bird = new Bird(new Location(-40, 300), 16, 0, this);
		this.addToModel(this.bird);
		this.loadRate = 60;
	}
   
   //This method call's act() method of each characters that are loaded and increments x,y position via its super class (GameCharacter) move() method
	public void step() {
		int i;
      
      //loops through arraylist of game characters and calls its act() method
		for (i = 0; i < this.gameCharacters.size(); ++i) {
			((GameCharacter) this.gameCharacters.get(i)).act();
		}

      //loops through arraylist of shoot and calls its act() method
		for (i = 0; i < this.birdShoots.size(); ++i) {
			((BirdShoot) this.birdShoots.get(i)).act();
		}

      ////loops through arraylist of booma and calls its act() method
		for (i = 0; i < this.booms.size(); ++i) {
			((Boom) this.booms.get(i)).act();
		}

		this.checkHit(); //checks if bird is collided
		this.removeOutOfBounds(); //removes out of bound characters
		this.removeFinishedBooms(); //removes booms effect once boom animation is completed
		if (this.time % this.loadRate == 0) {
			this.loadRandomCharacter();  //randomly loads characters
		}

      //controls speed when net is thrown at the bird
		if (this.time % 4000 == 0) {
			this.loadCharacter("Net");
		}

		++this.score; //increments score
		++this.time;
		this.increaseLoadRate(); //increases random character load rate as time goes by.
		this.control.updateView(); //refreshes characters on BirdView via Controller
	}

	public void increaseLoadRate() {
		if (this.loadRate > 20 && this.time % 150 == 0) {
			--this.loadRate;
		}

	}

	//checks if shot that bird fires hit the shooters or shooters shots hit bird which causes to game over.
	public void checkHit() {
		int b;
		for (b = 0; b < this.gameCharacters.size(); ++b) {
			for (int explosion = 0; explosion < this.birdShoots.size(); ++explosion) {
				if (!(this.gameCharacters.get(b) instanceof BirdShoot) && ((BirdShoot) this.birdShoots.get(explosion)).getHitBox()
						.checkCollision(((GameCharacter) this.gameCharacters.get(b)).getHitBox())) {
					this.birdShoots.remove(explosion);
					--explosion;
					if (!(this.gameCharacters.get(b) instanceof Net)) {
						Boom boom1 = new Boom(((GameCharacter) this.gameCharacters.get(b)).getLocation(), this);
						this.addBoom(boom1);
						this.score += ((GameCharacter) this.gameCharacters.get(b)).getScore();
						this.gameCharacters.remove(b);
						--b;
						++this.objectsDestroyed;
					}
				}
			}
		}

		for (b = 0; b < this.gameCharacters.size(); ++b) {
			if (this.bird.getHitBox().checkCollision(((GameCharacter) this.gameCharacters.get(b)).getHitBox())) {
				Boom arg3 = new Boom(this.bird.getLocation(), this);
				this.addBoom(arg3);
				this.control.onGameOver(); //if bird is collided by a shooter's bullet or an eagle, then it calls Controller's onGameOver method
			}
		}

	}

	public void addToModel(GameCharacter gameCharacter) {
		this.gameCharacters.add(gameCharacter);
	}

	public void addBirdShootToModel(BirdShoot birdShoot) {
		this.birdShoots.add(birdShoot);
		++this.shotsFired;
	}

	public void addBoom(Boom boom) {
		this.booms.add(boom);
	}

   //once boom effect animation is finished, boom character is removed from screen
	public void removeFinishedBooms() {
		Iterator iter = this.booms.iterator();

		while (iter.hasNext()) {
			if (((Boom) iter.next()).checkDone()) {
				iter.remove();
			}
		}

	}

   //removes character those are out of bound or no longer needed on screen from each character's ArrayList
	public void remove(GameCharacter toRemove) {
		Iterator iter = this.gameCharacters.iterator();

		while (iter.hasNext()) {
			if (iter.next() == toRemove) {
				iter.remove();
			}
		}

	}

   //removes birdshoot that are out of bound
	public void removeBullet(BirdShoot b) {
		Iterator iter = this.birdShoots.iterator();

		while (iter.hasNext()) {
			if (((BirdShoot) iter.next()).equals(b)) {
				iter.remove();
			}
		}

	}

	//Handles screen out of bounds. Any characters that are out of bound from screen, they are removed from an ArrayList of that character
	public void removeOutOfBounds() {
		int x;
		for (x = 0; x < this.gameCharacters.size(); ++x) {
			if (((GameCharacter) this.gameCharacters.get(x)).getLocation().getX() < -60
					|| ((GameCharacter) this.gameCharacters.get(x)).getLocation().getY() > 600) {
				this.gameCharacters.remove(x);
				--x;
			}
		}

		for (x = 0; x < this.birdShoots.size(); ++x) {
			if (((BirdShoot) this.birdShoots.get(x)).getLocation().getX() > 600) {
				this.birdShoots.remove(x);
			}
		}


		if (this.bird.getLocation().getY() > 600) {
			this.remove(this.bird);
			this.control.onGameOver();
		}

	}

	public int getScore() {
		return this.score;
	}

	public int getObjectsDestroyed() {
		return this.objectsDestroyed;
	}

	public int getAngryShotsFired() {
		return this.shotsFired;
	}

	public double getTime() {
		return (double) this.time;
	}

	public ArrayList<GameCharacter> getGameCharacters() {
		return this.gameCharacters;
	}

	public ArrayList<BirdShoot> getPlayerBullets() {
		return this.birdShoots;
	}


	public ArrayList<Boom> getExplosions() {
		return this.booms;
	}

	public Bird getBird() {
		return this.bird;
	}

   //loads characters randomly trying to hit bird
	public void loadRandomCharacter() {
		int id = (int) (Math.random() * 5.0D);
		switch (id) {
		case 0:
			this.loadCharacter("ShootingBall");
			break;
		case 1:
			this.loadCharacter("Net");
			break;
		case 2:
			this.loadCharacter("Shooter");
			break;
		case 3:
			this.loadCharacter("Eagle");
			break;
		case 4:
			this.loadCharacter("Shooter2");
		}

	}

	//randomly loads shooting characters throw at bird to kill it
	public void loadCharacter(String name) {
		Location loadLoc = new Location(680, (int) (Math.random() * 472.0D) + 64);
      switch (name) {
		case "ShootingBall":
			ShootingBall shootingBall = new ShootingBall(loadLoc, this);
			this.addToModel(shootingBall);
			break;
		case "Net":
			Net net = new Net(loadLoc, this);
			this.addToModel(net);
			break;
		case "Shooter":
			Shooter shooter1 = new Shooter(loadLoc, this);
			this.addToModel(shooter1);	
			break;
		case "Eagle":                                             
			Eagle eagle = new Eagle(loadLoc, this);
			this.addToModel(eagle);
			break;
		case "Shooter2":
      	Shooter2 shooter2 = new Shooter2(loadLoc, this);                
			this.addToModel(shooter2);
			
		}

	}

}

import java.awt.Image;
import java.util.ArrayList;
import java.util.Iterator;
import javax.swing.ImageIcon;

public class Boom {
	private Image img;
	private int timer = 0;
	private boolean done = false;
	private ArrayList<String> frameBoomNames = new ArrayList();
	private Iterator<String> iter;
	private Location location;

	public Boom(Location loc, GameModel field) {
   
      //Loads 7 boom images to an array to produce an animation of blast
		for (int i = 1; i <= 7; ++i) {
			this.frameBoomNames.add("boom/boom" + i + ".png");
		}

		this.iter = this.frameBoomNames.iterator();
		this.location = loc;
	}

	public void act() {
         //Loops through the array of images and loads the image via calling setImg method
			if (this.iter.hasNext()) {
				this.setImg((String) this.iter.next());
			} else {
				this.done = true;
			}
	

		++this.timer;
	}

	public Location getLocation() {
		return this.location;
	}

	public void setImg(String path) {
		this.img = (new ImageIcon(this.getClass().getClassLoader().getResource(path))).getImage();
	}

	public Image getImg() {
		return this.img;
	}

	public boolean checkDone() {
		return this.done;
	}
}
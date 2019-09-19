import java.awt.event.KeyEvent;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.awt.image.ImageObserver;
import java.io.PrintStream;
import java.net.URL;
import java.util.Random;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.Timer;

public class StarshipTrooper
extends JFrame {
    Image ship;
    Image asteroid;
    Image background;
    Image missile;
    private final int SCREENSIZE = 1000; //500;
    private int shipX = 75;
    private int shipY = 250;
    private int shipW = 72;
    private int shipH = 22;
    private int gravity = 7;
    private int bh = 120;
    private int bw = 27;
    private int bx = 600;
    private int by = 500;
    private int speed = 6;
    private int[] blockX = new int[10];
    public final int MAX_RECTANGLES = 800;
    private int[] heights = new int[800];
    private int missileX = shipX + 5;
    private int missileY = shipY;
    private int missileW = 30;
    private int missileH = 7;
    private int p = shipX + 10;
    private int score = 0;
    public static final Color col = new Color(255, 255, 255);
    private int bestScore = 0;
    private int missileS = 15;
    private int delay = 10;
    private boolean up;
    private boolean missileLeftFlag;
    private int xcoord;
    private int ycoord;
    private int missileCount = 3;
    Random rand = new Random(10);
    private Rectangle[] recArray = new Rectangle[800];
    private Rectangle missileRect = new Rectangle();
    private boolean gameS = true;
    private boolean resetFlag = false;
  
    
    ActionListener taskPerformer;

    public StarshipTrooper() {
        super("Starship Troopers");
        taskPerformer = new ActionListener(){

            public void actionPerformed(ActionEvent actionEvent) {
                if (collision()) {
                    playAgain();
                    resetGame();
                    resetFlag = false;
                    return;
                }
                if (resetFlag) {
                    resetGame();
                }
                move();
            }
        };
        ClassLoader classLoader = getClass().getClassLoader();
        addKeyListener((KeyListener)new KeyHandler(this));

        ImageIcon imageIcon = new ImageIcon(classLoader.getResource("rsz_blueships1.png"));

        ship = imageIcon.getImage();
        ImageIcon imageIcon2 = new ImageIcon(classLoader.getResource("rsz_asteroid.png"));
        
        asteroid = imageIcon2.getImage();
        ImageIcon imageIcon3 = new ImageIcon(classLoader.getResource("rsz_background.png"));
        background = imageIcon3.getImage();
        ImageIcon imageIcon4 = new ImageIcon(classLoader.getResource("missile.png"));
        missile = imageIcon4.getImage();
        addWindowListener(new WindowAdapter(){

            public void windowClosing(WindowEvent windowEvent) {
                System.exit(0);
            }
        });
        for (int i = 0; i < 800; ++i) {
            heights[i] = (int)(Math.random() * 400.0) + 60;
            xcoord = bx + i * 250;
            ycoord = heights[i];
            recArray[i] = new Rectangle(xcoord, ycoord, bw, bh);
        }
        setSize(500, 500);
        setVisible(true);
    }

    public void paint(Graphics graphics) {
        Image image = createImage(500, 500);
        paintoffscreen(image.getGraphics());
        graphics.drawImage(image, 0, 0, null);
    }

    public void paintoffscreen(Graphics graphics) {
        recArray = new Rectangle[800];
        int n = score;
        graphics.drawImage(background, -20, 30, this);
        for (int i = 0; i < 800; ++i) {
            Rectangle rectangle;
            xcoord = bx + i * 250;
            ycoord = heights[i];
            graphics.drawImage(asteroid, xcoord, ycoord, this);
            recArray[i] = rectangle = new Rectangle(xcoord, ycoord, bw, bh);
        }
        graphics.fillRect(0, 0, 500, 80);
        graphics.fillRect(0, 435, 500, 65);
        if (missileLeftFlag) {
            graphics.drawImage(missile, missileX, missileY, this);
            missileRect = new Rectangle(missileX, missileY, missileW, missileH);
        }
        graphics.drawImage(ship, shipX, shipY, this);
        graphics.setColor(col);
        graphics.drawString("Score: " + score, 20, 470);
        graphics.drawString("Missiles left: " + missileCount, 400, 485);
        graphics.drawString("Best Score: " + bestScore, 20, 485);
    }

    public void move() {
        bx -= speed;
        shipY += gravity;
        int n = 0;
        while (n < blockX.length - 1) {
            int[] arrn = blockX;
            int n2 = n++;
            arrn[n2] = arrn[n2] + speed;
        }
        if (up) {
            shipY -= 14;
        }
        ++score;
        if (missileX == shipX + 5) {
            missileY = shipY;
        }
        if (missileLeftFlag) {
            missileX += missileS;
        }
        if (missileX > 500) {
            missileLeftFlag = false;
            missileX = shipX + 5;
        }
        n = score;
        System.out.println("Score: " + n);
        if (n % 200 == 0) {
            ++missileCount;
            ++speed;
        }
        if (bestScore < score) {
            bestScore = score;
        }
        missileCollision();
        repaint();
    }

   //check if ship is collide
   public boolean collision() {
        Rectangle rectangle = new Rectangle(shipX, shipY, shipW, shipH);
        for (int i = 0; i < 800; ++i) {
            if (shipY <= 85 || shipY >= 412) {
                return true;
            }
            if (!rectangle.intersects(recArray[i])) continue;
            return true;
        }
        return false;
    }

  //check for missile collision
  public void missileCollision() {
        for (int i = 0; i < 800; ++i) {
            if (!missileRect.intersects(recArray[i])) continue;
            System.out.println("missile  collision: " + missileRect + " " + recArray[i]);
            heights[i] = -40;
            missileLeftFlag = false;
            missileX = shipX + 5;
            missileRect = new Rectangle(-200, -200, 1, 1);
        }
    }

    //Shows dialogue box to play again or exit the game
    public void playAgain() {
        int n = JOptionPane.showConfirmDialog(this, "Your score: " + score + "\n" + "Want to Play Again?", "Starship Trooper", 0);
        if (n == 0) {
            resetFlag = true;
        } else {
            System.exit(0);
        }
    }

    //resets game
    public void resetGame() {
        int n;
        shipX = 75;
        shipY = 250;
        speed = 6;
        up = false;
        missileLeftFlag = false;
        missileX = shipX + 5;
        missileY = shipY;
        missileW = 30;
        missileH = 7;
        p = shipX + 10;
        score = 0;
        bx = 600;
        by = 500;
        missileCount = 3;
        for (n = 0; n < 799; ++n) {
            heights[n] = (int)(Math.random() * 400.0) + 60;
        }
        for (n = 0; n < 800; ++n) {
            Rectangle rectangle;
            xcoord = bx + n * 250;
            ycoord = heights[n];
            recArray[n] = rectangle = new Rectangle(xcoord, ycoord, bw, bh);
        }
    }

    //game start
    public static void main(String[] args) {
        StarshipTrooper sShipTrooper = new StarshipTrooper();
        
              //loads background sound before game starts
        Sound sound = new Sound();
        sound.play("gamestart.wav");
        
        sShipTrooper.timing();
    }

    //starts timer
    public void timing() {
        Timer timer = new Timer(delay, taskPerformer);
        timer.start();
    }

    //when up button is pressed
    static  boolean pressUpButton(StarshipTrooper sShipTrooper, boolean bl) {
        Sound sound = new Sound();
        sound.play("jump.wav");

        sShipTrooper.up = bl;
        return sShipTrooper.up;
    }

    //when space button is pressed,fires missile
    static int pressSpaceButton(StarshipTrooper sShipTrooper) {
        return sShipTrooper.missileCount;
    }

    //sets missile flag true when missiles are left, otherwise sets to false
    static boolean setMissileFlag(StarshipTrooper sShipTrooper, boolean bl) {
        sShipTrooper.missileLeftFlag = bl;
        return sShipTrooper.missileLeftFlag;
    }

    //decrease missile count when missile is fired
    static int decreaseBulletCount(StarshipTrooper sShipTrooper) {
        return sShipTrooper.missileCount--;
    }

}
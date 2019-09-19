
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.LayoutManager;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.image.ImageObserver;
import java.util.ArrayList;
import java.util.Iterator;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.Timer;



import java.awt.image.BufferedImage;
import javax.imageio.ImageIO;
import java.io.File;
import java.io.IOException;


//This is a View class which draws backgrounds and menu options for a game user to interact
public class BirdView extends JFrame implements ActionListener, KeyListener, MouseListener  
{
	private Controller control;
	private boolean upButtonPressed;
	private boolean spaceButtontPressed;
	private Sound sound;
	
   //starting position for car. Increments for animation
	int x_Pos;
   int y_Pos = 480; 
   
   int sunX = 550; //starting position for sun x-coordinate
   int sunY = 800;  //starting position for sun y-coordinate
   boolean flag = true; //toggle for windmill


   //constructor taking Controller object as an input
	public BirdView(Controller controller) {
   
		super("Bird Fury"); //Title of frame
		control = controller;

		setBounds(100, 100, 600, 600); 		//sets screen boundary
		setDefaultCloseOperation(3);        //allows closing screen by clicking 'X'
		getContentPane().setLayout((LayoutManager) null); //set screenlayout manager
		getContentPane().setBackground(Color.BLACK);
		setResizable(false);
		
      //adding keyboard and mouse listener
      addKeyListener(this);
      addMouseListener(this);
		
      //Display menu options and registers menu control
      displayMenu();
		setVisible(true);
		
		//Timer class schedules tasks for one-time execution, or for repeated execution at regular define intervals which is in milliseconds.
		Timer timer = new Timer(25, this);
		timer.start();
      
      //loads background sound before game starts
      sound = new Sound();
      sound.play("gamestart.wav");
  
     	
	}

	public void paint(Graphics g) {
		Image offImage = createImage(600, 600);
        
      //creates buffer object of offscreen drawing to minimize flickering when objects or characters move    
		Graphics buffer = offImage.getGraphics();
		
		// In order to avoid flickering buffering is used. Double-buffering involves drawing to an offscreen graphics
		// surface and then copying that entire surface to the screen
		paintOffScreen(buffer);
		g.drawImage(offImage, 0, 0, (ImageObserver) null);

	}

	public void paintOffScreen(Graphics g) {
		super.paint(g);
	
		//grass, green
		g.setColor(new Color(0,128,0));
		g.fillRect(0, 0, getWidth(), getHeight()-50);
		        
		//sky
		g.setColor(new Color(0,191,255));
		g.fillRect(0, 0, getWidth(), getHeight()-150);
		  
		sun(g);	       
		cloud(g, 0, 30);
		cloud(g, 250, 120);
		house(g);
		tree(g, 200, 420);
		tree(g, 150, 380);
		tree(g, 100, 410);
		person(g,500-x_Pos,350);        
		windMill(g);
    	car(g);
	
		 //Increments or decrement for animations
		x_Pos = x_Pos + 1;  
		sunY -=  1;
		sunX -= 1;
		  
      //redraws game characters when you are in play mode  
		if (control.isInPlay()) {
			
			//if bird is not dead and game is still going on, reterive all characters from the Controller class control object
			//and draw them on screen based on new position of each character on screen via getX and getY function. Position of characters are managed via Location object
			ArrayList gameCharacter = control.getCharacterList(); //gets all the characters and draw them on screen
			ArrayList birdShoots = control.getBirdShootList();  //refreshes if bird has fired a shot
			ArrayList booms = control.getBoomList();  //gives blast affect when bird shot collides with shooters
			
         Iterator iterator = gameCharacter.iterator();
			while (iterator.hasNext())  //loops through all the characters
         {  
				GameCharacter gameChar = (GameCharacter) iterator.next();
				g.drawImage(gameChar.getImg(), gameChar.getLocation().getX(), gameChar.getLocation().getY(), this);  //draw character on screen based on character location
			}

			iterator = birdShoots.iterator(); //loops through all the bird bullets fired by bird
			while (iterator.hasNext()) {
				BirdShoot birdShoot = (BirdShoot) iterator.next();
				g.drawImage(birdShoot.getImg(), birdShoot.getLocation().getX(), birdShoot.getLocation().getY(), this); //draw bird bullet based on birdshoot location
			}

         
			iterator = booms.iterator();
			while (iterator.hasNext()) { //draws blast animation
				Boom boom = (Boom) iterator.next();
				g.drawImage(boom.getImg(), boom.getLocation().getX(), boom.getLocation().getY(), this); //draw blast effect on boom's location
			}

         //draw updated score on screen
			g.setColor(Color.WHITE);
			g.setFont(new Font("Impact", 0, 25));
			g.drawString(String.valueOf(control.getGameModel().getScore()), 20, 580);
		}
		

	}

   public void mousePressed(MouseEvent e) {
         control.onPressUp();
			upButtonPressed = true;
         sound.play("jump.wav");

   }

    public void mouseExited(MouseEvent e) {
    }
   
    public void mouseReleased(MouseEvent e) {
    }
    
     public void mouseClicked(MouseEvent e) {
        
    }

    public void mouseEntered(MouseEvent e) {
    }
   
   
   
   
	public void keyPressed(KeyEvent e) {
		if (e.getKeyCode() == KeyEvent.VK_UP && !upButtonPressed) {
			//when up arrow is pressed, it calls controller's onPressUp() method which jumps Bird object
			control.onPressUp();
			upButtonPressed = true;
         sound.play("jump.wav");
		} else if (e.getKeyCode() == KeyEvent.VK_SPACE &&  !spaceButtontPressed) {	
			control.onPressSpace();
         sound.play("birdshoot.wav");
			spaceButtontPressed = true;
		}

	}

	public void keyReleased(KeyEvent arg0) {
		if (arg0.getKeyCode() == KeyEvent.VK_UP) {
			upButtonPressed = false;
		} else if (arg0.getKeyCode() == KeyEvent.VK_SPACE) {
			spaceButtontPressed = false;
		}

	}

	public void keyTyped(KeyEvent arg0) {
	}


   //refreshes game characters when timer refreshes
	public void actionPerformed(ActionEvent e) {
      //upon action performed and play button is already clicked, step() function of modelView is called which randomly loads characters.
		if (control.isInPlay()) {
			control.step();
		}
       
	}

   //creates menu buttons and register events
	public void displayMenu() {
		final JButton btnStart = new JButton("Start Game");
		btnStart.setFont(new Font("Impact", 0, 20));
		btnStart.setToolTipText("");
		btnStart.setBackground(Color.GREEN);
		btnStart.setBounds(10, 530, 140, 30);
		getContentPane().add(btnStart);  //adds button to content pane
		final JButton btnHowPLay = new JButton("Help");
		btnHowPLay.setFont(new Font("Impact", 0, 20));
		btnHowPLay.setBackground(new Color(255, 215, 0));
		btnHowPLay.setBounds(155, 530, 140, 30);
		getContentPane().add(btnHowPLay);
		final JButton btnBack = new JButton("Back");
		btnBack.setFont(new Font("Impact", 0, 20));
		btnBack.setBackground(new Color(200, 0, 0));
		btnBack.setBounds(450, 530, 130, 30);
		getContentPane().add(btnBack);
		btnBack.setVisible(false);
		final JButton btnExitGame = new JButton("Exit Game");
		btnExitGame.setToolTipText("");
		btnExitGame.setForeground(Color.BLACK);
		btnExitGame.setFont(new Font("Impact", 0, 20));
		btnExitGame.setBackground(Color.RED);
		btnExitGame.setBounds(300, 530, 140, 30);
		final JLabel lblTitle = new JLabel("");
      
		Image img = (new ImageIcon(getClass().getClassLoader().getResource("birdfury.png"))).getImage().getScaledInstance(300, -1, 0);
		lblTitle.setIcon(new ImageIcon(img));
		lblTitle.setBounds(150, -6, 313, 190);
		getContentPane().add(lblTitle);
		final JLabel txtGameHelp = new JLabel(
				"<html>Press UP to jump.Press Space to fire.You cannot shoot catching net.<br>Shoot everything else.Stay alive!!!.</html>");
		txtGameHelp.setFont(new Font("Arial", 0, 12));
		txtGameHelp.setOpaque(true);
		txtGameHelp.setBounds(10, 530, 400, 50);
		txtGameHelp.setBackground(new Color(255, 215, 0));
		getContentPane().add(txtGameHelp);
		txtGameHelp.setVisible(false);
      
      //Action listner for the Back button
		btnBack.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				txtGameHelp.setVisible(false);
				btnBack.setVisible(false);
				btnHowPLay.setVisible(true);
				btnStart.setVisible(true);
				btnExitGame.setVisible(true);
			}
		});
      
      //When Help button is clicked
		btnHowPLay.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				txtGameHelp.setVisible(true);
				btnBack.setVisible(true);
				btnHowPLay.setVisible(false);
				btnStart.setVisible(false);
				btnExitGame.setVisible(false);
            
          
			}
		});
      
      //When Exit button is clicked it exits Game
		getContentPane().add(btnExitGame);
		btnExitGame.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				System.exit(0); //window exit
			}
		});
      
      //When Start button is clicked it starts Game
		btnStart.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				txtGameHelp.setVisible(false);
				btnBack.setVisible(false);
				btnHowPLay.setVisible(false);
				btnStart.setVisible(false);
				btnExitGame.setVisible(false);
				lblTitle.setVisible(false);
            sound.stop();
            
            //initialize GameModel object via initModel() and sets inPlayMode to true which means you are still alive. 
            //GameModel then calls the Step method which in turns randomly loads game characters
            control.initModel();
			}
		});
	}

	//This method is get called from Controller class when game is over. It shows score and gives option to play game again
	public void displayGameOver(int score, int killed) {
      sound.stop();
		final JButton btnMenu = new JButton("Back To Menu");
		btnMenu.setToolTipText("");
		btnMenu.setForeground(Color.BLACK);
		btnMenu.setFont(new Font("Impact", 0, 16));
		btnMenu.setBackground(Color.RED);
		btnMenu.setBounds(200, 530, 130, 30);
		btnMenu.setVisible(false);
		getContentPane().add(btnMenu);
		final JButton btnPlayAgain = new JButton("Play Again?");
		btnPlayAgain.setToolTipText("");
		btnPlayAgain.setForeground(Color.BLACK);
		btnPlayAgain.setFont(new Font("Impact", 0, 16));
		btnPlayAgain.setBackground(Color.GREEN);
		btnPlayAgain.setBounds(340, 530, 120, 30);
		btnPlayAgain.setVisible(false);
		getContentPane().add(btnPlayAgain);
		final JLabel lblGameOver = new JLabel("");
		Image imgG = (new ImageIcon(getClass().getClassLoader().getResource("gameover.png"))).getImage()
				.getScaledInstance(250, -1, 0);
		lblGameOver.setIcon(new ImageIcon(imgG));
		lblGameOver.setBounds(173, 0, 267, 231);
		getContentPane().add(lblGameOver);
		lblGameOver.setVisible(false);
		final JLabel txtScore = new JLabel();
		txtScore.setForeground(Color.WHITE);
		txtScore.setFont(new Font("Impact", 0, 20));
		txtScore.setBackground(Color.BLACK);
		txtScore.setText("Score: " + score);
		txtScore.setBounds(480, 530, 185, 30);
		getContentPane().add(txtScore);
		txtScore.setVisible(false);
		final JLabel txtShooterEliminated = new JLabel();
		txtShooterEliminated.setText("Shooters Eliminated: " + killed);
		txtShooterEliminated.setForeground(Color.WHITE);
		txtShooterEliminated.setFont(new Font("Impact", 0, 20));
		txtShooterEliminated.setBackground(Color.BLACK);
		txtShooterEliminated.setBounds(2, 530, 185, 30);
		getContentPane().add(txtShooterEliminated);
		txtShooterEliminated.setVisible(false);
		final JLabel txtAcc = new JLabel();

		btnMenu.setVisible(true);
		btnPlayAgain.setVisible(true);
		lblGameOver.setVisible(true);
		//txtAcc.setVisible(true);
		txtScore.setVisible(true);
		txtShooterEliminated.setVisible(true);
		btnPlayAgain.requestFocusInWindow();
		btnMenu.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				btnMenu.setVisible(false);
				lblGameOver.setVisible(false);
				btnPlayAgain.setVisible(false);
				txtAcc.setVisible(false);
				txtScore.setVisible(false);
				txtShooterEliminated.setVisible(false);
				control.getView().displayMenu();
			}
		});
		btnPlayAgain.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				btnMenu.setVisible(false);
				lblGameOver.setVisible(false);
				btnPlayAgain.setVisible(false);
				txtAcc.setVisible(false);
				txtScore.setVisible(false);
				txtShooterEliminated.setVisible(false);
				control.initModel();
			}
		});
	}
	
	 public void cloud(Graphics g, int width, int height)
     {
 
 
           
           g.setColor(Color.white);
           g.fillOval(width+x_Pos, height, 40, 70);
           g.fillOval(width+10+x_Pos, height-20, 60, 80);
           g.fillOval(width+20+x_Pos, height+40, 80, 40);
           g.fillOval(width+40+x_Pos, height, 70, 60);
           g.fillOval(width+50+x_Pos, height-30, 60, 40);
           g.fillOval(width+60+x_Pos, height-20, 70, 60);
           g.fillOval(width+70+x_Pos, height+20, 70, 60);
           g.fillOval(width+90+x_Pos, height, 65, 95); 

     }
    public void tree(Graphics g, int width, int height)
    {

           //draw tree trunk
           g.setColor(new Color(139, 69, 19));
           g.fillRect(width+20, height, 15, 100);
           
           
           //draw leaves
           g.setColor(Color.GREEN);
           int radius = 40;
           
           g.fillOval(width - 15, height, radius, radius);
           g.fillOval(width + 15, height, radius, radius);
           g.fillOval(width, height - 20, radius, radius);   

           
           //red apples
           g.setColor(Color.RED);
           radius = 5;
           g.fillOval(width + 15, height + 5, radius, radius);
           g.fillOval(width - 5, height + 8 , radius, radius);
           g.fillOval(width, height - 10, radius, radius);  
           g.fillOval(width + 30, height + 20, radius, radius); 
    }
  
     public void windMill(Graphics g)
     {
     
        //windmill base
        g.setColor(new Color(100, 55, 35));
        int xRoof[] = {25, 55, 75};
        int yRoof[] = {480, 325, 480};
        g.fillPolygon(xRoof, yRoof, 3);
           
        if (flag)
        {
           g.setColor(Color.red);
           g.fillRect(50, 300, 10, 50);
           g.setColor(Color.green);
           g.fillRect(30, 320, 50, 10);
           flag = false;
        }
        else
        {
           g.setColor(Color.green);
           g.fillRect(50, 300, 10, 50);
           g.setColor(Color.red);
           g.fillRect(30, 320, 50, 10);
           flag = true;

        }
     }

     public void sun(Graphics g)
     {
     
         g.setColor(Color.orange);
         g.fillOval(sunY,sunX,100,100);
     }
     
     public void house(Graphics g)
     {
     
           
           //draw house rectangle
           g.setColor(new Color(220,20,60));
           g.fillRect(300, 300, 200, 200);
           
           //draw door
           g.setColor(Color.blue);
           g.fillRect(370, 400, 60, 100);
           
           //draw door knob
           g.setColor(Color.black);
           g.fillOval(410,440,10,10);
           
           //draw chimney
           g.setColor(new Color(105,105,105));
           g.fillRect(290,215,30,65);
           g.setColor(Color.black);
           g.fillOval(300,195,15,15);
           g.fillOval(300,180,10,10);
           g.fillOval(300,160,10,10);
           
           //draw roof
           g.setColor(new Color(139,69,19));
           int xRoof[] = {260, 400, 540};
           int yRoof[] = {300, 195, 300};
           g.fillPolygon(xRoof, yRoof, 3);
           
           //draw left window              
           g.setColor(Color.yellow);
           g.fillRect(330, 330, 40, 40);
           
           //window cross, black
           g.setColor(Color.black);
           g.fillRect(347, 330, 6, 40);
           g.fillRect(330, 347, 40, 6);
       
           //draw right window             
           g.setColor(Color.yellow);
           g.fillRect(430, 330, 40, 40);
           
           //window cross, black
           g.setColor(Color.black);
           g.fillRect(447, 330, 6, 40);
           g.fillRect(430, 347, 40, 6);
           
           
           //window on the roof            
           g.setColor(Color.white);
           g.fillRect(380, 230, 40, 40);
           
           //window cross, black
           g.setColor(Color.black);
           g.fillRect(397, 230, 6, 40);
           g.fillRect(380, 247, 40, 6);
       
     }
  	public void car(Graphics g)
  	{
          //headlight
          g.setColor(Color.black);
          g.fillOval(x_Pos+102,y_Pos+24, 12, 10);  

          //car base
          g.setColor(Color.orange);
          g.fillRoundRect(x_Pos,y_Pos+20,100,40,5,5);
          g.fillArc(x_Pos+90,y_Pos+20,20,40,270,180);
  
          //car roof
          g.setColor(Color.red);
          g.fillRoundRect(x_Pos+10,y_Pos,70,25,10,10);
          //g.fillRect(x+50,y+5,20,25);
          
          
          g.setColor(Color.black);
          //driver
          g.fillRoundRect(x_Pos+55,y_Pos+10,10,20,10,10);
          
          //tire
          g.fillOval(x_Pos+10,y_Pos+50,25,25);
          g.fillOval(x_Pos+60,y_Pos+50,25,25);
          
           g.setColor(Color.white);
          g.fillOval(x_Pos+20,y_Pos+62,5,5);
          g.fillOval(x_Pos+70,y_Pos+62,5,5);
          
      
      	
     }
  	
  public void person(Graphics c, int person_X, int person_Y)
  {
      if (person_X < 360) person_X = 360;
      int[] shirt_PosX = {person_X+30,person_X+0,person_X+10,person_X+30,person_X+25,person_X+65,person_X+60,person_X+80,person_X+90,person_X+60};
      int[] shirt_PosY = {person_Y+50,person_Y+75,person_Y+90,person_Y+80,person_Y+125,person_Y+125,person_Y+80,person_Y+90,person_Y+75,person_Y+50};
      int[] pant_PosX = {person_X+25,person_X+10,person_X+25,person_X+45,person_X+65,person_X+80,person_X+65};
      int[] pant_PosY = {person_Y+125,person_Y+175,person_Y+175,person_Y+135,person_Y+175,person_Y+175,person_Y+125};
   
	
   
      // draw head.
      c.setColor(new Color(255, 228, 181));
      c.fillOval(person_X+30, person_Y+28, 30, 30 - 10);

      // draw hair
      c.setColor(Color.black);
      c.fillOval(person_X+35,person_Y+25,20,5);
 

      //draw eye and mouth
      c.setColor(Color.black);
      c.fillOval(person_X+35,person_Y+32,5,5);
      c.fillOval(person_X+45,person_Y+32,5,5);
      c.fillOval(person_X+35,person_Y+40,15,5);
      
      //draw hands
      c.setColor(Color.white);
     int radius = 15;
           
      c.fillOval(person_X - 10, person_Y+75, radius+10, radius);
      c.fillOval(person_X + 80, person_Y+75, radius+10, radius);         
      // Draw shirt.
      c.setColor(Color.RED);
      c.fillPolygon(shirt_PosX, shirt_PosY, shirt_PosX.length);

      // Draw pants.
      c.setColor(Color.darkGray);
      c.fillPolygon(pant_PosX, pant_PosY, pant_PosX.length);
	
   
     //draw  shoes
      c.setColor(Color.black);
      c.fillOval(person_X +2, person_Y+170, radius+10, radius-4);
      c.fillOval(person_X + 54, person_Y+170, radius+10, radius-4);



   }
  	

}
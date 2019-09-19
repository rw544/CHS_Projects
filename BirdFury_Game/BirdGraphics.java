
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
public class MyGraphics extends JFrame implements ActionListener, KeyListener, MouseListener  
{

	private boolean upButtonPressed;
	private boolean spaceButtontPressed;

 int sunX = 550; //starting position for sun x-coordinate
 int sunY = 800;  //starting position for sun y-coordinate
 int birdY = 300;
 
 int startX = 0;
 int startY = 0;
  int endX = 0;
 int endY = 0;
  
public  BirdGraphics()
{ 

      super("Bird Fury"); //Title of frame

		setBounds(100, 100, 600, 600); 		//sets screen boundary
		setDefaultCloseOperation(3);        //allows closing screen by clicking 'X'
		getContentPane().setLayout((LayoutManager) null); //set screenlayout manager
		getContentPane().setBackground(Color.BLACK);
		setResizable(false);
		
      //adding keyboard and mouse listener
      addKeyListener(this);
      addMouseListener(this);
	
      setVisible(true);
      displayMenu();

   	//Timer class schedules tasks for one-time execution, or for repeated execution at regular define intervals which is in milliseconds.
		//Timer timer = new Timer(25, this);
		//timer.start();
         	
   }
   
   
   public void paint(Graphics g) {
   
      Image offImage = createImage(600, 600);

		  //creates buffer object of offscreen drawing to minimize flickering when objects or characters move    
		Graphics buffer = offImage.getGraphics();
		
       paintOffScreen(buffer);
     
       sunX--; //starting position for sun x-coordinate
       sunY--;
       birdY = birdY+2;
       
            g.drawImage(offImage, 0, 0, (ImageObserver) null);

     
	}
   public void paintOffScreen(Graphics g) {
		super.paint(g);
  
 

  /*
      //grass, green
		g.setColor(new Color(0,128,0));
		g.fillRect(0, 0, getWidth(), getHeight()-50);
		        
		//sky
		g.setColor(new Color(0,191,255));
		g.fillRect(0, 0, getWidth(), getHeight()-150);

      sun(g);
 */     
 
      int fontSize = 20;

       g.setFont(new Font("TimesRoman", Font.PLAIN, fontSize));
       g.setColor(Color.RED);
      
       g.drawString(startX + "," + startY+ "," + endX+ "," +endY,  endX, endY);
       g.drawLine(startX,startY,endX,endY);
       

      Image img = (new ImageIcon(this.getClass().getClassLoader().getResource("player.png"))).getImage();
		g.drawImage(img, 400, birdY, this);		
   
   

   }
   //refreshes game characters when timer refreshes
	public void actionPerformed(ActionEvent e) {
     this.repaint();
        
	}
   
   public void sun(Graphics g)
   {
      //g.setColor(new Color(0,128,0));
	   //g.fillRect(0, 0, getWidth(), getHeight()-50);
      
      g.setColor(Color.orange);
      g.fillOval(sunY,sunX,100,100);

   } //creates menu buttons and register events
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
   
			}
		});
      
      
      
	}

      public void mousePressed(MouseEvent e) {
			upButtonPressed = true;
         startX = e.getX();
         startY = e.getY(); 

   }

    public void mouseExited(MouseEvent e) {
 
 
    }
   
    public void mouseReleased(MouseEvent e) {
    
       endX = e.getX();
       endY = e.getY(); 
             
       this.repaint();
    }
    
     public void mouseClicked(MouseEvent e) {
  
    }

    public void mouseEntered(MouseEvent e) {
    }
   
     public void mouseDown(MouseEvent e) {

    }

   public void mouseUp(MouseEvent e) {

    }

   
	public void keyPressed(KeyEvent e) {
		if (e.getKeyCode() == KeyEvent.VK_UP && !upButtonPressed) {
			//when up arrow is pressed, it calls controller's onPressUp() method which jumps Bird object
         birdY = birdY-14;
			upButtonPressed = true;
      } else if (e.getKeyCode() == KeyEvent.VK_SPACE &&  !spaceButtontPressed) {	
         
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
   
}
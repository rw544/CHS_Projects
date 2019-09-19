
//Programm starting point
public class BirdFury {
	public static void main(String[] args) {
		
      //instantiate Controller class to send commands to the model object from BirdView 
		Controller controller = new Controller();
      
      //gets instance of BirdView class and passing controller as parameter to constructor
	  // BirdView draws backgrounds and menu options for user to interact	
		BirdView birdView = new BirdView(controller);
		
		//setting BirdView object of controller
		controller.setView(birdView);
	}
}
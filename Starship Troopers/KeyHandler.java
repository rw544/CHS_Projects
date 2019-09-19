import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

class KeyHandler implements KeyListener {
   StarshipTrooper sShipTrooper;
	public KeyHandler(StarshipTrooper arg0) {
		sShipTrooper = arg0;
	}

	public void keyPressed(KeyEvent arg0) {
		if (arg0.getKeyCode() == 38) {
			StarshipTrooper.pressUpButton(sShipTrooper, true);
		} else if (arg0.getKeyCode() == 32) {
			if (StarshipTrooper.pressSpaceButton(sShipTrooper) > 0) {
				StarshipTrooper.setMissileFlag(sShipTrooper, true);
				StarshipTrooper.decreaseBulletCount(sShipTrooper);
			}
		} else if (arg0.getKeyCode() == 10) {
			sShipTrooper.resetGame();
		}

	}

	public void keyReleased(KeyEvent arg0) {
		if (arg0.getKeyCode() == 38) {
			StarshipTrooper.pressUpButton(sShipTrooper, false);
		}

	}

	public void keyTyped(KeyEvent arg0) {
	}
}
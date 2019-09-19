import java.io.*;
import java.net.URL;
import javax.sound.sampled.*;
public class Sound
{
    private String filename = "jump.wav";
    private Clip clip;
    public void play(String file)
    {
     try {
            // Open an audio input stream.
            URL url = this.getClass().getClassLoader().getResource(file);
            AudioInputStream audioIn = AudioSystem.getAudioInputStream(url);
            // Get a sound clip resource.
            clip = AudioSystem.getClip();
            // Open audio clip and load samples from the audio input stream.
            clip.open(audioIn);
            clip.start();
         } catch (UnsupportedAudioFileException e) {
            e.printStackTrace();
         } catch (IOException e) {
            e.printStackTrace();
         } catch (LineUnavailableException e) {
            e.printStackTrace();
      }
    }
    
    public void stop()
    {
      clip.stop();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blokus_Game
{
    class Player
    {
        private string playerName;
        private int playerScore;
        private int blockInHandCount;
        private ArrayList arrBlockInHand;
        private Form frmBlockUsGame;


        public Player(string name, Form frmBlockUsGame)
        {
            this.frmBlockUsGame = frmBlockUsGame;
            playerName = name;
            arrBlockInHand = new ArrayList();
            LoadArrayBlock();

        }

        public void LoadBlocks()
        {
   
            foreach (Control control in frmBlockUsGame.Controls)
            {

                if (control.Name.StartsWith("blk"))
                {

                    if (!arrBlockInHand.Contains(control.Name))
                    {
                        
                        control.Enabled = false;
                        ((Button)control).FlatStyle = FlatStyle.System;
                    }
                    else
                    {
  
                        control.Enabled = true;
                        ((Button)control).FlatStyle = FlatStyle.Standard;
                    }
                }
            }
        }
        public int GetPlayerScore()
        {
            playerScore = 0;
            foreach (Control control in frmBlockUsGame.Controls)
            {

                if (control.Name.StartsWith("blk") && control.Enabled)
                {

                    if (arrBlockInHand.Contains(control.Name))
                    {
                        playerScore += int.Parse(control.Tag.ToString());

                    }
                }
            }
            return playerScore;
        }

        public string GetPlayerName()
        {
            return playerName;
        }
        public void RemoveArrayBlock(string blockName)
        {
            arrBlockInHand.Remove(blockName);
        }
        private void LoadArrayBlock()
        {
            for (int i = 1; i < 22; i++)
            {
                arrBlockInHand.Add("blk" + i);
            }
        }
    }
}

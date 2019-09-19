using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blokus_Game
{
    public partial class frmBlokUsGame : Form
    {
        System.Windows.Forms.Button[] btnArray;
        private List<KeyValuePair<string, string>> blockButton;
        private string btnSelected;
        bool playerOneFirstTime = true;
        bool playerTwoFirstTime = true;
        private Player player1;
        private Player player2 ;
        private string playerTurn = "Player1";
        private string draggedBlockName = "";

        public frmBlokUsGame()
        {
            InitializeComponent();
            //load grid buttons
            LoadGrid();
           
        }

        private void pnlButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            LoadGrid();

            player1.LoadBlocks();


        }


        private void LoadGrid()
        {
          
            int xPos = 0;
            int yPos = 0;
            int btnWidth = 25;
            int btnHeight = 25;
            int gridSize = 400;
            int nextLine = 20;
            
            //define array of buttons
            btnArray = new System.Windows.Forms.Button[gridSize];
            // Create (400) Buttons: 
            for (int i = 0; i < gridSize; i++)
            {
                // Initialize one variable 
                btnArray[i] = new System.Windows.Forms.Button();
            }
            int n = 0;
            int cnt = 0;
            while (n < gridSize)
            {

                btnArray[n].Tag = n + 1; // Tag of button 
                btnArray[n].Width = btnWidth; // Width of button 
                btnArray[n].Height = btnHeight; // Height of button 
                if (cnt == nextLine) //(n == 20) // Location of second line of buttons: 
                {
                    cnt = 0;
                    xPos = 0;
                    yPos = yPos + btnHeight;
                }
                // Location of button: 
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                btnArray[n].Tag = n;
                btnArray[n].AllowDrop = true;
                // Add buttons to a Panel: 
                this.pnlButtons.Controls.Add(btnArray[n]); // Let panel hold the Buttons 
                xPos = xPos + btnArray[n].Width; // Left of next button 
                                                 // Write English Character: 
                                                 // btnArray[n].Text = ((char)(n + 65)).ToString();


              // the Event of click Button 
             // btnArray[n].Click += new System.EventHandler(ClickButton);
              btnArray[n].DragEnter += new System.Windows.Forms.DragEventHandler(DragEnterButton);
              btnArray[n].DragDrop += new System.Windows.Forms.DragEventHandler(DragDropButton);

                n++;
                cnt++;
            }
            //btnAddButton.Enabled = false; // not need now to this button now 
            //label1.Visible = true;
            cnt = 0;
            for (int r=0; r < nextLine; r++)
            {
                for (int c = 0; c < nextLine; c++)
                {
                    btnArray[cnt].AccessibleDescription = r + "," + c;
                    cnt++;
                }
            }
            InitializeBlocks();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            player1 = new Player("Player 1", this);
            player2 = new Player("Player 2", this);
            lblPlayer1Score.Text = player1.GetPlayerScore().ToString();
            lblPlayer2Score.Text = player2.GetPlayerScore().ToString();
            lblPlayer1.ForeColor = Color.Red;
            lblPlayer2.ForeColor = Color.Green;


            lblPlayer1.Text = player1.GetPlayerName();
            lblPlayerTurn.Text = "Turn: " + lblPlayer1.Text;
            lblPlayer2.Text = player2.GetPlayerName();

        }

        private void InitializeBlocks()
        {
             blockButton  = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("blk1", "1L,1D,1L,1R,1D"),
                new KeyValuePair<string, string>("blk2", "1D,1L,1R,1R,1L,1D"),
                new KeyValuePair<string, string>("blk3", "1L,1D,1D,1R"),
                new KeyValuePair<string, string>("blk4", "1L,1D,1L,1D"),
                new KeyValuePair<string, string>("blk5", "1D,1L,1R,1R,1R"),
                new KeyValuePair<string, string>("blk6", "1D,1D,1R,1U"),
                new KeyValuePair<string, string>("blk7", "1D,1D,1D,1D"),
                new KeyValuePair<string, string>("blk8", "1D,1L,1L,1D"),
                new KeyValuePair<string, string>("blk9", "1L,1L,1D,1L"),
                new KeyValuePair<string, string>("blk10", "1D,1D,1R,1R"),
                new KeyValuePair<string, string>("blk11", "1D,1D,1L,1R,1R"),
                new KeyValuePair<string, string>("blk12", "1D,1R,1R,1R"),
                new KeyValuePair<string, string>("blk13", "1L,1D,1L"),
                new KeyValuePair<string, string>("blk14", "1D,1L,1L"),
                new KeyValuePair<string, string>("blk15", "1L,1L,1L"),
                new KeyValuePair<string, string>("blk16", "1D,1L,1R,1R"),
                new KeyValuePair<string, string>("blk17", "1L,1D,1R"),
                new KeyValuePair<string, string>("blk18", "1Z"),
                new KeyValuePair<string, string>("blk19", "1L"),
                new KeyValuePair<string, string>("blk20", "1R,1D"),
                new KeyValuePair<string, string>("blk21", "1L,1L"),
            };

            
         

        }
        private void SetPlayer()
        {
            if (playerTurn == "Player1")
            {
               
                lblPlayerTurn.Text = "Turn: " + lblPlayer2.Text;
                player1.RemoveArrayBlock(draggedBlockName);
                lblPlayer1Score.Text = player1.GetPlayerScore().ToString();
                if (player1.GetPlayerScore() == 0 )
                {
                    MessageBox.Show(player1.GetPlayerName() + " is the winner!!!!");
                    this.Close();
                }
                playerTurn = "Player2";
                player2.LoadBlocks();
            }
            else
            {
                
                lblPlayerTurn.Text = "Turn: " + lblPlayer1.Text;
                player2.RemoveArrayBlock(draggedBlockName);
                lblPlayer2Score.Text = player2.GetPlayerScore().ToString();
                if (player2.GetPlayerScore() == 0)
                {
                    MessageBox.Show(player2.GetPlayerName() + " is the winner!!!!");
                    this.Close();
                }
                playerTurn = "Player1";
                player1.LoadBlocks();
            }

        }
        public void DragDropButton(Object sender, System.Windows.Forms.DragEventArgs e)
        {

            Button btn = (Button)sender;
            if (ValidateSelectedBlockRule(selectedBlockRule, btn.AccessibleDescription, int.Parse(btn.Tag.ToString())) && CheckOverlapGrid(selectedBlockRule, btn.AccessibleDescription, int.Parse(btn.Tag.ToString())))
            {
                DrawBlocks(selectedBlockRule, btn.AccessibleDescription, int.Parse(btn.Tag.ToString()));
                SetPlayer();
            }
        }

            // Result of (Click Button) event, get the text of button 
        public void DragEnterButton(Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
                
             else
                e.Effect = DragDropEffects.None;
        }
            // Result of (Click Button) event, get the text of button 
            public void ClickButton(Object sender, System.EventArgs e)
        {

            Button btn = (Button)sender;
            int currButtonIndex = Int32.Parse(btn.Tag.ToString());
            //btn.BackColor = Color.Red;
            //btnArray[currButtonIndex + 20].BackColor = Color.Red;
            //MessageBox.Show(btn.AccessibleDescription);

            if (ValidateSelectedBlockRule(selectedBlockRule, btn.AccessibleDescription, int.Parse(btn.Tag.ToString())) && CheckOverlapGrid(selectedBlockRule, btn.AccessibleDescription, int.Parse(btn.Tag.ToString())))
            {
                DrawBlocks(selectedBlockRule, btn.AccessibleDescription, int.Parse(btn.Tag.ToString()));
                if (playerTurn == "Player1")
                {
                    player1.RemoveArrayBlock(btn.Name);
                    lblPlayer1Score.Text = "Score: " + player1.GetPlayerScore().ToString();
                    playerTurn = "Player2";
                    player2.LoadBlocks();
                }
                else
                {
                    player2.RemoveArrayBlock(btn.Name);
                    lblPlayer2Score.Text = "Score: " + player2.GetPlayerScore().ToString();
                    playerTurn = "Player1";
                    player1.LoadBlocks();
                }
            }
        }

        //draws the block based on block rule which defines how many down, left, right, or up
        private bool DrawBlocks(string blockRule, string currentGridIndex, int currentGridSeqNumber)
        {
            String[] arr = blockRule.Split(',');
            String[] arrPos = currentGridIndex.Split(',');
            int row = int.Parse(arrPos[0]);
            int col = int.Parse(arrPos[1]);

            Color color = new Color();
            if (playerTurn == "Player1") color = Color.Red; else color = Color.Green;


            btnArray[currentGridSeqNumber].BackColor = color;
            foreach (String s in arr)
            {
                string moveLetter = s.Substring(s.Length - 1);
                int moveNumber = int.Parse(s.Substring(0, 1));

                if (moveLetter.Equals("L"))
                {
                   for (int i=0; i < moveNumber; i++)
                   {
                        currentGridSeqNumber = currentGridSeqNumber - 1;
                        btnArray[currentGridSeqNumber - i].BackColor = color;
                   }
                }
                else if (moveLetter.Equals("R"))
                {
                    for (int i = 0; i < moveNumber; i++)
                    {
                        currentGridSeqNumber = currentGridSeqNumber + 1;
                       btnArray[currentGridSeqNumber].BackColor = color;
                    }
                }
                else if (moveLetter.Equals("U"))
                {
                    for (int i = 0; i < moveNumber; i++)
                    {
                        currentGridSeqNumber = currentGridSeqNumber - 20;
                       btnArray[currentGridSeqNumber].BackColor = color;
                    }
                }
                else if (moveLetter.Equals("D"))
                {
                    for (int i = 0; i < moveNumber; i++)
                    {
                        currentGridSeqNumber = currentGridSeqNumber + 20;
                       btnArray[currentGridSeqNumber].BackColor = color;
                    }

                }
            }
            if (playerTurn == "Player1")
                btnArray[currentGridSeqNumber].BackColor = Color.Blue;
            else
                btnArray[currentGridSeqNumber].BackColor = Color.Yellow;
            return true;
        }

       
        //check if grid is already already populate which means with color green, red, or blue then you cannot drop and block here
        private bool CheckOverlapGrid(string blockRule, string currentGridIndex, int currentGridSeqNumber)
        {
            String[] arr = blockRule.Split(',');
            String[] arrPos = currentGridIndex.Split(',');
            int row = int.Parse(arrPos[0]);
            int col = int.Parse(arrPos[1]);

            if (btnArray[currentGridSeqNumber].BackColor == Color.Red || btnArray[currentGridSeqNumber].BackColor == Color.Green || btnArray[currentGridSeqNumber].BackColor == Color.Blue)
                return false;

            foreach (String s in arr)
            {
                string moveLetter = s.Substring(s.Length - 1);
                int moveNumber = int.Parse(s.Substring(0, 1));

                if (moveLetter.Equals("L"))
                {
                    for (int i = 0; i < moveNumber; i++)
                    {
                        currentGridSeqNumber = currentGridSeqNumber - 1;
                        if (btnArray[currentGridSeqNumber].BackColor == Color.Red || btnArray[currentGridSeqNumber].BackColor == Color.Green || btnArray[currentGridSeqNumber].BackColor == Color.Blue)
                            return false;
                    }
                }
                else if (moveLetter.Equals("R"))
                {
                    for (int i = 0; i < moveNumber; i++)
                    {
                        currentGridSeqNumber = currentGridSeqNumber + 1;
                        if (btnArray[currentGridSeqNumber].BackColor == Color.Red || btnArray[currentGridSeqNumber].BackColor == Color.Green || btnArray[currentGridSeqNumber].BackColor == Color.Blue)
                            return false;
                    }
                }
                else if (moveLetter.Equals("U"))
                {
                    for (int i = 0; i < moveNumber; i++)
                    {
                        currentGridSeqNumber = currentGridSeqNumber - 20;
                        if (btnArray[currentGridSeqNumber].BackColor == Color.Red || btnArray[currentGridSeqNumber].BackColor == Color.Green || btnArray[currentGridSeqNumber].BackColor == Color.Blue)
                            return false;
                    }
                }
                else if (moveLetter.Equals("D"))
                {
                    for (int i = 0; i < moveNumber; i++)
                    {
                        currentGridSeqNumber = currentGridSeqNumber + 20;
                        if (btnArray[currentGridSeqNumber].BackColor == Color.Red || btnArray[currentGridSeqNumber].BackColor == Color.Green || btnArray[currentGridSeqNumber].BackColor == Color.Blue)
                            return false;
                    }

                }
            }

            return true;
        }

        //validation rules for the blocks are set here
        private bool ValidateSelectedBlockRule(string blockRule, string currentGridIndex,  int currentGridSeqNumber)
        {
            String[] arr = blockRule.Split(',');
            String[] arrPos = currentGridIndex.Split(',');
            int row = int.Parse(arrPos[0]);
            int col = int.Parse(arrPos[1]);
            foreach (String s in arr)
            {
                string moveLetter = s.Substring(s.Length - 1);
                int moveNumber = int.Parse(s.Substring(0,1));

                if (moveLetter.Equals("L"))
                {
                    if (col - moveNumber < 0)
                        return false;
                }
                else if (moveLetter.Equals("R"))
                {
                    if (col + moveNumber > 19)
                        return false;
                }
                else if (moveLetter.Equals("U"))
                {
                    if (row - moveNumber < 0)
                        return false;
                }
                else if (moveLetter.Equals("D"))
                {
                    if (row + moveNumber > 19)
                        return false;

                }
            }

            //first time let player1 and player2 drop without applying bottom block validation rules
            if (playerTurn == "Player1" && playerOneFirstTime == true)
            {
                playerOneFirstTime = false;
                return true;
            }
            else if (playerTurn == "Player2" && playerTwoFirstTime == true)
            {
                playerTwoFirstTime = false;
                return true;
            }

            Color color = new Color();
            Color playerColor = new Color();
            if (playerTurn == "Player1")
            {
                color = Color.Blue;
                playerColor = Color.Red;
            }
            else
            {
                color = Color.Yellow;
                playerColor = Color.Green;
            }

            
            if (col - 1 >= 0 && row - 1 > 0  && btnArray[currentGridSeqNumber - 21].BackColor == color && btnArray[currentGridSeqNumber - 20].BackColor != playerColor && !blockRule.Contains("U"))
                return true;
            else if (col + 1 <= 19 && row - 1 > 0 && btnArray[currentGridSeqNumber - 19].BackColor == color && btnArray[currentGridSeqNumber - 20].BackColor != playerColor && !blockRule.Contains("U"))
                return true;
            if (col - 1 >= 0 && row + 1 < 19 && btnArray[currentGridSeqNumber + 21].BackColor == color && btnArray[currentGridSeqNumber + 20].BackColor != playerColor && !blockRule.Contains("D"))
                return true;
            else if (col + 1 <= 19 && row + 1 < 19 && btnArray[currentGridSeqNumber + 19].BackColor == color && btnArray[currentGridSeqNumber + 20].BackColor != playerColor && !blockRule.Contains("D"))
                return true;
           
            /*
            if (col - 1 >= 0 && btnArray[currentGridSeqNumber - 1].BackColor == color)
                return true;
            else if (col + 1 <= 19 && btnArray[currentGridSeqNumber + 1].BackColor == color)
                return true;
            else if (row + 1 < 19 && btnArray[currentGridSeqNumber - 20].BackColor == color)
                return true;
            else if (row - 1 < 0 && btnArray[row + 20].BackColor == color)
                return true;
            */

            return false;
        }



        private void blk_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //btnSelected = btn.Name;
            //var result = blockButton.Where(s => s.Key == "btn1");
            var pair = blockButton.FirstOrDefault(x => x.Key == btn.Name);
            selectedBlockRule = pair.Value;
        }

        string selectedBlockRule = "";

        private void blk_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            draggedBlockName = btn.Name;

            var pair = blockButton.FirstOrDefault(x => x.Key == btn.Name);
            selectedBlockRule = pair.Value;
            blk2.DoDragDrop(selectedBlockRule, DragDropEffects.Copy |
                DragDropEffects.Move);



          /*  Bitmap bmp = new Bitmap(btn.Width, btn.Height);
            btn.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            //optionally define a transparent color
            bmp.MakeTransparent(Color.White);

            Cursor cur = new Cursor(bmp.GetHicon());
            Cursor.Current = cur;
        */
        }

        private void btnPassTurn_Click(object sender, EventArgs e)
        {
            draggedBlockName = "";
            SetPlayer();
        }

        private void blk13_Click(object sender, EventArgs e)
        {

        }
    }

   
}

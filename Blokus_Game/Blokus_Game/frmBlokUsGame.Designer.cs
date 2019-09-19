
namespace Blokus_Game
{
    partial class frmBlokUsGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBlokUsGame));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.Start = new System.Windows.Forms.Button();
            this.blk1 = new System.Windows.Forms.Button();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer1Score = new System.Windows.Forms.Label();
            this.lblPlayer2Score = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayerTurn = new System.Windows.Forms.Label();
            this.blk2 = new System.Windows.Forms.Button();
            this.blk3 = new System.Windows.Forms.Button();
            this.blk4 = new System.Windows.Forms.Button();
            this.blk8 = new System.Windows.Forms.Button();
            this.blk7 = new System.Windows.Forms.Button();
            this.blk6 = new System.Windows.Forms.Button();
            this.blk5 = new System.Windows.Forms.Button();
            this.blk16 = new System.Windows.Forms.Button();
            this.blk15 = new System.Windows.Forms.Button();
            this.blk14 = new System.Windows.Forms.Button();
            this.blk13 = new System.Windows.Forms.Button();
            this.blk12 = new System.Windows.Forms.Button();
            this.blk11 = new System.Windows.Forms.Button();
            this.blk10 = new System.Windows.Forms.Button();
            this.blk9 = new System.Windows.Forms.Button();
            this.blk21 = new System.Windows.Forms.Button();
            this.blk20 = new System.Windows.Forms.Button();
            this.blk19 = new System.Windows.Forms.Button();
            this.blk18 = new System.Windows.Forms.Button();
            this.blk17 = new System.Windows.Forms.Button();
            this.btnPassTurn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(114, 32);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(521, 514);
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlButtons_Paint);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(314, 552);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Visible = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // blk1
            // 
            this.blk1.AccessibleDescription = "";
            this.blk1.BackColor = System.Drawing.Color.Black;
            this.blk1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk1.BackgroundImage")));
            this.blk1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.blk1.Location = new System.Drawing.Point(641, 32);
            this.blk1.Name = "blk1";
            this.blk1.Size = new System.Drawing.Size(71, 71);
            this.blk1.TabIndex = 2;
            this.blk1.Tag = "-5";
            this.blk1.UseVisualStyleBackColor = false;
            this.blk1.Click += new System.EventHandler(this.blk_Click);
            this.blk1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.Red;
            this.lblPlayer1.Location = new System.Drawing.Point(12, 85);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(79, 24);
            this.lblPlayer1.TabIndex = 4;
            this.lblPlayer1.Text = "Player1";
            // 
            // lblPlayer1Score
            // 
            this.lblPlayer1Score.AutoSize = true;
            this.lblPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Score.Location = new System.Drawing.Point(12, 113);
            this.lblPlayer1Score.Name = "lblPlayer1Score";
            this.lblPlayer1Score.Size = new System.Drawing.Size(50, 17);
            this.lblPlayer1Score.TabIndex = 5;
            this.lblPlayer1Score.Text = "Score";
            // 
            // lblPlayer2Score
            // 
            this.lblPlayer2Score.AutoSize = true;
            this.lblPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Score.Location = new System.Drawing.Point(12, 267);
            this.lblPlayer2Score.Name = "lblPlayer2Score";
            this.lblPlayer2Score.Size = new System.Drawing.Size(50, 17);
            this.lblPlayer2Score.TabIndex = 7;
            this.lblPlayer2Score.Text = "Score";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.Green;
            this.lblPlayer2.Location = new System.Drawing.Point(12, 239);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(79, 24);
            this.lblPlayer2.TabIndex = 6;
            this.lblPlayer2.Text = "Player2";
            // 
            // lblPlayerTurn
            // 
            this.lblPlayerTurn.AutoSize = true;
            this.lblPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTurn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblPlayerTurn.Location = new System.Drawing.Point(310, 5);
            this.lblPlayerTurn.Name = "lblPlayerTurn";
            this.lblPlayerTurn.Size = new System.Drawing.Size(60, 24);
            this.lblPlayerTurn.TabIndex = 8;
            this.lblPlayerTurn.Text = "Turn:";
            // 
            // blk2
            // 
            this.blk2.AccessibleDescription = "";
            this.blk2.BackColor = System.Drawing.Color.White;
            this.blk2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk2.BackgroundImage")));
            this.blk2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk2.Location = new System.Drawing.Point(718, 32);
            this.blk2.Name = "blk2";
            this.blk2.Size = new System.Drawing.Size(71, 71);
            this.blk2.TabIndex = 10;
            this.blk2.Tag = "-5";
            this.blk2.UseVisualStyleBackColor = false;
            this.blk2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk3
            // 
            this.blk3.AccessibleDescription = "";
            this.blk3.BackColor = System.Drawing.Color.White;
            this.blk3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk3.BackgroundImage")));
            this.blk3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk3.Location = new System.Drawing.Point(795, 32);
            this.blk3.Name = "blk3";
            this.blk3.Size = new System.Drawing.Size(71, 71);
            this.blk3.TabIndex = 11;
            this.blk3.Tag = "-5";
            this.blk3.UseVisualStyleBackColor = false;
            this.blk3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk4
            // 
            this.blk4.AccessibleDescription = "";
            this.blk4.BackColor = System.Drawing.Color.White;
            this.blk4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk4.BackgroundImage")));
            this.blk4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk4.Location = new System.Drawing.Point(872, 32);
            this.blk4.Name = "blk4";
            this.blk4.Size = new System.Drawing.Size(71, 71);
            this.blk4.TabIndex = 12;
            this.blk4.Tag = "-5";
            this.blk4.UseVisualStyleBackColor = false;
            this.blk4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk8
            // 
            this.blk8.AccessibleDescription = "";
            this.blk8.BackColor = System.Drawing.Color.White;
            this.blk8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk8.BackgroundImage")));
            this.blk8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk8.Location = new System.Drawing.Point(872, 109);
            this.blk8.Name = "blk8";
            this.blk8.Size = new System.Drawing.Size(71, 71);
            this.blk8.TabIndex = 16;
            this.blk8.Tag = "-5";
            this.blk8.UseVisualStyleBackColor = false;
            this.blk8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk7
            // 
            this.blk7.AccessibleDescription = "";
            this.blk7.BackColor = System.Drawing.Color.White;
            this.blk7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk7.BackgroundImage")));
            this.blk7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk7.Location = new System.Drawing.Point(795, 109);
            this.blk7.Name = "blk7";
            this.blk7.Size = new System.Drawing.Size(71, 71);
            this.blk7.TabIndex = 15;
            this.blk7.Tag = "-5";
            this.blk7.UseVisualStyleBackColor = false;
            this.blk7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk6
            // 
            this.blk6.AccessibleDescription = "";
            this.blk6.BackColor = System.Drawing.Color.White;
            this.blk6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk6.BackgroundImage")));
            this.blk6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk6.Location = new System.Drawing.Point(718, 109);
            this.blk6.Name = "blk6";
            this.blk6.Size = new System.Drawing.Size(71, 71);
            this.blk6.TabIndex = 14;
            this.blk6.Tag = "-5";
            this.blk6.UseVisualStyleBackColor = false;
            this.blk6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk5
            // 
            this.blk5.AccessibleDescription = "";
            this.blk5.BackColor = System.Drawing.Color.White;
            this.blk5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk5.BackgroundImage")));
            this.blk5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk5.Location = new System.Drawing.Point(641, 109);
            this.blk5.Name = "blk5";
            this.blk5.Size = new System.Drawing.Size(71, 71);
            this.blk5.TabIndex = 13;
            this.blk5.Tag = "-5";
            this.blk5.UseVisualStyleBackColor = false;
            this.blk5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk16
            // 
            this.blk16.AccessibleDescription = "";
            this.blk16.BackColor = System.Drawing.Color.White;
            this.blk16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk16.BackgroundImage")));
            this.blk16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk16.Location = new System.Drawing.Point(872, 263);
            this.blk16.Name = "blk16";
            this.blk16.Size = new System.Drawing.Size(71, 71);
            this.blk16.TabIndex = 24;
            this.blk16.Tag = "-4";
            this.blk16.UseVisualStyleBackColor = false;
            this.blk16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk15
            // 
            this.blk15.AccessibleDescription = "";
            this.blk15.BackColor = System.Drawing.Color.White;
            this.blk15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk15.BackgroundImage")));
            this.blk15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk15.Location = new System.Drawing.Point(795, 263);
            this.blk15.Name = "blk15";
            this.blk15.Size = new System.Drawing.Size(71, 71);
            this.blk15.TabIndex = 23;
            this.blk15.Tag = "-4";
            this.blk15.UseVisualStyleBackColor = false;
            this.blk15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk14
            // 
            this.blk14.AccessibleDescription = "";
            this.blk14.BackColor = System.Drawing.Color.White;
            this.blk14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk14.BackgroundImage")));
            this.blk14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk14.Location = new System.Drawing.Point(718, 263);
            this.blk14.Name = "blk14";
            this.blk14.Size = new System.Drawing.Size(71, 71);
            this.blk14.TabIndex = 22;
            this.blk14.Tag = "-4";
            this.blk14.UseVisualStyleBackColor = false;
            this.blk14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk13
            // 
            this.blk13.AccessibleDescription = "";
            this.blk13.BackColor = System.Drawing.Color.White;
            this.blk13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk13.BackgroundImage")));
            this.blk13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk13.Location = new System.Drawing.Point(641, 263);
            this.blk13.Name = "blk13";
            this.blk13.Size = new System.Drawing.Size(71, 71);
            this.blk13.TabIndex = 21;
            this.blk13.Tag = "-4";
            this.blk13.UseVisualStyleBackColor = false;
            this.blk13.Click += new System.EventHandler(this.blk13_Click);
            this.blk13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk12
            // 
            this.blk12.AccessibleDescription = "";
            this.blk12.BackColor = System.Drawing.Color.White;
            this.blk12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk12.BackgroundImage")));
            this.blk12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk12.Location = new System.Drawing.Point(872, 186);
            this.blk12.Name = "blk12";
            this.blk12.Size = new System.Drawing.Size(71, 71);
            this.blk12.TabIndex = 20;
            this.blk12.Tag = "-5";
            this.blk12.UseVisualStyleBackColor = false;
            this.blk12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk11
            // 
            this.blk11.AccessibleDescription = "";
            this.blk11.BackColor = System.Drawing.Color.White;
            this.blk11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk11.BackgroundImage")));
            this.blk11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk11.Location = new System.Drawing.Point(795, 186);
            this.blk11.Name = "blk11";
            this.blk11.Size = new System.Drawing.Size(71, 71);
            this.blk11.TabIndex = 19;
            this.blk11.Tag = "-5";
            this.blk11.UseVisualStyleBackColor = false;
            this.blk11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk10
            // 
            this.blk10.AccessibleDescription = "";
            this.blk10.BackColor = System.Drawing.Color.White;
            this.blk10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk10.BackgroundImage")));
            this.blk10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk10.Location = new System.Drawing.Point(718, 186);
            this.blk10.Name = "blk10";
            this.blk10.Size = new System.Drawing.Size(71, 71);
            this.blk10.TabIndex = 18;
            this.blk10.Tag = "-5";
            this.blk10.UseVisualStyleBackColor = false;
            this.blk10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk9
            // 
            this.blk9.AccessibleDescription = "";
            this.blk9.BackColor = System.Drawing.Color.White;
            this.blk9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk9.BackgroundImage")));
            this.blk9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk9.Location = new System.Drawing.Point(641, 186);
            this.blk9.Name = "blk9";
            this.blk9.Size = new System.Drawing.Size(71, 71);
            this.blk9.TabIndex = 17;
            this.blk9.Tag = "-5";
            this.blk9.UseVisualStyleBackColor = false;
            this.blk9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk21
            // 
            this.blk21.AccessibleDescription = "";
            this.blk21.BackColor = System.Drawing.Color.White;
            this.blk21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk21.BackgroundImage")));
            this.blk21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk21.Location = new System.Drawing.Point(641, 417);
            this.blk21.Name = "blk21";
            this.blk21.Size = new System.Drawing.Size(71, 71);
            this.blk21.TabIndex = 29;
            this.blk21.Tag = "-3";
            this.blk21.UseVisualStyleBackColor = false;
            this.blk21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk20
            // 
            this.blk20.AccessibleDescription = "";
            this.blk20.BackColor = System.Drawing.Color.White;
            this.blk20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk20.BackgroundImage")));
            this.blk20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk20.Location = new System.Drawing.Point(872, 340);
            this.blk20.Name = "blk20";
            this.blk20.Size = new System.Drawing.Size(71, 71);
            this.blk20.TabIndex = 28;
            this.blk20.Tag = "-3";
            this.blk20.UseVisualStyleBackColor = false;
            this.blk20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk19
            // 
            this.blk19.AccessibleDescription = "";
            this.blk19.BackColor = System.Drawing.Color.White;
            this.blk19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk19.BackgroundImage")));
            this.blk19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk19.Location = new System.Drawing.Point(795, 340);
            this.blk19.Name = "blk19";
            this.blk19.Size = new System.Drawing.Size(71, 71);
            this.blk19.TabIndex = 27;
            this.blk19.Tag = "-2";
            this.blk19.UseVisualStyleBackColor = false;
            this.blk19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk18
            // 
            this.blk18.AccessibleDescription = "";
            this.blk18.BackColor = System.Drawing.Color.White;
            this.blk18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk18.BackgroundImage")));
            this.blk18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk18.Location = new System.Drawing.Point(718, 340);
            this.blk18.Name = "blk18";
            this.blk18.Size = new System.Drawing.Size(71, 71);
            this.blk18.TabIndex = 26;
            this.blk18.Tag = "-1";
            this.blk18.UseVisualStyleBackColor = false;
            this.blk18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // blk17
            // 
            this.blk17.AccessibleDescription = "";
            this.blk17.BackColor = System.Drawing.Color.White;
            this.blk17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("blk17.BackgroundImage")));
            this.blk17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blk17.Location = new System.Drawing.Point(641, 340);
            this.blk17.Name = "blk17";
            this.blk17.Size = new System.Drawing.Size(71, 71);
            this.blk17.TabIndex = 25;
            this.blk17.Tag = "-4";
            this.blk17.UseVisualStyleBackColor = false;
            this.blk17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blk_MouseDown);
            // 
            // btnPassTurn
            // 
            this.btnPassTurn.Location = new System.Drawing.Point(739, 508);
            this.btnPassTurn.Name = "btnPassTurn";
            this.btnPassTurn.Size = new System.Drawing.Size(75, 23);
            this.btnPassTurn.TabIndex = 9;
            this.btnPassTurn.Text = "Pass Turn";
            this.btnPassTurn.UseVisualStyleBackColor = true;
            this.btnPassTurn.Click += new System.EventHandler(this.btnPassTurn_Click);
            // 
            // frmBlokUsGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 600);
            this.Controls.Add(this.blk21);
            this.Controls.Add(this.blk20);
            this.Controls.Add(this.blk19);
            this.Controls.Add(this.blk18);
            this.Controls.Add(this.blk17);
            this.Controls.Add(this.blk16);
            this.Controls.Add(this.blk15);
            this.Controls.Add(this.blk14);
            this.Controls.Add(this.blk13);
            this.Controls.Add(this.blk12);
            this.Controls.Add(this.blk11);
            this.Controls.Add(this.blk10);
            this.Controls.Add(this.blk9);
            this.Controls.Add(this.blk8);
            this.Controls.Add(this.blk7);
            this.Controls.Add(this.blk6);
            this.Controls.Add(this.blk5);
            this.Controls.Add(this.blk4);
            this.Controls.Add(this.blk3);
            this.Controls.Add(this.blk2);
            this.Controls.Add(this.btnPassTurn);
            this.Controls.Add(this.lblPlayerTurn);
            this.Controls.Add(this.lblPlayer2Score);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1Score);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.blk1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.pnlButtons);
            this.Name = "frmBlokUsGame";
            this.Text = "Blockus Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    
        #endregion

        private System.Windows.Forms.Panel pnlButtons;



        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button blk1;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer1Score;
        private System.Windows.Forms.Label lblPlayer2Score;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPlayerTurn;
        private System.Windows.Forms.Button blk2;
        private System.Windows.Forms.Button blk3;
        private System.Windows.Forms.Button blk4;
        private System.Windows.Forms.Button blk8;
        private System.Windows.Forms.Button blk7;
        private System.Windows.Forms.Button blk6;
        private System.Windows.Forms.Button blk5;
        private System.Windows.Forms.Button blk16;
        private System.Windows.Forms.Button blk15;
        private System.Windows.Forms.Button blk14;
        private System.Windows.Forms.Button blk13;
        private System.Windows.Forms.Button blk12;
        private System.Windows.Forms.Button blk11;
        private System.Windows.Forms.Button blk10;
        private System.Windows.Forms.Button blk9;
        private System.Windows.Forms.Button blk21;
        private System.Windows.Forms.Button blk20;
        private System.Windows.Forms.Button blk19;
        private System.Windows.Forms.Button blk18;
        private System.Windows.Forms.Button blk17;
        private System.Windows.Forms.Button btnPassTurn;
    }

    
}


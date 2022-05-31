using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game05app
{
    public partial class Game : Form
    {
        bool jumping = false; 
        int jumpSpeed = 10; // integer to set jump speed
        int force = 12; // force the jump in an integer
        int score = 0; //  score integer set to 0
        int obstacleSpeed = 10; // the default speed for the obstacles
        Random rnd = new Random(); // create a new  class
        private string scoreText;
        private object gameTimer;

        public int Dino { get; private set; }

        public Game()
        {
            InitializeComponent();

            resetGame(); 
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.SuspendLayout();
            
            // Game
            // 
            this.AccessibleDescription = "Run for your life";
            this.AccessibleName = "Dino Game";
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1037, 681);
            this.Name = "Game";
            this.ContextMenuStripChanged += new System.EventHandler(this.gameEvent);
            this.Click += new System.EventHandler(this.gameEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            this.ResumeLayout(false);

        }

        private void gameEvent(object sender, EventArgs e)
        {
            Dino = jumpSpeed;

          

          
            if (jumping && force < 0)
            {
                jumping = false;
            }

           
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                
                jumpSpeed = 12;
            }

            foreach (Control x in this.Controls)
            {
               
                if (x is PictureBox && x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed; 

                    if (x.Left + x.Width < -120)
                    {
                       
                        x.Left = this.ClientSize.Width + rnd.Next(200, 800);
                        
                        score++;
                    }

                    
                    
                }
            }

            
            if (Dino >= 380 && !jumping)
            {
               
                force = 12; 
               
                jumpSpeed = 0; 
            }

            
            if (score >= 10)
            {
                
                obstacleSpeed = 15;
            }
        }

       
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                resetGame();
            }

          
            if (jumping)
            {
                jumping = false;
            }
        }

        public void resetGame()
        {
            
            force = 12;
            
            jumpSpeed = 0; 
            jumping = false; 
            score = 0; 
            obstacleSpeed = 10; 
           

            foreach (Control x in this.Controls)
            {
                
                if (x is PictureBox && x.Tag == "obstacle")
                {
                    
                    int position = rnd.Next(600, 1000);

                    
                    x.Left = 640 + (x.Left + position + x.Width * 3);
                }
            }

            
        }
    }

      
       
    
}


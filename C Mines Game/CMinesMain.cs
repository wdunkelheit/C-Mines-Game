/* FILENAME: Program.cs
 * AUTHOR: William Mack
 * Date Created: 28th January 2019
 * Data Last Modified: 8th February
 * Purpose: Create a grid based computer game with a loop.
 * Brief Description: Computer Systems Assignment
 * License: GPL v2
 *
 * Copyright (C) 2019  William Mack, University of Dundee
 * Microsoft Visual Studio, .NET and other Trademarks and Copyrights 
 * are the property of their respective owners and no infringement is intended.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 * 
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Imported Libraries
using System.Media;

namespace C_Mines_Game
{
    public partial class CMinesMain : Form
    {
        //Initialize size variables.
        int sizeX = 20;
        int sizeY = 20;

        int dif = 0;    //Initialize difficulty variable.
        int revealed = 0; //Initialized revealed variable.
        int mines = 0;  //Initialize mines variable.

        //Declare background game data types.
        List<List<Button>> buttonMatrix = new List<List<Button>>();     //2D List Matrix of Buttons
        List<List<int>> minefield = new List<List<int>>();              //2D List Matrix of int for storing logic data.
        List<string> Cheats = new List<string>();                       //1D List of active cheat codes.

        //Declare UI Elements
        Timer stopwatch = new Timer();                                  //Timer for tracking time.
        TextBox txtTimer = new TextBox();                               //Textbox for updating time.
        Button btnReset = new Button();
        Button btnMusic = new Button();
        SoundPlayer wavPlayer = new SoundPlayer(C_Mines_Game.Properties.Resources.Wallpaper);
        

        //Button[,] btn = new Button[5, 5];  //Create new button array.
        Random r = new Random();           //Random number generator.
        public CMinesMain()
        {
            InitializeComponent();              //Initialize Form
        }

        //Event handler for the 2D List Array of Buttons.
        void btnEvent_Click(object sender, EventArgs e) //Event Handler
        {
            Button sent = sender as Button;
            string[] coords = sent.Text.Split(',');
            int x = Convert.ToInt32(coords[0]);
            int y = Convert.ToInt32(coords[1]);
            Console.WriteLine("COORDINATES OF BUTTON CLICK ARE X: " + (x + 1) + " Y: " + (y + 1));

            //Run game logic on player action.
            gridCheck(y, x);
        }

        //Exit game from menu.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //Hide UI Elements - May require a new function of it's own.
            btnNewGame.Hide();
            lblCheats.Hide();
            txtCheats.Hide();
            btnCheats.Hide();
            lblWarningSticker.Hide();
            lblDifficulty.Hide();
            rdoEasy.Hide();
            rdoMedium.Hide();
            rdoHard.Hide();
            lblResolution.Hide();

            //Change window size for new grid.
            if (rdoEasy.Checked) { sizeX = 10; sizeY = 10; }
            else if (rdoMedium.Checked) { sizeX = 15; sizeY = 15; }
            else if (rdoHard.Checked) { sizeX = 20; sizeY = 20; }


            //Determine the average size of the grid for use in determining difficulty level.
            dif = (sizeX + sizeY) / 2;  //Determine grid size average.
            for (int i = 0; i < 3; i++)      //Round to nearest multiple of 3. This is the difficulty.
            {
                if (dif % 3 != 0)
                {
                    dif--;
                }
            }

            //Create reset button and define properties.
            btnReset.SetBounds(0, menuMain.Height, 180, 45); //Place button below the menu.
            btnReset.Text = "RESET";
            btnReset.BackColor = Color.White;
            btnReset.Font = btnNewGame.Font;
            btnReset.Click += new EventHandler(this.btnReset_Click);
            Controls.Add(btnReset);


            //Create Timer Textbox and define properties.
            txtTimer.SetBounds(180, menuMain.Height, 180, 45);
            txtTimer.BackColor = Color.Black;
            txtTimer.ForeColor = Color.Red;
            txtTimer.AcceptsTab = false;
            txtTimer.ReadOnly = true;
            txtTimer.Font = new Font(txtTimer.Font.FontFamily, 25);
            Controls.Add(txtTimer);

            //Spawn the grid.
            spawnMatrix();
            stopwatch.Interval = 1000;
            stopwatch.Tick += new EventHandler(tickTock);
            stopwatch.Enabled = true;
            stopwatch.Start();

            //Create music control button.
            btnMusic.SetBounds(360, menuMain.Height, 45, 45);
            btnMusic.Font = btnNewGame.Font;
            btnMusic.BackColor = Color.White;
            btnMusic.Text = "🔊";
            btnMusic.Click += new EventHandler(this.btnMusic_Click);
            wavPlayer.Play();
            Controls.Add(btnMusic);
        }

        //Start and stop music.
        private void btnMusic_Click(object sender, EventArgs e)
        {
            //If music is playing turn off.
            if (btnMusic.Text == "🔊")
            {
                btnMusic.Text = "🔇";
                wavPlayer.Stop();
            }
            //If music is off start playing.
            else
            {
                btnMusic.Text = "🔊";
                wavPlayer.Play();
            }
        }

        //Track time.
        private int ticks = 0;
        private void tickTock(object sender, EventArgs e)
        {
            //Every second increment the number of seconds passed.
            ticks++;
            txtTimer.Text = TimeSpan.FromSeconds(ticks).ToString("hh\\:mm\\:ss");
        }


        private void spawnMatrix()
        {
            //Create and place button array on the form.
            //X Axis
            for (int y = 0; y < sizeY; y++)
            {
                buttonMatrix.Add(new List<Button>());
                //Y Axis
                for (int x = 0; x < sizeX; x++)
                {
                    //Define button properties.
                    buttonMatrix[y].Add(new Button());       
                    
                    //Declare New Button
                    ///Set size of tiles according to difficulty. Make it harder to click as aswell as making the game playable on small screens.
                    if (rdoMedium.Checked){ buttonMatrix[y][x].SetBounds(30 * y, (30 * x) + (menuMain.Height + 45), 30, 30); }
                    else if(rdoHard.Checked) { buttonMatrix[y][x].SetBounds(22 * y, (22 * x) + (menuMain.Height + 45), 22, 22); }
                    else { buttonMatrix[y][x].SetBounds(45 * y, (45 * x) + (menuMain.Height + 45), 45, 45);}

                    //Change the colour of the buttons.
                    buttonMatrix[y][x].BackColor = Color.PowderBlue;  //Set Color (COLOUR)
                    buttonMatrix[y][x].ForeColor = Color.PowderBlue;  //Set Fore colour to the same to hide text.

                    //Add data to the button.
                    buttonMatrix[y][x].Text = Convert.ToString((x) + "," + (y));        //Assign Button text to coordinates.

                    //Give buttons EventHandlers and add them to the display.
                    buttonMatrix[y][x].Click += new EventHandler(this.btnEvent_Click);          //Assign Event Handler
                    Controls.Add(buttonMatrix[y][x]);                                           //Add Button to Form.
                }
            }

            //Mines placement logic.
           //Number of mines is determined by the difficulty.
            mines = dif * 3;
            if (rdoMedium.Checked) { mines *= 2; }
            if (rdoHard.Checked) { mines *= 3; }

            //ROMERO mode will spawn 1 less than the capacity for mines.
            //This is a reference to DOOM2's Ultra-Violence difficulty mode inwhich the game spawns a ridiculous number of demons to fight you.
            if (Cheats.Contains("ROMERO"))
            {
                mines = (sizeX * sizeY) - 1;
            }

            //Create the minefield logic matrix.
            for (int y = 0; y < sizeY; y++)
            {
                //Create the minefield to the size specified.
                minefield.Add(new List<int>()); //New Y Axis
                for (int x = 0; x < sizeX; x++)
                {
                    minefield[y].Add(0);
                    Console.WriteLine("X: " + x + " Y: " + y + " = " + minefield[y][x]);
                }
            }

            //Place Mines on the minefield
            for (int i = 0; i < mines; i++)
            {
                //Randomly place the mines on the board.
                //The possibility of two mines being randomly assigned the same tile is intentional, adds some small variable difficulty changes.
                int xRand = r.Next(sizeX );
                int yRand = r.Next(sizeY );
                minefield[yRand][xRand] = 1;

                //Check for RADAR cheat to facilitate alternative logic for mines.
                if (Cheats.Contains("RADAR"))
                {
                    buttonMatrix[yRand][xRand].BackColor = Color.Red;
                    buttonMatrix[yRand][xRand].ForeColor = Color.Red;
                    buttonMatrix[yRand][xRand].Image = C_Mines_Game.Properties.Resources.cmineboom;
                }
                //DEBUG Console
                Console.WriteLine("X: " + (xRand + 1) + " Y: " + (yRand + 1) + " = " + minefield[xRand][yRand] + " MINE# " + (i + 1));
            }

            //Reset to count the true number of mines.
            mines = 0;

            //Count the new number of mines.
            for (int i = 0; i < minefield.Count(); i++)
            {
                for (int j = 0; j < minefield[i].Count; j++)
                {
                    if(minefield[i][j] == 1)
                    {
                        mines++;
                    }
                }
            }
        }

        //Trigger reset.
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        //Requires non event-handler for interaction with non-button functions.
        private void reset()
        {
            //Remove the old buttons.
            for (int i = 0; i < buttonMatrix.Count; i++)
            {
                for (int j = 0; j < buttonMatrix[i].Count; j++)
                {
                    Controls.Remove(buttonMatrix[i][j]);
                }
            }

            //Clear the button matrix memory.
            buttonMatrix.Clear();

            //Clear the current mines out.
            minefield.Clear();

            //Clear timer box to prevent visual bugs. Reset Timer to 0
            txtTimer.Text = "";
            ticks = 0;
            revealed = 0;
            mines = 0;

            //Start new game.
            spawnMatrix();

            //Restart music.
            wavPlayer.Play();
            btnMusic.Text = "🔊";

            //Restart clock.
            stopwatch.Start();
        }


        //Check the grid around where the player has clicked for mines.
        private void gridCheck(int y, int x)
        {
            //Check for mines.
            if (minefield[y][x] == 1)
            {
                //Stop counting.
                stopwatch.Stop();
                //Trigger the mine.
                buttonMatrix[y][x].BackColor = Color.Red;
                buttonMatrix[y][x].ForeColor = Color.Red;
                //Inform you of your untimely demise.
                var lose = MessageBox.Show("You hit a mine! Click OK to retry.", "Game Over",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                //Reset the board.
                reset();
            }
            //No mines directly underneath that tile.
            else
            {
                //List of tiles to check. Safer method than previously planned.
                List<string> checkEm = new List<string>();
                //If on X axis boundary shift apropriately to prevent crash.
                if (x == 0) { x++; }
                else if (x == sizeX - 1) { x--; }

                //If on Y axis boundary shift apropriately to prevent crash.
                if (y == 0) { y++; }
                else if (y == sizeY - 1) { y--; }

                //Add the coorindates of the tiles to the List.
                for (int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        checkEm.Add(Convert.ToString(y - 1 + i) + "," + Convert.ToString(x - 1 +j));
                    }
                }

                //Check the tiles.
                for (int i = 0; i < 9; i++)
                {
                    //Convert text field from the buttons that stores the coordinate data to usable formats.
                    string[] coords = checkEm[i].Split(',');
                    int xVal = Convert.ToInt32(coords[1]);
                    int yVal = Convert.ToInt32(coords[0]);

                    //Check if safe.
                    if (minefield[yVal][xVal] == 0)
                    {
                        //Make sure the reveal counter isn't eploited.
                        if(buttonMatrix[yVal][xVal].BackColor == Color.PowderBlue)
                        {
                            revealed++;
                            Console.WriteLine("revealed = " + revealed + " mines = " + mines);
                        }
                        //Change button parameters to stop cheating and show what has been done.
                        buttonMatrix[yVal][xVal].BackColor = Color.Gray;
                        buttonMatrix[yVal][xVal].ForeColor = Color.Gray;
                    }
                    //Check if mine.
                    else
                    {
                        //Reveals nearby mines without triggering them.
                        buttonMatrix[yVal][xVal].BackColor = Color.Orange;
                        buttonMatrix[yVal][xVal].ForeColor = Color.Orange;
                    }
                }
            }
            //Check for victory condition.
            if(revealed == (sizeX * sizeY) - mines)
            {
                winGame();
            }
        }

        //Victory conditions met, trigger game end.
        private void winGame()
        {
            //Pauses the timer.
            stopwatch.Stop();
            //Plays victory sound.
            SoundPlayer SonyWalkman = new SoundPlayer(C_Mines_Game.Properties.Resources.powerup);
            SonyWalkman.Play();
            //Lets you know you won.
            var winner = MessageBox.Show("Congratulations, you cleared all the mines. Your time was: " + txtTimer.Text, "WE HAVE A WINNER!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }

        //Print About info.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Welcome to C Mines, the Open Source C# computer game!\n\nMade by William Mack, University of Dundee, 2019.", "ABOUT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Print license info to the screen.
        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Required GPLv2 Notice.
            var message = MessageBox.Show("C Mines is a Free Open Source computer game made for educational purposes.\n\nCopyright (C) 2019 William Mack, University of Dundee" +
                "\n\nThis program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version." +
                "\n\nThis program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details." +
                "\n\nYou should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.!" +
                "\n\nA Copy of the GPLv2 License is provided in the source folder of this program. If it is unavailable or corrupted you can view it online at https://www.gnu.org/licenses/old-licenses/gpl-2.0.txt" +
                "\n\nSelect Yes to view the GPLv2 License online or no to return to the game.", "License Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //If user wishes to view the GPLv2 License online they can do so by clicking OK.
            if (message == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.gnu.org/licenses/old-licenses/gpl-2.0.txt");
            }
        }


        //Trigger cheat entry on Enter key pressed.
        private void txtCheats_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Char 13 is a return / enter.
            if (e.KeyChar == (char)13)
            {
                enterCheat();
            }
        }

        //Trigger cheat entry.
        private void btnCheats_Click(object sender, EventArgs e)
        {
            enterCheat();
        }

        private void enterCheat()
        {
            txtCheats.Text = txtCheats.Text.ToUpper();
            if (txtCheats.Text == "ROMERO")
            {
                //Triggers ROMERO cheat.
                romero();
            }
            else if(txtCheats.Text == "RADAR")
            {
                //Creates a SoundPlayer and plays the referenced sound clip.
                SoundPlayer SonyWalkman = new SoundPlayer(C_Mines_Game.Properties.Resources.beeps);
                SonyWalkman.Play();
                
                //Change UI elements to reflect the confusing nature of a bomb radar.
                lblWarningSticker.Text = ("How does a bomb radar even work? 🤔");
                
                //Inform the user of their good fortune.
                MessageBox.Show("By some kind of miracle or sheer luck you have come across a BombRadar with a 64-bit AMD Processor.\n\nThe game will now be laughable.", "Radar.Cheat>Code", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Add RADAR to the active cheats list.
                Cheats.Add("RADAR");
            }

            else if (txtCheats.Text == "EASY" || txtCheats.Text == "MEDIUM" || txtCheats.Text == "HARD" || txtCheats.Text == "HELL")
            {
                difficultyCode(txtCheats.Text);
            }
            else
            {
                //Inform the user that their cheat code is invalid.
                MessageBox.Show("Invalid Cheat Code", "Invalid Cheat Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //The ROMERO Cheat requires it's own function due to other Cheat Codes interacting with it.
        private void romero()
        {
            //Creates a SoundPlayer and plays the referenced sound clip.
            SoundPlayer SonyWalkman = new SoundPlayer(C_Mines_Game.Properties.Resources.romero);
            SonyWalkman.Play();

            //Change UI elements to reflect the evil that has been unleashed by this cheat code.
            lblWarningSticker.Text = ("All hope is lost.👿👿👿👿👿");
            lblWarningSticker.ForeColor = Color.White;
            this.BackColor = Color.DarkRed;
            lblCheats.ForeColor = Color.White;
            btnCheats.ForeColor = Color.White;
            btnCheats.BackColor = Color.Red;
            btnNewGame.ForeColor = Color.White;
            btnNewGame.BackColor = Color.Red;

            //Inform the user of their impending DOOM.
            MessageBox.Show("You have invoked the ICON OF SIN, the path before you will be impassible.", "D2M30.Easter>Egg", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Add ROMERO to the active Cheats list.
            Cheats.Add("ROMERO");
        }

        //It's cleaner for this to be a function than repeating code.
        private void difficultyCode(string difficulty)
        {
            //Creates a SoundPlayer and plays the referenced sound clip.
            SoundPlayer SonyWalkman = new SoundPlayer(C_Mines_Game.Properties.Resources.beep);
            SonyWalkman.Play();
            
            //If HELL then special message.
            if(difficulty == "HELL")
            {
                //Change UI elements to reflect the confusing nature of a bomb radar.
                lblWarningSticker.Text = ("☠ You absolute madman! ☠");
            }
            //If not hell then standard message.
            else
            {
                //Change UI elements to ask why they didn't just click the button.
                lblWarningSticker.Text = ("Why didn't you just click the \n" + difficulty +" button? 🙂");
            }
            
            //If hell then special message.
            if(difficulty == "HELL")
            {
                //Inform the user of their misfortune.
                MessageBox.Show("Difficulty changed to " + difficulty + " mode.\n\nNow you've gone and done it!", "Hell.Difficulty>Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //If not hell then standard message.
            else
            {
                //Inform the user of difficulty change.
                MessageBox.Show("Difficulty changed to " + difficulty + " mode.", difficulty+".Difficulty>Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            //Change difficulty accordingly.
            switch (difficulty)
            {
                case "EASY":
                    //Change difficulty.
                    rdoEasy.Checked = true;
                    break;
                case "MEDIUM":
                    //Change difficulty.
                    rdoMedium.Checked = true;
                    break;
                case "HARD":
                    //Change difficulty.
                    rdoHard.Checked = true;
                    break;
                case "HELL":
                    //Change difficulty.
                    rdoHard.Checked = true;
                    romero();
                    break;
            }
        }

        //Video games have a credit screen so this is as close as I can get without intruding on the play space uninvited.
        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Audio assets were created by William Mack.\nUsing Audacity (software), a NW-700 Microphone and a Behringer UMC204HD Audio Interface.", "Audio credits.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Video games have a credit screen so this is as close as I can get without intruding on the play space uninvited.
        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All programming was completed by by William Mack.\nUsing Visual Studio 2017.", "Coding credits.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Inform user of where the music is from and which license it uses.
        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Wallpaper\" by Kevin MacLeod (incompetech.com)\n\nLicensed under Creative Commons: By Attribution 3.0\n\nhttp://creativecommons.org/licenses/by/3.0/", "Music Credits.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Inform the user who made the Icon file and other art assets used.
        private void artToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All art files were created by William Mack using the GNU Image Manipulation Program.", "Art credits.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

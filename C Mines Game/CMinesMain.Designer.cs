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
namespace C_Mines_Game
{
    partial class CMinesMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMinesMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnCheats = new System.Windows.Forms.Button();
            this.txtCheats = new System.Windows.Forms.TextBox();
            this.lblCheats = new System.Windows.Forms.Label();
            this.lblWarningSticker = new System.Windows.Forms.Label();
            this.rdoEasy = new System.Windows.Forms.RadioButton();
            this.rdoHard = new System.Windows.Forms.RadioButton();
            this.rdoMedium = new System.Windows.Forms.RadioButton();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(454, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.licenseToolStripMenuItem.Text = "License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artToolStripMenuItem,
            this.codeToolStripMenuItem,
            this.musicToolStripMenuItem,
            this.audioToolStripMenuItem});
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.creditsToolStripMenuItem.Text = "Credits";
            // 
            // artToolStripMenuItem
            // 
            this.artToolStripMenuItem.Name = "artToolStripMenuItem";
            this.artToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.artToolStripMenuItem.Text = "Art";
            this.artToolStripMenuItem.Click += new System.EventHandler(this.artToolStripMenuItem_Click);
            // 
            // codeToolStripMenuItem
            // 
            this.codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            this.codeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.codeToolStripMenuItem.Text = "Code";
            this.codeToolStripMenuItem.Click += new System.EventHandler(this.codeToolStripMenuItem_Click);
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.musicToolStripMenuItem.Text = "Music";
            this.musicToolStripMenuItem.Click += new System.EventHandler(this.musicToolStripMenuItem_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.audioToolStripMenuItem.Text = "Sound Effects";
            this.audioToolStripMenuItem.Click += new System.EventHandler(this.audioToolStripMenuItem_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnNewGame.ForeColor = System.Drawing.Color.Red;
            this.btnNewGame.Location = new System.Drawing.Point(12, 27);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(430, 57);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnCheats
            // 
            this.btnCheats.BackColor = System.Drawing.SystemColors.Control;
            this.btnCheats.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnCheats.ForeColor = System.Drawing.Color.Red;
            this.btnCheats.Location = new System.Drawing.Point(241, 400);
            this.btnCheats.Name = "btnCheats";
            this.btnCheats.Size = new System.Drawing.Size(201, 57);
            this.btnCheats.TabIndex = 2;
            this.btnCheats.Text = "Enter Cheat Code";
            this.btnCheats.UseVisualStyleBackColor = false;
            this.btnCheats.Click += new System.EventHandler(this.btnCheats_Click);
            // 
            // txtCheats
            // 
            this.txtCheats.BackColor = System.Drawing.Color.Black;
            this.txtCheats.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtCheats.ForeColor = System.Drawing.Color.Red;
            this.txtCheats.Location = new System.Drawing.Point(241, 362);
            this.txtCheats.Name = "txtCheats";
            this.txtCheats.Size = new System.Drawing.Size(201, 32);
            this.txtCheats.TabIndex = 3;
            this.txtCheats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheats_KeyPress);
            // 
            // lblCheats
            // 
            this.lblCheats.AutoSize = true;
            this.lblCheats.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblCheats.ForeColor = System.Drawing.Color.White;
            this.lblCheats.Location = new System.Drawing.Point(101, 365);
            this.lblCheats.Name = "lblCheats";
            this.lblCheats.Size = new System.Drawing.Size(134, 26);
            this.lblCheats.TabIndex = 4;
            this.lblCheats.Text = "Cheat Code:";
            // 
            // lblWarningSticker
            // 
            this.lblWarningSticker.AutoSize = true;
            this.lblWarningSticker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblWarningSticker.ForeColor = System.Drawing.Color.White;
            this.lblWarningSticker.Location = new System.Drawing.Point(12, 460);
            this.lblWarningSticker.Name = "lblWarningSticker";
            this.lblWarningSticker.Size = new System.Drawing.Size(426, 52);
            this.lblWarningSticker.TabIndex = 5;
            this.lblWarningSticker.Text = "Please note: Using cheat codes may break\r\nthe game. Use with caution.";
            // 
            // rdoEasy
            // 
            this.rdoEasy.AutoSize = true;
            this.rdoEasy.Checked = true;
            this.rdoEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.rdoEasy.ForeColor = System.Drawing.Color.White;
            this.rdoEasy.Location = new System.Drawing.Point(13, 134);
            this.rdoEasy.Name = "rdoEasy";
            this.rdoEasy.Size = new System.Drawing.Size(168, 30);
            this.rdoEasy.TabIndex = 6;
            this.rdoEasy.TabStop = true;
            this.rdoEasy.Text = "Easy (10 * 10)";
            this.rdoEasy.UseVisualStyleBackColor = true;
            // 
            // rdoHard
            // 
            this.rdoHard.AutoSize = true;
            this.rdoHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.rdoHard.ForeColor = System.Drawing.Color.White;
            this.rdoHard.Location = new System.Drawing.Point(13, 206);
            this.rdoHard.Name = "rdoHard";
            this.rdoHard.Size = new System.Drawing.Size(166, 30);
            this.rdoHard.TabIndex = 7;
            this.rdoHard.Text = "Hard (20 * 20)";
            this.rdoHard.UseVisualStyleBackColor = true;
            // 
            // rdoMedium
            // 
            this.rdoMedium.AutoSize = true;
            this.rdoMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.rdoMedium.ForeColor = System.Drawing.Color.White;
            this.rdoMedium.Location = new System.Drawing.Point(12, 170);
            this.rdoMedium.Name = "rdoMedium";
            this.rdoMedium.Size = new System.Drawing.Size(191, 30);
            this.rdoMedium.TabIndex = 8;
            this.rdoMedium.Text = "Medium (15 *15)";
            this.rdoMedium.UseVisualStyleBackColor = true;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblDifficulty.ForeColor = System.Drawing.Color.White;
            this.lblDifficulty.Location = new System.Drawing.Point(12, 105);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(182, 26);
            this.lblDifficulty.TabIndex = 9;
            this.lblDifficulty.Text = "Select a difficulty.";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblResolution.ForeColor = System.Drawing.Color.White;
            this.lblResolution.Location = new System.Drawing.Point(176, 213);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(131, 20);
            this.lblResolution.TabIndex = 10;
            this.lblResolution.Text = "- Requires 1080p";
            // 
            // CMinesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(454, 521);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.rdoMedium);
            this.Controls.Add(this.rdoHard);
            this.Controls.Add(this.rdoEasy);
            this.Controls.Add(this.lblWarningSticker);
            this.Controls.Add(this.lblCheats);
            this.Controls.Add(this.txtCheats);
            this.Controls.Add(this.btnCheats);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(470, 560);
            this.Name = "CMinesMain";
            this.Text = "C Mines";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.Button btnCheats;
        private System.Windows.Forms.TextBox txtCheats;
        private System.Windows.Forms.Label lblCheats;
        private System.Windows.Forms.Label lblWarningSticker;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdoEasy;
        private System.Windows.Forms.RadioButton rdoHard;
        private System.Windows.Forms.RadioButton rdoMedium;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.ToolStripMenuItem artToolStripMenuItem;
    }
}


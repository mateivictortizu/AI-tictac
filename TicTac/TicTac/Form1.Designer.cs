using System;
using System.Windows.Forms;

namespace TicTac
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jocNouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dificultateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxBoard = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(398, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jocToolStripMenuItem
            // 
            this.jocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jocNouToolStripMenuItem,
            this.dificultateToolStripMenuItem});
            this.jocToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.jocToolStripMenuItem.Name = "jocToolStripMenuItem";
            this.jocToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.jocToolStripMenuItem.Text = "&Joc";
            // 
            // jocNouToolStripMenuItem
            // 
            this.jocNouToolStripMenuItem.Name = "jocNouToolStripMenuItem";
            this.jocNouToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jocNouToolStripMenuItem.Text = "Joc &nou";
            this.jocNouToolStripMenuItem.Click += new System.EventHandler(this.jocNouToolStripMenuItem_Click);
            // 
            // dificultateToolStripMenuItem
            // 
            this.dificultateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usorToolStripMenuItem,
            this.greuToolStripMenuItem});
            this.dificultateToolStripMenuItem.Name = "dificultateToolStripMenuItem";
            this.dificultateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dificultateToolStripMenuItem.Text = "Dificultate";
            // 
            // usorToolStripMenuItem
            // 
            this.usorToolStripMenuItem.Checked = true;
            this.usorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.usorToolStripMenuItem.Name = "usorToolStripMenuItem";
            this.usorToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.usorToolStripMenuItem.Text = "Usor";
            this.usorToolStripMenuItem.Click += new System.EventHandler(this.usorToolStripMenuItem_Click);
            // 
            // greuToolStripMenuItem
            // 
            this.greuToolStripMenuItem.Name = "greuToolStripMenuItem";
            this.greuToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.greuToolStripMenuItem.Text = "Greu";
            this.greuToolStripMenuItem.Click += new System.EventHandler(this.greuToolStripMenuItem_Click);
            // 
            // pictureBoxBoard
            // 
            this.pictureBoxBoard.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBoard.Location = new System.Drawing.Point(0, 24);
            this.pictureBoxBoard.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxBoard.Name = "pictureBoxBoard";
            this.pictureBoxBoard.Size = new System.Drawing.Size(400, 401);
            this.pictureBoxBoard.TabIndex = 1;
            this.pictureBoxBoard.TabStop = false;
            this.pictureBoxBoard.Click += new System.EventHandler(this.pictureBoxBoard_Click);
            this.pictureBoxBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBoard_Paint);
            this.pictureBoxBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoard_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(398, 426);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBoxBoard);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Tic Tac Toe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jocNouToolStripMenuItem;
        private ToolStripMenuItem dificultateToolStripMenuItem;
        private ToolStripMenuItem usorToolStripMenuItem;
        private ToolStripMenuItem greuToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        public PictureBox pictureBoxBoard;
    }
}



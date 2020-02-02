namespace Sevens
{
    partial class StartMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            this.playButton = new System.Windows.Forms.Button();
            this.Difficulty = new System.Windows.Forms.ListBox();
            this.Rounds = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menu1 = new System.Windows.Forms.TableLayoutPanel();
            this.loadPreviousGame = new System.Windows.Forms.Button();
            this.Instructions = new System.Windows.Forms.Button();
            this.menu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playButton.Location = new System.Drawing.Point(268, 374);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(260, 154);
            this.playButton.TabIndex = 5;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // Difficulty
            // 
            this.Difficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Difficulty.FormattingEnabled = true;
            this.Difficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Difficult"});
            this.Difficulty.Location = new System.Drawing.Point(534, 270);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(261, 98);
            this.Difficulty.TabIndex = 4;
            this.Difficulty.SelectedIndexChanged += new System.EventHandler(this.Difficulty_SelectedIndexChanged);
            // 
            // Rounds
            // 
            this.Rounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rounds.FormattingEnabled = true;
            this.Rounds.Items.AddRange(new object[] {
            "One",
            "Two",
            "Three",
            "Four",
            "Five"});
            this.Rounds.Location = new System.Drawing.Point(3, 270);
            this.Rounds.Name = "Rounds";
            this.Rounds.Size = new System.Drawing.Size(259, 98);
            this.Rounds.TabIndex = 1;
            this.Rounds.SelectedIndexChanged += new System.EventHandler(this.Rounds_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(534, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pick a difficulty level:";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(268, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 267);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEVENS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(3, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "How many rounds would you like to play?";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // menu1
            // 
            this.menu1.ColumnCount = 3;
            this.menu1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menu1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.menu1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.menu1.Controls.Add(this.label2, 0, 0);
            this.menu1.Controls.Add(this.label1, 1, 0);
            this.menu1.Controls.Add(this.label3, 2, 0);
            this.menu1.Controls.Add(this.Rounds, 0, 1);
            this.menu1.Controls.Add(this.Difficulty, 2, 1);
            this.menu1.Controls.Add(this.playButton, 1, 2);
            this.menu1.Controls.Add(this.loadPreviousGame, 2, 2);
            this.menu1.Controls.Add(this.Instructions, 0, 2);
            this.menu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.RowCount = 4;
            this.menu1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.25126F));
            this.menu1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.59799F));
            this.menu1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.15075F));
            this.menu1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.menu1.Size = new System.Drawing.Size(798, 553);
            this.menu1.TabIndex = 7;
            this.menu1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // loadPreviousGame
            // 
            this.loadPreviousGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadPreviousGame.Location = new System.Drawing.Point(534, 505);
            this.loadPreviousGame.Name = "loadPreviousGame";
            this.loadPreviousGame.Size = new System.Drawing.Size(261, 23);
            this.loadPreviousGame.TabIndex = 6;
            this.loadPreviousGame.Text = "Resume previous game";
            this.loadPreviousGame.UseVisualStyleBackColor = true;
            this.loadPreviousGame.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Instructions
            // 
            this.Instructions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Instructions.Location = new System.Drawing.Point(3, 505);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(259, 23);
            this.Instructions.TabIndex = 7;
            this.Instructions.Text = "How to play";
            this.Instructions.UseVisualStyleBackColor = true;
            this.Instructions.Click += new System.EventHandler(this.Instructions_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 553);
            this.Controls.Add(this.menu1);
            this.Name = "StartMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu1.ResumeLayout(false);
            this.menu1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ListBox Difficulty;
        private System.Windows.Forms.ListBox Rounds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel menu1;
        private System.Windows.Forms.Button loadPreviousGame;
        private System.Windows.Forms.Button Instructions;
    }
}


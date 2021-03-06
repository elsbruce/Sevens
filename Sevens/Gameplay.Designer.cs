﻿namespace Sevens
{
    partial class Gameplay
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
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.sortValue = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.skipTurnButton = new System.Windows.Forms.Button();
            this.SortSuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.BackColor = System.Drawing.Color.ForestGreen;
            this.tablePanel.ColumnCount = 16;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249691F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249693F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.254592F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249692F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.249691F));
            this.tablePanel.Controls.Add(this.sortValue, 15, 5);
            this.tablePanel.Controls.Add(this.pauseButton, 15, 3);
            this.tablePanel.Controls.Add(this.skipTurnButton, 14, 3);
            this.tablePanel.Controls.Add(this.SortSuit, 14, 5);
            this.tablePanel.Controls.Add(this.label1, 14, 0);
            this.tablePanel.Controls.Add(this.label2, 14, 1);
            this.tablePanel.Controls.Add(this.label3, 14, 2);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 6;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.15708F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.15709F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.15709F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.15709F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.214563F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.15709F));
            this.tablePanel.Size = new System.Drawing.Size(777, 447);
            this.tablePanel.TabIndex = 0;
            this.tablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TablePanel_Paint);
            // 
            // sortValue
            // 
            this.sortValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortValue.Location = new System.Drawing.Point(723, 361);
            this.sortValue.Name = "sortValue";
            this.sortValue.Size = new System.Drawing.Size(51, 83);
            this.sortValue.TabIndex = 0;
            this.sortValue.Text = "Sort by Value";
            this.sortValue.UseVisualStyleBackColor = true;
            this.sortValue.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pauseButton.Location = new System.Drawing.Point(723, 258);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(51, 79);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "PAUSE";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // skipTurnButton
            // 
            this.skipTurnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skipTurnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skipTurnButton.Location = new System.Drawing.Point(675, 258);
            this.skipTurnButton.Name = "skipTurnButton";
            this.skipTurnButton.Size = new System.Drawing.Size(42, 79);
            this.skipTurnButton.TabIndex = 1;
            this.skipTurnButton.Text = "PASS";
            this.skipTurnButton.UseVisualStyleBackColor = true;
            this.skipTurnButton.Click += new System.EventHandler(this.SkipTurn_Click);
            // 
            // SortSuit
            // 
            this.SortSuit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SortSuit.Location = new System.Drawing.Point(675, 361);
            this.SortSuit.Name = "SortSuit";
            this.SortSuit.Size = new System.Drawing.Size(42, 83);
            this.SortSuit.TabIndex = 3;
            this.SortSuit.Text = "Sort by Suit";
            this.SortSuit.UseVisualStyleBackColor = true;
            this.SortSuit.Click += new System.EventHandler(this.SortSuit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(676, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 85);
            this.label1.TabIndex = 4;
            this.label1.Text = "AI PLAYER 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(676, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 85);
            this.label2.TabIndex = 5;
            this.label2.Text = "AI PLAYER 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(676, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 85);
            this.label3.TabIndex = 6;
            this.label3.Text = "AI PLAYER 3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Gameplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(777, 447);
            this.Controls.Add(this.tablePanel);
            this.Name = "Gameplay";
            this.Text = "Gameplay";
            this.tablePanel.ResumeLayout(false);
            this.tablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.Button sortValue;
        private System.Windows.Forms.Button skipTurnButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button SortSuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
    }
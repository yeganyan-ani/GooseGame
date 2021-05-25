
namespace GooseGame.View
{
    partial class GameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRollDice = new System.Windows.Forms.Button();
            this.buttonRules = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelRollingDice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRollDice);
            this.panel1.Controls.Add(this.buttonRules);
            this.panel1.Controls.Add(this.buttonReset);
            this.panel1.Controls.Add(this.labelRollingDice);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panelBoard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 521);
            this.panel1.TabIndex = 0;
            // 
            // buttonRollDice
            // 
            this.buttonRollDice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRollDice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRollDice.Location = new System.Drawing.Point(678, 442);
            this.buttonRollDice.Name = "buttonRollDice";
            this.buttonRollDice.Size = new System.Drawing.Size(94, 46);
            this.buttonRollDice.TabIndex = 1;
            this.buttonRollDice.Text = "Roll Dice";
            this.buttonRollDice.UseVisualStyleBackColor = true;
            this.buttonRollDice.Click += new System.EventHandler(this.buttonRollDice_Click);
            // 
            // buttonRules
            // 
            this.buttonRules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRules.Location = new System.Drawing.Point(578, 442);
            this.buttonRules.Name = "buttonRules";
            this.buttonRules.Size = new System.Drawing.Size(94, 46);
            this.buttonRules.TabIndex = 5;
            this.buttonRules.Text = "Rules";
            this.buttonRules.UseVisualStyleBackColor = true;
            this.buttonRules.Click += new System.EventHandler(this.buttonRules_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(478, 442);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(94, 46);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelRollingDice
            // 
            this.labelRollingDice.AutoSize = true;
            this.labelRollingDice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRollingDice.Location = new System.Drawing.Point(393, 451);
            this.labelRollingDice.Name = "labelRollingDice";
            this.labelRollingDice.Size = new System.Drawing.Size(21, 24);
            this.labelRollingDice.TabIndex = 3;
            this.labelRollingDice.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 455);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rolling Dice:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelBoard
            // 
            this.panelBoard.Controls.Add(this.label1);
            this.panelBoard.Location = new System.Drawing.Point(12, 12);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(760, 400);
            this.panelBoard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rolling Dice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // VistaDiGioco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goose Game";
            this.Load += new System.EventHandler(this.GameView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBoard.ResumeLayout(false);
            this.panelBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelRollingDice;
        private System.Windows.Forms.Button buttonRollDice;
        private System.Windows.Forms.Button buttonRules;
    }
}
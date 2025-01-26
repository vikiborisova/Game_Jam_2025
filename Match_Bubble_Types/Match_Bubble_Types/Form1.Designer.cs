namespace Match_Bubble_Types
{
    partial class Match_Bubble_Types
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestart.Location = new System.Drawing.Point(531, 651);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(136, 46);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.RestartGameEvent);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimeLeft.Location = new System.Drawing.Point(673, 659);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(190, 38);
            this.lblTimeLeft.TabIndex = 1;
            this.lblTimeLeft.Text = "Time Left: 60";
            this.lblTimeLeft.Click += new System.EventHandler(this.lblTimeLeft_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 900;
            this.GameTimer.Tick += new System.EventHandler(this.TimerEvent);
            // 
            // Match_Bubble_Types
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.btnRestart);
            this.Name = "Match_Bubble_Types";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match Bubble Types";
            this.Load += new System.EventHandler(this.Match_Bubble_Types_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnRestart;
        private Label lblTimeLeft;
        private System.Windows.Forms.Timer GameTimer;
    }
}
namespace ATCSimTest
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
            this.components = new System.ComponentModel.Container();
            this.radarScreen = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.acListBox = new System.Windows.Forms.ListBox();
            this.turnTestbtn = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radarScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // radarScreen
            // 
            this.radarScreen.BackColor = System.Drawing.Color.LightSlateGray;
            this.radarScreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.radarScreen.Location = new System.Drawing.Point(13, 28);
            this.radarScreen.Name = "radarScreen";
            this.radarScreen.Size = new System.Drawing.Size(759, 689);
            this.radarScreen.TabIndex = 1;
            this.radarScreen.TabStop = false;
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(778, 246);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Enabled = false;
            this.pauseBtn.Location = new System.Drawing.Point(778, 276);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseBtn.TabIndex = 3;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // acListBox
            // 
            this.acListBox.FormattingEnabled = true;
            this.acListBox.Location = new System.Drawing.Point(779, 28);
            this.acListBox.Name = "acListBox";
            this.acListBox.Size = new System.Drawing.Size(127, 212);
            this.acListBox.TabIndex = 4;
            // 
            // turnTestbtn
            // 
            this.turnTestbtn.Location = new System.Drawing.Point(779, 305);
            this.turnTestbtn.Name = "turnTestbtn";
            this.turnTestbtn.Size = new System.Drawing.Size(75, 23);
            this.turnTestbtn.TabIndex = 5;
            this.turnTestbtn.Text = "Test turn";
            this.turnTestbtn.UseVisualStyleBackColor = true;
            this.turnTestbtn.Click += new System.EventHandler(this.turnTestbtn_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(779, 335);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(423, 289);
            this.logBox.TabIndex = 6;
            this.logBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 734);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.turnTestbtn);
            this.Controls.Add(this.acListBox);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.radarScreen);
            this.Name = "Form1";
            this.Text = "ATC Sim Test";
            ((System.ComponentModel.ISupportInitialize)(this.radarScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox radarScreen;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox acListBox;
        private System.Windows.Forms.Button turnTestbtn;
        private System.Windows.Forms.RichTextBox logBox;
    }
}


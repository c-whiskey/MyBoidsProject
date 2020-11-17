namespace MyBoids
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
            this.Renderer = new System.Windows.Forms.GroupBox();
            this.CPUParRadBut = new System.Windows.Forms.RadioButton();
            this.CpuSeqRadBut = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BoidCountLabel = new System.Windows.Forms.Label();
            this.FPSLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.VisionLabel = new System.Windows.Forms.Label();
            this.AttractLabel = new System.Windows.Forms.Label();
            this.AvoidLabel = new System.Windows.Forms.Label();
            this.AlignLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.VisionTrackBar = new System.Windows.Forms.TrackBar();
            this.AttractTrackBar = new System.Windows.Forms.TrackBar();
            this.AvoidTrackBar = new System.Windows.Forms.TrackBar();
            this.AlignTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.RenderArea = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RecordButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Renderer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisionTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttractTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvoidTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlignTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RenderArea)).BeginInit();
            this.SuspendLayout();
            // 
            // Renderer
            // 
            this.Renderer.Controls.Add(this.CPUParRadBut);
            this.Renderer.Controls.Add(this.CpuSeqRadBut);
            this.Renderer.Location = new System.Drawing.Point(12, 12);
            this.Renderer.Name = "Renderer";
            this.Renderer.Size = new System.Drawing.Size(120, 74);
            this.Renderer.TabIndex = 0;
            this.Renderer.TabStop = false;
            this.Renderer.Text = "Renderer";
            // 
            // CPUParRadBut
            // 
            this.CPUParRadBut.AutoSize = true;
            this.CPUParRadBut.Location = new System.Drawing.Point(7, 43);
            this.CPUParRadBut.Name = "CPUParRadBut";
            this.CPUParRadBut.Size = new System.Drawing.Size(90, 17);
            this.CPUParRadBut.TabIndex = 1;
            this.CPUParRadBut.TabStop = true;
            this.CPUParRadBut.Text = "CPU - Parallel";
            this.CPUParRadBut.UseVisualStyleBackColor = true;
            this.CPUParRadBut.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // CpuSeqRadBut
            // 
            this.CpuSeqRadBut.AutoSize = true;
            this.CpuSeqRadBut.Location = new System.Drawing.Point(6, 19);
            this.CpuSeqRadBut.Name = "CpuSeqRadBut";
            this.CpuSeqRadBut.Size = new System.Drawing.Size(106, 17);
            this.CpuSeqRadBut.TabIndex = 0;
            this.CpuSeqRadBut.TabStop = true;
            this.CpuSeqRadBut.Text = "CPU - Sequential";
            this.CpuSeqRadBut.UseVisualStyleBackColor = true;
            this.CpuSeqRadBut.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // BoidCountLabel
            // 
            this.BoidCountLabel.AutoSize = true;
            this.BoidCountLabel.Location = new System.Drawing.Point(9, 98);
            this.BoidCountLabel.Name = "BoidCountLabel";
            this.BoidCountLabel.Size = new System.Drawing.Size(90, 13);
            this.BoidCountLabel.TabIndex = 1;
            this.BoidCountLabel.Text = "Boids On Screen:";
            // 
            // FPSLabel
            // 
            this.FPSLabel.AutoSize = true;
            this.FPSLabel.Location = new System.Drawing.Point(9, 123);
            this.FPSLabel.Name = "FPSLabel";
            this.FPSLabel.Size = new System.Drawing.Size(33, 13);
            this.FPSLabel.TabIndex = 2;
            this.FPSLabel.Text = "FPS: ";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(11, 148);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(98, 33);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // VisionLabel
            // 
            this.VisionLabel.AutoSize = true;
            this.VisionLabel.Location = new System.Drawing.Point(43, 197);
            this.VisionLabel.Name = "VisionLabel";
            this.VisionLabel.Size = new System.Drawing.Size(35, 13);
            this.VisionLabel.TabIndex = 4;
            this.VisionLabel.Text = "Vision";
            // 
            // AttractLabel
            // 
            this.AttractLabel.AutoSize = true;
            this.AttractLabel.Location = new System.Drawing.Point(43, 261);
            this.AttractLabel.Name = "AttractLabel";
            this.AttractLabel.Size = new System.Drawing.Size(38, 13);
            this.AttractLabel.TabIndex = 5;
            this.AttractLabel.Text = "Attract";
            // 
            // AvoidLabel
            // 
            this.AvoidLabel.AutoSize = true;
            this.AvoidLabel.Location = new System.Drawing.Point(44, 325);
            this.AvoidLabel.Name = "AvoidLabel";
            this.AvoidLabel.Size = new System.Drawing.Size(34, 13);
            this.AvoidLabel.TabIndex = 6;
            this.AvoidLabel.Text = "Avoid";
            // 
            // AlignLabel
            // 
            this.AlignLabel.AutoSize = true;
            this.AlignLabel.Location = new System.Drawing.Point(43, 389);
            this.AlignLabel.Name = "AlignLabel";
            this.AlignLabel.Size = new System.Drawing.Size(30, 13);
            this.AlignLabel.TabIndex = 7;
            this.AlignLabel.Text = "Align";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(43, 453);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(38, 13);
            this.SpeedLabel.TabIndex = 8;
            this.SpeedLabel.Text = "Speed";
            // 
            // VisionTrackBar
            // 
            this.VisionTrackBar.Location = new System.Drawing.Point(12, 213);
            this.VisionTrackBar.Maximum = 9;
            this.VisionTrackBar.Minimum = 1;
            this.VisionTrackBar.Name = "VisionTrackBar";
            this.VisionTrackBar.Size = new System.Drawing.Size(104, 45);
            this.VisionTrackBar.TabIndex = 9;
            this.VisionTrackBar.Value = 5;
            this.VisionTrackBar.Scroll += new System.EventHandler(this.VisionTrackBar_Scroll);
            // 
            // AttractTrackBar
            // 
            this.AttractTrackBar.Location = new System.Drawing.Point(12, 277);
            this.AttractTrackBar.Maximum = 9;
            this.AttractTrackBar.Minimum = 1;
            this.AttractTrackBar.Name = "AttractTrackBar";
            this.AttractTrackBar.Size = new System.Drawing.Size(104, 45);
            this.AttractTrackBar.TabIndex = 10;
            this.AttractTrackBar.Value = 5;
            this.AttractTrackBar.Scroll += new System.EventHandler(this.AttractTrackBar_Scroll);
            // 
            // AvoidTrackBar
            // 
            this.AvoidTrackBar.Location = new System.Drawing.Point(12, 341);
            this.AvoidTrackBar.Maximum = 9;
            this.AvoidTrackBar.Minimum = 1;
            this.AvoidTrackBar.Name = "AvoidTrackBar";
            this.AvoidTrackBar.Size = new System.Drawing.Size(104, 45);
            this.AvoidTrackBar.TabIndex = 11;
            this.AvoidTrackBar.Value = 5;
            this.AvoidTrackBar.Scroll += new System.EventHandler(this.AvoidTrackBar_Scroll);
            // 
            // AlignTrackBar
            // 
            this.AlignTrackBar.Location = new System.Drawing.Point(12, 405);
            this.AlignTrackBar.Maximum = 9;
            this.AlignTrackBar.Minimum = 1;
            this.AlignTrackBar.Name = "AlignTrackBar";
            this.AlignTrackBar.Size = new System.Drawing.Size(104, 45);
            this.AlignTrackBar.TabIndex = 12;
            this.AlignTrackBar.Value = 5;
            this.AlignTrackBar.Scroll += new System.EventHandler(this.AlignTrackBar_Scroll);
            // 
            // SpeedTrackBar
            // 
            this.SpeedTrackBar.Location = new System.Drawing.Point(12, 469);
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(104, 45);
            this.SpeedTrackBar.TabIndex = 13;
            this.SpeedTrackBar.Value = 5;
            this.SpeedTrackBar.Scroll += new System.EventHandler(this.SpeedTrackBar_Scroll);
            // 
            // RenderArea
            // 
            this.RenderArea.Location = new System.Drawing.Point(138, 12);
            this.RenderArea.Name = "RenderArea";
            this.RenderArea.Size = new System.Drawing.Size(942, 657);
            this.RenderArea.TabIndex = 14;
            this.RenderArea.TabStop = false;
            this.RenderArea.Click += new System.EventHandler(this.RenderArea_Click);
            this.RenderArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RenderArea_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(19, 552);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(92, 32);
            this.RecordButton.TabIndex = 15;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(21, 602);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(90, 32);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 681);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.RenderArea);
            this.Controls.Add(this.SpeedTrackBar);
            this.Controls.Add(this.AlignTrackBar);
            this.Controls.Add(this.AvoidTrackBar);
            this.Controls.Add(this.AttractTrackBar);
            this.Controls.Add(this.VisionTrackBar);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.AlignLabel);
            this.Controls.Add(this.AvoidLabel);
            this.Controls.Add(this.AttractLabel);
            this.Controls.Add(this.VisionLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.FPSLabel);
            this.Controls.Add(this.BoidCountLabel);
            this.Controls.Add(this.Renderer);
            this.Name = "Form1";
            this.Text = "CAB401 - CW - Parallel project";
            this.Renderer.ResumeLayout(false);
            this.Renderer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisionTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttractTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvoidTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlignTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RenderArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Renderer;
        private System.Windows.Forms.RadioButton CPUParRadBut;
        private System.Windows.Forms.RadioButton CpuSeqRadBut;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label BoidCountLabel;
        private System.Windows.Forms.Label FPSLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label VisionLabel;
        private System.Windows.Forms.Label AttractLabel;
        private System.Windows.Forms.Label AvoidLabel;
        private System.Windows.Forms.Label AlignLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.TrackBar VisionTrackBar;
        private System.Windows.Forms.TrackBar AttractTrackBar;
        private System.Windows.Forms.TrackBar AvoidTrackBar;
        private System.Windows.Forms.TrackBar AlignTrackBar;
        private System.Windows.Forms.TrackBar SpeedTrackBar;
        private System.Windows.Forms.PictureBox RenderArea;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button SaveButton;
    }
}


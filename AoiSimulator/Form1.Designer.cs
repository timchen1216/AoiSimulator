namespace AoiSimulator
{
    partial class Form1
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
            pictureBox1 = new PictureBox();
            btnCapture = new Button();
            lblResult = new Label();
            lblStats = new Label();
            btnStart = new Button();
            btnStop = new Button();
            lblState = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(85, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(291, 93);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(139, 55);
            btnCapture.TabIndex = 1;
            btnCapture.Text = "拍照檢測";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            lblResult.Location = new Point(447, 93);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(123, 35);
            lblResult.TabIndex = 2;
            lblResult.Text = "尚未檢測";
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            lblStats.Location = new Point(447, 165);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(123, 35);
            lblStats.TabIndex = 3;
            lblStats.Text = "尚無統計";
            lblStats.Click += lblStats_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(291, 165);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(139, 58);
            btnStart.TabIndex = 4;
            btnStart.Text = "開始";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(291, 235);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(139, 58);
            btnStop.TabIndex = 5;
            btnStop.Text = "結束";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            lblState.Location = new Point(447, 235);
            lblState.Name = "lblState";
            lblState.Size = new Size(143, 35);
            lblState.TabIndex = 7;
            lblState.Text = "狀態：Idle";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 450);
            Controls.Add(lblState);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblStats);
            Controls.Add(lblResult);
            Controls.Add(btnCapture);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Mini AOI Simulator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnCapture;
        private Label lblResult;
        private Label lblStats;
        private Button btnStart;
        private Button btnStop;
        private Label lblState;
    }
}

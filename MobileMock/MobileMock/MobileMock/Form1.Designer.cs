namespace MobileMock
{
    partial class mainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxServerAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gbxControls = new System.Windows.Forms.GroupBox();
            this.pnlMovementControls = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnRegisterAsRemote = new System.Windows.Forms.Button();
            this.gbxReceivedMessages = new System.Windows.Forms.GroupBox();
            this.lblObstacleEventData = new System.Windows.Forms.Label();
            this.pbxObstacle = new System.Windows.Forms.PictureBox();
            this.lstbxReceivedMessages = new System.Windows.Forms.ListBox();
            this.btnStartNewMap = new System.Windows.Forms.Button();
            this.gbxControls.SuspendLayout();
            this.pnlMovementControls.SuspendLayout();
            this.gbxReceivedMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxObstacle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Address";
            // 
            // tbxServerAddress
            // 
            this.tbxServerAddress.Location = new System.Drawing.Point(12, 27);
            this.tbxServerAddress.Name = "tbxServerAddress";
            this.tbxServerAddress.Size = new System.Drawing.Size(161, 23);
            this.tbxServerAddress.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(179, 27);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // gbxControls
            // 
            this.gbxControls.Controls.Add(this.btnStartNewMap);
            this.gbxControls.Controls.Add(this.pnlMovementControls);
            this.gbxControls.Controls.Add(this.btnMode);
            this.gbxControls.Controls.Add(this.btnRegisterAsRemote);
            this.gbxControls.Location = new System.Drawing.Point(12, 56);
            this.gbxControls.Name = "gbxControls";
            this.gbxControls.Size = new System.Drawing.Size(460, 416);
            this.gbxControls.TabIndex = 3;
            this.gbxControls.TabStop = false;
            this.gbxControls.Text = "Controls";
            // 
            // pnlMovementControls
            // 
            this.pnlMovementControls.Controls.Add(this.btnUp);
            this.pnlMovementControls.Controls.Add(this.btnRight);
            this.pnlMovementControls.Controls.Add(this.btnDown);
            this.pnlMovementControls.Controls.Add(this.btnLeft);
            this.pnlMovementControls.Location = new System.Drawing.Point(9, 255);
            this.pnlMovementControls.Name = "pnlMovementControls";
            this.pnlMovementControls.Size = new System.Drawing.Size(233, 155);
            this.pnlMovementControls.TabIndex = 2;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(81, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(72, 72);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForwardStart);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveForwardStop);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(158, 80);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(72, 72);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveRightStart);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveRightStop);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(81, 80);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(72, 72);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBackwardStart);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBackwardStop);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(3, 80);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(72, 72);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveLeftStart);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveLeftStop);
            // 
            // btnMode
            // 
            this.btnMode.Location = new System.Drawing.Point(9, 51);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(125, 23);
            this.btnMode.TabIndex = 1;
            this.btnMode.Text = "Autonomous";
            this.btnMode.UseVisualStyleBackColor = true;
            // 
            // btnRegisterAsRemote
            // 
            this.btnRegisterAsRemote.Location = new System.Drawing.Point(9, 22);
            this.btnRegisterAsRemote.Name = "btnRegisterAsRemote";
            this.btnRegisterAsRemote.Size = new System.Drawing.Size(125, 23);
            this.btnRegisterAsRemote.TabIndex = 0;
            this.btnRegisterAsRemote.Text = "Register as remote";
            this.btnRegisterAsRemote.UseVisualStyleBackColor = true;
            this.btnRegisterAsRemote.Click += new System.EventHandler(this.btnRegisterAsRemote_Click);
            // 
            // gbxReceivedMessages
            // 
            this.gbxReceivedMessages.Controls.Add(this.lblObstacleEventData);
            this.gbxReceivedMessages.Controls.Add(this.pbxObstacle);
            this.gbxReceivedMessages.Controls.Add(this.lstbxReceivedMessages);
            this.gbxReceivedMessages.Location = new System.Drawing.Point(478, 9);
            this.gbxReceivedMessages.Name = "gbxReceivedMessages";
            this.gbxReceivedMessages.Size = new System.Drawing.Size(411, 463);
            this.gbxReceivedMessages.TabIndex = 4;
            this.gbxReceivedMessages.TabStop = false;
            this.gbxReceivedMessages.Text = "Received Message";
            // 
            // lblObstacleEventData
            // 
            this.lblObstacleEventData.AutoSize = true;
            this.lblObstacleEventData.Location = new System.Drawing.Point(6, 283);
            this.lblObstacleEventData.Name = "lblObstacleEventData";
            this.lblObstacleEventData.Size = new System.Drawing.Size(112, 15);
            this.lblObstacleEventData.TabIndex = 2;
            this.lblObstacleEventData.Text = "Obstacle Event Data";
            // 
            // pbxObstacle
            // 
            this.pbxObstacle.Location = new System.Drawing.Point(203, 283);
            this.pbxObstacle.Name = "pbxObstacle";
            this.pbxObstacle.Size = new System.Drawing.Size(202, 174);
            this.pbxObstacle.TabIndex = 1;
            this.pbxObstacle.TabStop = false;
            // 
            // lstbxReceivedMessages
            // 
            this.lstbxReceivedMessages.FormattingEnabled = true;
            this.lstbxReceivedMessages.ItemHeight = 15;
            this.lstbxReceivedMessages.Location = new System.Drawing.Point(6, 18);
            this.lstbxReceivedMessages.Name = "lstbxReceivedMessages";
            this.lstbxReceivedMessages.Size = new System.Drawing.Size(399, 259);
            this.lstbxReceivedMessages.TabIndex = 0;
            // 
            // btnStartNewMap
            // 
            this.btnStartNewMap.Location = new System.Drawing.Point(9, 80);
            this.btnStartNewMap.Name = "btnStartNewMap";
            this.btnStartNewMap.Size = new System.Drawing.Size(125, 23);
            this.btnStartNewMap.TabIndex = 3;
            this.btnStartNewMap.Text = "Start new map";
            this.btnStartNewMap.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 484);
            this.Controls.Add(this.gbxReceivedMessages);
            this.Controls.Add(this.gbxControls);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbxServerAddress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "mainForm";
            this.Text = "WallE Mobile Mock";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.gbxControls.ResumeLayout(false);
            this.pnlMovementControls.ResumeLayout(false);
            this.gbxReceivedMessages.ResumeLayout(false);
            this.gbxReceivedMessages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxObstacle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbxServerAddress;
        private Button btnConnect;
        private GroupBox gbxControls;
        private Panel pnlMovementControls;
        private Button btnUp;
        private Button btnRight;
        private Button btnDown;
        private Button btnLeft;
        private Button btnMode;
        private Button btnRegisterAsRemote;
        private GroupBox gbxReceivedMessages;
        private Label lblObstacleEventData;
        private PictureBox pbxObstacle;
        private ListBox lstbxReceivedMessages;
        private Button btnStartNewMap;
    }
}
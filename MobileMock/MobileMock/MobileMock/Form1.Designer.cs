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
            this.btnStartNewMap = new System.Windows.Forms.Button();
            this.pnlMovementControls = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnRegisterAsRemote = new System.Windows.Forms.Button();
            this.gbxReceivedMessages = new System.Windows.Forms.GroupBox();
            this.gbxSelectObstacleEventData = new System.Windows.Forms.GroupBox();
            this.lblObstacleEventDocumentId = new System.Windows.Forms.Label();
            this.lblObstacleEventLabel = new System.Windows.Forms.Label();
            this.lblObstacleEventPosition = new System.Windows.Forms.Label();
            this.lblObstacleEventUrl = new System.Windows.Forms.Label();
            this.pbxObstacleEventImage = new System.Windows.Forms.PictureBox();
            this.btnCopyObstacleEventImageUrl = new System.Windows.Forms.Button();
            this.gbxPositionData = new System.Windows.Forms.GroupBox();
            this.lstbxReceivedPositionData = new System.Windows.Forms.ListBox();
            this.lstbxReceivedMessages = new System.Windows.Forms.ListBox();
            this.lblObstacleEvents = new System.Windows.Forms.Label();
            this.lstbxObstacleEvents = new System.Windows.Forms.ListBox();
            this.gbxControls.SuspendLayout();
            this.pnlMovementControls.SuspendLayout();
            this.gbxReceivedMessages.SuspendLayout();
            this.gbxSelectObstacleEventData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxObstacleEventImage)).BeginInit();
            this.gbxPositionData.SuspendLayout();
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
            this.gbxControls.Size = new System.Drawing.Size(272, 306);
            this.gbxControls.TabIndex = 3;
            this.gbxControls.TabStop = false;
            this.gbxControls.Text = "Controls";
            // 
            // btnStartNewMap
            // 
            this.btnStartNewMap.Location = new System.Drawing.Point(9, 51);
            this.btnStartNewMap.Name = "btnStartNewMap";
            this.btnStartNewMap.Size = new System.Drawing.Size(125, 23);
            this.btnStartNewMap.TabIndex = 3;
            this.btnStartNewMap.Text = "Start new map";
            this.btnStartNewMap.UseVisualStyleBackColor = true;
            // 
            // pnlMovementControls
            // 
            this.pnlMovementControls.Controls.Add(this.btnUp);
            this.pnlMovementControls.Controls.Add(this.btnRight);
            this.pnlMovementControls.Controls.Add(this.btnDown);
            this.pnlMovementControls.Controls.Add(this.btnLeft);
            this.pnlMovementControls.Location = new System.Drawing.Point(6, 128);
            this.pnlMovementControls.Name = "pnlMovementControls";
            this.pnlMovementControls.Size = new System.Drawing.Size(257, 169);
            this.pnlMovementControls.TabIndex = 2;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(93, 2);
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
            this.btnRight.Location = new System.Drawing.Point(182, 87);
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
            this.btnDown.Location = new System.Drawing.Point(93, 87);
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
            this.btnLeft.Location = new System.Drawing.Point(3, 87);
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
            this.btnMode.Location = new System.Drawing.Point(138, 22);
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
            this.gbxReceivedMessages.Controls.Add(this.gbxSelectObstacleEventData);
            this.gbxReceivedMessages.Controls.Add(this.gbxPositionData);
            this.gbxReceivedMessages.Controls.Add(this.lstbxReceivedMessages);
            this.gbxReceivedMessages.Controls.Add(this.lblObstacleEvents);
            this.gbxReceivedMessages.Controls.Add(this.lstbxObstacleEvents);
            this.gbxReceivedMessages.Location = new System.Drawing.Point(290, 12);
            this.gbxReceivedMessages.Name = "gbxReceivedMessages";
            this.gbxReceivedMessages.Size = new System.Drawing.Size(566, 350);
            this.gbxReceivedMessages.TabIndex = 4;
            this.gbxReceivedMessages.TabStop = false;
            this.gbxReceivedMessages.Text = "Received Messages";
            // 
            // gbxSelectObstacleEventData
            // 
            this.gbxSelectObstacleEventData.Controls.Add(this.lblObstacleEventDocumentId);
            this.gbxSelectObstacleEventData.Controls.Add(this.lblObstacleEventLabel);
            this.gbxSelectObstacleEventData.Controls.Add(this.lblObstacleEventPosition);
            this.gbxSelectObstacleEventData.Controls.Add(this.lblObstacleEventUrl);
            this.gbxSelectObstacleEventData.Controls.Add(this.pbxObstacleEventImage);
            this.gbxSelectObstacleEventData.Controls.Add(this.btnCopyObstacleEventImageUrl);
            this.gbxSelectObstacleEventData.Location = new System.Drawing.Point(203, 154);
            this.gbxSelectObstacleEventData.Name = "gbxSelectObstacleEventData";
            this.gbxSelectObstacleEventData.Size = new System.Drawing.Size(354, 187);
            this.gbxSelectObstacleEventData.TabIndex = 11;
            this.gbxSelectObstacleEventData.TabStop = false;
            this.gbxSelectObstacleEventData.Text = "Selected Obstacle Event Data";
            // 
            // lblObstacleEventDocumentId
            // 
            this.lblObstacleEventDocumentId.AutoSize = true;
            this.lblObstacleEventDocumentId.Location = new System.Drawing.Point(6, 19);
            this.lblObstacleEventDocumentId.Name = "lblObstacleEventDocumentId";
            this.lblObstacleEventDocumentId.Size = new System.Drawing.Size(73, 15);
            this.lblObstacleEventDocumentId.TabIndex = 3;
            this.lblObstacleEventDocumentId.Text = "DocumentId";
            // 
            // lblObstacleEventLabel
            // 
            this.lblObstacleEventLabel.AutoSize = true;
            this.lblObstacleEventLabel.Location = new System.Drawing.Point(6, 34);
            this.lblObstacleEventLabel.Name = "lblObstacleEventLabel";
            this.lblObstacleEventLabel.Size = new System.Drawing.Size(35, 15);
            this.lblObstacleEventLabel.TabIndex = 4;
            this.lblObstacleEventLabel.Text = "Label";
            // 
            // lblObstacleEventPosition
            // 
            this.lblObstacleEventPosition.AutoSize = true;
            this.lblObstacleEventPosition.Location = new System.Drawing.Point(6, 49);
            this.lblObstacleEventPosition.Name = "lblObstacleEventPosition";
            this.lblObstacleEventPosition.Size = new System.Drawing.Size(50, 15);
            this.lblObstacleEventPosition.TabIndex = 5;
            this.lblObstacleEventPosition.Text = "Position";
            // 
            // lblObstacleEventUrl
            // 
            this.lblObstacleEventUrl.Location = new System.Drawing.Point(6, 64);
            this.lblObstacleEventUrl.Name = "lblObstacleEventUrl";
            this.lblObstacleEventUrl.Size = new System.Drawing.Size(164, 15);
            this.lblObstacleEventUrl.TabIndex = 6;
            this.lblObstacleEventUrl.Text = "URL";
            this.lblObstacleEventUrl.Click += new System.EventHandler(this.lblObstacleEventUrl_Click);
            // 
            // pbxObstacleEventImage
            // 
            this.pbxObstacleEventImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxObstacleEventImage.Location = new System.Drawing.Point(180, 19);
            this.pbxObstacleEventImage.Name = "pbxObstacleEventImage";
            this.pbxObstacleEventImage.Size = new System.Drawing.Size(168, 158);
            this.pbxObstacleEventImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxObstacleEventImage.TabIndex = 1;
            this.pbxObstacleEventImage.TabStop = false;
            // 
            // btnCopyObstacleEventImageUrl
            // 
            this.btnCopyObstacleEventImageUrl.Location = new System.Drawing.Point(6, 82);
            this.btnCopyObstacleEventImageUrl.Name = "btnCopyObstacleEventImageUrl";
            this.btnCopyObstacleEventImageUrl.Size = new System.Drawing.Size(112, 23);
            this.btnCopyObstacleEventImageUrl.TabIndex = 7;
            this.btnCopyObstacleEventImageUrl.Text = "Copy URL";
            this.btnCopyObstacleEventImageUrl.UseVisualStyleBackColor = true;
            this.btnCopyObstacleEventImageUrl.Click += new System.EventHandler(this.btnCopyObstacleEventImageUrl_Click);
            // 
            // gbxPositionData
            // 
            this.gbxPositionData.Controls.Add(this.lstbxReceivedPositionData);
            this.gbxPositionData.Location = new System.Drawing.Point(377, 22);
            this.gbxPositionData.Name = "gbxPositionData";
            this.gbxPositionData.Size = new System.Drawing.Size(180, 127);
            this.gbxPositionData.TabIndex = 10;
            this.gbxPositionData.TabStop = false;
            this.gbxPositionData.Text = "Received Position Data";
            // 
            // lstbxReceivedPositionData
            // 
            this.lstbxReceivedPositionData.FormattingEnabled = true;
            this.lstbxReceivedPositionData.ItemHeight = 15;
            this.lstbxReceivedPositionData.Location = new System.Drawing.Point(6, 22);
            this.lstbxReceivedPositionData.Name = "lstbxReceivedPositionData";
            this.lstbxReceivedPositionData.Size = new System.Drawing.Size(168, 94);
            this.lstbxReceivedPositionData.TabIndex = 0;
            // 
            // lstbxReceivedMessages
            // 
            this.lstbxReceivedMessages.FormattingEnabled = true;
            this.lstbxReceivedMessages.ItemHeight = 15;
            this.lstbxReceivedMessages.Location = new System.Drawing.Point(6, 22);
            this.lstbxReceivedMessages.Name = "lstbxReceivedMessages";
            this.lstbxReceivedMessages.Size = new System.Drawing.Size(365, 124);
            this.lstbxReceivedMessages.TabIndex = 9;
            this.lstbxReceivedMessages.SelectedIndexChanged += new System.EventHandler(this.lstbxReceivedMessages_SelectedIndexChanged);
            // 
            // lblObstacleEvents
            // 
            this.lblObstacleEvents.AutoSize = true;
            this.lblObstacleEvents.Location = new System.Drawing.Point(6, 154);
            this.lblObstacleEvents.Name = "lblObstacleEvents";
            this.lblObstacleEvents.Size = new System.Drawing.Size(140, 15);
            this.lblObstacleEvents.TabIndex = 8;
            this.lblObstacleEvents.Text = "Received Obstacle Events";
            this.lblObstacleEvents.Click += new System.EventHandler(this.lblObstacleEvents_Click);
            // 
            // lstbxObstacleEvents
            // 
            this.lstbxObstacleEvents.FormattingEnabled = true;
            this.lstbxObstacleEvents.ItemHeight = 15;
            this.lstbxObstacleEvents.Location = new System.Drawing.Point(6, 172);
            this.lstbxObstacleEvents.Name = "lstbxObstacleEvents";
            this.lstbxObstacleEvents.Size = new System.Drawing.Size(191, 169);
            this.lstbxObstacleEvents.TabIndex = 0;
            this.lstbxObstacleEvents.SelectedIndexChanged += new System.EventHandler(this.lstbxObstacleEvents_SelectedIndexChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 369);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.gbxControls.ResumeLayout(false);
            this.pnlMovementControls.ResumeLayout(false);
            this.gbxReceivedMessages.ResumeLayout(false);
            this.gbxReceivedMessages.PerformLayout();
            this.gbxSelectObstacleEventData.ResumeLayout(false);
            this.gbxSelectObstacleEventData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxObstacleEventImage)).EndInit();
            this.gbxPositionData.ResumeLayout(false);
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
        private PictureBox pbxObstacleEventImage;
        private ListBox lstbxObstacleEvents;
        private Button btnStartNewMap;
        private Label lblObstacleEventUrl;
        private Label lblObstacleEventPosition;
        private Label lblObstacleEventLabel;
        private Label lblObstacleEventDocumentId;
        private Button btnCopyObstacleEventImageUrl;
        private Label lblObstacleEvents;
        private ListBox lstbxReceivedMessages;
        private GroupBox gbxPositionData;
        private GroupBox gbxSelectObstacleEventData;
        private ListBox lstbxReceivedPositionData;
    }
}
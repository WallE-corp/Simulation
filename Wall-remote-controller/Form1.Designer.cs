namespace Wall_remote_controller
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
            System.Windows.Forms.Button btnRegister;
            this.gbxControls = new System.Windows.Forms.GroupBox();
            this.pnlMovementControls = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.addressTbx = new System.Windows.Forms.TextBox();
            this.addressLbl = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.lstvMessages = new System.Windows.Forms.ListBox();
            this.lblReceivedMessages = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            btnRegister = new System.Windows.Forms.Button();
            this.gbxControls.SuspendLayout();
            this.pnlMovementControls.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Location = new System.Drawing.Point(6, 19);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(109, 23);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Register as remote";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // gbxControls
            // 
            this.gbxControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbxControls.Controls.Add(btnRegister);
            this.gbxControls.Controls.Add(this.pnlMovementControls);
            this.gbxControls.Location = new System.Drawing.Point(12, 87);
            this.gbxControls.Name = "gbxControls";
            this.gbxControls.Size = new System.Drawing.Size(423, 295);
            this.gbxControls.TabIndex = 0;
            this.gbxControls.TabStop = false;
            this.gbxControls.Text = "Controls";
            // 
            // pnlMovementControls
            // 
            this.pnlMovementControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMovementControls.Controls.Add(this.btnUp);
            this.pnlMovementControls.Controls.Add(this.btnRight);
            this.pnlMovementControls.Controls.Add(this.btnDown);
            this.pnlMovementControls.Controls.Add(this.btnLeft);
            this.pnlMovementControls.Location = new System.Drawing.Point(6, 118);
            this.pnlMovementControls.Name = "pnlMovementControls";
            this.pnlMovementControls.Size = new System.Drawing.Size(244, 171);
            this.pnlMovementControls.TabIndex = 4;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(84, 9);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 75);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveForwardStart);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveForwardStop);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(165, 90);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 75);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveRightStart);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveRightStop);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(84, 90);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 75);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBackwardStart);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBackwardStop);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(3, 90);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 75);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveLeftStart);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveLeftStop);
            // 
            // addressTbx
            // 
            this.addressTbx.Location = new System.Drawing.Point(12, 25);
            this.addressTbx.Name = "addressTbx";
            this.addressTbx.Size = new System.Drawing.Size(123, 20);
            this.addressTbx.TabIndex = 1;
            // 
            // addressLbl
            // 
            this.addressLbl.AutoSize = true;
            this.addressLbl.Location = new System.Drawing.Point(9, 9);
            this.addressLbl.Name = "addressLbl";
            this.addressLbl.Size = new System.Drawing.Size(45, 13);
            this.addressLbl.TabIndex = 2;
            this.addressLbl.Text = "Address";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(141, 23);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // lstvMessages
            // 
            this.lstvMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstvMessages.FormattingEnabled = true;
            this.lstvMessages.Location = new System.Drawing.Point(0, 31);
            this.lstvMessages.Name = "lstvMessages";
            this.lstvMessages.Size = new System.Drawing.Size(325, 342);
            this.lstvMessages.TabIndex = 6;
            // 
            // lblReceivedMessages
            // 
            this.lblReceivedMessages.AutoSize = true;
            this.lblReceivedMessages.Location = new System.Drawing.Point(3, 9);
            this.lblReceivedMessages.Name = "lblReceivedMessages";
            this.lblReceivedMessages.Size = new System.Drawing.Size(104, 13);
            this.lblReceivedMessages.TabIndex = 7;
            this.lblReceivedMessages.Text = "Received Messages";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstvMessages);
            this.panel1.Controls.Add(this.lblReceivedMessages);
            this.panel1.Location = new System.Drawing.Point(432, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 373);
            this.panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 388);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.addressLbl);
            this.Controls.Add(this.addressTbx);
            this.Controls.Add(this.gbxControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "WallE Remote Controls";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.gbxControls.ResumeLayout(false);
            this.pnlMovementControls.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxControls;
        private System.Windows.Forms.TextBox addressTbx;
        private System.Windows.Forms.Label addressLbl;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Panel pnlMovementControls;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ListBox lstvMessages;
        private System.Windows.Forms.Label lblReceivedMessages;
        private System.Windows.Forms.Panel panel1;
    }
}


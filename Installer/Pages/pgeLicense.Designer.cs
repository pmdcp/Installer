namespace Installer.Pages
{
    partial class pgeLicense
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.rtbLicense = new System.Windows.Forms.RichTextBox();
            this.optDisagree = new System.Windows.Forms.RadioButton();
            this.optAgree = new System.Windows.Forms.RadioButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnBack);
            this.pnlButtons.Controls.Add(this.btnNext);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.rtbLicense);
            this.pnlInfo.Controls.Add(this.optDisagree);
            this.pnlInfo.Controls.Add(this.optAgree);
            this.pnlInfo.Controls.Add(this.lblHeader);
            // 
            // rtbLicense
            // 
            this.rtbLicense.BackColor = System.Drawing.Color.White;
            this.rtbLicense.Location = new System.Drawing.Point(16, 51);
            this.rtbLicense.Name = "rtbLicense";
            this.rtbLicense.ReadOnly = true;
            this.rtbLicense.Size = new System.Drawing.Size(478, 182);
            this.rtbLicense.TabIndex = 8;
            this.rtbLicense.Text = "";
            this.rtbLicense.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbLicense_LinkClicked);
            // 
            // optDisagree
            // 
            this.optDisagree.AutoSize = true;
            this.optDisagree.Checked = true;
            this.optDisagree.Location = new System.Drawing.Point(354, 239);
            this.optDisagree.Name = "optDisagree";
            this.optDisagree.Size = new System.Drawing.Size(73, 17);
            this.optDisagree.TabIndex = 7;
            this.optDisagree.TabStop = true;
            this.optDisagree.Text = "I Disagree";
            this.optDisagree.UseVisualStyleBackColor = true;
            this.optDisagree.CheckedChanged += new System.EventHandler(this.optDisagree_CheckedChanged);
            // 
            // optAgree
            // 
            this.optAgree.AutoSize = true;
            this.optAgree.Enabled = false;
            this.optAgree.Location = new System.Drawing.Point(432, 239);
            this.optAgree.Name = "optAgree";
            this.optAgree.Size = new System.Drawing.Size(59, 17);
            this.optAgree.TabIndex = 6;
            this.optAgree.Text = "I Agree";
            this.optAgree.UseVisualStyleBackColor = true;
            this.optAgree.CheckedChanged += new System.EventHandler(this.optAgree_CheckedChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.White;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(12, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(482, 36);
            this.lblHeader.TabIndex = 5;
            this.lblHeader.Text = "license header";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(343, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "<- Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(424, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next ->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pgeLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "pgeLicense";
            this.pnlButtons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLicense;
        private System.Windows.Forms.RadioButton optDisagree;
        private System.Windows.Forms.RadioButton optAgree;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
    }
}

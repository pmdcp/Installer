namespace Installer.Pages
{
    partial class pgeWelcome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPortableMode = new System.Windows.Forms.CheckBox();
            this.btnRestartAsAdmin = new System.Windows.Forms.Button();
            this.exclamationImage = new System.Windows.Forms.PictureBox();
            this.pnlButtons.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exclamationImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRestartAsAdmin);
            this.pnlButtons.Controls.Add(this.label1);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnNext);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.exclamationImage);
            this.pnlInfo.Controls.Add(this.chkPortableMode);
            this.pnlInfo.Controls.Add(this.lblError);
            this.pnlInfo.Controls.Add(this.lblHeader);
            this.pnlInfo.Controls.Add(this.lblWelcome);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(12, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(482, 36);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "welcome header";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Location = new System.Drawing.Point(12, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(482, 145);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "welcome";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(343, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(424, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next ->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(61, 218);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(434, 47);
            this.lblError.TabIndex = 4;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rev #";
            // 
            // chkPortableMode
            // 
            this.chkPortableMode.AutoSize = true;
            this.chkPortableMode.Location = new System.Drawing.Point(337, 268);
            this.chkPortableMode.Name = "chkPortableMode";
            this.chkPortableMode.Size = new System.Drawing.Size(162, 17);
            this.chkPortableMode.TabIndex = 5;
            this.chkPortableMode.Text = "Install as portable application";
            this.chkPortableMode.UseVisualStyleBackColor = true;
            // 
            // btnRestartAsAdmin
            // 
            this.btnRestartAsAdmin.Location = new System.Drawing.Point(189, 10);
            this.btnRestartAsAdmin.Name = "btnRestartAsAdmin";
            this.btnRestartAsAdmin.Size = new System.Drawing.Size(148, 23);
            this.btnRestartAsAdmin.TabIndex = 6;
            this.btnRestartAsAdmin.Text = "Restart as Administrator";
            this.btnRestartAsAdmin.UseVisualStyleBackColor = true;
            this.btnRestartAsAdmin.Visible = false;
            this.btnRestartAsAdmin.Click += new System.EventHandler(this.btnRestartAsAdmin_Click);
            // 
            // exclamationImage
            // 
            this.exclamationImage.Image = global::Installer.Properties.Resources.exclamation;
            this.exclamationImage.Location = new System.Drawing.Point(11, 221);
            this.exclamationImage.Name = "exclamationImage";
            this.exclamationImage.Size = new System.Drawing.Size(40, 40);
            this.exclamationImage.TabIndex = 6;
            this.exclamationImage.TabStop = false;
            this.exclamationImage.Visible = false;
            // 
            // pgeWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "pgeWelcome";
            this.pnlButtons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exclamationImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRestartAsAdmin;
        private System.Windows.Forms.CheckBox chkPortableMode;
        private System.Windows.Forms.PictureBox exclamationImage;
    }
}

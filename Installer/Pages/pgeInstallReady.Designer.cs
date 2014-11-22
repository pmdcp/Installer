namespace Installer.Pages
{
    partial class pgeInstallReady
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
            this.lblInstallReady = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblClientOptions = new System.Windows.Forms.Label();
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
            // pnlBanner
            // 
            this.pnlBanner.Size = new System.Drawing.Size(506, 60);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblClientOptions);
            this.pnlInfo.Controls.Add(this.lblInstallReady);
            this.pnlInfo.Location = new System.Drawing.Point(0, 60);
            this.pnlInfo.Size = new System.Drawing.Size(506, 291);
            // 
            // lblInstallReady
            // 
            this.lblInstallReady.BackColor = System.Drawing.Color.Transparent;
            this.lblInstallReady.Location = new System.Drawing.Point(12, 50);
            this.lblInstallReady.Name = "lblInstallReady";
            this.lblInstallReady.Size = new System.Drawing.Size(482, 181);
            this.lblInstallReady.TabIndex = 2;
            this.lblInstallReady.Text = "ready";
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
            this.btnNext.Location = new System.Drawing.Point(424, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next ->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblClientOptions
            // 
            this.lblClientOptions.AutoSize = true;
            this.lblClientOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientOptions.Location = new System.Drawing.Point(11, 14);
            this.lblClientOptions.Name = "lblClientOptions";
            this.lblClientOptions.Size = new System.Drawing.Size(135, 24);
            this.lblClientOptions.TabIndex = 9;
            this.lblClientOptions.Text = "Ready to Install";
            // 
            // pgeInstallReady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "pgeInstallReady";
            this.pnlButtons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInstallReady;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblClientOptions;
    }
}

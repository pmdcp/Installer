namespace Installer.Pages
{
    partial class pgeModeSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pgeModeSelect));
            this.lblInstallInfo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblClientOptions = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.lblRepairInfo = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnBack);
            // 
            // pnlBanner
            // 
            this.pnlBanner.Size = new System.Drawing.Size(506, 60);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.btnRepair);
            this.pnlInfo.Controls.Add(this.lblRepairInfo);
            this.pnlInfo.Controls.Add(this.btnInstall);
            this.pnlInfo.Controls.Add(this.lblClientOptions);
            this.pnlInfo.Controls.Add(this.lblInstallInfo);
            this.pnlInfo.Location = new System.Drawing.Point(0, 60);
            this.pnlInfo.Size = new System.Drawing.Size(506, 291);
            // 
            // lblInstallInfo
            // 
            this.lblInstallInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInstallInfo.Location = new System.Drawing.Point(96, 44);
            this.lblInstallInfo.Name = "lblInstallInfo";
            this.lblInstallInfo.Size = new System.Drawing.Size(361, 59);
            this.lblInstallInfo.TabIndex = 2;
            this.lblInstallInfo.Text = "Install Pokémon Mystery Universe. Select this option if you would like to install" +
                " or reinstall any of the PMU components.";
            this.lblInstallInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(419, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "<- Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 10);
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
            this.lblClientOptions.Size = new System.Drawing.Size(235, 24);
            this.lblClientOptions.TabIndex = 9;
            this.lblClientOptions.Text = "What would you like to do?";
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(15, 62);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 10;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.Location = new System.Drawing.Point(15, 127);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(75, 23);
            this.btnRepair.TabIndex = 12;
            this.btnRepair.Text = "Repair";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // lblRepairInfo
            // 
            this.lblRepairInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblRepairInfo.Location = new System.Drawing.Point(96, 109);
            this.lblRepairInfo.Name = "lblRepairInfo";
            this.lblRepairInfo.Size = new System.Drawing.Size(361, 59);
            this.lblRepairInfo.TabIndex = 11;
            this.lblRepairInfo.Text = resources.GetString("lblRepairInfo.Text");
            this.lblRepairInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgeModeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "pgeModeSelect";
            this.pnlButtons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInstallInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblClientOptions;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Label lblRepairInfo;
    }
}

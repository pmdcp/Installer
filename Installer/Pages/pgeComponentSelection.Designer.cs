namespace Installer.Pages
{
    partial class pgeComponentSelection
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtInstallDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpComponents = new System.Windows.Forms.GroupBox();
            this.chkMapEditor = new System.Windows.Forms.CheckBox();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.grpComponents.SuspendLayout();
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
            this.pnlInfo.Controls.Add(this.grpComponents);
            this.pnlInfo.Controls.Add(this.btnBrowse);
            this.pnlInfo.Controls.Add(this.txtInstallDir);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Location = new System.Drawing.Point(0, 60);
            this.pnlInfo.Size = new System.Drawing.Size(506, 291);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(343, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
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
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next ->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(441, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(51, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Location = new System.Drawing.Point(12, 30);
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Size = new System.Drawing.Size(423, 20);
            this.txtInstallDir.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Installation Directory";
            // 
            // grpComponents
            // 
            this.grpComponents.Controls.Add(this.chkMapEditor);
            this.grpComponents.Controls.Add(this.chkClient);
            this.grpComponents.Location = new System.Drawing.Point(12, 56);
            this.grpComponents.Name = "grpComponents";
            this.grpComponents.Size = new System.Drawing.Size(480, 97);
            this.grpComponents.TabIndex = 10;
            this.grpComponents.TabStop = false;
            this.grpComponents.Text = "Components to Install";
            // 
            // chkMapEditor
            // 
            this.chkMapEditor.AutoSize = true;
            this.chkMapEditor.Location = new System.Drawing.Point(6, 42);
            this.chkMapEditor.Name = "chkMapEditor";
            this.chkMapEditor.Size = new System.Drawing.Size(77, 17);
            this.chkMapEditor.TabIndex = 1;
            this.chkMapEditor.Text = "Map Editor";
            this.chkMapEditor.UseVisualStyleBackColor = true;
            this.chkMapEditor.CheckedChanged += new System.EventHandler(this.chkMapEditor_CheckedChanged);
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Checked = true;
            this.chkClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClient.Location = new System.Drawing.Point(6, 19);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(52, 17);
            this.chkClient.TabIndex = 0;
            this.chkClient.Text = "Client";
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.CheckedChanged += new System.EventHandler(this.chkClient_CheckedChanged);
            // 
            // pgeComponentSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "pgeComponentSelection";
            this.pnlButtons.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.grpComponents.ResumeLayout(false);
            this.grpComponents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtInstallDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpComponents;
        private System.Windows.Forms.CheckBox chkMapEditor;
        private System.Windows.Forms.CheckBox chkClient;
    }
}

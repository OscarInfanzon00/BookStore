namespace WindowsFormsApp
{
    partial class frmAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(139, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(254, 31);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "About This Project";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(41, 64);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 16);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "BookStore";
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(41, 90);
            this.lblTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(125, 176);
            this.lblTeam.TabIndex = 2;
            this.lblTeam.Text = "Team Members:\r\n\r\n- Oscar Infanzon\r\n\r\n- Andrew\r\n\r\n- Carlos Martin\r\n\r\n- Jonathan Qu" +
    "intana\r\n\r\n- Isaiah Simon\r\n";
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(197, 366);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(141, 57);
            this.btnMainMenu.TabIndex = 3;
            this.btnMainMenu.Text = "Back to Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 291);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Version 1.0.0\r\n\r\nThis is an FIU project for COP4226\r\n";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 446);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label label1;
    }
}

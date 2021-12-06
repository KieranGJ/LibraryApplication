
namespace LibraryApplication.Forms
{
    partial class EnterUsername
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
            this.startingPanel = new System.Windows.Forms.Panel();
            this.happyFace = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.Close_Button = new System.Windows.Forms.Button();
            this.startingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startingPanel
            // 
            this.startingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.startingPanel.Controls.Add(this.happyFace);
            this.startingPanel.Controls.Add(this.startButton);
            this.startingPanel.Controls.Add(this.usernameBox);
            this.startingPanel.Controls.Add(this.usernameLabel);
            this.startingPanel.Location = new System.Drawing.Point(66, 45);
            this.startingPanel.Name = "startingPanel";
            this.startingPanel.Size = new System.Drawing.Size(1772, 951);
            this.startingPanel.TabIndex = 18;
            // 
            // happyFace
            // 
            this.happyFace.AutoSize = true;
            this.happyFace.Font = new System.Drawing.Font("Broadway", 48F, System.Drawing.FontStyle.Bold);
            this.happyFace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.happyFace.Location = new System.Drawing.Point(600, 314);
            this.happyFace.Name = "happyFace";
            this.happyFace.Size = new System.Drawing.Size(416, 72);
            this.happyFace.TabIndex = 4;
            this.happyFace.Text = "(づ｡◕‿‿◕｡)づ";
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Broadway", 48F, System.Drawing.FontStyle.Bold);
            this.startButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.startButton.Location = new System.Drawing.Point(568, 411);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(483, 194);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.startButton_MouseEnter);
            this.startButton.MouseLeave += new System.EventHandler(this.startButton_MouseLeave);
            // 
            // usernameBox
            // 
            this.usernameBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameBox.Font = new System.Drawing.Font("Broadway", 48F, System.Drawing.FontStyle.Bold);
            this.usernameBox.Location = new System.Drawing.Point(398, 206);
            this.usernameBox.MaxLength = 9;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(762, 80);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.TextChanged += new System.EventHandler(this.usernameBox_TextChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Broadway", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.usernameLabel.Location = new System.Drawing.Point(386, 62);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(787, 72);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Enter your Username";
            // 
            // Close_Button
            // 
            this.Close_Button.BackColor = System.Drawing.Color.Maroon;
            this.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(170)))), ((int)(((byte)(181)))));
            this.Close_Button.Location = new System.Drawing.Point(1832, 12);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(63, 25);
            this.Close_Button.TabIndex = 19;
            this.Close_Button.Text = "x";
            this.Close_Button.UseVisualStyleBackColor = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // EnterUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.startingPanel);
            this.Name = "EnterUsername";
            this.Text = "EnterUsername";
            this.Load += new System.EventHandler(this.EnterUsername_Load);
            this.startingPanel.ResumeLayout(false);
            this.startingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel startingPanel;
        private System.Windows.Forms.Label happyFace;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button Close_Button;
    }
}
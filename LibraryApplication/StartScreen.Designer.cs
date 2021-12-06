
namespace LibraryApplication
{
    partial class StartScreen
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
            this.button1 = new System.Windows.Forms.Button();
            this.CallNumbers = new System.Windows.Forms.Button();
            this.AreaIdentification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.button1.Location = new System.Drawing.Point(40, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 136);
            this.button1.TabIndex = 0;
            this.button1.Text = "Replace Books";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CallNumbers
            // 
            this.CallNumbers.FlatAppearance.BorderSize = 3;
            this.CallNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CallNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.CallNumbers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.CallNumbers.Location = new System.Drawing.Point(40, 353);
            this.CallNumbers.Name = "CallNumbers";
            this.CallNumbers.Size = new System.Drawing.Size(271, 136);
            this.CallNumbers.TabIndex = 5;
            this.CallNumbers.Text = "Call Numbers";
            this.CallNumbers.UseVisualStyleBackColor = true;
            this.CallNumbers.Click += new System.EventHandler(this.CallNumbers_Click);
            // 
            // AreaIdentification
            // 
            this.AreaIdentification.FlatAppearance.BorderSize = 3;
            this.AreaIdentification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AreaIdentification.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.AreaIdentification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.AreaIdentification.Location = new System.Drawing.Point(40, 190);
            this.AreaIdentification.Name = "AreaIdentification";
            this.AreaIdentification.Size = new System.Drawing.Size(271, 136);
            this.AreaIdentification.TabIndex = 6;
            this.AreaIdentification.Text = "Area Identification";
            this.AreaIdentification.UseVisualStyleBackColor = true;
            this.AreaIdentification.Click += new System.EventHandler(this.AreaIdentification_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(348, 514);
            this.Controls.Add(this.AreaIdentification);
            this.Controls.Add(this.CallNumbers);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartScreen";
            this.Text = "Library Application";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CallNumbers;
        private System.Windows.Forms.Button AreaIdentification;
    }
}


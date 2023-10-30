namespace Canteen_Management_System.UI
{
    partial class Password
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordButton = new System.Windows.Forms.Button();
            this.RegistrationBox1 = new System.Windows.Forms.TextBox();
            this.CurrentBox = new System.Windows.Forms.TextBox();
            this.NewBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "New Password";
            // 
            // PasswordButton
            // 
            this.PasswordButton.Location = new System.Drawing.Point(186, 249);
            this.PasswordButton.Name = "PasswordButton";
            this.PasswordButton.Size = new System.Drawing.Size(174, 41);
            this.PasswordButton.TabIndex = 1;
            this.PasswordButton.Text = "Change Password";
            this.PasswordButton.UseVisualStyleBackColor = true;
            this.PasswordButton.Click += new System.EventHandler(this.PasswordButton_Click);
            // 
            // RegistrationBox1
            // 
            this.RegistrationBox1.Location = new System.Drawing.Point(250, 55);
            this.RegistrationBox1.Name = "RegistrationBox1";
            this.RegistrationBox1.ReadOnly = true;
            this.RegistrationBox1.Size = new System.Drawing.Size(245, 26);
            this.RegistrationBox1.TabIndex = 2;
            this.RegistrationBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CurrentBox
            // 
            this.CurrentBox.Location = new System.Drawing.Point(250, 127);
            this.CurrentBox.Name = "CurrentBox";
            this.CurrentBox.PasswordChar = '*';
            this.CurrentBox.Size = new System.Drawing.Size(245, 26);
            this.CurrentBox.TabIndex = 2;
            // 
            // NewBox
            // 
            this.NewBox.Location = new System.Drawing.Point(250, 197);
            this.NewBox.Name = "NewBox";
            this.NewBox.PasswordChar = '*';
            this.NewBox.Size = new System.Drawing.Size(245, 26);
            this.NewBox.TabIndex = 2;
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 322);
            this.Controls.Add(this.NewBox);
            this.Controls.Add(this.CurrentBox);
            this.Controls.Add(this.RegistrationBox1);
            this.Controls.Add(this.PasswordButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Password";
            this.Text = "Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PasswordButton;
        private System.Windows.Forms.TextBox CurrentBox;
        private System.Windows.Forms.TextBox NewBox;
        public System.Windows.Forms.TextBox RegistrationBox1;
    }
}
namespace Canteen_Management_System.UI
{
    partial class CashForm
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
            this.TotalBillBox = new System.Windows.Forms.TextBox();
            this.CurrentBalanceBox = new System.Windows.Forms.TextBox();
            this.RemainingBalanceBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Bill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Balance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remaining Balance";
            // 
            // TotalBillBox
            // 
            this.TotalBillBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBillBox.Location = new System.Drawing.Point(240, 58);
            this.TotalBillBox.Name = "TotalBillBox";
            this.TotalBillBox.ReadOnly = true;
            this.TotalBillBox.Size = new System.Drawing.Size(192, 31);
            this.TotalBillBox.TabIndex = 1;
            // 
            // CurrentBalanceBox
            // 
            this.CurrentBalanceBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentBalanceBox.Location = new System.Drawing.Point(236, 135);
            this.CurrentBalanceBox.Name = "CurrentBalanceBox";
            this.CurrentBalanceBox.ReadOnly = true;
            this.CurrentBalanceBox.Size = new System.Drawing.Size(196, 29);
            this.CurrentBalanceBox.TabIndex = 1;
            this.CurrentBalanceBox.TextChanged += new System.EventHandler(this.CurrentBalanceBox_TextChanged);
            // 
            // RemainingBalanceBox
            // 
            this.RemainingBalanceBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemainingBalanceBox.Location = new System.Drawing.Point(236, 214);
            this.RemainingBalanceBox.Name = "RemainingBalanceBox";
            this.RemainingBalanceBox.ReadOnly = true;
            this.RemainingBalanceBox.Size = new System.Drawing.Size(196, 31);
            this.RemainingBalanceBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(212, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirm Checkout";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 360);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RemainingBalanceBox);
            this.Controls.Add(this.CurrentBalanceBox);
            this.Controls.Add(this.TotalBillBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CashForm";
            this.Text = "CashForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox TotalBillBox;
        public System.Windows.Forms.TextBox CurrentBalanceBox;
        public System.Windows.Forms.TextBox RemainingBalanceBox;
    }
}

namespace pos02.Viwe
{
    partial class Dashboard
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotaIncome = new System.Windows.Forms.Label();
            this.lblBillCount = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.lblTotaIncome);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(27, 36);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(192, 92);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Panel2.Controls.Add(this.lblProduct);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Location = new System.Drawing.Point(550, 36);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(192, 92);
            this.guna2Panel2.TabIndex = 1;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Panel3.Controls.Add(this.lblBillCount);
            this.guna2Panel3.Controls.Add(this.label2);
            this.guna2Panel3.Location = new System.Drawing.Point(292, 36);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(192, 92);
            this.guna2Panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Income";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bill Count";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Products";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotaIncome
            // 
            this.lblTotaIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaIncome.ForeColor = System.Drawing.Color.White;
            this.lblTotaIncome.Location = new System.Drawing.Point(2, 37);
            this.lblTotaIncome.Name = "lblTotaIncome";
            this.lblTotaIncome.Size = new System.Drawing.Size(189, 37);
            this.lblTotaIncome.TabIndex = 3;
            this.lblTotaIncome.Text = "0";
            this.lblTotaIncome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTotaIncome.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblBillCount
            // 
            this.lblBillCount.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillCount.ForeColor = System.Drawing.Color.White;
            this.lblBillCount.Location = new System.Drawing.Point(3, 37);
            this.lblBillCount.Name = "lblBillCount";
            this.lblBillCount.Size = new System.Drawing.Size(189, 37);
            this.lblBillCount.TabIndex = 4;
            this.lblBillCount.Text = "0";
            this.lblBillCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProduct
            // 
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.Color.White;
            this.lblProduct.Location = new System.Drawing.Point(0, 37);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(189, 37);
            this.lblProduct.TabIndex = 5;
            this.lblProduct.Text = "0";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 491);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTotaIncome;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblBillCount;
    }
}

namespace pos02.Model
{
    partial class ucProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPName = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPic)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblQty);
            this.guna2ShadowPanel1.Controls.Add(this.txtPic);
            this.guna2ShadowPanel1.Controls.Add(this.lblPrice);
            this.guna2ShadowPanel1.Controls.Add(this.lblPName);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(11, 16);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(129, 181);
            this.guna2ShadowPanel1.TabIndex = 3;
            this.guna2ShadowPanel1.Click += new System.EventHandler(this.guna2ShadowPanel1_Click);
            this.guna2ShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(86, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(44, 83);
            this.lblQty.TabIndex = 3;
            this.lblQty.Text = "Qty";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQty.Click += new System.EventHandler(this.lblQty_Click);
            // 
            // txtPic
            // 
            this.txtPic.Image = global::pos02.Properties.Resources._1684687418700;
            this.txtPic.ImageRotate = 0F;
            this.txtPic.Location = new System.Drawing.Point(7, -14);
            this.txtPic.Name = "txtPic";
            this.txtPic.Size = new System.Drawing.Size(86, 99);
            this.txtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txtPic.TabIndex = 2;
            this.txtPic.TabStop = false;
            this.txtPic.Click += new System.EventHandler(this.txtPic_Click_1);
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(6, 146);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(120, 23);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "200";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrice.Click += new System.EventHandler(this.lblPrice_Click);
            // 
            // lblPName
            // 
            this.lblPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPName.Location = new System.Drawing.Point(3, 83);
            this.lblPName.Name = "lblPName";
            this.lblPName.Size = new System.Drawing.Size(123, 58);
            this.lblPName.TabIndex = 0;
            this.lblPName.Text = "Product Name";
            this.lblPName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPName.Click += new System.EventHandler(this.lblPName_Click);
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(149, 210);
            this.Load += new System.EventHandler(this.ucProduct_Load);
            this.Click += new System.EventHandler(this.ucProduct_Click);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPName;
        private Guna.UI2.WinForms.Guna2PictureBox txtPic;
        private System.Windows.Forms.Label lblQty;
    }
}

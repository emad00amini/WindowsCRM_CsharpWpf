
namespace CRM
{
    partial class loginUserUC
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(162, 212);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(374, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "برای ورود نام کاربری و رمز خودرا وارد کنید";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.textBoxX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxX1.Location = new System.Drawing.Point(78, 389);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxX1.Size = new System.Drawing.Size(508, 40);
            this.textBoxX1.TabIndex = 10;
            this.textBoxX1.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBoxX1.WatermarkText = "کلمه ی عبور";
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.textBoxX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxX2.Location = new System.Drawing.Point(78, 317);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxX2.Size = new System.Drawing.Size(508, 40);
            this.textBoxX2.TabIndex = 9;
            this.textBoxX2.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBoxX2.WatermarkText = "نام کاربری";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(283, 470);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 12;
            this.buttonX1.Text = "ورود";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // loginUserUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.textBoxX2);
            this.Name = "loginUserUC";
            this.Size = new System.Drawing.Size(665, 640);
            this.Load += new System.EventHandler(this.loginUserUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}

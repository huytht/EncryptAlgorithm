
namespace EncryptAlgorithm
{
    partial class EncryptForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDecryptVigener = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCipherVigener = new System.Windows.Forms.TextBox();
            this.btnDecryptVigener = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlainTextVigener = new System.Windows.Forms.TextBox();
            this.txtKeyVigener = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEncryptVigener = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtDecryptTextRSA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCipherTextRSA = new System.Windows.Forms.TextBox();
            this.btnDecryptRSA = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlainTextRSA = new System.Windows.Forms.TextBox();
            this.btnEncryptRSA = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 460);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDecryptVigener);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtCipherVigener);
            this.tabPage1.Controls.Add(this.btnDecryptVigener);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtPlainTextVigener);
            this.tabPage1.Controls.Add(this.txtKeyVigener);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnEncryptVigener);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(786, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vigener";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDecryptVigener
            // 
            this.txtDecryptVigener.Location = new System.Drawing.Point(22, 323);
            this.txtDecryptVigener.Multiline = true;
            this.txtDecryptVigener.Name = "txtDecryptVigener";
            this.txtDecryptVigener.Size = new System.Drawing.Size(743, 102);
            this.txtDecryptVigener.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Giải mã";
            // 
            // txtCipherVigener
            // 
            this.txtCipherVigener.Location = new System.Drawing.Point(22, 202);
            this.txtCipherVigener.Multiline = true;
            this.txtCipherVigener.Name = "txtCipherVigener";
            this.txtCipherVigener.Size = new System.Drawing.Size(743, 96);
            this.txtCipherVigener.TabIndex = 6;
            // 
            // btnDecryptVigener
            // 
            this.btnDecryptVigener.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecryptVigener.Location = new System.Drawing.Point(83, 167);
            this.btnDecryptVigener.Name = "btnDecryptVigener";
            this.btnDecryptVigener.Size = new System.Drawing.Size(96, 29);
            this.btnDecryptVigener.TabIndex = 5;
            this.btnDecryptVigener.Text = "Giải mã";
            this.btnDecryptVigener.UseVisualStyleBackColor = true;
            this.btnDecryptVigener.Click += new System.EventHandler(this.btnDecryptVigener_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bản mã";
            // 
            // txtPlainTextVigener
            // 
            this.txtPlainTextVigener.Location = new System.Drawing.Point(22, 64);
            this.txtPlainTextVigener.Multiline = true;
            this.txtPlainTextVigener.Name = "txtPlainTextVigener";
            this.txtPlainTextVigener.Size = new System.Drawing.Size(743, 91);
            this.txtPlainTextVigener.TabIndex = 3;
            // 
            // txtKeyVigener
            // 
            this.txtKeyVigener.Location = new System.Drawing.Point(242, 28);
            this.txtKeyVigener.Name = "txtKeyVigener";
            this.txtKeyVigener.Size = new System.Drawing.Size(140, 27);
            this.txtKeyVigener.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(193, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khóa";
            // 
            // btnEncryptVigener
            // 
            this.btnEncryptVigener.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptVigener.Location = new System.Drawing.Point(78, 26);
            this.btnEncryptVigener.Name = "btnEncryptVigener";
            this.btnEncryptVigener.Size = new System.Drawing.Size(79, 29);
            this.btnEncryptVigener.TabIndex = 1;
            this.btnEncryptVigener.Text = "Mã hóa";
            this.btnEncryptVigener.UseVisualStyleBackColor = true;
            this.btnEncryptVigener.Click += new System.EventHandler(this.btnEncryptVigener_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bản rõ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtDecryptTextRSA);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtCipherTextRSA);
            this.tabPage2.Controls.Add(this.btnDecryptRSA);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtPlainTextRSA);
            this.tabPage2.Controls.Add(this.btnEncryptRSA);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(786, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RSA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDecryptTextRSA
            // 
            this.txtDecryptTextRSA.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptTextRSA.Location = new System.Drawing.Point(24, 315);
            this.txtDecryptTextRSA.Multiline = true;
            this.txtDecryptTextRSA.Name = "txtDecryptTextRSA";
            this.txtDecryptTextRSA.Size = new System.Drawing.Size(743, 102);
            this.txtDecryptTextRSA.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Giải mã";
            // 
            // txtCipherTextRSA
            // 
            this.txtCipherTextRSA.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCipherTextRSA.Location = new System.Drawing.Point(24, 194);
            this.txtCipherTextRSA.Multiline = true;
            this.txtCipherTextRSA.Name = "txtCipherTextRSA";
            this.txtCipherTextRSA.Size = new System.Drawing.Size(743, 96);
            this.txtCipherTextRSA.TabIndex = 16;
            // 
            // btnDecryptRSA
            // 
            this.btnDecryptRSA.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecryptRSA.Location = new System.Drawing.Point(85, 159);
            this.btnDecryptRSA.Name = "btnDecryptRSA";
            this.btnDecryptRSA.Size = new System.Drawing.Size(96, 29);
            this.btnDecryptRSA.TabIndex = 15;
            this.btnDecryptRSA.Text = "Giải mã";
            this.btnDecryptRSA.UseVisualStyleBackColor = true;
            this.btnDecryptRSA.Click += new System.EventHandler(this.btnDecryptRSA_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Bản mã";
            // 
            // txtPlainTextRSA
            // 
            this.txtPlainTextRSA.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlainTextRSA.Location = new System.Drawing.Point(24, 56);
            this.txtPlainTextRSA.Multiline = true;
            this.txtPlainTextRSA.Name = "txtPlainTextRSA";
            this.txtPlainTextRSA.Size = new System.Drawing.Size(743, 91);
            this.txtPlainTextRSA.TabIndex = 13;
            // 
            // btnEncryptRSA
            // 
            this.btnEncryptRSA.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptRSA.Location = new System.Drawing.Point(80, 18);
            this.btnEncryptRSA.Name = "btnEncryptRSA";
            this.btnEncryptRSA.Size = new System.Drawing.Size(79, 29);
            this.btnEncryptRSA.TabIndex = 11;
            this.btnEncryptRSA.Text = "Mã hóa";
            this.btnEncryptRSA.UseVisualStyleBackColor = true;
            this.btnEncryptRSA.Click += new System.EventHandler(this.btnEncryptRSA_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 10;
            this.label9.Text = "Bản rõ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(786, 434);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "6Men Member";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 217);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(315, 24);
            this.label16.TabIndex = 6;
            this.label16.Text = "Trần Nguyên Khánh - 4501104110";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(247, 24);
            this.label15.TabIndex = 5;
            this.label15.Text = "Võ Anh Kha - 4501104103";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(248, 24);
            this.label14.TabIndex = 4;
            this.label14.Text = "Võ Thế Hiển - 4501104080";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(348, 24);
            this.label13.TabIndex = 3;
            this.label13.Text = "Trần Huỳnh Tường Huy - 4501104096";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(291, 24);
            this.label12.TabIndex = 2;
            this.label12.Text = "Huỳnh Thiên Phú - 4501104177";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(303, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "Lê Khánh Phương - 4501104183";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Thông tin thành viên";
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 459);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EncryptForm";
            this.Text = "DEMO CÁC THUẬT TOÁN MÃ HÓA";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEncryptVigener;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDecryptVigener;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCipherVigener;
        private System.Windows.Forms.Button btnDecryptVigener;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlainTextVigener;
        private System.Windows.Forms.TextBox txtKeyVigener;
        private System.Windows.Forms.TextBox txtDecryptTextRSA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCipherTextRSA;
        private System.Windows.Forms.Button btnDecryptRSA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlainTextRSA;
        private System.Windows.Forms.Button btnEncryptRSA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}


namespace ParseProject
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ButtonDeleteGate = new System.Windows.Forms.Button();
            this.ButtonAddGate = new System.Windows.Forms.Button();
            this.ButtonSaveAsPicture = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ButtonAddAnother = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Graphic Designation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(278, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 200);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ButtonDeleteGate
            // 
            this.ButtonDeleteGate.Location = new System.Drawing.Point(15, 213);
            this.ButtonDeleteGate.Name = "ButtonDeleteGate";
            this.ButtonDeleteGate.Size = new System.Drawing.Size(97, 36);
            this.ButtonDeleteGate.TabIndex = 7;
            this.ButtonDeleteGate.Text = "Delete Gate";
            this.ButtonDeleteGate.UseVisualStyleBackColor = true;
            this.ButtonDeleteGate.Click += new System.EventHandler(this.ButtonDeleteGate_Click);
            // 
            // ButtonAddGate
            // 
            this.ButtonAddGate.Location = new System.Drawing.Point(15, 156);
            this.ButtonAddGate.Name = "ButtonAddGate";
            this.ButtonAddGate.Size = new System.Drawing.Size(97, 35);
            this.ButtonAddGate.TabIndex = 8;
            this.ButtonAddGate.Text = "Add Gate";
            this.ButtonAddGate.UseVisualStyleBackColor = true;
            this.ButtonAddGate.Click += new System.EventHandler(this.ButtonAddGate_Click);
            // 
            // ButtonSaveAsPicture
            // 
            this.ButtonSaveAsPicture.Location = new System.Drawing.Point(15, 270);
            this.ButtonSaveAsPicture.Name = "ButtonSaveAsPicture";
            this.ButtonSaveAsPicture.Size = new System.Drawing.Size(97, 40);
            this.ButtonSaveAsPicture.TabIndex = 11;
            this.ButtonSaveAsPicture.Text = "Save As Picture";
            this.ButtonSaveAsPicture.UseVisualStyleBackColor = true;
            this.ButtonSaveAsPicture.Click += new System.EventHandler(this.ButtonSaveAsPicture_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox2.Location = new System.Drawing.Point(610, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(177, 200);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.DoubleClick += new System.EventHandler(this.pictureBox2_DoubleClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // ButtonAddAnother
            // 
            this.ButtonAddAnother.Location = new System.Drawing.Point(15, 85);
            this.ButtonAddAnother.Name = "ButtonAddAnother";
            this.ButtonAddAnother.Size = new System.Drawing.Size(97, 39);
            this.ButtonAddAnother.TabIndex = 13;
            this.ButtonAddAnother.Text = "Add Another Gesignation";
            this.ButtonAddAnother.UseVisualStyleBackColor = true;
            this.ButtonAddAnother.Click += new System.EventHandler(this.ButtonAddAnother_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox3.Location = new System.Drawing.Point(146, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(757, 434);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(915, 471);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonAddAnother);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ButtonSaveAsPicture);
            this.Controls.Add(this.ButtonAddGate);
            this.Controls.Add(this.ButtonDeleteGate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Graphic Designation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ButtonDeleteGate;
        private System.Windows.Forms.Button ButtonAddGate;
        private System.Windows.Forms.Button ButtonSaveAsPicture;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ButtonAddAnother;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}


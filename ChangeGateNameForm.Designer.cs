namespace ParseProject
{
    partial class ChangeGateNameForm
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
            this.TextBoxNewGateName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonChangeName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxNewGateName
            // 
            this.TextBoxNewGateName.Location = new System.Drawing.Point(119, 61);
            this.TextBoxNewGateName.Name = "TextBoxNewGateName";
            this.TextBoxNewGateName.Size = new System.Drawing.Size(100, 20);
            this.TextBoxNewGateName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input new gate name";
            // 
            // ButtonChangeName
            // 
            this.ButtonChangeName.Location = new System.Drawing.Point(109, 110);
            this.ButtonChangeName.Name = "ButtonChangeName";
            this.ButtonChangeName.Size = new System.Drawing.Size(114, 44);
            this.ButtonChangeName.TabIndex = 2;
            this.ButtonChangeName.Text = "Change Name";
            this.ButtonChangeName.UseVisualStyleBackColor = true;
            this.ButtonChangeName.Click += new System.EventHandler(this.ButtonChangeName_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 175);
            this.Controls.Add(this.ButtonChangeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxNewGateName);
            this.Name = "Form2";
            this.Text = "Change Gate Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxNewGateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonChangeName;
    }
}
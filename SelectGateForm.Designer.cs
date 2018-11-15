namespace ParseProject
{
    partial class SelectGateForm
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
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ListBoxListOfGates = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(83, 185);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(99, 43);
            this.ButtonDelete.TabIndex = 1;
            this.ButtonDelete.Text = "Delete Gate";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ListBoxListOfGates
            // 
            this.ListBoxListOfGates.FormattingEnabled = true;
            this.ListBoxListOfGates.Location = new System.Drawing.Point(83, 27);
            this.ListBoxListOfGates.Name = "ListBoxListOfGates";
            this.ListBoxListOfGates.Size = new System.Drawing.Size(120, 95);
            this.ListBoxListOfGates.TabIndex = 2;
            // 
            // SelectGateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ListBoxListOfGates);
            this.Controls.Add(this.ButtonDelete);
            this.Name = "SelectGateForm";
            this.Text = "Select Gate";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.ListBox ListBoxListOfGates;
    }
}
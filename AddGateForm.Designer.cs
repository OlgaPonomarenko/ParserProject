namespace ParseProject
{
    partial class AddGateForm
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
            this.TexBoxGateName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioButtonAccessModeIn = new System.Windows.Forms.RadioButton();
            this.RadioButtonAccessModeOut = new System.Windows.Forms.RadioButton();
            this.RadioButtonTypeStdLogic = new System.Windows.Forms.RadioButton();
            this.RadioButtonTypeStdLogicVector = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxDimension = new System.Windows.Forms.TextBox();
            this.LabelDimension = new System.Windows.Forms.Label();
            this.ButtonAddGate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TexBoxGateName
            // 
            this.TexBoxGateName.Location = new System.Drawing.Point(30, 30);
            this.TexBoxGateName.Name = "TexBoxGateName";
            this.TexBoxGateName.Size = new System.Drawing.Size(100, 20);
            this.TexBoxGateName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Gate\'s Name";
            // 
            // RadioButtonAccessModeIn
            // 
            this.RadioButtonAccessModeIn.AutoSize = true;
            this.RadioButtonAccessModeIn.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonAccessModeIn.Name = "RadioButtonAccessModeIn";
            this.RadioButtonAccessModeIn.Size = new System.Drawing.Size(34, 17);
            this.RadioButtonAccessModeIn.TabIndex = 2;
            this.RadioButtonAccessModeIn.TabStop = true;
            this.RadioButtonAccessModeIn.Text = "In";
            this.RadioButtonAccessModeIn.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAccessModeOut
            // 
            this.RadioButtonAccessModeOut.AutoSize = true;
            this.RadioButtonAccessModeOut.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonAccessModeOut.Name = "RadioButtonAccessModeOut";
            this.RadioButtonAccessModeOut.Size = new System.Drawing.Size(42, 17);
            this.RadioButtonAccessModeOut.TabIndex = 3;
            this.RadioButtonAccessModeOut.TabStop = true;
            this.RadioButtonAccessModeOut.Text = "Out";
            this.RadioButtonAccessModeOut.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTypeStdLogic
            // 
            this.RadioButtonTypeStdLogic.AutoSize = true;
            this.RadioButtonTypeStdLogic.Location = new System.Drawing.Point(6, 22);
            this.RadioButtonTypeStdLogic.Name = "RadioButtonTypeStdLogic";
            this.RadioButtonTypeStdLogic.Size = new System.Drawing.Size(73, 17);
            this.RadioButtonTypeStdLogic.TabIndex = 5;
            this.RadioButtonTypeStdLogic.TabStop = true;
            this.RadioButtonTypeStdLogic.Text = "Std_Logic";
            this.RadioButtonTypeStdLogic.UseVisualStyleBackColor = true;
            this.RadioButtonTypeStdLogic.CheckedChanged += new System.EventHandler(this.RadioButtonTypeStdLogic_CheckedChanged);
            // 
            // RadioButtonTypeStdLogicVector
            // 
            this.RadioButtonTypeStdLogicVector.AutoSize = true;
            this.RadioButtonTypeStdLogicVector.Location = new System.Drawing.Point(6, 45);
            this.RadioButtonTypeStdLogicVector.Name = "RadioButtonTypeStdLogicVector";
            this.RadioButtonTypeStdLogicVector.Size = new System.Drawing.Size(110, 17);
            this.RadioButtonTypeStdLogicVector.TabIndex = 6;
            this.RadioButtonTypeStdLogicVector.TabStop = true;
            this.RadioButtonTypeStdLogicVector.Text = "Std_Logic_Vector";
            this.RadioButtonTypeStdLogicVector.UseVisualStyleBackColor = true;
            this.RadioButtonTypeStdLogicVector.CheckedChanged += new System.EventHandler(this.RadioButtonTypeStdLogicVector_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // TextBoxDimension
            // 
            this.TextBoxDimension.Location = new System.Drawing.Point(30, 247);
            this.TextBoxDimension.Name = "TextBoxDimension";
            this.TextBoxDimension.Size = new System.Drawing.Size(100, 20);
            this.TextBoxDimension.TabIndex = 9;
            this.TextBoxDimension.Visible = false;
            // 
            // LabelDimension
            // 
            this.LabelDimension.AutoSize = true;
            this.LabelDimension.Location = new System.Drawing.Point(27, 231);
            this.LabelDimension.Name = "LabelDimension";
            this.LabelDimension.Size = new System.Drawing.Size(84, 13);
            this.LabelDimension.TabIndex = 10;
            this.LabelDimension.Text = "Enter Dimension";
            this.LabelDimension.Visible = false;
            // 
            // ButtonAddGate
            // 
            this.ButtonAddGate.Location = new System.Drawing.Point(30, 273);
            this.ButtonAddGate.Name = "ButtonAddGate";
            this.ButtonAddGate.Size = new System.Drawing.Size(100, 48);
            this.ButtonAddGate.TabIndex = 11;
            this.ButtonAddGate.Text = "Add Gate";
            this.ButtonAddGate.UseVisualStyleBackColor = true;
            this.ButtonAddGate.Click += new System.EventHandler(this.ButtonAddGate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioButtonAccessModeIn);
            this.groupBox1.Controls.Add(this.RadioButtonAccessModeOut);
            this.groupBox1.Location = new System.Drawing.Point(33, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 73);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Access Mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioButtonTypeStdLogic);
            this.groupBox2.Controls.Add(this.RadioButtonTypeStdLogicVector);
            this.groupBox2.Location = new System.Drawing.Point(33, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 79);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Type";
            // 
            // AddGateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 333);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonAddGate);
            this.Controls.Add(this.LabelDimension);
            this.Controls.Add(this.TextBoxDimension);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TexBoxGateName);
            this.Name = "AddGateForm";
            this.Text = "Add New Gate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TexBoxGateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RadioButtonAccessModeIn;
        private System.Windows.Forms.RadioButton RadioButtonAccessModeOut;
        private System.Windows.Forms.RadioButton RadioButtonTypeStdLogic;
        private System.Windows.Forms.RadioButton RadioButtonTypeStdLogicVector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxDimension;
        private System.Windows.Forms.Label LabelDimension;
        private System.Windows.Forms.Button ButtonAddGate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
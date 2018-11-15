using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseProject
{
    public partial class AddGateForm : Form
    {
        Gate gate;

        public bool operationCreateGate = false;

        public AddGateForm()
        {
            InitializeComponent();
        }

        private void ButtonAddGate_Click(object sender, EventArgs e)
        {
            bool operationWithName = false;
            bool operationWithAccessMode = false;
            bool operationWithType = false;
            bool operationWithDimension = false;

           

            string name = "";
            string accessMode = "";
            string type = "";
            int dimension = 0;

            if (TexBoxGateName.Text == "")
                MessageBox.Show("Gate name is not entered. Please, enter gate's name.");
            else
            {
                name = TexBoxGateName.Text;
                operationWithName = true;
            }

            if (!RadioButtonAccessModeIn.Checked && !RadioButtonAccessModeOut.Checked)
                MessageBox.Show("Access mode is not selected. Please, select access mode.");
            else
            {
                if (RadioButtonAccessModeIn.Checked)
                    accessMode = "in";
                if (RadioButtonAccessModeOut.Checked)
                    accessMode = "out";
                operationWithAccessMode = true;
            }

            if(!RadioButtonTypeStdLogic.Checked && !RadioButtonTypeStdLogicVector.Checked)
                MessageBox.Show("Type is not selected. Please, select type.");
            {
                if (RadioButtonTypeStdLogic.Checked)
                {
                    type = "std_logic";
                    operationWithType = true;
                    operationWithDimension = true;
                    
                }
                if (RadioButtonTypeStdLogicVector.Checked)
                {
                    type = "std_logic_vector";
                    operationWithType = true;
                    
                    if (TextBoxDimension.Text == "")
                        MessageBox.Show("Dimension is not entered. Please, enter dimension.");
                    else
                    {
                        dimension = Int32.Parse(TextBoxDimension.Text);                      
                        operationWithDimension = true;
                    }
                }
            }

            if (name != "" && accessMode != "" && type != "")
            {

                if (type == "std_logic")
                    gate = new Gate(name, type, accessMode);
                if (type == "std_logic_vector")
                    gate = new Gate(name, type, accessMode, dimension);

                operationCreateGate = true;
            }

            if (operationWithName && operationWithAccessMode && operationWithType && operationWithDimension)
                this.Close();
        }

        public Gate GetNewGate()
        {
            return gate;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RadioButtonTypeStdLogicVector_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxDimension.Visible = true;
            LabelDimension.Visible = true;
        }

        private void RadioButtonTypeStdLogic_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxDimension.Visible = false;
            LabelDimension.Visible = false;
        }
    }
}

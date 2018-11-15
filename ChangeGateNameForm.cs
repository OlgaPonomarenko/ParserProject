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
    public partial class ChangeGateNameForm : Form
    {
        public bool operationChangeName = false;

        public string newGateName { get; set; }

        public ChangeGateNameForm()
        {
            newGateName = null;
            InitializeComponent();
        }

        private void ButtonChangeName_Click(object sender, EventArgs e)
        {
            if (TextBoxNewGateName.Text == "" || TextBoxNewGateName.Text == " ")
                MessageBox.Show("New gate's name is not entered. Please, enter new gate name.");
            else
            {
                newGateName = TextBoxNewGateName.Text;
                operationChangeName = true;
                this.Close();
            }

         }
    }
}

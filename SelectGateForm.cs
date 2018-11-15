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
    public partial class SelectGateForm : Form
    {
        public string selectedGateName { get; set; }

        public SelectGateForm()
        {
            InitializeComponent();
            selectedGateName = "";
        }

        public void FillListBoxByGateName(List<Gate> _listOfGateIn, List<Gate> _listOfGateOut)
        {
            foreach(Gate entry in _listOfGateIn)
            {
                ListBoxListOfGates.Items.Add(entry.gateName);
            }

            foreach(Gate entry in _listOfGateOut)
            {
                ListBoxListOfGates.Items.Add(entry.gateName);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            this.SetSelectedGateName();
            this.Close();
        }

        public void SetSelectedGateName()
        {
            selectedGateName = (string)ListBoxListOfGates.SelectedItem;
        }
    }
}

using BarcodeDesktopApp.DataHandling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeDesktopApp
{
    public partial class FormNewBarcode : Form
    {
        public FormNewBarcode(List<BarcodePartDataClass> in_ListAllParts)
        {
            InitializeComponent();
            cmbPart.DataSource = in_ListAllParts;
            cmbPart.DisplayMember = "BarcodePart";
        }

        private void buttonForOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbPart_Leave(object sender, EventArgs e)
        {
            if (cmbPart.SelectedItem != null)
            { // show barcode for part
                BarcodePartDataClass partToResolve = cmbPart.SelectedItem as BarcodePartDataClass;
                this.textBoxBarcode.Text = partToResolve.BarcodeRaw;
                // generate here barcode and show it

            }
        }
    }
}

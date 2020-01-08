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
    public partial class FormMain : Form
    {
        public DataHandlingClass dataHandlerLocal = new DataHandlingClass();

        public FormMain()
        {
            InitializeComponent();

            dataHandlerLocal.getDataFromConfigFile();
            dataHandlerLocal.checkDbAvailabilityAndRecreate(dataHandlerLocal.newconfig.pathToDatabase);
            //fill now table
            List<BarcodeDataClass> lst = dataHandlerLocal.getBarcodesDataFromDataBase(null);
            dataHandlerLocal.allPartsList = dataHandlerLocal.getAllParts();
            this.objectListViewMain.SetObjects(lst);
        }

        private void buttonNewEmptyRecord_Click(object sender, EventArgs e)
        {
            FormNewBarcode newBarcodeWnd = new FormNewBarcode(dataHandlerLocal.allPartsList,dataHandlerLocal);
            DialogResult rsDialg = newBarcodeWnd.ShowDialog();
            if (rsDialg == DialogResult.OK)
            {
                // check availability of part name

                // save new part if required

            }

        }

        private void objectListViewMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCopyRecord.Enabled = true;
            buttonPrint.Enabled = true;
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {

        }
    }
}

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
        private List<BarcodeDataClass> lstForTableInForm; // may be worth moving to DataHandlingClass, like allPartsList
        public FormMain()
        {
            InitializeComponent();

            dataHandlerLocal.getDataFromConfigFile();
            dataHandlerLocal.checkDbAvailabilityAndRecreate(dataHandlerLocal.newconfig.pathToDatabase);
            //fill now table
            lstForTableInForm = dataHandlerLocal.getBarcodesDataFromDataBase(null);
            dataHandlerLocal.allPartsList = dataHandlerLocal.getAllParts();
            this.objectListViewMain.SetObjects(lstForTableInForm);
        }

        private void buttonNewEmptyRecord_Click(object sender, EventArgs e)
        {
            FormNewBarcode newBarcodeWnd = new FormNewBarcode(dataHandlerLocal.allPartsList,dataHandlerLocal);
            DialogResult rsDialg = newBarcodeWnd.ShowDialog();
            if (rsDialg == DialogResult.OK)
            {
                // check part name and rescan list if needed
                bool refreshPartList = false;
                int IDofRelatedPart = dataHandlerLocal.insertNewEntryToPartsList(newBarcodeWnd.partName, newBarcodeWnd.barcodeString, ref refreshPartList);
                if (refreshPartList) {
                    //dataHandlerLocal.allPartsList = dataHandlerLocal.getAllParts();
                    // line above was changed to this:
                    dataHandlerLocal.allPartsList.Add(new BarcodePartDataClass { BarcodeType = BarcodeTypeEnum.EAN13, BarcodePart = newBarcodeWnd.partName, BarcodeRaw = newBarcodeWnd.barcodeString });
                }
                // save new part
                dataHandlerLocal.insertNewEntryToBarcodesList(IDofRelatedPart,newBarcodeWnd.BarcodeDate, newBarcodeWnd.BarcodeTruck, newBarcodeWnd.BarcodeCustomer, newBarcodeWnd.BarcodeMachine);
                this.lstForTableInForm.Insert(0, new BarcodeDataClass
                {
                    BarcodeCustomer = newBarcodeWnd.BarcodeCustomer,
                    BarcodeDate = newBarcodeWnd.BarcodeDate,
                    BarcodeMachine = newBarcodeWnd.BarcodeMachine,
                    BarcodePart = newBarcodeWnd.partName,
                    BarcodeTruck = newBarcodeWnd.BarcodeTruck,
                    barcodePartID = IDofRelatedPart
                });
                this.objectListViewMain.SetObjects(lstForTableInForm);
            }

        }

        private void objectListViewMain_SelectedIndexChanged(object sender, EventArgs e)
        {

                buttonCopyRecord.Enabled = (objectListViewMain.SelectedIndex != -1);
                buttonPrint.Enabled = (objectListViewMain.SelectedIndex != -1);
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {

        }
    }
}

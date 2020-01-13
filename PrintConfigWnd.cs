﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;
using BarcodeDesktopApp.DataHandling;

namespace BarcodeDesktopApp
{
    public partial class PrintConfigWnd : Form
    {
        // assign these values before showing up form (maube worth to move them to constructor)
        public List<BarcodeDataClass> itemsToShow = null;
        public DataHandlingClass handlingClassRef = null;
        bool doomedToReturn = false;

        public PrintConfigWnd()
        {
            InitializeComponent();
            printDoc.QueryPageSettings += PrintDoc_QueryPageSettings;
            printDoc.PrintPage += PrintDoc_PrintPage;
        }
        
        private void PrintConfigWnd_Load(object sender, EventArgs e)  {
            // fill printer list
            fillPrinterList();
            fillPrintDocument();
        }

        private void fillPrintDocument()  {
            doomedToReturn = false;
            if (handlingClassRef == null)  {
                MessageBox.Show("handlingClassRef == null", "No way to print");
                doomedToReturn = true;
            } else if (handlingClassRef.newconfig == null)  {
                MessageBox.Show("handlingClassRef not null ; config == null", "No way to print");
            }
            if (itemsToShow == null)    {
                MessageBox.Show("itemsToShow == null", "No way to print");
                doomedToReturn = true;
            }
            if (doomedToReturn) return;
            
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
        }

        private void PrintDoc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            PageSettings nSettings = new PageSettings();
            //e.PageSettings
        }

        private void fillPrinterList ()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            comboInstalledPrinters.Items.Clear();
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboInstalledPrinters.Items.Add(pkInstalledPrinters);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty( comboInstalledPrinters.Text ))   {
                errorProvider1.SetError(comboInstalledPrinters, LocalizableStrings.ErrorEmptyPrinter);
            } else {
                errorProvider1.SetError(comboInstalledPrinters, null);
            }
            printDoc.PrinterSettings.PrinterName = comboInstalledPrinters.Text;
        }
    }
}

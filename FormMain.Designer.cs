namespace BarcodeDesktopApp
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.objectListViewMain = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnPartNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDeliveryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTruckNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMachineName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCustomer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonNewEmptyRecord = new System.Windows.Forms.Button();
            this.buttonCopyRecord = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListViewMain
            // 
            this.objectListViewMain.AllColumns.Add(this.olvColumnPartNumber);
            this.objectListViewMain.AllColumns.Add(this.olvColumnDeliveryDate);
            this.objectListViewMain.AllColumns.Add(this.olvColumnTruckNumber);
            this.objectListViewMain.AllColumns.Add(this.olvColumnMachineName);
            this.objectListViewMain.AllColumns.Add(this.olvColumnCustomer);
            resources.ApplyResources(this.objectListViewMain, "objectListViewMain");
            this.objectListViewMain.CellEditUseWholeCell = false;
            this.objectListViewMain.CheckBoxes = true;
            this.objectListViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnPartNumber,
            this.olvColumnDeliveryDate,
            this.olvColumnTruckNumber,
            this.olvColumnMachineName,
            this.olvColumnCustomer});
            this.objectListViewMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewMain.FullRowSelect = true;
            this.objectListViewMain.HasCollapsibleGroups = false;
            this.objectListViewMain.HideSelection = false;
            this.objectListViewMain.MultiSelect = false;
            this.objectListViewMain.Name = "objectListViewMain";
            this.objectListViewMain.ShowGroups = false;
            this.objectListViewMain.UseCompatibleStateImageBehavior = false;
            this.objectListViewMain.View = System.Windows.Forms.View.Details;
            this.objectListViewMain.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ObjectListViewMain_ItemChecked);
            this.objectListViewMain.SelectedIndexChanged += new System.EventHandler(this.objectListViewMain_SelectedIndexChanged);
            // 
            // olvColumnPartNumber
            // 
            this.olvColumnPartNumber.AspectName = "BarcodePart";
            resources.ApplyResources(this.olvColumnPartNumber, "olvColumnPartNumber");
            // 
            // olvColumnDeliveryDate
            // 
            this.olvColumnDeliveryDate.AspectName = "BarcodeDate";
            this.olvColumnDeliveryDate.AspectToStringFormat = "{0:dd/MM/yyyy}";
            resources.ApplyResources(this.olvColumnDeliveryDate, "olvColumnDeliveryDate");
            // 
            // olvColumnTruckNumber
            // 
            this.olvColumnTruckNumber.AspectName = "BarcodeTruck";
            resources.ApplyResources(this.olvColumnTruckNumber, "olvColumnTruckNumber");
            // 
            // olvColumnMachineName
            // 
            this.olvColumnMachineName.AspectName = "BarcodeMachine";
            resources.ApplyResources(this.olvColumnMachineName, "olvColumnMachineName");
            // 
            // olvColumnCustomer
            // 
            this.olvColumnCustomer.AspectName = "BarcodeCustomer";
            resources.ApplyResources(this.olvColumnCustomer, "olvColumnCustomer");
            // 
            // buttonNewEmptyRecord
            // 
            resources.ApplyResources(this.buttonNewEmptyRecord, "buttonNewEmptyRecord");
            this.buttonNewEmptyRecord.Name = "buttonNewEmptyRecord";
            this.buttonNewEmptyRecord.UseVisualStyleBackColor = true;
            this.buttonNewEmptyRecord.Click += new System.EventHandler(this.buttonNewEmptyRecord_Click);
            // 
            // buttonCopyRecord
            // 
            resources.ApplyResources(this.buttonCopyRecord, "buttonCopyRecord");
            this.buttonCopyRecord.Name = "buttonCopyRecord";
            this.buttonCopyRecord.UseVisualStyleBackColor = true;
            this.buttonCopyRecord.Click += new System.EventHandler(this.ButtonCopyRecord_Click);
            // 
            // buttonPrint
            // 
            resources.ApplyResources(this.buttonPrint, "buttonPrint");
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // buttonFilter
            // 
            resources.ApplyResources(this.buttonFilter, "buttonFilter");
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonCopyRecord);
            this.Controls.Add(this.buttonNewEmptyRecord);
            this.Controls.Add(this.objectListViewMain);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListViewMain;
        private System.Windows.Forms.Button buttonNewEmptyRecord;
        private System.Windows.Forms.Button buttonCopyRecord;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonFilter;
        private BrightIdeasSoftware.OLVColumn olvColumnPartNumber;
        private BrightIdeasSoftware.OLVColumn olvColumnDeliveryDate;
        private BrightIdeasSoftware.OLVColumn olvColumnTruckNumber;
        private BrightIdeasSoftware.OLVColumn olvColumnMachineName;
        private BrightIdeasSoftware.OLVColumn olvColumnCustomer;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hummingbird.DM.Extensions.Interop.CMSFORM;
using Hummingbird.DM.Extensions.Interop.DOCSObjects;
using Hummingbird.DM.Extensions.Interop.VBFORMS;
using Hummingbird.DM.Server.Interop.PCDClient;

namespace cmdCustomSearch
{
    public partial class frmCustomSearchForm : Form
    {
        public bool bOK;
        private Hummingbird.DM.Extensions.Interop.VBFORMS.ISearch DMSearch;
        public Hummingbird.DM.Extensions.Interop.DOCSObjects.Application myDMApp;
        public string DMLibraryName = "", DMmyDST = "";


        public frmCustomSearchForm()
        {
            InitializeComponent();
        }

        public void init(Hummingbird.DM.Extensions.Interop.VBFORMS.ISearch objSearchArgument)
        {
            Hummingbird.DM.Extensions.Interop.DOCSObjects.Library DMLibrary;
            Hummingbird.DM.Extensions.Interop.DOCSObjects.DOCSForms DMForms;
            Hummingbird.DM.Extensions.Interop.DOCSObjects.DOCSForm DMForm;
            string strFormDefinition;
            object objControl;
            DMSearch = objSearchArgument;
            DMLibrary = (Hummingbird.DM.Extensions.Interop.DOCSObjects.Library)DMSearch.Library;
            DMForms = DMLibrary.Forms;
            DMForm = DMForms[DMSearch.FormName];
            strFormDefinition = DMForm.FormDefinition;
            this.axCMSForm1.Init(Hummingbird.DM.Extensions.Interop.CMSFORM.InitFormFlags.frmQBE, DMForm.FormDefinition);
            foreach (Hummingbird.DM.Extensions.Interop.DOCSObjects.Column DMColumn in DMSearch.Columns)
            {
                objControl = this.axCMSForm1.GetControl(DMColumn.Name);
                Type t = objControl.GetType();
                if (t.ToString() == "Hummingbird.DM.Extensions.Interop.CMSCTRLS.CMSEditClass")
                {
                    ((Hummingbird.DM.Extensions.Interop.CMSCTRLS.CMSEdit)objControl).Value = DMColumn.Value;
                }
                else if (t.ToString() == "Hummingbird.DM.Extensions.Interop.CMSCTRLS.CMSCheckBoxClass")
                {
                    ((Hummingbird.DM.Extensions.Interop.CMSCTRLS.CMSCheckBox)objControl).Value = DMColumn.Value;
                }
            }
        }
        
        private void frmCustomSearchForm_Load(object sender, EventArgs e)
        {
            this.Text = "Custom Search Form";
            myDMApp = new Hummingbird.DM.Extensions.Interop.DOCSObjects.Application();
            DMmyDST = myDMApp.DST;
            DMLibraryName = myDMApp.CurrentLibrary.Name;
        }

        private void axCMSForm1_ButtonPressed(object sender, AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_ButtonPressedEvent e)
        {
            switch (e.controlName)
            {
                case "OK":
                    this.bOK = true;
                    this.Hide();
                    break;
                case "CANCEL":
                    this.Hide();
                    break;
                case "CLOSE":
                    this.Hide();
                    break;
            }
        }

        private void axCMSForm1_DataChanged(object sender, AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_DataChangedEvent e)
        {
            Hummingbird.DM.Extensions.Interop.DOCSObjects.Column DMColumn;
            DMColumn = (Hummingbird.DM.Extensions.Interop.DOCSObjects.Column)DMSearch.Columns[e.controlName];
            if (DMColumn != null)
            {
                DMColumn.Value = this.axCMSForm1.GetValue(e.controlName);
            }
        }

        private void axCMSForm1_DoLookup(object sender, AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_DoLookupEvent e)
        {
            Hummingbird.DM.Extensions.Interop.DOCSObjects.IBCCoreCtx DMBCCoreCtx;
            object objControl;
            Hummingbird.DM.Extensions.Interop.DOCSObjects.Column DMColumn;
            string strChangedColumns = "";
            string strColumnName = "";
            string strColumnValue = "";
            string[] arrStrColumnNames;
            DMColumn = (Hummingbird.DM.Extensions.Interop.DOCSObjects.Column)DMSearch.Columns[e.controlName];
            if (DMColumn != null)
            {
                DMBCCoreCtx = DMColumn.DoLookup(0, (int)Hummingbird.DM.Extensions.Interop.DOCSObjects.OMFlagsLookUp.DL_SHOW_LOOKUP);
                strChangedColumns = DMBCCoreCtx.GetVariantParam("ChangedColumns").ToString();
                if (strChangedColumns != "")
                {
                    arrStrColumnNames = strChangedColumns.Split(';');
                    strColumnName = arrStrColumnNames[0].ToString();
                    strColumnValue = DMBCCoreCtx.GetVariantParam(strColumnName).ToString();
                }
                objControl = this.axCMSForm1.GetControl(strColumnName);
                this.axCMSForm1.SetValue(strColumnName, strColumnValue);
            }
        }

        private void axCMSForm1_InvalidInput(object sender, AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_InvalidInputEvent e)
        {

        }

    }
}

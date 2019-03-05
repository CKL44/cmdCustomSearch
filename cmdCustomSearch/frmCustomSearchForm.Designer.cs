namespace cmdCustomSearch
{
    partial class frmCustomSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomSearchForm));
            this.axCMSForm1 = new AxHummingbird.DM.Extensions.Interop.CMSFORM.AxCMSForm();
            ((System.ComponentModel.ISupportInitialize)(this.axCMSForm1)).BeginInit();
            this.SuspendLayout();
            // 
            // axCMSForm1
            // 
            this.axCMSForm1.Enabled = true;
            this.axCMSForm1.Location = new System.Drawing.Point(12, 12);
            this.axCMSForm1.Name = "axCMSForm1";
            this.axCMSForm1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCMSForm1.OcxState")));
            this.axCMSForm1.Size = new System.Drawing.Size(32, 32);
            this.axCMSForm1.TabIndex = 0;
            this.axCMSForm1.DataChanged += new AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_DataChangedEventHandler(this.axCMSForm1_DataChanged);
            this.axCMSForm1.InvalidInput += new AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_InvalidInputEventHandler(this.axCMSForm1_InvalidInput);
            this.axCMSForm1.ButtonPressed += new AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_ButtonPressedEventHandler(this.axCMSForm1_ButtonPressed);
            this.axCMSForm1.DoLookup += new AxHummingbird.DM.Extensions.Interop.CMSFORM._DCMSFormEvents_DoLookupEventHandler(this.axCMSForm1_DoLookup);
            // 
            // frmCustomSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axCMSForm1);
            this.Name = "frmCustomSearchForm";
            this.Text = "frmCustomSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.axCMSForm1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxHummingbird.DM.Extensions.Interop.CMSFORM.AxCMSForm axCMSForm1;
    }
}
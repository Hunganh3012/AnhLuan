namespace QLNhaSach
{
    partial class frmInDanhSachNhaCungCap
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InDanhSachNhaCungCapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsNhaCungCap = new QLNhaSach.DsNhaCungCap();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InDanhSachNhaCungCapTableAdapter = new QLNhaSach.DsNhaCungCapTableAdapters.InDanhSachNhaCungCapTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InDanhSachNhaCungCapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // InDanhSachNhaCungCapBindingSource
            // 
            this.InDanhSachNhaCungCapBindingSource.DataMember = "InDanhSachNhaCungCap";
            this.InDanhSachNhaCungCapBindingSource.DataSource = this.DsNhaCungCap;
            // 
            // DsNhaCungCap
            // 
            this.DsNhaCungCap.DataSetName = "DsNhaCungCap";
            this.DsNhaCungCap.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.InDanhSachNhaCungCapBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNhaSach.ReportDsNhaCungCap.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(985, 502);
            this.reportViewer1.TabIndex = 0;
            // 
            // InDanhSachNhaCungCapTableAdapter
            // 
            this.InDanhSachNhaCungCapTableAdapter.ClearBeforeFill = true;
            // 
            // frmInDanhSachNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 502);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInDanhSachNhaCungCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Nhà Cung Cấp";
            this.Load += new System.EventHandler(this.InDanhSachNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InDanhSachNhaCungCapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsNhaCungCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InDanhSachNhaCungCapBindingSource;
        private DsNhaCungCap DsNhaCungCap;
        private DsNhaCungCapTableAdapters.InDanhSachNhaCungCapTableAdapter InDanhSachNhaCungCapTableAdapter;
    }
}
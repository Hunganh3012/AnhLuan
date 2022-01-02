namespace QLNhaSach
{
    partial class frmInDanhSachMatHang
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
            this.DsLoaiMatHang = new QLNhaSach.DsLoaiMatHang();
            this.LOAIMATHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LOAIMATHANGTableAdapter = new QLNhaSach.DsLoaiMatHangTableAdapters.LOAIMATHANGTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsMatHang = new QLNhaSach.DsMatHang();
            this.InDsMatHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InDsMatHangTableAdapter = new QLNhaSach.DsMatHangTableAdapters.InDsMatHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsLoaiMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOAIMATHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InDsMatHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DsLoaiMatHang
            // 
            this.DsLoaiMatHang.DataSetName = "DsLoaiMatHang";
            this.DsLoaiMatHang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LOAIMATHANGBindingSource
            // 
            this.LOAIMATHANGBindingSource.DataMember = "LOAIMATHANG";
            this.LOAIMATHANGBindingSource.DataSource = this.DsLoaiMatHang;
            // 
            // LOAIMATHANGTableAdapter
            // 
            this.LOAIMATHANGTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.InDsMatHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNhaSach.ReportDsMatHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1173, 630);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsMatHang
            // 
            this.DsMatHang.DataSetName = "DsMatHang";
            this.DsMatHang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // InDsMatHangBindingSource
            // 
            this.InDsMatHangBindingSource.DataMember = "InDsMatHang";
            this.InDsMatHangBindingSource.DataSource = this.DsMatHang;
            // 
            // InDsMatHangTableAdapter
            // 
            this.InDsMatHangTableAdapter.ClearBeforeFill = true;
            // 
            // frmInDanhSachMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 630);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInDanhSachMatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Mặt Hàng";
            this.Load += new System.EventHandler(this.InDanhSachMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsLoaiMatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOAIMATHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsMatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InDsMatHangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource LOAIMATHANGBindingSource;
        private DsLoaiMatHang DsLoaiMatHang;
        private DsLoaiMatHangTableAdapters.LOAIMATHANGTableAdapter LOAIMATHANGTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InDsMatHangBindingSource;
        private DsMatHang DsMatHang;
        private DsMatHangTableAdapters.InDsMatHangTableAdapter InDsMatHangTableAdapter;
    }
}
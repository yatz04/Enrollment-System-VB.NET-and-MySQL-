<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ReportEnrollment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.tbl_enrollmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.db_enrollmentDataSet = New Enrollment.db_enrollmentDataSet()
        Me.tbl_subjectsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewerEnrollment = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tbl_enrollmentTableAdapter = New Enrollment.db_enrollmentDataSetTableAdapters.tbl_enrollmentTableAdapter()
        Me.tbl_subjectsTableAdapter = New Enrollment.db_enrollmentDataSetTableAdapters.tbl_subjectsTableAdapter()
        Me.db_enrollmentDataSet1 = New Enrollment.db_enrollmentDataSet1()
        Me.temp_tableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.temp_tableTableAdapter = New Enrollment.db_enrollmentDataSet1TableAdapters.temp_tableTableAdapter()
        Me.db_enrollmentDataSet2 = New Enrollment.db_enrollmentDataSet2()
        Me.tbl_accountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbl_accountsTableAdapter = New Enrollment.db_enrollmentDataSet2TableAdapters.tbl_accountsTableAdapter()
        CType(Me.tbl_enrollmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.db_enrollmentDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbl_subjectsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.db_enrollmentDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.temp_tableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.db_enrollmentDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbl_accountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_enrollmentBindingSource
        '
        Me.tbl_enrollmentBindingSource.DataMember = "tbl_enrollment"
        Me.tbl_enrollmentBindingSource.DataSource = Me.db_enrollmentDataSet
        '
        'db_enrollmentDataSet
        '
        Me.db_enrollmentDataSet.DataSetName = "db_enrollmentDataSet"
        Me.db_enrollmentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tbl_subjectsBindingSource
        '
        Me.tbl_subjectsBindingSource.DataMember = "tbl_subjects"
        Me.tbl_subjectsBindingSource.DataSource = Me.db_enrollmentDataSet
        '
        'ReportViewerEnrollment
        '
        Me.ReportViewerEnrollment.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsEnrollment"
        ReportDataSource1.Value = Me.temp_tableBindingSource
        ReportDataSource2.Name = "dsAccount"
        ReportDataSource2.Value = Me.tbl_accountsBindingSource
        Me.ReportViewerEnrollment.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewerEnrollment.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewerEnrollment.LocalReport.ReportEmbeddedResource = "Enrollment.rptEnrollmentForm.rdlc"
        Me.ReportViewerEnrollment.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewerEnrollment.Name = "ReportViewerEnrollment"
        Me.ReportViewerEnrollment.Size = New System.Drawing.Size(474, 550)
        Me.ReportViewerEnrollment.TabIndex = 0
        Me.ReportViewerEnrollment.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        '
        'tbl_enrollmentTableAdapter
        '
        Me.tbl_enrollmentTableAdapter.ClearBeforeFill = True
        '
        'tbl_subjectsTableAdapter
        '
        Me.tbl_subjectsTableAdapter.ClearBeforeFill = True
        '
        'db_enrollmentDataSet1
        '
        Me.db_enrollmentDataSet1.DataSetName = "db_enrollmentDataSet1"
        Me.db_enrollmentDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'temp_tableBindingSource
        '
        Me.temp_tableBindingSource.DataMember = "temp_table"
        Me.temp_tableBindingSource.DataSource = Me.db_enrollmentDataSet1
        '
        'temp_tableTableAdapter
        '
        Me.temp_tableTableAdapter.ClearBeforeFill = True
        '
        'db_enrollmentDataSet2
        '
        Me.db_enrollmentDataSet2.DataSetName = "db_enrollmentDataSet2"
        Me.db_enrollmentDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tbl_accountsBindingSource
        '
        Me.tbl_accountsBindingSource.DataMember = "tbl_accounts"
        Me.tbl_accountsBindingSource.DataSource = Me.db_enrollmentDataSet2
        '
        'tbl_accountsTableAdapter
        '
        Me.tbl_accountsTableAdapter.ClearBeforeFill = True
        '
        'frm_ReportEnrollment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 550)
        Me.Controls.Add(Me.ReportViewerEnrollment)
        Me.Name = "frm_ReportEnrollment"
        Me.Text = "Enrollment Form"
        CType(Me.tbl_enrollmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.db_enrollmentDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbl_subjectsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.db_enrollmentDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.temp_tableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.db_enrollmentDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbl_accountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewerEnrollment As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tbl_enrollmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents db_enrollmentDataSet As Enrollment.db_enrollmentDataSet
    Friend WithEvents tbl_subjectsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tbl_enrollmentTableAdapter As Enrollment.db_enrollmentDataSetTableAdapters.tbl_enrollmentTableAdapter
    Friend WithEvents tbl_subjectsTableAdapter As Enrollment.db_enrollmentDataSetTableAdapters.tbl_subjectsTableAdapter
    Friend WithEvents temp_tableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents db_enrollmentDataSet1 As Enrollment.db_enrollmentDataSet1
    Friend WithEvents tbl_accountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents db_enrollmentDataSet2 As Enrollment.db_enrollmentDataSet2
    Friend WithEvents temp_tableTableAdapter As Enrollment.db_enrollmentDataSet1TableAdapters.temp_tableTableAdapter
    Friend WithEvents tbl_accountsTableAdapter As Enrollment.db_enrollmentDataSet2TableAdapters.tbl_accountsTableAdapter
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ReportAllEnrollmentForm
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
        Me.temp_tableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.db_enrollmentDataSet1 = New Enrollment.db_enrollmentDataSet1()
        Me.tbl_accountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.db_enrollmentDataSet2 = New Enrollment.db_enrollmentDataSet2()
        Me.ReportViewerAll = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.temp_tableTableAdapter = New Enrollment.db_enrollmentDataSet1TableAdapters.temp_tableTableAdapter()
        Me.tbl_accountsTableAdapter = New Enrollment.db_enrollmentDataSet2TableAdapters.tbl_accountsTableAdapter()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.temp_tableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.db_enrollmentDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbl_accountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.db_enrollmentDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'temp_tableBindingSource
        '
        Me.temp_tableBindingSource.DataMember = "temp_table"
        Me.temp_tableBindingSource.DataSource = Me.db_enrollmentDataSet1
        '
        'db_enrollmentDataSet1
        '
        Me.db_enrollmentDataSet1.DataSetName = "db_enrollmentDataSet1"
        Me.db_enrollmentDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tbl_accountsBindingSource
        '
        Me.tbl_accountsBindingSource.DataMember = "tbl_accounts"
        Me.tbl_accountsBindingSource.DataSource = Me.db_enrollmentDataSet2
        '
        'db_enrollmentDataSet2
        '
        Me.db_enrollmentDataSet2.DataSetName = "db_enrollmentDataSet2"
        Me.db_enrollmentDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewerAll
        '
        Me.ReportViewerAll.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsEnrollment"
        ReportDataSource1.Value = Me.temp_tableBindingSource
        ReportDataSource2.Name = "dsAccount"
        ReportDataSource2.Value = Me.tbl_accountsBindingSource
        Me.ReportViewerAll.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewerAll.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewerAll.LocalReport.ReportEmbeddedResource = "Enrollment.rpt_AllEnrollmentForm.rdlc"
        Me.ReportViewerAll.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewerAll.Name = "ReportViewerAll"
        Me.ReportViewerAll.Size = New System.Drawing.Size(936, 549)
        Me.ReportViewerAll.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(191, 493)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Year Level"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Course"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(11, 145)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(166, 21)
        Me.ComboBox2.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(10, 57)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(168, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'temp_tableTableAdapter
        '
        Me.temp_tableTableAdapter.ClearBeforeFill = True
        '
        'tbl_accountsTableAdapter
        '
        Me.tbl_accountsTableAdapter.ClearBeforeFill = True
        '
        'frm_ReportAllEnrollmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 549)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ReportViewerAll)
        Me.Name = "frm_ReportAllEnrollmentForm"
        Me.Text = "Enrollment Forms"
        CType(Me.temp_tableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.db_enrollmentDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbl_accountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.db_enrollmentDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewerAll As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents temp_tableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents db_enrollmentDataSet1 As Enrollment.db_enrollmentDataSet1
    Friend WithEvents tbl_accountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents db_enrollmentDataSet2 As Enrollment.db_enrollmentDataSet2
    Friend WithEvents temp_tableTableAdapter As Enrollment.db_enrollmentDataSet1TableAdapters.temp_tableTableAdapter
    Friend WithEvents tbl_accountsTableAdapter As Enrollment.db_enrollmentDataSet2TableAdapters.tbl_accountsTableAdapter
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class

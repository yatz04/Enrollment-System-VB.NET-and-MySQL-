<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ReportStudents
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
        Me.tbl_enrollmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.db_enrollmentDataSet3 = New Enrollment.db_enrollmentDataSet3()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ComboCourse = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboYearLevel = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboMajor = New System.Windows.Forms.ComboBox()
        Me.tbl_enrollmentTableAdapter = New Enrollment.db_enrollmentDataSet3TableAdapters.tbl_enrollmentTableAdapter()
        CType(Me.tbl_enrollmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.db_enrollmentDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_enrollmentBindingSource
        '
        Me.tbl_enrollmentBindingSource.DataMember = "tbl_enrollment"
        Me.tbl_enrollmentBindingSource.DataSource = Me.db_enrollmentDataSet3
        '
        'db_enrollmentDataSet3
        '
        Me.db_enrollmentDataSet3.DataSetName = "db_enrollmentDataSet3"
        Me.db_enrollmentDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "dsStudents"
        ReportDataSource1.Value = Me.tbl_enrollmentBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Enrollment.Rpt_Students.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 80)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(767, 536)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        Me.ReportViewer1.ZoomPercent = 25
        '
        'ComboCourse
        '
        Me.ComboCourse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCourse.FormattingEnabled = True
        Me.ComboCourse.Location = New System.Drawing.Point(74, 12)
        Me.ComboCourse.Name = "ComboCourse"
        Me.ComboCourse.Size = New System.Drawing.Size(442, 28)
        Me.ComboCourse.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Course:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(579, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Year Level:"
        '
        'ComboYearLevel
        '
        Me.ComboYearLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboYearLevel.FormattingEnabled = True
        Me.ComboYearLevel.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ComboYearLevel.Location = New System.Drawing.Point(673, 12)
        Me.ComboYearLevel.Name = "ComboYearLevel"
        Me.ComboYearLevel.Size = New System.Drawing.Size(82, 28)
        Me.ComboYearLevel.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Major:"
        '
        'ComboMajor
        '
        Me.ComboMajor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMajor.FormattingEnabled = True
        Me.ComboMajor.Location = New System.Drawing.Point(74, 46)
        Me.ComboMajor.Name = "ComboMajor"
        Me.ComboMajor.Size = New System.Drawing.Size(442, 28)
        Me.ComboMajor.TabIndex = 5
        '
        'tbl_enrollmentTableAdapter
        '
        Me.tbl_enrollmentTableAdapter.ClearBeforeFill = True
        '
        'frm_ReportStudents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RoyalBlue
        Me.ClientSize = New System.Drawing.Size(767, 616)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboMajor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboYearLevel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboCourse)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ReportStudents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of Students"
        CType(Me.tbl_enrollmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.db_enrollmentDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ComboCourse As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboYearLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboMajor As System.Windows.Forms.ComboBox
    Friend WithEvents tbl_enrollmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents db_enrollmentDataSet3 As Enrollment.db_enrollmentDataSet3
    Friend WithEvents tbl_enrollmentTableAdapter As Enrollment.db_enrollmentDataSet3TableAdapters.tbl_enrollmentTableAdapter
End Class

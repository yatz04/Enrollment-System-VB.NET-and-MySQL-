<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ReportCurriculumvb
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
        Me.tbl_coursesubjectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.db_enrollmentDataSet4 = New Enrollment.db_enrollmentDataSet4()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tbl_coursesubjectTableAdapter = New Enrollment.db_enrollmentDataSet4TableAdapters.tbl_coursesubjectTableAdapter()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboMajor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboCourse = New System.Windows.Forms.ComboBox()
        CType(Me.tbl_coursesubjectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.db_enrollmentDataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_coursesubjectBindingSource
        '
        Me.tbl_coursesubjectBindingSource.DataMember = "tbl_coursesubject"
        Me.tbl_coursesubjectBindingSource.DataSource = Me.db_enrollmentDataSet4
        '
        'db_enrollmentDataSet4
        '
        Me.db_enrollmentDataSet4.DataSetName = "db_enrollmentDataSet4"
        Me.db_enrollmentDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "dsCurriculum"
        ReportDataSource1.Value = Me.tbl_coursesubjectBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Enrollment.Rpt_Curriculum.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 80)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(725, 534)
        Me.ReportViewer1.TabIndex = 0
        '
        'tbl_coursesubjectTableAdapter
        '
        Me.tbl_coursesubjectTableAdapter.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(20, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Major:"
        '
        'ComboMajor
        '
        Me.ComboMajor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMajor.FormattingEnabled = True
        Me.ComboMajor.Location = New System.Drawing.Point(78, 46)
        Me.ComboMajor.Name = "ComboMajor"
        Me.ComboMajor.Size = New System.Drawing.Size(442, 28)
        Me.ComboMajor.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Course:"
        '
        'ComboCourse
        '
        Me.ComboCourse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCourse.FormattingEnabled = True
        Me.ComboCourse.Location = New System.Drawing.Point(78, 12)
        Me.ComboCourse.Name = "ComboCourse"
        Me.ComboCourse.Size = New System.Drawing.Size(442, 28)
        Me.ComboCourse.TabIndex = 7
        '
        'frm_ReportCurriculumvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RoyalBlue
        Me.ClientSize = New System.Drawing.Size(725, 614)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboMajor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboCourse)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ReportCurriculumvb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Curriculum"
        CType(Me.tbl_coursesubjectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.db_enrollmentDataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tbl_coursesubjectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents db_enrollmentDataSet4 As Enrollment.db_enrollmentDataSet4
    Friend WithEvents tbl_coursesubjectTableAdapter As Enrollment.db_enrollmentDataSet4TableAdapters.tbl_coursesubjectTableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboMajor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboCourse As System.Windows.Forms.ComboBox
End Class

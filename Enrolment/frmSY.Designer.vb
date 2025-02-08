<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSY
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
        Me.ComboSY = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_CLOSE = New System.Windows.Forms.Button()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboSY
        '
        Me.ComboSY.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboSY.FormattingEnabled = True
        Me.ComboSY.Location = New System.Drawing.Point(165, 45)
        Me.ComboSY.Name = "ComboSY"
        Me.ComboSY.Size = New System.Drawing.Size(167, 30)
        Me.ComboSY.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "School Year:"
        '
        'BTN_CLOSE
        '
        Me.BTN_CLOSE.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CLOSE.Location = New System.Drawing.Point(208, 115)
        Me.BTN_CLOSE.Name = "BTN_CLOSE"
        Me.BTN_CLOSE.Size = New System.Drawing.Size(90, 40)
        Me.BTN_CLOSE.TabIndex = 7
        Me.BTN_CLOSE.Text = "Close"
        Me.BTN_CLOSE.UseVisualStyleBackColor = True
        '
        'BTN_OK
        '
        Me.BTN_OK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_OK.Location = New System.Drawing.Point(101, 115)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(90, 40)
        Me.BTN_OK.TabIndex = 6
        Me.BTN_OK.Text = "OK"
        Me.BTN_OK.UseVisualStyleBackColor = True
        '
        'frmSY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 175)
        Me.Controls.Add(Me.BTN_CLOSE)
        Me.Controls.Add(Me.BTN_OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboSY)
        Me.Name = "frmSY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "School Year"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboSY As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTN_CLOSE As System.Windows.Forms.Button
    Friend WithEvents BTN_OK As System.Windows.Forms.Button
End Class

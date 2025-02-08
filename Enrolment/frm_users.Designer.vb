<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_users
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_users))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonPreview = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxUserID = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxUserName = New System.Windows.Forms.TextBox()
        Me.ListBoxAccounts = New System.Windows.Forms.ListBox()
        Me.GroupBoxAllow = New System.Windows.Forms.GroupBox()
        Me.CheckBoxDelete = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEdit = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAdd = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxType = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBoxAllow.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNew, Me.ToolStripButtonSave, Me.ToolStripButtonEdit, Me.ToolStripButtonDelete, Me.ToolStripButtonPreview})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(703, 39)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonNew
        '
        Me.ToolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonNew.Image = CType(resources.GetObject("ToolStripButtonNew.Image"), System.Drawing.Image)
        Me.ToolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonNew.Name = "ToolStripButtonNew"
        Me.ToolStripButtonNew.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButtonNew.Tag = "New"
        Me.ToolStripButtonNew.Text = "New"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Image = CType(resources.GetObject("ToolStripButtonSave.Image"), System.Drawing.Image)
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButtonSave.Tag = "Save"
        Me.ToolStripButtonSave.Text = "Save"
        '
        'ToolStripButtonEdit
        '
        Me.ToolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonEdit.Image = CType(resources.GetObject("ToolStripButtonEdit.Image"), System.Drawing.Image)
        Me.ToolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEdit.Name = "ToolStripButtonEdit"
        Me.ToolStripButtonEdit.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButtonEdit.Tag = "Edit"
        Me.ToolStripButtonEdit.Text = "Edit"
        '
        'ToolStripButtonDelete
        '
        Me.ToolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDelete.Image = CType(resources.GetObject("ToolStripButtonDelete.Image"), System.Drawing.Image)
        Me.ToolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDelete.Name = "ToolStripButtonDelete"
        Me.ToolStripButtonDelete.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButtonDelete.Tag = "Delete"
        Me.ToolStripButtonDelete.Text = "Delete"
        '
        'ToolStripButtonPreview
        '
        Me.ToolStripButtonPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPreview.Image = CType(resources.GetObject("ToolStripButtonPreview.Image"), System.Drawing.Image)
        Me.ToolStripButtonPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPreview.Name = "ToolStripButtonPreview"
        Me.ToolStripButtonPreview.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButtonPreview.Tag = "Preview"
        Me.ToolStripButtonPreview.Text = "Preview"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBoxType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TextBoxUserID)
        Me.GroupBox1.Controls.Add(Me.TextBoxPassword)
        Me.GroupBox1.Controls.Add(Me.TextBoxUserName)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(218, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(463, 170)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 23)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Password:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(38, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 23)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "User ID:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(42, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 23)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Username:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxUserID
        '
        Me.TextBoxUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxUserID.Location = New System.Drawing.Point(149, 20)
        Me.TextBoxUserID.Name = "TextBoxUserID"
        Me.TextBoxUserID.Size = New System.Drawing.Size(225, 26)
        Me.TextBoxUserID.TabIndex = 47
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPassword.Location = New System.Drawing.Point(149, 84)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(225, 26)
        Me.TextBoxPassword.TabIndex = 43
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxUserName.Location = New System.Drawing.Point(149, 52)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(225, 26)
        Me.TextBoxUserName.TabIndex = 42
        '
        'ListBoxAccounts
        '
        Me.ListBoxAccounts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxAccounts.FormattingEnabled = True
        Me.ListBoxAccounts.ItemHeight = 20
        Me.ListBoxAccounts.Location = New System.Drawing.Point(7, 51)
        Me.ListBoxAccounts.Name = "ListBoxAccounts"
        Me.ListBoxAccounts.Size = New System.Drawing.Size(205, 224)
        Me.ListBoxAccounts.TabIndex = 62
        '
        'GroupBoxAllow
        '
        Me.GroupBoxAllow.Controls.Add(Me.CheckBoxDelete)
        Me.GroupBoxAllow.Controls.Add(Me.CheckBoxEdit)
        Me.GroupBoxAllow.Controls.Add(Me.CheckBoxAdd)
        Me.GroupBoxAllow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxAllow.ForeColor = System.Drawing.Color.Black
        Me.GroupBoxAllow.Location = New System.Drawing.Point(218, 218)
        Me.GroupBoxAllow.Name = "GroupBoxAllow"
        Me.GroupBoxAllow.Size = New System.Drawing.Size(464, 62)
        Me.GroupBoxAllow.TabIndex = 61
        Me.GroupBoxAllow.TabStop = False
        Me.GroupBoxAllow.Text = "Allowed to..."
        '
        'CheckBoxDelete
        '
        Me.CheckBoxDelete.AutoSize = True
        Me.CheckBoxDelete.Location = New System.Drawing.Point(342, 29)
        Me.CheckBoxDelete.Name = "CheckBoxDelete"
        Me.CheckBoxDelete.Size = New System.Drawing.Size(75, 24)
        Me.CheckBoxDelete.TabIndex = 9
        Me.CheckBoxDelete.Text = "Delete"
        Me.CheckBoxDelete.UseVisualStyleBackColor = True
        '
        'CheckBoxEdit
        '
        Me.CheckBoxEdit.AutoSize = True
        Me.CheckBoxEdit.Location = New System.Drawing.Point(190, 29)
        Me.CheckBoxEdit.Name = "CheckBoxEdit"
        Me.CheckBoxEdit.Size = New System.Drawing.Size(56, 24)
        Me.CheckBoxEdit.TabIndex = 8
        Me.CheckBoxEdit.Text = "Edit"
        Me.CheckBoxEdit.UseVisualStyleBackColor = True
        '
        'CheckBoxAdd
        '
        Me.CheckBoxAdd.AutoSize = True
        Me.CheckBoxAdd.Location = New System.Drawing.Point(37, 29)
        Me.CheckBoxAdd.Name = "CheckBoxAdd"
        Me.CheckBoxAdd.Size = New System.Drawing.Size(57, 24)
        Me.CheckBoxAdd.TabIndex = 7
        Me.CheckBoxAdd.Text = "Add"
        Me.CheckBoxAdd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 23)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Type:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxType
        '
        Me.ComboBoxType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxType.FormattingEnabled = True
        Me.ComboBoxType.Items.AddRange(New Object() {"Admin", "Registrar", "Cashier", "Teacher"})
        Me.ComboBoxType.Location = New System.Drawing.Point(149, 115)
        Me.ComboBoxType.Name = "ComboBoxType"
        Me.ComboBoxType.Size = New System.Drawing.Size(225, 28)
        Me.ComboBoxType.TabIndex = 55
        '
        'frm_users
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(703, 299)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListBoxAccounts)
        Me.Controls.Add(Me.GroupBoxAllow)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frm_users"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Accounts"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBoxAllow.ResumeLayout(False)
        Me.GroupBoxAllow.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButtonNew As ToolStripButton
    Friend WithEvents ToolStripButtonSave As ToolStripButton
    Friend WithEvents ToolStripButtonEdit As ToolStripButton
    Friend WithEvents ToolStripButtonDelete As ToolStripButton
    Friend WithEvents ToolStripButtonPreview As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxUserID As TextBox
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents TextBoxUserName As TextBox
    Friend WithEvents ListBoxAccounts As ListBox
    Friend WithEvents GroupBoxAllow As GroupBox
    Friend WithEvents CheckBoxDelete As CheckBox
    Friend WithEvents CheckBoxEdit As CheckBox
    Friend WithEvents CheckBoxAdd As CheckBox
    Friend WithEvents ComboBoxType As ComboBox
    Friend WithEvents Label2 As Label
End Class

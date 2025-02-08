<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Students
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Students))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEdit = New System.Windows.Forms.ToolStripButton()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.txtIDNO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtExt = New System.Windows.Forms.TextBox()
        Me.DateTimePickerDOB = New System.Windows.Forms.DateTimePicker()
        Me.ComboSex = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtContactno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMiddle = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLast = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtContactCP = New System.Windows.Forms.TextBox()
        Me.txtContactRelationship = New System.Windows.Forms.TextBox()
        Me.txtContactAddress = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ButtonSearch)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.TextBoxSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(901, 61)
        Me.Panel1.TabIndex = 0
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Image = CType(resources.GetObject("ButtonSearch.Image"), System.Drawing.Image)
        Me.ButtonSearch.Location = New System.Drawing.Point(375, 16)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(39, 29)
        Me.ButtonSearch.TabIndex = 47
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(13, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 20)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Search:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSearch.Location = New System.Drawing.Point(85, 17)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(274, 26)
        Me.TextBoxSearch.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNew, Me.ToolStripButtonSave, Me.ToolStripButtonDelete, Me.ToolStripButtonEdit})
        Me.ToolStrip1.Location = New System.Drawing.Point(225, 61)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(676, 43)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonNew
        '
        Me.ToolStripButtonNew.AutoSize = False
        Me.ToolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonNew.Image = CType(resources.GetObject("ToolStripButtonNew.Image"), System.Drawing.Image)
        Me.ToolStripButtonNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonNew.Name = "ToolStripButtonNew"
        Me.ToolStripButtonNew.Size = New System.Drawing.Size(60, 40)
        Me.ToolStripButtonNew.Tag = "New"
        Me.ToolStripButtonNew.Text = "New"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.AutoSize = False
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Image = CType(resources.GetObject("ToolStripButtonSave.Image"), System.Drawing.Image)
        Me.ToolStripButtonSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(60, 40)
        Me.ToolStripButtonSave.Tag = "Save"
        Me.ToolStripButtonSave.Text = "Save"
        '
        'ToolStripButtonDelete
        '
        Me.ToolStripButtonDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonDelete.AutoSize = False
        Me.ToolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDelete.Image = CType(resources.GetObject("ToolStripButtonDelete.Image"), System.Drawing.Image)
        Me.ToolStripButtonDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDelete.Name = "ToolStripButtonDelete"
        Me.ToolStripButtonDelete.Size = New System.Drawing.Size(60, 40)
        Me.ToolStripButtonDelete.Tag = "Delete"
        Me.ToolStripButtonDelete.Text = "Delete"
        '
        'ToolStripButtonEdit
        '
        Me.ToolStripButtonEdit.AutoSize = False
        Me.ToolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonEdit.Image = CType(resources.GetObject("ToolStripButtonEdit.Image"), System.Drawing.Image)
        Me.ToolStripButtonEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEdit.Name = "ToolStripButtonEdit"
        Me.ToolStripButtonEdit.Size = New System.Drawing.Size(60, 40)
        Me.ToolStripButtonEdit.Tag = "Edit"
        Me.ToolStripButtonEdit.Text = "Edit"
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 61)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(225, 459)
        Me.ListBox1.TabIndex = 0
        '
        'txtIDNO
        '
        Me.txtIDNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDNO.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNO.Location = New System.Drawing.Point(366, 142)
        Me.txtIDNO.Name = "txtIDNO"
        Me.txtIDNO.Size = New System.Drawing.Size(195, 26)
        Me.txtIDNO.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(258, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 20)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "ID No.:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(253, 270)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 22)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Ext. (Jr., II, III):"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtExt
        '
        Me.txtExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExt.Location = New System.Drawing.Point(366, 269)
        Me.txtExt.Name = "txtExt"
        Me.txtExt.Size = New System.Drawing.Size(195, 26)
        Me.txtExt.TabIndex = 5
        '
        'DateTimePickerDOB
        '
        Me.DateTimePickerDOB.CustomFormat = "MMMM dd, yyyyy"
        Me.DateTimePickerDOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerDOB.Location = New System.Drawing.Point(687, 269)
        Me.DateTimePickerDOB.Name = "DateTimePickerDOB"
        Me.DateTimePickerDOB.Size = New System.Drawing.Size(194, 26)
        Me.DateTimePickerDOB.TabIndex = 10
        Me.DateTimePickerDOB.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'ComboSex
        '
        Me.ComboSex.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboSex.FormattingEnabled = True
        Me.ComboSex.Items.AddRange(New Object() {"Male", "Female"})
        Me.ComboSex.Location = New System.Drawing.Point(686, 236)
        Me.ComboSex.Name = "ComboSex"
        Me.ComboSex.Size = New System.Drawing.Size(195, 28)
        Me.ComboSex.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(575, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Email:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(575, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Contact No.:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(686, 206)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(195, 26)
        Me.txtEmail.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(258, 302)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 20)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Address:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContactno
        '
        Me.txtContactno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactno.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactno.Location = New System.Drawing.Point(686, 174)
        Me.txtContactno.Name = "txtContactno"
        Me.txtContactno.Size = New System.Drawing.Size(195, 26)
        Me.txtContactno.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(575, 271)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 20)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Date of Birth:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(366, 301)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(515, 26)
        Me.txtAddress.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(575, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Sex:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMiddle
        '
        Me.txtMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMiddle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddle.Location = New System.Drawing.Point(366, 238)
        Me.txtMiddle.Name = "txtMiddle"
        Me.txtMiddle.Size = New System.Drawing.Size(195, 26)
        Me.txtMiddle.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(258, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 20)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Middle Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFirst
        '
        Me.txtFirst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirst.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirst.Location = New System.Drawing.Point(366, 206)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(195, 26)
        Me.txtFirst.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(258, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 20)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "First Name:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLast
        '
        Me.txtLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLast.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLast.Location = New System.Drawing.Point(366, 174)
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(195, 26)
        Me.txtLast.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(258, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Last Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtContactCP)
        Me.GroupBox1.Controls.Add(Me.txtContactRelationship)
        Me.GroupBox1.Controls.Add(Me.txtContactAddress)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtContactName)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(248, 347)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(633, 160)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contact Person"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(17, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 20)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Contact No.:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(17, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 20)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "Relationship:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContactCP
        '
        Me.txtContactCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactCP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactCP.Location = New System.Drawing.Point(128, 119)
        Me.txtContactCP.Name = "txtContactCP"
        Me.txtContactCP.Size = New System.Drawing.Size(480, 26)
        Me.txtContactCP.TabIndex = 3
        '
        'txtContactRelationship
        '
        Me.txtContactRelationship.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactRelationship.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactRelationship.Location = New System.Drawing.Point(128, 87)
        Me.txtContactRelationship.Name = "txtContactRelationship"
        Me.txtContactRelationship.Size = New System.Drawing.Size(480, 26)
        Me.txtContactRelationship.TabIndex = 2
        '
        'txtContactAddress
        '
        Me.txtContactAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactAddress.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactAddress.Location = New System.Drawing.Point(128, 55)
        Me.txtContactAddress.Name = "txtContactAddress"
        Me.txtContactAddress.Size = New System.Drawing.Size(480, 26)
        Me.txtContactAddress.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(20, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 20)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Address:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContactName
        '
        Me.txtContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactName.Location = New System.Drawing.Point(128, 23)
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(480, 26)
        Me.txtContactName.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(20, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 20)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "Name:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_Students
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RoyalBlue
        Me.ClientSize = New System.Drawing.Size(901, 520)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtIDNO)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtExt)
        Me.Controls.Add(Me.DateTimePickerDOB)
        Me.Controls.Add(Me.ComboSex)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtContactno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMiddle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFirst)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLast)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Students"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student's Profile"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents txtIDNO As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtExt As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePickerDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtContactno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMiddle As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLast As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtContactCP As System.Windows.Forms.TextBox
    Friend WithEvents txtContactRelationship As System.Windows.Forms.TextBox
    Friend WithEvents txtContactAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents ToolStripButtonNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEdit As System.Windows.Forms.ToolStripButton
End Class

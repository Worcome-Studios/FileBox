<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FileBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileBox))
        Me.LB_ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuLB_ListBox1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeparatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveToDesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToDesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_NewFile = New System.Windows.Forms.Button()
        Me.BTN_RemoveFile = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ContextMenuStripTEXTO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LenguajeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSharpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualBasicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PHPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JavaScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FastColoredTextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BTN_PNL_SaveChangesAndClose = New System.Windows.Forms.Button()
        Me.BTN_PNL_CloseFile = New System.Windows.Forms.Button()
        Me.BTN_PNL_SaveChanges = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuGENERAL = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CifradoRapidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LlaveCriptograficaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuLB_ListBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStripTEXTO.SuspendLayout()
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuGENERAL.SuspendLayout()
        Me.SuspendLayout()
        '
        'LB_ListBox1
        '
        Me.LB_ListBox1.AllowDrop = True
        Me.LB_ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB_ListBox1.ContextMenuStrip = Me.ContextMenuLB_ListBox1
        Me.LB_ListBox1.FormattingEnabled = True
        Me.LB_ListBox1.Location = New System.Drawing.Point(12, 72)
        Me.LB_ListBox1.Name = "LB_ListBox1"
        Me.LB_ListBox1.Size = New System.Drawing.Size(198, 420)
        Me.LB_ListBox1.TabIndex = 0
        '
        'ContextMenuLB_ListBox1
        '
        Me.ContextMenuLB_ListBox1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFileToolStripMenuItem, Me.SeparatorToolStripMenuItem, Me.RemoveFileToolStripMenuItem, Me.ToolStripMenuItem1, Me.MoveToDesktopToolStripMenuItem, Me.CopyToDesktopToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripMenuItem2, Me.ReloadToolStripMenuItem})
        Me.ContextMenuLB_ListBox1.Name = "ContextMenuLB_ListBox1"
        Me.ContextMenuLB_ListBox1.Size = New System.Drawing.Size(165, 170)
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.New_32
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        Me.NewFileToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.NewFileToolStripMenuItem.Text = "New File"
        '
        'SeparatorToolStripMenuItem
        '
        Me.SeparatorToolStripMenuItem.Name = "SeparatorToolStripMenuItem"
        Me.SeparatorToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SeparatorToolStripMenuItem.Text = "Separator"
        '
        'RemoveFileToolStripMenuItem
        '
        Me.RemoveFileToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.Button_Close_icon
        Me.RemoveFileToolStripMenuItem.Name = "RemoveFileToolStripMenuItem"
        Me.RemoveFileToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.RemoveFileToolStripMenuItem.Text = "Remove"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(161, 6)
        '
        'MoveToDesktopToolStripMenuItem
        '
        Me.MoveToDesktopToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.Flecha_Der
        Me.MoveToDesktopToolStripMenuItem.Name = "MoveToDesktopToolStripMenuItem"
        Me.MoveToDesktopToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.MoveToDesktopToolStripMenuItem.Text = "Move to Desktop"
        '
        'CopyToDesktopToolStripMenuItem
        '
        Me.CopyToDesktopToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.Flecha_Der
        Me.CopyToDesktopToolStripMenuItem.Name = "CopyToDesktopToolStripMenuItem"
        Me.CopyToDesktopToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CopyToDesktopToolStripMenuItem.Text = "Copy to Desktop"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.Search
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(161, 6)
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.refresh_512
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload"
        '
        'BTN_NewFile
        '
        Me.BTN_NewFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTN_NewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_NewFile.Location = New System.Drawing.Point(12, 498)
        Me.BTN_NewFile.Name = "BTN_NewFile"
        Me.BTN_NewFile.Size = New System.Drawing.Size(198, 23)
        Me.BTN_NewFile.TabIndex = 1
        Me.BTN_NewFile.Text = "New File"
        Me.ToolTip1.SetToolTip(Me.BTN_NewFile, "Creates a New File")
        Me.BTN_NewFile.UseVisualStyleBackColor = True
        '
        'BTN_RemoveFile
        '
        Me.BTN_RemoveFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTN_RemoveFile.Location = New System.Drawing.Point(12, 527)
        Me.BTN_RemoveFile.Name = "BTN_RemoveFile"
        Me.BTN_RemoveFile.Size = New System.Drawing.Size(198, 23)
        Me.BTN_RemoveFile.TabIndex = 2
        Me.BTN_RemoveFile.Text = "Remove File"
        Me.ToolTip1.SetToolTip(Me.BTN_RemoveFile, "Delete an existing File")
        Me.BTN_RemoveFile.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.ContextMenuStrip = Me.ContextMenuStripTEXTO
        Me.GroupBox1.Controls.Add(Me.FastColoredTextBox1)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(216, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(606, 478)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Archivos"
        Me.GroupBox1.Visible = False
        '
        'ContextMenuStripTEXTO
        '
        Me.ContextMenuStripTEXTO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LenguajeToolStripMenuItem})
        Me.ContextMenuStripTEXTO.Name = "ContextMenuStripTEXTO"
        Me.ContextMenuStripTEXTO.Size = New System.Drawing.Size(123, 26)
        '
        'LenguajeToolStripMenuItem
        '
        Me.LenguajeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NormalToolStripMenuItem, Me.CSharpToolStripMenuItem, Me.VisualBasicToolStripMenuItem, Me.HTMLToolStripMenuItem, Me.SQLToolStripMenuItem, Me.PHPToolStripMenuItem, Me.JavaScriptToolStripMenuItem})
        Me.LenguajeToolStripMenuItem.Name = "LenguajeToolStripMenuItem"
        Me.LenguajeToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.LenguajeToolStripMenuItem.Text = "Lenguaje"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.NormalToolStripMenuItem.Text = "Normal"
        '
        'CSharpToolStripMenuItem
        '
        Me.CSharpToolStripMenuItem.Name = "CSharpToolStripMenuItem"
        Me.CSharpToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.CSharpToolStripMenuItem.Text = "CSharp"
        '
        'VisualBasicToolStripMenuItem
        '
        Me.VisualBasicToolStripMenuItem.Name = "VisualBasicToolStripMenuItem"
        Me.VisualBasicToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.VisualBasicToolStripMenuItem.Text = "Visual Basic"
        '
        'HTMLToolStripMenuItem
        '
        Me.HTMLToolStripMenuItem.Name = "HTMLToolStripMenuItem"
        Me.HTMLToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.HTMLToolStripMenuItem.Text = "HTML"
        '
        'SQLToolStripMenuItem
        '
        Me.SQLToolStripMenuItem.Name = "SQLToolStripMenuItem"
        Me.SQLToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SQLToolStripMenuItem.Text = "SQL"
        '
        'PHPToolStripMenuItem
        '
        Me.PHPToolStripMenuItem.Name = "PHPToolStripMenuItem"
        Me.PHPToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PHPToolStripMenuItem.Text = "PHP"
        '
        'JavaScriptToolStripMenuItem
        '
        Me.JavaScriptToolStripMenuItem.Name = "JavaScriptToolStripMenuItem"
        Me.JavaScriptToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.JavaScriptToolStripMenuItem.Text = "JavaScript"
        '
        'FastColoredTextBox1
        '
        Me.FastColoredTextBox1.AutoScrollMinSize = New System.Drawing.Size(179, 14)
        Me.FastColoredTextBox1.BackBrush = Nothing
        Me.FastColoredTextBox1.CharHeight = 14
        Me.FastColoredTextBox1.CharWidth = 8
        Me.FastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FastColoredTextBox1.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.FastColoredTextBox1.IsReplaceMode = False
        Me.FastColoredTextBox1.Location = New System.Drawing.Point(3, 16)
        Me.FastColoredTextBox1.Name = "FastColoredTextBox1"
        Me.FastColoredTextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.FastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FastColoredTextBox1.Size = New System.Drawing.Size(600, 422)
        Me.FastColoredTextBox1.TabIndex = 2
        Me.FastColoredTextBox1.Text = "FastColoredTextBox1"
        Me.FastColoredTextBox1.Zoom = 100
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.BTN_PNL_SaveChangesAndClose)
        Me.Panel1.Controls.Add(Me.BTN_PNL_CloseFile)
        Me.Panel1.Controls.Add(Me.BTN_PNL_SaveChanges)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 438)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 37)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(405, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 25)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Open File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BTN_PNL_SaveChangesAndClose
        '
        Me.BTN_PNL_SaveChangesAndClose.Image = Global.Wor_FileBox.My.Resources.Resources.Files_Edit_file_icon
        Me.BTN_PNL_SaveChangesAndClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_PNL_SaveChangesAndClose.Location = New System.Drawing.Point(202, 3)
        Me.BTN_PNL_SaveChangesAndClose.Name = "BTN_PNL_SaveChangesAndClose"
        Me.BTN_PNL_SaveChangesAndClose.Size = New System.Drawing.Size(197, 31)
        Me.BTN_PNL_SaveChangesAndClose.TabIndex = 2
        Me.BTN_PNL_SaveChangesAndClose.Text = "Save and Close"
        Me.ToolTip1.SetToolTip(Me.BTN_PNL_SaveChangesAndClose, "Save the Changes and Close the File")
        Me.BTN_PNL_SaveChangesAndClose.UseVisualStyleBackColor = True
        '
        'BTN_PNL_CloseFile
        '
        Me.BTN_PNL_CloseFile.Image = Global.Wor_FileBox.My.Resources.Resources.Button_Close_icon
        Me.BTN_PNL_CloseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_PNL_CloseFile.Location = New System.Drawing.Point(475, 3)
        Me.BTN_PNL_CloseFile.Name = "BTN_PNL_CloseFile"
        Me.BTN_PNL_CloseFile.Size = New System.Drawing.Size(122, 31)
        Me.BTN_PNL_CloseFile.TabIndex = 1
        Me.BTN_PNL_CloseFile.Text = "Close File"
        Me.ToolTip1.SetToolTip(Me.BTN_PNL_CloseFile, "Close without Save")
        Me.BTN_PNL_CloseFile.UseVisualStyleBackColor = True
        '
        'BTN_PNL_SaveChanges
        '
        Me.BTN_PNL_SaveChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_PNL_SaveChanges.Image = Global.Wor_FileBox.My.Resources.Resources.Save_32
        Me.BTN_PNL_SaveChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_PNL_SaveChanges.Location = New System.Drawing.Point(3, 3)
        Me.BTN_PNL_SaveChanges.Name = "BTN_PNL_SaveChanges"
        Me.BTN_PNL_SaveChanges.Size = New System.Drawing.Size(197, 31)
        Me.BTN_PNL_SaveChanges.TabIndex = 0
        Me.BTN_PNL_SaveChanges.Text = "Save Changes"
        Me.ToolTip1.SetToolTip(Me.BTN_PNL_SaveChanges, "Save the Changes")
        Me.BTN_PNL_SaveChanges.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Helper"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Protector de Archivos"
        '
        'ContextMenuGENERAL
        '
        Me.ContextMenuGENERAL.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.LlaveCriptograficaToolStripMenuItem, Me.ToolStripMenuItem3, Me.AboutToolStripMenuItem, Me.ToolStripMenuItem4, Me.ExitToolStripMenuItem})
        Me.ContextMenuGENERAL.Name = "ContextMenuGENERAL"
        Me.ContextMenuGENERAL.Size = New System.Drawing.Size(174, 126)
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.Paste_32
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CifradoRapidoToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'CifradoRapidoToolStripMenuItem
        '
        Me.CifradoRapidoToolStripMenuItem.Name = "CifradoRapidoToolStripMenuItem"
        Me.CifradoRapidoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CifradoRapidoToolStripMenuItem.Text = "Cifrado rapido"
        '
        'LlaveCriptograficaToolStripMenuItem
        '
        Me.LlaveCriptograficaToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.codigo_binario_318_46836
        Me.LlaveCriptograficaToolStripMenuItem.Name = "LlaveCriptograficaToolStripMenuItem"
        Me.LlaveCriptograficaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.LlaveCriptograficaToolStripMenuItem.Text = "Llave Criptografica"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(170, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.Ball_info_32
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(170, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.Wor_FileBox.My.Resources.Resources.Button_Close_icon
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Lista de Archivos"
        '
        'FileBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.ContextMenuStrip = Me.ContextMenuGENERAL
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_RemoveFile)
        Me.Controls.Add(Me.BTN_NewFile)
        Me.Controls.Add(Me.LB_ListBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FileBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wor: FileBox"
        Me.ContextMenuLB_ListBox1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ContextMenuStripTEXTO.ResumeLayout(False)
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuGENERAL.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LB_ListBox1 As ListBox
    Friend WithEvents BTN_NewFile As Button
    Friend WithEvents BTN_RemoveFile As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BTN_PNL_SaveChanges As Button
    Friend WithEvents BTN_PNL_CloseFile As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents BTN_PNL_SaveChangesAndClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ContextMenuLB_ListBox1 As ContextMenuStrip
    Friend WithEvents NewFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents MoveToDesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToDesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ReloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuGENERAL As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LlaveCriptograficaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeparatorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents ContextMenuStripTEXTO As ContextMenuStrip
    Friend WithEvents LenguajeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSharpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualBasicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HTMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SQLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PHPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JavaScriptToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FastColoredTextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents HerramientasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CifradoRapidoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
End Class

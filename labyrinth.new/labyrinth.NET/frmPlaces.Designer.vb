<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPlaces
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents lstPlaces As System.Windows.Forms.ListBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPlaces))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstPlaces = New System.Windows.Forms.ListBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "Locations of Interest"
		Me.ClientSize = New System.Drawing.Size(290, 369)
		Me.Location = New System.Drawing.Point(3, 19)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmPlaces"
		Me.lstPlaces.Size = New System.Drawing.Size(289, 371)
		Me.lstPlaces.Location = New System.Drawing.Point(0, 0)
		Me.lstPlaces.Sorted = True
		Me.lstPlaces.TabIndex = 0
		Me.lstPlaces.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstPlaces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstPlaces.BackColor = System.Drawing.SystemColors.Window
		Me.lstPlaces.CausesValidation = True
		Me.lstPlaces.Enabled = True
		Me.lstPlaces.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPlaces.IntegralHeight = True
		Me.lstPlaces.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPlaces.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstPlaces.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPlaces.TabStop = True
		Me.lstPlaces.Visible = True
		Me.lstPlaces.MultiColumn = False
		Me.lstPlaces.Name = "lstPlaces"
		Me.Controls.Add(lstPlaces)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class
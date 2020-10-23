<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTreeDataTable
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemSalva = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemAggiungi = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemCancella = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeList1
        '
        Me.TreeList1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.Size = New System.Drawing.Size(800, 450)
        Me.TreeList1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemSalva, Me.MenuItemAggiungi, Me.MenuItemCancella})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 76)
        '
        'MenuItemSalva
        '
        Me.MenuItemSalva.Name = "MenuItemSalva"
        Me.MenuItemSalva.Size = New System.Drawing.Size(210, 24)
        Me.MenuItemSalva.Text = "Salva"
        '
        'MenuItemAggiungi
        '
        Me.MenuItemAggiungi.Name = "MenuItemAggiungi"
        Me.MenuItemAggiungi.Size = New System.Drawing.Size(210, 24)
        Me.MenuItemAggiungi.Text = "Aggiungi"
        '
        'MenuItemCancella
        '
        Me.MenuItemCancella.Name = "MenuItemCancella"
        Me.MenuItemCancella.Size = New System.Drawing.Size(210, 24)
        Me.MenuItemCancella.Text = "Cancella"
        '
        'FormTreeDataTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.TreeList1)
        Me.Name = "FormTreeDataTable"
        Me.Text = "Form1"
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MenuItemSalva As ToolStripMenuItem
    Friend WithEvents MenuItemAggiungi As ToolStripMenuItem
    Friend WithEvents MenuItemCancella As ToolStripMenuItem
End Class

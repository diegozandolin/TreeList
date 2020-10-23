Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraTreeList.Nodes

Public Class FormTreeDataTable
    Private path = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "data.xml")
    Private hitInfo As GridHitInfo = Nothing

    Private Sub FormTreeDataTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TreeList1.DataSource = GetData()
        TreeList1.KeyFieldName = "Id"
        TreeList1.ParentFieldName = "IdP"
        TreeList1.ExpandAll()
        TreeList1.HierarchyColumn = TreeList1.Columns("Cognome")

        ' drag_drop
        TreeList1.AllowDrop = True
        TreeList1.OptionsView.ShowIndentAsRowStyle = True
    End Sub

    Private Function GetData() As DataTable

        Dim dt As New DataTable("tabella1")
        If IO.File.Exists(Me.path) Then
            dt.ReadXml(Me.path)
            Return dt
        End If

        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("IdP", GetType(Integer))
        dt.Columns.Add("Nome", GetType(String))
        dt.Columns.Add("Cognome", GetType(String))
        dt.Columns.Add("Nascita", GetType(Date))
        dt.Columns.Add("Eta", GetType(Integer))

        Dim row = dt.NewRow()
        'For num As Integer = 1 To 10
        '    dt.Rows.Add(num, num, $"Nome{num}", $"Cognome{num}", New Date(2020, num, num), num)
        'Next
        dt.Rows.Add(1, Nothing, $"Nome{1}", $"Cognome{1}", New Date(2020, 1, 1), 1)
        dt.Rows.Add(2, 1, $"Nome{2}", $"Cognome{2}", New Date(2020, 2, 2), 2)
        dt.Rows.Add(3, 1, $"Nome{3}", $"Cognome{3}", New Date(2020, 3, 3), 3)
        dt.Rows.Add(4, 3, $"Nome{4}", $"Cognome{4}", New Date(2020, 4, 4), 4)
        dt.Rows.Add(5, 3, $"Nome{5}", $"Cognome{5}", New Date(2020, 5, 5), 5)
        dt.Rows.Add(6, 3, $"Nome{6}", $"Cognome{6}", New Date(2020, 6, 6), 6)


        Return dt
    End Function


    Private Sub MenuItemSalva_Click(sender As Object, e As EventArgs) Handles MenuItemSalva.Click
        Dim dt = TryCast(TreeList1.DataSource, DataTable)
        SaveData(dt)
    End Sub


    Sub SaveData(dt As DataTable)

        dt.WriteXml(path, XmlWriteMode.WriteSchema)
        MessageBox.Show($"Salvataggio eseguito su: {path}")
    End Sub

    Private Sub MenuItemAggiungi_Click(sender As Object, e As EventArgs) Handles MenuItemAggiungi.Click
        'If Me.ContextMenuStrip.SourceControl
    End Sub

    Private Sub gridControl_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridControl.MouseDown
        hitInfo = gridView.CalcHitInfo(New Point(e.X, e.Y))
    End Sub

    ' Initialize a drag-and-drop operation.
    Private Sub gridControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridControl.MouseMove
        If hitInfo Is Nothing Then
            Return
        End If
        If e.Button <> MouseButtons.Left Then
            Return
        End If
        Dim dragRect As New Rectangle(New Point(hitInfo.HitPoint.X - SystemInformation.DragSize.Width \ 2, hitInfo.HitPoint.Y - SystemInformation.DragSize.Height \ 2), SystemInformation.DragSize)
        If Not (hitInfo.RowHandle = gridControl.InvalidRowHandle) AndAlso (Not dragRect.Contains(New Point(e.X, e.Y))) Then
            Dim data As Object = gridView.GetRow(hitInfo.RowHandle)
            gridControl.DoDragDrop(data, DragDropEffects.Copy)
        End If

    End Sub

    Private Sub treeList_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles treeList.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    ' Add a node to the TreeList when a grid row is dropped.
    Private Sub treeList_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles treeList.DragDrop
        ' Get extended arguments of the drag event.
        Dim args As DXDragEventArgs = TreeList.GetDXDragEventArgs(e)
        ' Get how a node is inserted (as a child, before or after a node, or at the end of the node collection).
        Dim position As DragInsertPosition = args.DragInsertPosition
        Dim dataRow As Person = TryCast(e.Data.GetData(GetType(DragAndDropRows.Person)), Person)
        If dataRow Is Nothing Then
            Return
        End If
        Dim parentID As Integer = DirectCast(TreeList1.RootValue, Integer)
        ' Get the node over which the row is dropped.
        Dim node As TreeListNode = args.TargetNode
        ' Add a node at the root level.
        If node Is Nothing Then
            Dim parentNode As TreeListNode = Nothing
            TreeList1.AppendNode(New PersonEx(dataRow, parentID).ToArray(), parentNode)
        Else
            ' Add a child node to the target node.
            If position = DragInsertPosition.AsChild Then
                parentID = Convert.ToInt32(node.GetValue("ID"))
                Dim targetObject() As Object = (New PersonEx(dataRow, parentID)).ToArray()
                TreeList1.AppendNode(targetObject, node)
            End If
            ' Insert a node before the taget node.
            If position = DragInsertPosition.Before Then
                parentID = Convert.ToInt32(node.GetValue("ParentID"))
                Dim targetObject() As Object = (New PersonEx(dataRow, parentID)).ToArray()
                Dim newNode As TreeListNode = TreeList.AppendNode(targetObject, node.ParentNode)
                Dim targetPosition As Integer
                If node.ParentNode Is Nothing Then
                    targetPosition = TreeList.Nodes.IndexOf(node)
                Else
                    targetPosition = node.ParentNode.Nodes.IndexOf(node)
                End If
                TreeList.SetNodeIndex(newNode, targetPosition)
            End If
            node.Expanded = True
        End If
    End Sub

    Private Sub treeList_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles treeList.DragOver
        e.Effect = DragDropEffects.Copy
    End Sub

End Class

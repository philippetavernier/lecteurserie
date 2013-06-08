Imports System.IO.Ports
Imports Microsoft.Office.Interop

Public Class Form1
    'exel'
    Dim xlapp As Excel.Application
    Dim xlbook As Excel.Workbook
    Dim xlsheet As Excel.Worksheet
    Dim x = 1
    Dim y = 1

    'port'
    Dim str As String
    Public WithEvents comPort As SerialPort
    Public Event ScanDataRecieved(ByVal data As String)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            comPort = My.Computer.Ports.OpenSerialPort(TextBox1.Text, "19200")
        Catch ex As Exception
            MsgBox("Une erreur est survenu", MsgBoxStyle.Critical)
        End Try
    End Sub

#Region "Reception des données"
    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles comPort.DataReceived
        Try
            If e.EventType = SerialData.Chars Then
                Do
                    Try
                        Dim message As String = comPort.ReadLine
                        updateStatus(message)
                    Catch ex As TimeoutException
                        updateStatus(ex.ToString)
                    End Try
                Loop
            End If
            RaiseEvent ScanDataRecieved(str)
        Catch ex As Exception
            MsgBox("impossible de lire le flux entrant", MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Delegate Sub updateStatusDelegate(ByVal newStatus As String)
    Public Sub updateStatus(ByVal newStatus As String)
        If Me.InvokeRequired Then
            Dim upbd As New updateStatusDelegate(AddressOf updateStatus)
            Me.Invoke(upbd, New Object() {newStatus})
        Else
            RichTextBox1.Text = newStatus
            exel()
        End If
    End Sub
#End Region

    Public Sub exel()
        xlapp = CType(CreateObject("Excel.Application"), Excel.Application)
        xlbook = xlapp.Workbooks.Open(Filename:="C:\Users\cedric gaucheron\Documents\Book2.xlsx", Editable:=True, ReadOnly:=False)
        xlbook.Application.Cells(x, y) = RichTextBox1.Text
        xlapp.ActiveWorkbook.Save()
        xlbook.Close()
        xlapp.Quit()
        x = x + 1
        y = y + 1
        RichTextBox1.Clear()
    End Sub
End Class

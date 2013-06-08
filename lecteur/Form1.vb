Imports System.IO.Ports
Imports Microsoft.Office.Interop
<<<<<<< HEAD
Public Class Form1

#Region "Initialisation"

Public Class Form1

#Region "Initialisation"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each pn As String In IO.Ports.SerialPort.GetPortNames
            ComboBox1.Items.Add(pn.ToString())
        Next
    End Sub
#End Region

    'Déclaration variables Exel'
    Dim xlapp As Excel.Application
    Dim xlbook As Excel.Workbook
    Dim xlsheet As Excel.Worksheet
    Dim x = 1
    Dim y = 1

    'Vérouillage Port'
    Dim str As String
    Public WithEvents comPort As SerialPort
    Public Event ScanDataRecieved(ByVal data As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each pn As String In IO.Ports.SerialPort.GetPortNames
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add(pn.ToString())
        Next
    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            comPort = My.Computer.Ports.OpenSerialPort(ComboBox1.Text, "9600")
            Button1.Text = "connecté"
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

#Region "gestion des données"
    Public Sub exel()
        xlapp = CType(CreateObject("Excel.Application"), Excel.Application)
        xlbook = xlapp.Workbooks.Open(Filename:="C:\Users\cedric gaucheron\Documents\Book2.xlsx", Editable:=True, ReadOnly:=False)
        xlbook.Application.Cells(x, y) = RichTextBox1.Text
        xlapp.ActiveWorkbook.Save()
        xlbook.Close()
        xlapp.Quit()
        y = y + 1
        RichTextBox1.Clear()
    End Sub
#End Region
End Class

Imports System.IO.Ports
Imports Microsoft.Office.Interop


Public Class Form1

    'Déclaration variables
    Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    Dim misValue As Object = System.Reflection.Missing.Value
    Dim xlapp As Excel.Application
    Dim xlbook As Excel.Workbook
    Dim xlsheet As Excel.Worksheet
    Dim lastRowIMPORT, lastRowEXPORT As Long
    Dim lastEntryDate, lastEntryValue

    'Vérouillage Port'
    Dim str As String
    Public WithEvents comPort As SerialPort
    Public Event ScanDataRecieved(ByVal data As String)


#Region "Initialisation"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        COMLocked.Hide()
        ButtonSwitchCom.Hide()

        For Each pn As String In IO.Ports.SerialPort.GetPortNames
            ComboBox1.Items.Add(pn.ToString())
        Next

        'Création du xlsx par défaut si pas trouvé + notification
        If Not My.Computer.FileSystem.FileExists(s & "\data.xlsx") Then
            xlapp = New Excel.ApplicationClass
            xlbook = xlapp.Workbooks.Add(misValue)
            xlsheet = xlapp.Workbooks(1).Worksheets("Feuil1")
            xlsheet.Cells(1, 1) = "IMPORT"
            xlsheet.Cells(1, 2) = 1 'Pour le nombre de cellules en A (LastrowIMPORT)
            xlsheet.Cells(1, 3) = 1 'Pour le nombre de cellules en D (lastrowEXPORT)
            xlsheet.Cells(1, 4) = "EXPORT"
            xlsheet.Cells(1, 6) = "Dernière"
            xlsheet.Cells(1, 7) = "entrée :"
            xlsheet.Cells(2, 6) = "Aucune"
            xlsheet.Cells(2, 7) = "à ce jour."
            xlsheet.SaveAs(s & "\data.xlsx", ReadOnlyRecommended:=False)
            xlbook.Close()
            xlapp.Quit()
            MsgBox("Document EXEL non trouvé (Bureau\data.xlsx)" & Chr(10) & "Un nouveau document à été crée.", 64, "Windows - Information")
        End If
    End Sub
#End Region


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            comPort = My.Computer.Ports.OpenSerialPort(ComboBox1.Text, "9600")
            Button1.Hide()
            ComboBox1.Hide()
            COMLocked.Text = "Port " & ComboBox1.Text & " en cours d'écoute..."
            COMLocked.Show()
            ButtonSwitchCom.Show()

        Catch ex As Exception
            MsgBox("Port COM manquant ou indisponible.", MsgBoxStyle.Critical)
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

        End Try
    End Sub

    Public Delegate Sub updateStatusDelegate(ByVal newStatus As String)
    Public Sub updateStatus(ByVal newStatus As String)
        If Me.InvokeRequired Then
            Dim upbd As New updateStatusDelegate(AddressOf updateStatus)
            Me.Invoke(upbd, New Object() {newStatus})
        Else
                COMReceive.Text = newStatus
                exel()
        End If
    End Sub
#End Region

    Public Sub exel()
        xlapp = CType(CreateObject("Excel.Application"), Excel.Application)
        xlbook = xlapp.Workbooks.Open(Filename:=s & "\data.xlsx", Editable:=True, ReadOnly:=False)
        lastRowIMPORT = xlbook.Application.Cells(1, 2).value
        lastRowEXPORT = xlbook.Application.Cells(1, 3).value
        If TrackBar.Value = 0 Then
            xlbook.Application.Cells(lastRowIMPORT + 1, 1) = COMReceive.Text
            xlbook.Application.Cells(1, 2) = lastRowIMPORT + 1
        Else
            xlbook.Application.Cells(lastRowEXPORT + 1, 4) = COMReceive.Text
            xlbook.Application.Cells(1, 2) = lastRowEXPORT + 1
        End If


        xlbook.Application.Cells(2, 6) = lastEntryDate
        xlbook.Application.Cells(2, 7) = lastEntryValue

        xlapp.ActiveWorkbook.Save()
        xlbook.Close()
        xlapp.Quit()
        'fix
        Shell("taskkill /F /IM Excel.exe")
        COMReceive.Clear()
    End Sub

    Private Sub ButtonSwitchCom_Click(sender As Object, e As EventArgs) Handles ButtonSwitchCom.Click
        COMLocked.Hide()
        ButtonSwitchCom.Hide()
        ComboBox1.Show()
        Button1.Show()
        comPort.Close()
    End Sub

End Class

' Exemple de code : Ecoute de données sur le RS232, réception code barre 
' sous forme alphanumérique, stockage dans fichier Excel.

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

    'Vérouillage du port série'
    Dim str As String
    Dim erreur = False
    Public WithEvents comPort As SerialPort
    Public Event ScanDataRecieved(ByVal data As String)
    Dim c



#Region "Initialisation"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Partie arrêt de l'écoute du port
        COMLocked.Hide()
        ButtonSwitchCom.Hide()

        'Récupération de tous les ports COM actifs
        For Each pn As String In IO.Ports.SerialPort.GetPortNames
            ComboBox1.Items.Add(pn.ToString())
        Next

        'Création du xlsx par défaut si pas trouvé + notification
        If Not My.Computer.FileSystem.FileExists(s & "\data.xlsx") Then
            xlapp = New Excel.ApplicationClass
            xlbook = xlapp.Workbooks.Add(misValue)
            xlsheet = xlbook.Worksheets.Item(1)
            xlsheet.Cells(1, 1) = "IMPORT"
            xlsheet.Cells(1, 2) = 1 'Pour le nombre de cellules en A (LastrowIMPORT)
            xlsheet.Cells(1, 3) = 1 'Pour le nombre de cellules en D (lastrowEXPORT)
            xlsheet.Cells(1, 4) = "EXPORT"
            xlsheet.Cells(1, 6) = "Dernière"
            xlsheet.Cells(1, 7) = "entrée :"
            xlsheet.Cells(2, 6) = "Aucune"
            xlsheet.Cells(2, 7) = "à ce jour."

            'Pour le champ derniere valeur enregistrée
            LBL_Lastvalue.Text = "Aucune à ce jour."
            xlsheet.SaveAs(s & "\data.xlsx", ReadOnlyRecommended:=False)
            xlbook.Close()
            xlapp.Quit()
            MsgBox("Document EXCEL non détecté (Bureau\data.xlsx)" & Chr(10) & "Un nouveau document à été crée.", 64, "Windows - Information")
        Else
            xlapp = CType(CreateObject("Excel.Application"), Excel.Application)
            xlbook = xlapp.Workbooks.Open(Filename:=s & "\data.xlsx", Editable:=True, ReadOnly:=False)
            ' If xlbook.Application.Cells(2, 6).value = "Aucune" Then
            'LBL_Lastvalue.Text = "Aucune à ce jour."
            ' Else
            'LBL_Lastvalue.Text = xlbook.Application.Cells(2, 7).value & "( " & xlbook.Application.Cells(2, 6).value & " )"
            'End If
            'fix si le processus qui traite cette tâche ne se ferme pas
            Shell("taskkill /F /IM Excel.exe")
            xlbook.Close()
            xlapp.Quit()
        End If


    End Sub
#End Region

#Region "Reception des données"
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

    ' Si on clique sur le bouton "Arret de l'écoute"
    Private Sub ButtonSwitchCom_Click(sender As Object, e As EventArgs) Handles ButtonSwitchCom.Click
        COMLocked.Hide()
        ButtonSwitchCom.Hide()
        ComboBox1.Show()
        Button1.Show()
        comPort.Close()
    End Sub
#End Region

#Region "Traitement via EXCEL"

    Public Sub exel()
        xlapp = CType(CreateObject("Excel.Application"), Excel.Application)
        xlbook = xlapp.Workbooks.Open(Filename:=s & "\data.xlsx", Editable:=True, ReadOnly:=False)
        lastRowIMPORT = xlbook.Application.Cells(1, 2).value
        lastRowEXPORT = xlbook.Application.Cells(1, 3).value

        'Dans le cas d'un import, on cherche si la valeur existe et on place la valeur dans une cellule libre.
        If TrackBar.Value = 0 Then
            With xlbook.Worksheets.Item(1).Range("A1:A65000")
                c = .Find(COMReceive.Text)
                If Not c Is Nothing Then
                    MsgBox("Attention : ce code existe déjà dans les imports (Ignoré)", MsgBoxStyle.Critical)
                    erreur = True
                Else
                    'On stock la valeur dans la cellule suivante (de la colonne)
                    xlbook.Application.Cells(lastRowIMPORT + 1, 1) = COMReceive.Text
                    xlbook.Application.Cells(1, 2) = lastRowIMPORT + 1
                End If
            End With
        Else
            With xlbook.Worksheets.Item(1).Range("A1:A65000")
                c = .Find(COMReceive.Text)
                If c Is Nothing Then
                    MsgBox("Attention : ce code n'existe pas à l'origine dans la colonne Import", MsgBoxStyle.Critical)
                    erreur = True
                Else
                    'On supprime la valeur de la colonne Import
                    c.value = ""

                    'On stock la valeur dans la cellule suivante (de la colonne Export)
                    xlbook.Application.Cells(lastRowEXPORT + 1, 4) = COMReceive.Text
                    xlbook.Application.Cells(1, 2) = lastRowEXPORT + 1 'Et on met à jour la référence de cellule
                End If
            End With
          End If

        If Not erreur Then
            'On indique la derniere valeur reçue (+ horodatage) dans 2 cellules (2 ème ligne, cellule 6 et 7)
            xlbook.Application.Cells(2, 6) = Now()
            xlbook.Application.Cells(2, 7) = COMReceive.Text
            LBL_Lastvalue.Text = COMReceive.Text & "( " & Now() & " )"
        Else
            erreur = False
        End If

        'On sauvegarde et on quitte
        xlapp.ActiveWorkbook.Save()
        xlbook.Close()
        xlapp.Quit()

        'fix si le processus qui traite cette tâche ne se ferme pas
        Shell("taskkill /F /IM Excel.exe")

        'On attend la valeur suivante.
        COMReceive.Clear()
    End Sub
#End Region

#Region "Déchargement programme"
    Private Sub frmProgramma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Shell("taskkill /F /IM Excel.exe")
    End Sub
#End Region


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("iexplore", "https://github.com/bachou/lecteurserie")
    End Sub
End Class

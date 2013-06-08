<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.COMLocked = New System.Windows.Forms.Label()
        Me.ButtonSwitchCom = New System.Windows.Forms.Button()
        Me.COMReceive = New System.Windows.Forms.TextBox()
        Me.TrackBar = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(306, 9)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 19)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Lancer l'écoute "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Réception :"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 7)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(289, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'COMLocked
        '
        Me.COMLocked.AutoSize = True
        Me.COMLocked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMLocked.Location = New System.Drawing.Point(26, 12)
        Me.COMLocked.Name = "COMLocked"
        Me.COMLocked.Size = New System.Drawing.Size(35, 15)
        Me.COMLocked.TabIndex = 5
        Me.COMLocked.Text = "Void"
        '
        'ButtonSwitchCom
        '
        Me.ButtonSwitchCom.Location = New System.Drawing.Point(306, 9)
        Me.ButtonSwitchCom.Name = "ButtonSwitchCom"
        Me.ButtonSwitchCom.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSwitchCom.TabIndex = 6
        Me.ButtonSwitchCom.Text = "Arrêter"
        Me.ButtonSwitchCom.UseVisualStyleBackColor = False
        '
        'COMReceive
        '
        Me.COMReceive.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.COMReceive.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.COMReceive.Enabled = False
        Me.COMReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMReceive.Location = New System.Drawing.Point(14, 74)
        Me.COMReceive.Name = "COMReceive"
        Me.COMReceive.ReadOnly = True
        Me.COMReceive.Size = New System.Drawing.Size(427, 29)
        Me.COMReceive.TabIndex = 7
        Me.COMReceive.TabStop = False
        Me.COMReceive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TrackBar
        '
        Me.TrackBar.Location = New System.Drawing.Point(93, 109)
        Me.TrackBar.Maximum = 1
        Me.TrackBar.Name = "TrackBar"
        Me.TrackBar.Size = New System.Drawing.Size(258, 45)
        Me.TrackBar.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(345, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Export Produit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Import produit"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 151)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TrackBar)
        Me.Controls.Add(Me.COMReceive)
        Me.Controls.Add(Me.ButtonSwitchCom)
        Me.Controls.Add(Me.COMLocked)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Lecteur de code barre"
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents COMLocked As System.Windows.Forms.Label
    Friend WithEvents ButtonSwitchCom As System.Windows.Forms.Button
    Friend WithEvents COMReceive As System.Windows.Forms.TextBox
    Friend WithEvents TrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class

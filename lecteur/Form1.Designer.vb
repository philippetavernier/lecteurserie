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
<<<<<<< HEAD
        Me.components = New System.ComponentModel.Container()
=======
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
<<<<<<< HEAD
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
=======
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        Me.SuspendLayout()
        '
        'Button1
        '
<<<<<<< HEAD
        Me.Button1.Location = New System.Drawing.Point(408, 11)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
=======
        Me.Button1.Location = New System.Drawing.Point(306, 9)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 19)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Connexion au port com"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
<<<<<<< HEAD
        Me.Label1.Location = New System.Drawing.Point(12, 57)
=======
        Me.Label1.Location = New System.Drawing.Point(9, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Reception"
        '
        'RichTextBox1
        '
<<<<<<< HEAD
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 85)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
=======
        Me.RichTextBox1.Location = New System.Drawing.Point(9, 69)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2)
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(433, 238)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
<<<<<<< HEAD
        Me.ComboBox1.Location = New System.Drawing.Point(16, 9)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(384, 24)
        Me.ComboBox1.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000000
        '
=======
        Me.ComboBox1.Location = New System.Drawing.Point(12, 7)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(289, 21)
        Me.ComboBox1.TabIndex = 4
        '
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
<<<<<<< HEAD
        Me.ClientSize = New System.Drawing.Size(601, 400)
=======
        Me.ClientSize = New System.Drawing.Size(451, 325)
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
<<<<<<< HEAD
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
=======
        Me.Margin = New System.Windows.Forms.Padding(2)
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb
        Me.Name = "Form1"
        Me.Text = "Lecteur"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
<<<<<<< HEAD
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
=======
>>>>>>> 33701ab71b37476968cd410bdb5966bb00cf8dbb

End Class

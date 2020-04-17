<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnConvertirABinario = New System.Windows.Forms.Button()
        Me.btnConvertirADecimal = New System.Windows.Forms.Button()
        Me.btnOperar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.txtNumero1 = New System.Windows.Forms.TextBox()
        Me.txtNumero2 = New System.Windows.Forms.TextBox()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnConvertirABinario
        '
        Me.btnConvertirABinario.Location = New System.Drawing.Point(12, 179)
        Me.btnConvertirABinario.Name = "btnConvertirABinario"
        Me.btnConvertirABinario.Size = New System.Drawing.Size(157, 46)
        Me.btnConvertirABinario.TabIndex = 0
        Me.btnConvertirABinario.Text = "Convertir a Binario"
        Me.btnConvertirABinario.UseVisualStyleBackColor = True
        '
        'btnConvertirADecimal
        '
        Me.btnConvertirADecimal.Location = New System.Drawing.Point(175, 179)
        Me.btnConvertirADecimal.Name = "btnConvertirADecimal"
        Me.btnConvertirADecimal.Size = New System.Drawing.Size(157, 46)
        Me.btnConvertirADecimal.TabIndex = 1
        Me.btnConvertirADecimal.Text = "Convertir a Decimal"
        Me.btnConvertirADecimal.UseVisualStyleBackColor = True
        '
        'btnOperar
        '
        Me.btnOperar.Location = New System.Drawing.Point(12, 117)
        Me.btnOperar.Name = "btnOperar"
        Me.btnOperar.Size = New System.Drawing.Size(102, 46)
        Me.btnOperar.TabIndex = 2
        Me.btnOperar.Text = "Operar"
        Me.btnOperar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(120, 117)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 45)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(228, 117)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(102, 45)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'txtNumero1
        '
        Me.txtNumero1.Location = New System.Drawing.Point(10, 71)
        Me.txtNumero1.Name = "txtNumero1"
        Me.txtNumero1.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero1.TabIndex = 5
        '
        'txtNumero2
        '
        Me.txtNumero2.Location = New System.Drawing.Point(228, 71)
        Me.txtNumero2.Name = "txtNumero2"
        Me.txtNumero2.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero2.TabIndex = 6
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Location = New System.Drawing.Point(289, 26)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(0, 13)
        Me.lblResultado.TabIndex = 7
        '
        'cmbOperador
        '
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(135, 70)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(68, 21)
        Me.cmbOperador.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 270)
        Me.Controls.Add(Me.cmbOperador)
        Me.Controls.Add(Me.lblResultado)
        Me.Controls.Add(Me.txtNumero2)
        Me.Controls.Add(Me.txtNumero1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnOperar)
        Me.Controls.Add(Me.btnConvertirADecimal)
        Me.Controls.Add(Me.btnConvertirABinario)
        Me.Name = "Form1"
        Me.Text = "t"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConvertirABinario As Button
    Friend WithEvents btnConvertirADecimal As Button
    Friend WithEvents btnOperar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents txtNumero1 As TextBox
    Friend WithEvents txtNumero2 As TextBox
    Friend WithEvents lblResultado As Label
    Friend WithEvents cmbOperador As ComboBox
End Class

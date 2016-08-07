<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowStand
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RotateShow = New System.Windows.Forms.PictureBox()
        CType(Me.RotateShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RotateShow
        '
        Me.RotateShow.BackColor = System.Drawing.Color.Transparent
        Me.RotateShow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RotateShow.Location = New System.Drawing.Point(0, 0)
        Me.RotateShow.Name = "RotateShow"
        Me.RotateShow.Size = New System.Drawing.Size(360, 360)
        Me.RotateShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.RotateShow.TabIndex = 0
        Me.RotateShow.TabStop = False
        '
        'ShowStand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = Global.旋转PNG.My.Resources.PNGResource.背景
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(360, 360)
        Me.Controls.Add(Me.RotateShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ShowStand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ShowStand"
        Me.TopMost = True
        CType(Me.RotateShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RotateShow As System.Windows.Forms.PictureBox

End Class

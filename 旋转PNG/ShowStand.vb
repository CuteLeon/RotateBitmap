Option Explicit On
'呵呵哒
Imports System.Drawing.Drawing2D

Public Class ShowStand
    '让鼠标拖动无边框窗体使用的API
    Private Declare Function ReleaseCapture Lib "user32" () As Integer
    Private Declare Function SendMessageA Lib "user32" (ByVal hwnd As Integer, ByVal wMsg As Integer,
                                                                            ByVal wParam As Integer, lParam As VariantType) As Integer

    '旋转位图专用的线程，我嫌Time控件麻烦（其实多线程才更麻烦好吧！！！）
    Dim RotateThread As Threading.Thread

    '程序启动
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '一些UI设计，不要在意
        Dim MyBackground As Bitmap = My.Resources.PNGResource.背景
        Dim MyGraphics As Graphics = Graphics.FromImage(MyBackground)
        MyGraphics.SmoothingMode = SmoothingMode.HighQuality
        MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        Dim MyBitmap As Bitmap = My.Resources.PNGResource.瞄准准星
        MyGraphics.DrawImage(MyBitmap, (Me.Width - MyBitmap.Width) \ 2, (Me.Height - MyBitmap.Height) \ 2)
        Me.BackgroundImage = MyBackground
        MyGraphics.Dispose()
    End Sub

    Private Sub ShowStand_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '启动旋转位图的线程，函数地址：ShowRotateBitmap
        RotateThread = New Threading.Thread(AddressOf ShowRotateBitmap)
        RotateThread.Start()
    End Sub

    '程序退出
    Private Sub ShowStand_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '窗体关闭时，中断多线程
        RotateThread.Abort()
        '卸载线程
        RotateThread = Nothing
    End Sub

    '多线程绑定的函数：
    Private Sub ShowRotateBitmap()
        '无限循环，不停的旋转
        Do While True
            '静态变量：旋转角度
            Static Angle As Single = 0.0
            '线程睡眠10微秒，防止占用过多CPU
            Threading.Thread.Sleep(10)
            '调用函数
            RotateShow.Image = GetRotateBitmap(My.Resources.PNGResource.旋转进度条, Angle)
            RotateShow.BackgroundImage = GetRotateBitmap(My.Resources.PNGResource.瞄准准星, Angle * 5)
            '角度循环加大
            Angle = IIf(Angle = 360, 0, Angle + 1)
        Loop
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles _
                                                                            Me.MouseDown, RotateShow.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then Me.Close() : End
        '鼠标拖动窗体
        ReleaseCapture()
        SendMessageA(Me.Handle, &HA1, 2, 0&)
    End Sub

    ''' <summary>
    ''' 返回旋转任意角度后的图像
    ''' </summary>
    ''' <param name="BitmapRes">需要旋转处理的图像</param>
    ''' <param name="Angle">旋转角度[单位：度]</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRotateBitmap(ByVal BitmapRes As Bitmap, ByVal Angle As Single) As Bitmap
        Dim ReturnBitmap As New Bitmap(BitmapRes.Width, BitmapRes.Height)
        Dim MyGraphics As Graphics = Graphics.FromImage(ReturnBitmap)
        MyGraphics.SmoothingMode = SmoothingMode.HighQuality
        MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality

        MyGraphics.TranslateTransform(BitmapRes.Width / 2, BitmapRes.Height / 2)
        MyGraphics.RotateTransform(Angle, MatrixOrder.Prepend)

        MyGraphics.TranslateTransform(-BitmapRes.Width / 2, -BitmapRes.Height / 2)
        MyGraphics.DrawImage(BitmapRes, 0, 0, BitmapRes.Width, BitmapRes.Height)
        MyGraphics.Dispose()
        GC.Collect()
        Return ReturnBitmap
    End Function

End Class
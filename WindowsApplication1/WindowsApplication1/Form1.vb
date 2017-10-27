Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s, x
        Randomize()
        s = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        For i = 1 To 32
            x = x & Mid(s, Int(Rnd() * Len(s) + 1), 1)
        Next
        TextBox2.Text = x
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If MsgBox("是否继续生成并转换二维码？", vbYesNo, "确认生成") = vbNo Then
            Exit Sub
        Else
            Dim MyStream As New System.IO.FileStream(Application.StartupPath + "\Data\" + TextBox2.Text + ".SHSdata", System.IO.FileMode.Create)
            Dim Data As New IO.StreamReader(MyStream, System.Text.Encoding.Default)
            Data.Close()
            Randomize()
            MyStream.Close()
            Label3.Text = "消息：票号" + TextBox2.Text + "生成成功"
            System.Diagnostics.Process.Start("https://cli.im/api/qrcode/code?text=" + TextBox2.Text)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IO.File.Exists(Application.StartupPath + "\Data\" + TextBox1.Text + ".SHSdata") Then
            '删除文件file的方法1:删除到回收站里面。
            My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\Data\" + TextBox1.Text + ".SHSdata", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
            '删除文件file的方法2:直接从硬盘上删除。
            'IO.File.Delete(fpath)
            Label3.Text = "消息：票号" + TextBox1.Text + "扫描成功"
            TextBox1.Text = ""
            TextBox1.Select()
        Else
            Label3.Text = "消息：票号" + TextBox1.Text + "已经失效！！！请重试！！！"
            TextBox1.Text = ""
            TextBox1.Select()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub PictureBox1_Click_2(sender As Object, e As EventArgs)

    End Sub
End Class

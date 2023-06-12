using SKYNET;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class Common
{
    public static string GetPath()
    {
        Process currentProcess;
        try
        {
            currentProcess = Process.GetCurrentProcess();
            return new FileInfo(currentProcess.MainModule.FileName).Directory?.FullName;
        }
        finally { currentProcess = null; }
    }

    public static void Show(object msg)
    {
        if (msg == null)
        {
            MessageBox.Show("El mensaje es nulo");
            return;
        }
        MessageBox.Show(msg.ToString());
    }

    public static int GenerateId2()
    {
        return new Random().Next(0, 999999);
    }

    internal static int GetTextSize(Control control, string text)
    {
        return Convert.ToInt32(Common.GetTextSize(text, control.Font).Width);
    }

    public static SizeF GetTextSize(string text, Font font)
    {
        try
        {
            SizeF result;
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                result = graphics.MeasureString(text, font);
            }
            return result;
        }
        catch (Exception)
        {
            return new SizeF(700, 0);
        }
    }

    public static void EnsureDirectoryExists(string filePath, bool isFile = false)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            filePath = filePath.Trim().Replace("\0", string.Empty);
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    string text = isFile ? Path.GetDirectoryName(filePath) : filePath;
                    if (Path.IsPathRooted(filePath))
                    {
                        text = text.Trim();
                        if (!Directory.Exists(text))
                        {
                            Directory.CreateDirectory(text);
                        }
                    }
                }
                catch { }
            }
        }
    }

    internal static void Notify(string msg, SKYNET_AlertBox.NotificationType flag = SKYNET_AlertBox.NotificationType.Success)
    {
        frmMain.frm.Notify(msg, flag);
    }

    public static void InvokeAction(Control control, Action Action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(Action);
        }
        else
        {
            Action();
        }
    }
}
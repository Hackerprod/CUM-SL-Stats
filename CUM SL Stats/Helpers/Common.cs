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
}
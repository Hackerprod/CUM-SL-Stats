using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET.Helpers
{
    public static class Extentions
    {
        public static void PrintData(this ListView lvw, Point location,
    Graphics gr, Brush header_brush, Brush data_brush, Pen grid_pen)
        {
            const int x_margin = 5;
            const int y_margin = 3;
            float x = location.X;
            float y = location.Y;

            // See how tall rows should be.
            SizeF row_size = gr.MeasureString(lvw.Columns[0].Text, lvw.Font);
            int row_height = (int)row_size.Height + 2 * y_margin;

            // Get the screen's horizontal resolution.
            float screen_res_x;
            using (Graphics screen_gr = lvw.CreateGraphics())
            {
                screen_res_x = screen_gr.DpiX;
            }

            // Scale factor to convert from screen pixels
            // to printer units (100ths of inches).
            float screen_to_printer = 100 / screen_res_x;

            // Get the column widths in printer dots.
            float[] col_wids = new float[lvw.Columns.Count];
            for (int i = 0; i < lvw.Columns.Count; i++)
                col_wids[i] = (lvw.Columns[i].Width + 4 * x_margin) *
                    screen_to_printer;

            int num_columns = lvw.Columns.Count;
            using (StringFormat string_format = new StringFormat())
            {
                // Draw the column headers.
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                for (int i = 0; i < num_columns; i++)
                {
                    RectangleF rect = new RectangleF(x + x_margin, y + y_margin, col_wids[i] - x_margin, row_height - y_margin);
                    gr.DrawString(lvw.Columns[i].Text, lvw.Font, header_brush, rect, string_format);
                    rect = new RectangleF(x, y, col_wids[i], row_height);
                    gr.DrawRectangle(grid_pen, rect);
                    x += col_wids[i];
                }
                y += row_height;

                // Draw the data.
                foreach (ListViewItem item in lvw.Items)
                {
                    x = location.X;
                    for (int i = 0; i < num_columns; i++)
                    {
                        RectangleF rect = new RectangleF(
                            x + x_margin, y,
                            col_wids[i] - x_margin, row_height);

                        switch (lvw.Columns[i].TextAlign)
                        {
                            case HorizontalAlignment.Left:
                                string_format.Alignment = StringAlignment.Near;
                                break;
                            case HorizontalAlignment.Center:
                                string_format.Alignment = StringAlignment.Center;
                                break;
                            case HorizontalAlignment.Right:
                                string_format.Alignment = StringAlignment.Far;
                                break;
                        }

                        gr.DrawString(item.SubItems[i].Text,
                            lvw.Font, header_brush, rect, string_format);
                        rect = new RectangleF(x, y, col_wids[i], row_height);
                        gr.DrawRectangle(grid_pen, rect);
                        x += col_wids[i];
                    }
                    y += row_height;
                }
            }
        }
        public static void DrawRectangle(this Graphics gr, Pen pen, RectangleF rectf)
        {
            gr.DrawRectangle(pen,
                rectf.Left, rectf.Top, rectf.Width, rectf.Height);
        }
    }
}

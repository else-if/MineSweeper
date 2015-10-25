using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    class ImagedTextBox : System.Windows.Forms.TextBox
    {
        public ImagedTextBox()
        {
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint,
                     true);
        }

        protected override void
           OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            /*Rectangle rect = new Rectangle(e.ClipRectangle.X,  
                e.ClipRectangle.Y,  
                e.ClipRectangle.Width - 1,  
                e.ClipRectangle.Height - 1);*/

            e.Graphics.DrawImage(Properties.Resources.PointedCell, 0, 0);
            /*e.Graphics.DrawRectangle(new Pen(Color.Chocolate, 1),  
                rect);  */
        }
    }
}

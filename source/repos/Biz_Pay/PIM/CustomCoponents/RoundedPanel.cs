using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM
{

    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 10;
        private Color _borderColor = Color.Gray;
        private int _borderThickness = 2;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        public int BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, _cornerRadius * 2, _cornerRadius * 2), 180, 90);
            path.AddLine(_cornerRadius, 0, Width - _cornerRadius, 0);
            path.AddArc(new Rectangle(Width - _cornerRadius * 2, 0, _cornerRadius * 2, _cornerRadius * 2), -90, 90);
            path.AddLine(Width, _cornerRadius, Width, Height - _cornerRadius);
            path.AddArc(new Rectangle(Width - _cornerRadius * 2, Height - _cornerRadius * 2, _cornerRadius * 2, _cornerRadius * 2), 0, 90);
            path.AddLine(Width - _cornerRadius, Height, _cornerRadius, Height);
            path.AddArc(new Rectangle(0, Height - _cornerRadius * 2, _cornerRadius * 2, _cornerRadius * 2), 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            Pen pen = new Pen(_borderColor, _borderThickness);
            e.Graphics.DrawPath(pen, path);
        }
    }

}
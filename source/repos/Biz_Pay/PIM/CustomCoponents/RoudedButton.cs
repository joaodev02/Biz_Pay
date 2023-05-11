using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PIM
{

    public class RoudedButton : Button
    {
        // Defina as cores do botao
        private Color color = Color.FromArgb(12, 35, 64);
        public int _cornerRadius = 10;
        private Color _borderColor = Color.Transparent;
        private int _borderThickness = 0;

        public void setGradientColor(Color color)
        {
            this.color = color;
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


            // Defina o retângulo de desenho do botao
            Rectangle retangle = new Rectangle(0, 0, this.Width, this.Height);
            SolidBrush solid = new SolidBrush(color);

            // Desenhe o solido no fundo do botao
            e.Graphics.FillRectangle(solid, retangle);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoudedButton
            // 
            this.Text = "77";
            this.ResumeLayout(false);

        }
    }

}
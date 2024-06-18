using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class EllipseShape : Shape
    {
        #region Constructor
        [JsonConstructor]
        public EllipseShape(RectangleF rect) : base(rect)
        {
        }

        public EllipseShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            float cx = point.X - (Location.X + Width / 2);
            float cy = point.Y - (Location.Y + Height / 2);
            float halfHeightP2 = Height / 2 * Height / 2;
            float halfWidthP2 = Width / 2 * Width / 2;
            float gg = (cx * cx) / halfWidthP2 + (cy * cy) / halfHeightP2;
            if (gg <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            var state = grfx.Save();
            grfx.MultiplyTransform(TransformationMatrix);

            int FillColorOpasityValue = 255 * FillColorOpacity / 100;

            if (GradientActive)
            {
                Color opColor = Color.FromArgb(FillColorOpasityValue, FillColor);
                Color grColor = Color.FromArgb(FillColorOpasityValue, GradientColor);

                LinearGradientBrush c = new LinearGradientBrush(new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X + Width, Rectangle.Y + Height), opColor, grColor);
                grfx.FillEllipse(c, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
            else
            {
                SolidBrush c = new SolidBrush(Color.FromArgb(FillColorOpasityValue, FillColor));
                grfx.FillEllipse(c, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
            Pen pen = new Pen(StrokeColor);
            pen.Width = BorderWidth;
            grfx.DrawEllipse(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            if (IsSelected) DrawSelectionBorder(grfx);
            grfx.Restore(state);         
        }
    }
}

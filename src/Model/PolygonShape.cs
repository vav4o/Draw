using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using Newtonsoft.Json;

namespace Draw.src.Model
{
    public class PolygonShape : Shape
    {
        #region Constructor
        [JsonConstructor]
        public PolygonShape(PointF[] points)
        {
            this.points = points;
        }

        public PolygonShape(RectangleShape rectangle) : base(rectangle)
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
            int intersectCount = 0;
            for (int i = 0; i < points.Count(); i++)
            {
                int next = (i + 1) % points.Count();
                if (
                (
                 (points[i].Y <= point.Y && point.Y < points[next].Y)
                 ||
                 (points[next].Y <= point.Y && point.Y < points[i].Y)
                )
                &&
                (point.X < (points[next].X - points[i].X) * (point.Y - points[i].Y)
                  / (points[next].Y - points[i].Y) + points[i].X))
                {
                    intersectCount++;
                }
            }
            return intersectCount % 2 == 1;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            var state = grfx.Save();
            grfx.MultiplyTransform(TransformationMatrix);

            int FillColorOpacityValue = 255 * FillColorOpacity / 100;

            if (GradientActive)
            {
                Color opColor = Color.FromArgb(FillColorOpacityValue, FillColor);
                Color grColor = Color.FromArgb(FillColorOpacityValue, GradientColor);

                LinearGradientBrush c = new LinearGradientBrush(new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X + Width, Rectangle.Y + Height), opColor, grColor);
                //LinearGradientBrush c = new LinearGradientBrush(new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X + Width, Rectangle.Y + Height), FillColor, GradientColor);
                grfx.FillPolygon(c, points);
            }
            else
            {
                SolidBrush c = new SolidBrush(Color.FromArgb(FillColorOpacityValue, FillColor));
                grfx.FillPolygon(c, points);
                //Color c = Color.FromArgb(FillColorOpasity, FillColor);
            }
            Pen pen = new Pen(StrokeColor);
            pen.Width = BorderWidth;
            grfx.DrawPolygon(pen, points);
            if (IsSelected) DrawSelectionBorder(grfx);
            grfx.Restore(state);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class Line : Shape
    {
        #region Constructor
        [JsonConstructor]
        public Line(RectangleF rect) : base(rect)
        {
        }

        public Line(RectangleShape rectangle) : base(rectangle)
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
            PointF fp = new PointF(Math.Min(Rectangle.X, Rectangle.X + Width), Math.Min(Rectangle.Y, Rectangle.Y + Height));
            PointF sp = new PointF(Math.Max(Rectangle.X, Rectangle.X + Width), Math.Max(Rectangle.Y, Rectangle.Y + Height));
            RectangleF a = new RectangleF(fp.X, fp.Y, sp.X - fp.X, sp.Y - fp.Y);
            return a.Contains(point.X, point.Y);
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            var state = grfx.Save();
            grfx.MultiplyTransform(TransformationMatrix);
            base.DrawSelf(grfx);
            if (IsSelected) DrawSelectionBorder(grfx);
            Pen pen = new Pen(FillColor);

           

            pen.Width = BorderWidth;
            grfx.DrawLine(
                pen,
                new PointF(Location.X, Location.Y),
                new PointF(Location.X + Width, Location.Y + Height));
            grfx.Restore(state);
        }
        public override void DrawSelectionBorder(Graphics grfx)
        {
            Pen pen = new Pen(Color.Black);
            PointF fp = new PointF(Math.Min(Rectangle.X, Rectangle.X + Width), Math.Min(Rectangle.Y, Rectangle.Y + Height));
            PointF sp = new PointF(Math.Max(Rectangle.X, Rectangle.X + Width), Math.Max(Rectangle.Y, Rectangle.Y + Height));
            pen.DashPattern = new float[] { 5, 5, 5, 5 };
            grfx.DrawRectangle(pen, fp.X, fp.Y, sp.X - fp.X, sp.Y - fp.Y);

            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X, Rectangle.Y, 8, 8);
            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X + Rectangle.Width - 8, Rectangle.Y, 8, 8);
            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X, Rectangle.Y + Rectangle.Height - 8, 8, 8);
            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X + Rectangle.Width - 8, Rectangle.Y + Rectangle.Height - 8, 8, 8);
        }
    }
}

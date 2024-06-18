using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	public class StarShape : Shape
	{
        #region Constructor
        [JsonConstructor]
        public StarShape(RectangleF rect) : base(rect)
		{
		}
		
		public StarShape(RectangleShape rectangle) : base(rectangle)
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

			float smallWidth = Width / 3;
			float smallHeight = Height / 3;
			float smallX = Location.X + smallWidth;
			float smallY = Location.Y + smallHeight;

			PointF[] edges = {
                new PointF(Location.X + Width / 2, Location.Y),
                new PointF(smallX + smallWidth * 3 / 4, Location.Y + smallHeight),
                new PointF(Location.X + Width, Location.Y + smallHeight),
                new PointF(smallX + smallWidth, smallY + smallHeight * 2 / 3),
                new PointF(Location.X + Width * 3 / 4, Location.Y + Height),
                new PointF(Location.X + Width / 2, Location.Y + smallHeight * 2),
                new PointF(Location.X + Width / 4, Location.Y + Height),
                new PointF(Location.X + smallWidth, smallY + smallHeight * 2 / 3),
                new PointF(Location.X, Location.Y + smallHeight),
                new PointF(smallX +	smallWidth / 4, Location.Y + smallHeight)
            };
            Points = edges;

            base.DrawSelf(grfx);
            var state = grfx.Save();
            grfx.MultiplyTransform(TransformationMatrix);

            int FillColorOpasityValue = 255 * FillColorOpacity / 100;

            if (GradientActive)
            {
                Color opColor = Color.FromArgb(FillColorOpasityValue, FillColor);
                Color grColor = Color.FromArgb(FillColorOpasityValue, GradientColor);

                LinearGradientBrush c = new LinearGradientBrush(new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X + Width, Rectangle.Y + Height), opColor, grColor);
                grfx.FillPolygon(c, edges);
            }
            else
            {
                SolidBrush c = new SolidBrush(Color.FromArgb(FillColorOpasityValue, FillColor));
                grfx.FillPolygon(c, edges);
            }
            Pen pen = new Pen(StrokeColor);
            pen.Width = BorderWidth;
            grfx.DrawPolygon(pen, edges);
            if (IsSelected) DrawSelectionBorder(grfx);
            grfx.Restore(state);
        }
	}
}

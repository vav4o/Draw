using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	public class RectangleShape : Shape
	{
        #region Constructor
        [JsonConstructor]
        public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
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
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}
		
		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{		
			var state = grfx.Save();
			grfx.MultiplyTransform(TransformationMatrix);
            
			int FillColorOpasityValue = 255 * FillColorOpacity / 100;

            if (GradientActive)
			{
				Color opColor = Color.FromArgb(FillColorOpasityValue, FillColor);
				Color grColor = Color.FromArgb(FillColorOpasityValue, GradientColor);

                LinearGradientBrush c = new LinearGradientBrush(new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X + Width, Rectangle.Y + Height), opColor, grColor);
				grfx.FillRectangle(c, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
			else
			{
				SolidBrush c = new SolidBrush(Color.FromArgb(FillColorOpasityValue, FillColor));
                grfx.FillRectangle(c, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
			Pen pen = new Pen(StrokeColor);
			pen.Width = BorderWidth;
			grfx.DrawRectangle(pen ,Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            if (IsSelected) DrawSelectionBorder(grfx);
            grfx.Restore(state);

            base.DrawSelf(grfx);
        }
	}
}

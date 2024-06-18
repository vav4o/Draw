using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.AxHost;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
	public abstract class Shape
	{
		#region Constructors

		public Shape()
		{
		}

		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}

		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;

			this.FillColor = shape.FillColor;
		}
		#endregion

		#region Properties

		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}

		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}

		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}

		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}

		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		protected Color fillColor = Color.White;
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

        protected Color strokeColor = Color.Black;
		public virtual Color StrokeColor
		{
			get { return strokeColor; }
			set { strokeColor = value; }
		}

        protected int fillColorOpacity = 100;
		public virtual int FillColorOpacity
		{
			get { return fillColorOpacity; }
			set { fillColorOpacity = value; }
		}

        protected bool gradientActive;
		public virtual bool GradientActive
		{
			get { return gradientActive; }
			set { gradientActive = value; }
		}

        protected Color gradientColor;
		public virtual Color GradientColor
		{
			get { return gradientColor; }
			set { gradientColor = value; }
		}

        protected Matrix transformationMatrix = new Matrix();

		public virtual Matrix TransformationMatrix
		{
			get { return transformationMatrix; }
			set { transformationMatrix = value; }
		}
		protected PointF[] points;
		public virtual PointF[] Points
		{
			get { return points; }
			set { points = value; }
		}
        protected float angle = 0;

        public virtual float Angle
        {
            get { return angle; }
            set { angle = value; }
        }
        protected int borderWidth = 1;

        public virtual int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }
        protected bool isSelected = false;
		public virtual bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        protected string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected List<Shape> subShapes = new List<Shape>();
        public List<Shape> SubShapes
        {
            get { return subShapes; }
            set { subShapes = value; }
        }
        #endregion


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point.X, point.Y);
		}
		
		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
		}

		public virtual void DrawSelectionBorder(Graphics grfx)
		{
            Pen pen = new Pen(Color.Black);
			pen.DashPattern = new float[] {5, 5, 5, 5};
            grfx.DrawRectangle(pen, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X, Rectangle.Y, 8, 8);
            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X + Rectangle.Width - 8, Rectangle.Y, 8, 8);
            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X, Rectangle.Y + Rectangle.Height - 8, 8, 8);
            grfx.DrawRectangle(new Pen(Color.Black), Rectangle.X + Rectangle.Width - 8, Rectangle.Y + Rectangle.Height - 8, 8, 8);
        }
		public virtual bool DetectBorderPress(PointF point)
		{
			if ((point.X >= Rectangle.X && point.X <= Rectangle.X + 8 && point.Y >= Rectangle.Y && point.Y <= Rectangle.Y + 8) ||
                (point.X >= Rectangle.X + Rectangle.Width - 8 && point.X <= Rectangle.X + Rectangle.Width && point.Y >= Rectangle.Y && point.Y <= Rectangle.Y + 8) ||
                (point.X >= Rectangle.X && point.X <= Rectangle.X + 8 && point.Y >= Rectangle.Y + Rectangle.Height - 8 && point.Y <= Rectangle.Y + Rectangle.Height) ||
                (point.X >= Rectangle.X + Rectangle.Width - 8 && point.X <= Rectangle.X + Rectangle.Width && point.Y >= Rectangle.Y + Rectangle.Height - 8 && point.Y <= Rectangle.Y + Rectangle.Height))
			{
				return true;
			}
			else { return false; }
		}
	}
}

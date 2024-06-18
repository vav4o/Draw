using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на дисплейната система.
	/// </summary>
	public class DisplayProcessor
	{
		#region Constructor
		
		public DisplayProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Списък с всички елементи формиращи изображението.
		/// </summary>
		private List<Shape> shapeList = new List<Shape>();		
		public List<Shape> ShapeList {
			get { return shapeList; }
			set { shapeList = value; }
		}

        protected PointF dragSelectOn = new PointF(100, 100);
        public PointF DragSelectOn
        {
            get { return dragSelectOn; }
            set { dragSelectOn = value; }
        }

        protected bool dragSelectOn2;
        public bool DragSelectOn2
        {
            get { return dragSelectOn2; }
            set { dragSelectOn2 = value; }
        }

        protected PointF currentPoint = new PointF(100, 100);
        public PointF CurrentPoint
        {
            get { return currentPoint; }
            set { currentPoint = value; }
        }
        protected PointF clickPoint = new PointF(0, 0);
        public PointF ClickPoint
        {
            get { return clickPoint; }
            set { clickPoint = value; }
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Прерисува всички елементи в shapeList върху e.Graphics
        /// </summary>
        public void ReDraw(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(e.Graphics);
			DragSelectDraw(e.Graphics);
		}
		
		/// <summary>
		/// Визуализация.
		/// Обхождане на всички елементи в списъка и извикване на визуализиращия им метод.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		public virtual void Draw(Graphics grfx)
		{
			foreach (Shape item in ShapeList){
				DrawShape(grfx, item);
			}
		}
		
		/// <summary>
		/// Визуализира даден елемент от изображението.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		/// <param name="item">Елемент за визуализиране.</param>
		public virtual void DrawShape(Graphics grfx, Shape item)
		{
			item.DrawSelf(grfx);
		}
        public void DragSelectDraw(Graphics grfx)
        {
            PointF stP = new PointF(Math.Min(clickPoint.X, currentPoint.X), Math.Min(clickPoint.Y, currentPoint.Y));
            PointF endP = new PointF(Math.Max(clickPoint.X, currentPoint.X), Math.Max(clickPoint.Y, currentPoint.Y));
            Pen pen = new Pen(Color.Black);
            pen.DashPattern = new float[] { 8, 8, 8, 8 };
            if (dragSelectOn2)
				grfx.DrawRectangle(pen, stP.X, stP.Y, endP.X - stP.X, endP.Y-stP.Y);
        }
        #endregion
    }
}

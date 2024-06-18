using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Draw.src.Model
{
    public class GroupShape : Shape
    {
        #region Constructor
        [JsonConstructor]
        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        public override PointF Location
        {
            get => base.Location;
            set
            {
                foreach (Shape shp in subShapes) 
                {
                    shp.Location = new PointF(
                        shp.Location.X + value.X - Location.X,
                        shp.Location.Y + value.Y - Location.Y);
                }
                foreach (PolygonShape shp in subShapes.Where(x => x is PolygonShape))
                {
                    for (int i = 0; i < shp.Points.Length; i++)
                    {
                        shp.Points[i] = new PointF(
                            shp.Points[i].X + value.X - Location.X,
                            shp.Points[i].Y + value.Y - Location.Y);
                    }
                }
                base.Location = new PointF(value.X, value.Y);
            }
        }

        public override Color StrokeColor
        {
            get => base.strokeColor;
            set
            {
                strokeColor = value;
                foreach (Shape shp in subShapes)
                {
                    shp.StrokeColor = this.strokeColor;
                }
            }
        }
        public override Color FillColor
        {
            get => base.fillColor;
            set
            {
                fillColor = value;
                foreach (Shape shp in subShapes)
                {
                    shp.FillColor = this.fillColor;
                }
            }
        }

        public override Color GradientColor 
        { 
            get => base.gradientColor; 
            set 
            {
                gradientColor = value;
                foreach (Shape shp in subShapes)
                {
                    shp.GradientColor = this.gradientColor;
                }
            } 
        }

        public override int FillColorOpacity 
        { 
            get => base.fillColorOpacity; 
            set 
            {
                fillColorOpacity = value;
                foreach(Shape shp in subShapes)
                {
                    shp.FillColorOpacity = this.fillColorOpacity;
                }
            } 
        }
        public override bool GradientActive 
        { 
            get => base.gradientActive; 
            set 
            {
                gradientActive = value;
                foreach( Shape shp in subShapes)
                {
                    shp.GradientActive = this.gradientActive;
                }
            } 
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
            //Check if point is in the Bounding Box
            if (!Rectangle.Contains(point))
                return false;
            foreach (Shape shape in SubShapes)
            {
                if (shape.Contains(point)) return true;
            }
            return false;
        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public override void DrawSelf(Graphics grfx)
        {           
            base.DrawSelf(grfx);

            var state = grfx.Save();

            grfx.MultiplyTransform(TransformationMatrix);
            foreach (Shape shp in SubShapes)
            {
                var subState = grfx.Save();
                
                shp.DrawSelf(grfx);
                grfx.Restore(subState);
            }
            if (IsSelected) DrawSelectionBorder(grfx);
            grfx.Restore(state);
        }

    }
}

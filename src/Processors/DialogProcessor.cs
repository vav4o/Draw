using Draw.src.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : DisplayProcessor
    {
        #region Constructor

        public DialogProcessor()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Избран елемент.
        /// </summary>
        private List<Shape> selection = new List<Shape>();
        private List<PointF> polygonPoints = new List<PointF>();
        public List<Shape> Selection
        {
            get { return selection; }
            set { selection = value; }
        }
        private Shape currentShape;
        public Shape CurrentShape
        {
            get { return currentShape; }
            set { currentShape = value; }
        }

        private Shape savedShape;
        public Shape SavedShape
        {
            get { return savedShape; }
            set { savedShape = value; }
        }
        private Shape notSavedShape;
        public Shape NotSavedShape
        {
            get { return notSavedShape; }
            set { notSavedShape = value; }
        }
        private Layer currentLayer;
        public Layer CurrentLayer
        {
            get { return currentLayer; }
            set { currentLayer = value; }
        }
        private List<Layer> currentLayers = new List<Layer>();
        public List<Layer> CurrentLayers
        {
            get { return currentLayers; }
            set { currentLayers = value; }
        }
        private List<Layer> layers = new List<Layer>();
        public List<Layer> Layers
        {
            get { return layers; }
            set { layers = value; }
        }
        private int shapeNumber = 0;
        public int ShapeNumber
        {
            get { return shapeNumber; }
            set { shapeNumber = value; }
        }

        private PointF linePoint = new PointF(-5, -5);
        public PointF LinePoint
        {
            get { return linePoint; }
            set { linePoint = value; }
        }
        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        
        private bool isDragging = false;
        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF lastLocation;
        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }

        #endregion

        /// <summary>
        /// Добавя примитив - правоъгълник на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomRectangle(int borderWidth)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
            rect.BorderWidth = borderWidth;
            shapeNumber++;
            rect.Name = "Rectangle " + shapeNumber;

            ShapeList.Add(rect);
            currentLayer.Shapes.Add(rect);
        }
        public void AddRandomEllipse(int borderWidth)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 100, 200));
            ellipse.BorderWidth = borderWidth;
            shapeNumber++;
            ellipse.Name = "Ellipse " + shapeNumber;

            ShapeList.Add(ellipse);
            currentLayer.Shapes.Add(ellipse);
        }
        public void AddRandomLine(int borderWidth)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            Line line = new Line(new Rectangle(x, y, 100, 200));
            line.FillColor = Color.Black;
            line.BorderWidth = borderWidth;
            shapeNumber++;
            line.Name = "line " + shapeNumber;

            ShapeList.Add(line);
            currentLayer.Shapes.Add(line);
        }
        public void AddRandomStar(int borderWidth)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            StarShape star = new StarShape(new Rectangle(x, y, 200, 200));
            star.BorderWidth = borderWidth;
            shapeNumber++;
            star.Name = "Star " + shapeNumber;

            ShapeList.Add(star);
            currentLayer.Shapes.Add(star);
        }
        public bool CheckForCompletePolygon(PointF point, int borderWidth)
        {
            if (polygonPoints.Count > 1 && Math.Abs(point.X - polygonPoints[0].X) <= 50 && Math.Abs(point.Y - polygonPoints[0].Y) <= 20) return true;
            return false;
        }
        public void SelectPolygonPoint(PointF point, int borderWidth)
        {
            if (polygonPoints.Count > 1 && Math.Abs(point.X - polygonPoints[0].X) <= 50 && Math.Abs(point.Y - polygonPoints[0].Y) <= 20)
            {
                for (int i = 0; i < polygonPoints.Count; i++)
                {
                    ShapeList.RemoveAt(ShapeList.Count - 1);
                }
                float minX = float.MaxValue;
                float minY = float.MaxValue;
                float maxX = float.MinValue;
                float maxY = float.MinValue;
                foreach (PointF edge in polygonPoints)
                {
                    if (edge.X < minX) minX = edge.X;
                    if (edge.Y < minY) minY = edge.Y;
                    if (edge.X > maxX) maxX = edge.X;
                    if (edge.Y > maxY) maxY = edge.Y;
                }
                PointF[] pointArr = polygonPoints.ToArray();
                PolygonShape pol = new PolygonShape(pointArr);
                pol.Width = maxX - minX;
                pol.Height = maxY - minY;

                pol.Rectangle = new RectangleF(minX, minY, pol.Width, pol.Height);
                pol.BorderWidth = borderWidth;
                shapeNumber++;
                pol.Name = "Polygon " + shapeNumber;
                ShapeList.Add(pol);
                currentLayer.Shapes.Add(pol);
                polygonPoints.Clear();
            }
            else
            {
                if (polygonPoints.Count == 0)
                {
                    polygonPoints.Add(point);
                    EllipseShape ellipse = new EllipseShape(new RectangleF(point.X, point.Y, 2, 2));
                    ellipse.FillColor = Color.Blue;
                    ellipse.StrokeColor = Color.Green;

                    ShapeList.Add(ellipse);
                }
                else
                {
                    Line line = new Line(new RectangleF(polygonPoints.Last().X, polygonPoints.Last().Y,
                        point.X - polygonPoints.Last().X, point.Y - polygonPoints.Last().Y));
                    polygonPoints.Add(point);
                    line.FillColor = Color.Black;

                    ShapeList.Add(line);
                }
            }
        }
        public void DrawLineStart(PointF point)
        {
            linePoint = point;
            EllipseShape ellipse = new EllipseShape(new RectangleF(point.X, point.Y, 2, 2));
            ellipse.StrokeColor = Color.Green;
            ShapeList.Add(ellipse);
        }
        public void FinishLine(PointF point, int borderWidth)
        {
            ShapeList.RemoveAt(ShapeList.Count-1);
            Line line = new Line(new RectangleF(linePoint.X, linePoint.Y, point.X-linePoint.X, point.Y-linePoint.Y));
            line.FillColor= Color.Black;
            line.BorderWidth = borderWidth;
            shapeNumber++;
            line.Name = "line " + shapeNumber;

            ShapeList.Add(line);
            currentLayer.Shapes.Add(line);
            linePoint.X = -5;
        }
        public void CancelLine()
        {
            if (linePoint.X != -5) ShapeList.RemoveAt(ShapeList.Count - 1);
            linePoint.X = -5;
        }
        public void CancelPolygon()
        {
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                ShapeList.RemoveAt(ShapeList.Count - 1);
            }
            polygonPoints.Clear();
        }
        public void GroupSelected()
        {
            if (Selection.Count < 2) return;

            float minX, minY, maxX, maxY;
            minX = float.PositiveInfinity; minY = float.PositiveInfinity;
            maxX = float.NegativeInfinity; maxY = float.NegativeInfinity;

            foreach (Shape shp in Selection)
            {
                if (shp.Location.X < minX) minX = shp.Location.X;
                if (shp.Location.Y < minY) minY = shp.Location.Y;
                if (shp.Location.X + shp.Width > maxX) maxX = shp.Location.X + shp.Width;
                if (shp.Location.Y + shp.Height > maxY) maxY = shp.Location.Y + shp.Height;

            }
            GroupShape group = new GroupShape(new RectangleF(minX, minY, maxX - minX, maxY - minY));

            group.StrokeColor = Color.Black;
            group.FillColor = Color.White;
            group.TransformationMatrix = new Matrix();
            group.FillColorOpacity = 100;
            group.Width = maxX - minX;
            group.Height = maxY - minY;
            foreach (Shape shp in Selection)
            {
                shp.IsSelected = false;
                group.SubShapes.Add(shp);
                ShapeList.Remove(shp);
            }

            Selection.Clear();
            Selection.Add(group);
            ShapeList.Add(group);
            currentLayer.Shapes.Add(group);
        }
        public void UngroupSelected()
        {
            foreach (GroupShape shp in selection)
            {
                ShapeList.AddRange(shp.SubShapes);
                ShapeList.Remove(shp);
            }
            for (int i = 0; i < selection.Count; i++)
            {
                if (selection[i].GetType() == typeof(GroupShape))
                {
                    selection.Remove(selection[i]);
                }
            }
        }
        public void DragSelectStart(PointF loc)
        {
            dragSelectOn = loc;
        }

        public void DragSelectEnd()
        {
            if (dragSelectOn2)
            {
                PointF stP = new PointF(Math.Min(clickPoint.X, currentPoint.X), Math.Min(clickPoint.Y, currentPoint.Y));
                PointF endP = new PointF(Math.Max(clickPoint.X, currentPoint.X), Math.Max(clickPoint.Y, currentPoint.Y));
                foreach (Shape shape in selection)
                    shape.IsSelected = false;
                selection.Clear();
                
                foreach (Shape shp in ShapeList) 
                {
                    if (ShapeCenter(shp).X > stP.X && ShapeCenter(shp).Y > stP.Y && ShapeCenter(shp).X < endP.X && ShapeCenter(shp).Y < endP.Y)
                    {
                        selection.Add(shp);
                        shp.IsSelected = true;
                    }
                }
                dragSelectOn2 = false;
            }
        }
        
        public void PlaceOnTop()
        {
            List<Shape> shapes = selection;
            foreach (Shape shp in shapes)
            {
                ShapeList.Remove(shp);
            }
            foreach (Shape shp in shapes)
            {
                ShapeList.Add(shp);
            }
        }
        public void RotateAt(float rotation)
        {
            foreach (Shape shp in selection)
            {
                shp.TransformationMatrix.RotateAt(rotation, new PointF((shp.Location.X + shp.Width / 2), shp.Location.Y + shp.Height / 2));
                shp.Angle += rotation;
                if (shp.Angle > 360) shp.Angle -= 360;
            }
        }
        public void SetRotate(float rotation)
        {
            foreach (Shape shp in selection)
            {
                shp.TransformationMatrix.RotateAt(shp.Angle * -1, new PointF((shp.Location.X + shp.Width / 2), shp.Location.Y + shp.Height / 2));
                shp.Angle = rotation;
                if (shp.Angle > 360) shp.Angle -= 360;
                shp.TransformationMatrix.RotateAt(shp.Angle, new PointF((shp.Location.X + shp.Width / 2), shp.Location.Y + shp.Height / 2));
            }
        }
        public void Rotate(Shape shp, float rotation)
        {

            shp.TransformationMatrix.RotateAt(rotation, new PointF((shp.Location.X + shp.Width / 2), shp.Location.Y + shp.Height / 2));

        }

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
        {
            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                point = RotatePoint(point, ShapeCenter(ShapeList[i]), ShapeList[i].Angle);
                if (ShapeList[i].Contains(point))
                {
                    point = RotatePoint(point, ShapeCenter(ShapeList[i]), ShapeList[i].Angle*-1);
                    return ShapeList[i];
                }
                point = RotatePoint(point, ShapeCenter(ShapeList[i]), ShapeList[i].Angle * -1);
            }
            return null;
        }
        public PointF ShapeCenter(Shape shape)
        {
            return new PointF(shape.Location.X + shape.Width/2, shape.Location.Y + shape.Height/2);
        }
        static PointF RotatePoint(PointF pointToRotate, PointF centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / -180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new PointF
            {
                X =
                    (int)
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (int)
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }
        public Shape ContainsBorder(PointF point)
        {
            for (int i = selection.Count-1; i >= 0; i--)
            {
                point = RotatePoint(point, ShapeCenter(selection[i]), ShapeList[i].Angle);
                if (selection[i].DetectBorderPress(point))
                {
                    point = RotatePoint(point, ShapeCenter(ShapeList[i]), ShapeList[i].Angle * -1);
                    return selection[i];
                }
                point = RotatePoint(point, ShapeCenter(ShapeList[i]), ShapeList[i].Angle * -1);
            }
            return null;
        }
        public void ChangeSize(PointF p)
        {
            if (currentShape.GetType() == typeof(PolygonShape))
            {
                List<float> proportionsX = new List<float>();
                List<float> proportionsY = new List<float>();
                foreach (var point in currentShape.Points)
                {
                    proportionsX.Add(point.X - currentShape.Location.X);
                    proportionsY.Add(point.Y - currentShape.Location.Y);
                }

                if (p.X < currentShape.Location.X + currentShape.Width / 2)
                {
                    if (p.X != currentShape.Location.X)
                    {
                        float oldWidth = currentShape.Width;
                        currentShape.Width -= p.X - lastLocation.X;
                        float widthProportion = currentShape.Width / oldWidth;

                        Rotate(currentShape, currentShape.Angle * -1);
                        currentShape.Location = new PointF(currentShape.Location.X + p.X - lastLocation.X, currentShape.Location.Y);
                        Rotate(currentShape, currentShape.Angle);
                        for (int i = 0; i < proportionsX.Count; i++)
                        {
                            currentShape.Points[i].X = proportionsX[i] * widthProportion + currentShape.Location.X;
                        }
                    }
                }
                if (p.X > currentShape.Location.X + currentShape.Width / 2)
                {
                    if (p.X != currentShape.Location.X + currentShape.Width)
                    {
                        float oldWidth = currentShape.Width;
                        currentShape.Width += p.X - lastLocation.X;
                        float widthProportion = currentShape.Width / oldWidth;

                        for (int i = 0; i < proportionsX.Count; i++)
                        {
                            currentShape.Points[i].X = proportionsX[i] * widthProportion + currentShape.Location.X;
                        }
                    }
                }
                if (p.Y < currentShape.Location.Y + currentShape.Width / 2)
                {
                    if (p.Y != currentShape.Location.Y)
                    {
                        float oldHeight = currentShape.Height;
                        currentShape.Height -= p.Y - lastLocation.Y;
                        float heightProportion = currentShape.Height / oldHeight;

                        Rotate(currentShape, currentShape.Angle * -1);
                        currentShape.Location = new PointF(currentShape.Location.X, currentShape.Location.Y + p.Y - lastLocation.Y);
                        Rotate(currentShape, currentShape.Angle);
                        for (int i = 0; i < proportionsY.Count; i++)
                        {
                            currentShape.Points[i].Y = proportionsY[i] * heightProportion + currentShape.Location.Y;
                        }
                    }
                }
                if (p.Y > currentShape.Location.Y + currentShape.Height / 2)
                {
                    if (p.Y != currentShape.Location.Y + currentShape.Height)
                    {
                        float oldHeight = currentShape.Height;
                        currentShape.Height += p.Y - lastLocation.Y;
                        float heightProportion = currentShape.Height / oldHeight;

                        for (int i = 0; i < proportionsY.Count; i++)
                        {
                            currentShape.Points[i].Y = proportionsY[i] * heightProportion + currentShape.Location.Y;
                        }
                    }
                }
            }
            else if (currentShape.GetType() == typeof(GroupShape))
            {
                List<Shape> temp = currentShape.SubShapes;
                List<float> proportionsX = new List<float>();
                List<float> proportionsY = new List<float>();
                List<float> proportionsWidth = new List<float>();
                List<float> proportionsHeight = new List<float>();

                foreach (Shape shp in temp)
                {
                    proportionsX.Add(currentShape.Width / (currentShape.Location.X - shp.Location.X));
                    proportionsY.Add(currentShape.Height / (currentShape.Location.Y - shp.Location.Y));
                    proportionsWidth.Add(currentShape.Width / shp.Width);
                    proportionsHeight.Add(currentShape.Height / shp.Height);
                }

                if (p.X < currentShape.Location.X + currentShape.Width / 2)
                {
                    if (p.X != currentShape.Location.X)
                    {
                        currentShape.Width -= p.X - lastLocation.X;
                        Rotate(currentShape, currentShape.Angle * -1);
                        currentShape.Location = new PointF(currentShape.Location.X + p.X - lastLocation.X, currentShape.Location.Y);
                        Rotate(currentShape, currentShape.Angle);
                    }
                }
                if (p.X > currentShape.Location.X + currentShape.Width / 2)
                {
                    if (p.X != currentShape.Location.X + currentShape.Width)
                    {
                        currentShape.Width += p.X - lastLocation.X;
                    }
                }
                if (p.Y < currentShape.Location.Y + currentShape.Width / 2)
                {
                    if (p.Y != currentShape.Location.Y)
                    {
                        currentShape.Height -= p.Y - lastLocation.Y;
                        Rotate(currentShape, currentShape.Angle * -1);
                        currentShape.Location = new PointF(currentShape.Location.X, currentShape.Location.Y + p.Y - lastLocation.Y);
                        Rotate(currentShape, currentShape.Angle);
                    }
                }
                if (p.Y > currentShape.Location.Y + currentShape.Height / 2)
                {
                    if (p.Y != currentShape.Location.Y + currentShape.Height)
                    {
                        currentShape.Height += p.Y - lastLocation.Y;
                    }
                }
                for (int i = 0; i < currentShape.SubShapes.Count; i++)
                {
                    currentShape.SubShapes[i].Location = new PointF(Math.Abs(currentShape.Width / proportionsX[i]) + currentShape.Location.X, Math.Abs(currentShape.Height / proportionsY[i])+ currentShape.Location.Y);
                    currentShape.SubShapes[i].Width = currentShape.Width / proportionsWidth[i];
                    currentShape.SubShapes[i].Height = currentShape.Height / proportionsHeight[i];
                }
            }
            else
            {
                if (p.X < currentShape.Location.X + currentShape.Width / 2)
                {
                    if (p.X != currentShape.Location.X)
                    {
                        currentShape.Width -= p.X - lastLocation.X;
                        Rotate(currentShape, currentShape.Angle * -1);
                        currentShape.Location = new PointF(currentShape.Location.X + p.X - lastLocation.X, currentShape.Location.Y);
                        Rotate(currentShape, currentShape.Angle);
                    }
                }
                if (p.X > currentShape.Location.X + currentShape.Width / 2)
                {
                    if (p.X != currentShape.Location.X + currentShape.Width)
                    {
                        currentShape.Width += p.X - lastLocation.X;
                    }
                }
                if (p.Y < currentShape.Location.Y + currentShape.Width / 2)
                {
                    if (p.Y != currentShape.Location.Y)
                    {
                        currentShape.Height -= p.Y - lastLocation.Y;
                        Rotate(currentShape, currentShape.Angle * -1);
                        currentShape.Location = new PointF(currentShape.Location.X, currentShape.Location.Y + p.Y - lastLocation.Y);
                        Rotate(currentShape, currentShape.Angle);
                    }
                }
                if (p.Y > currentShape.Location.Y + currentShape.Height / 2)
                {
                    if (p.Y != currentShape.Location.Y + currentShape.Height)
                    {
                        currentShape.Height += p.Y - lastLocation.Y;
                    }
                }
            }
            lastLocation = p;
        }

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (selection.Count > 0)
            {
                foreach (Shape shp in selection)
                {

                    if (shp.GetType() == typeof(PolygonShape))
                    {
                        for (int i = 0; i < shp.Points.Length; i++)
                            shp.Points[i] = new PointF(shp.Points[i].X + p.X - lastLocation.X, shp.Points[i].Y + p.Y - lastLocation.Y);
                    }
                    Rotate(shp, shp.Angle * -1);
                    shp.Location = new PointF(shp.Location.X + p.X - lastLocation.X, shp.Location.Y + p.Y - lastLocation.Y);
                    Rotate(shp, shp.Angle);
                }
                lastLocation = p;
            }
        }
        public void SaveFile(string fileName)
        {
            foreach (Shape shape in selection) shape.IsSelected = false;
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = JsonSerializer.Create(settings);
                serializer.Serialize(file, Layers);
            }
        }
        public void LoadFile(string fileName)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            using (StreamReader file = new StreamReader(fileName))
            {
                JsonSerializer serializer = JsonSerializer.Create(settings);
                Layers = (List<Layer>)serializer.Deserialize(file, typeof(List<Layer>));
                foreach (Layer layer in Layers)
                {
                    foreach (Shape shape in layer.Shapes)
                    {
                        Rotate(shape, shape.Angle);
                    }
                    if (layer.Name == "Base Layer")
                    {
                        ShapeList = layer.Shapes;
                        currentLayer = layer;
                        break;
                    }
                }
            }

        }

        public void SaveShape()
        {
            if (notSavedShape.GetType() == typeof(RectangleShape)) savedShape = new RectangleShape(new Rectangle(0, 0, 0, 0));
            else if (notSavedShape.GetType() == typeof(EllipseShape)) savedShape = new EllipseShape(new Rectangle(0, 0, 0, 0));
            else if (notSavedShape.GetType() == typeof(StarShape)) savedShape = new StarShape(new Rectangle(0, 0, 0, 0));
            else if (notSavedShape.GetType() == typeof(GroupShape)) savedShape = new GroupShape(new Rectangle(0, 0, 0, 0));
            else if (notSavedShape.GetType() == typeof(Line)) savedShape = new Line(new Rectangle(0, 0, 0, 0));
            else if (notSavedShape.GetType() == typeof(PolygonShape))
            {
                savedShape = new PolygonShape(new PointF[notSavedShape.Points.Length]);
                for (int i = 0; i < NotSavedShape.Points.Length; i++)
                {
                    savedShape.Points[i] = new PointF(notSavedShape.Points[i].X, (notSavedShape.Points[i].Y));
                }
            }
            savedShape.SubShapes = notSavedShape.SubShapes;
            savedShape.Location = notSavedShape.Location;
            savedShape.Rectangle = notSavedShape.Rectangle;
            savedShape.Angle = notSavedShape.Angle;
            savedShape.BorderWidth = notSavedShape.BorderWidth;
            savedShape.Width = notSavedShape.Width;
            savedShape.Height = notSavedShape.Height;
            savedShape.FillColor = notSavedShape.FillColor;
            savedShape.FillColorOpacity = notSavedShape.FillColorOpacity;
            savedShape.GradientColor = notSavedShape.GradientColor;
            savedShape.GradientActive = notSavedShape.GradientActive;
            savedShape.IsSelected = false;
            savedShape.StrokeColor = notSavedShape.StrokeColor;
            savedShape.TransformationMatrix = notSavedShape.TransformationMatrix;
        }
        public void Paste()
        {
            if (SavedShape != null)
            {
                shapeNumber++;
                savedShape.Name = "Shape Copy " + shapeNumber;
                if (notSavedShape.GetType() == typeof(PolygonShape))
                {
                    for (int i = 0; i < savedShape.Points.Length; i++)
                    {
                        savedShape.Points[i].X -= savedShape.Location.X - currentPoint.X;
                        savedShape.Points[i].Y -= savedShape.Location.Y - currentPoint.Y;
                    }
                }
                savedShape.Location = currentPoint;

                CurrentLayer.Shapes.Add(SavedShape);
                ShapeList.Add(SavedShape);
                SaveShape();
            }       
        }
    }
}

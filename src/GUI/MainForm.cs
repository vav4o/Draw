using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Върху главната форма е поставен потребителски контрол,
    /// в който се осъществява визуализацията
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
        /// </summary>
        private DialogProcessor dialogProcessor = new DialogProcessor();
        private Layer baseLayer = new Layer("Base Layer");

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            dialogProcessor.CurrentLayer = baseLayer;
            dialogProcessor.Layers.Add(baseLayer);
            LayerComboBoxPanel.Items.Add(baseLayer.Name);
            MultiLayerComboBoxPanel.Items.Add(baseLayer.Name);
            LayerComboBoxPanel.SelectedIndex = 0;

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        /// <summary>
        /// Изход от програмата. Затваря главната форма, а с това и програмата.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
        /// </summary>
        void ViewPortPaint(object sender, PaintEventArgs e)
        {
            dialogProcessor.ReDraw(sender, e);
        }

        /// <summary>
        /// Бутон, който поставя на произволно място правоъгълник със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRectangle(borderWidthTrackBar.Value);
            ShapeNameComboBoxPanel.Items.Add("Rectangle " + dialogProcessor.ShapeNumber);
            ShapeNameComboBoxPanel.SelectedIndex = ShapeNameComboBoxPanel.FindStringExact("Rectangle " + dialogProcessor.ShapeNumber);
            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>

        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dialogProcessor.ClickPoint = e.Location;
            dialogProcessor.DragSelectOn = e.Location;

            if (drawPolygonSpeedButton.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (dialogProcessor.CheckForCompletePolygon(e.Location, borderWidthTrackBar.Value))
                    {
                        ShapeNameComboBoxPanel.Items.Add("Polygon " + (dialogProcessor.ShapeNumber + 1));
                        ShapeNameComboBoxPanel.SelectedIndex = ShapeNameComboBoxPanel.FindStringExact("Polygon " + (dialogProcessor.ShapeNumber + 1));
                        drawPolygonSpeedButton.Checked = false;
                    }
                    dialogProcessor.SelectPolygonPoint(e.Location, borderWidthTrackBar.Value);
                }
                else dialogProcessor.CancelPolygon();
            }
            else if (DrawLineBtn.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (dialogProcessor.LinePoint.X == -5)
                    {
                        dialogProcessor.DrawLineStart(e.Location);
                    }
                    else
                    {
                        dialogProcessor.FinishLine(e.Location, borderWidthTrackBar.Value);
                        ShapeNameComboBoxPanel.Items.Add("Line " + dialogProcessor.ShapeNumber);
                        ShapeNameComboBoxPanel.SelectedIndex = ShapeNameComboBoxPanel.FindStringExact("Line " + dialogProcessor.ShapeNumber);
                    }
                }
                else dialogProcessor.CancelLine();
            }
            else
            {
                Shape tempB = dialogProcessor.ContainsBorder(e.Location);
                if (tempB != null)
                {
                    dialogProcessor.IsDragging = true;
                    dialogProcessor.LastLocation = e.Location;
                    dialogProcessor.CurrentShape = tempB;
                    dialogProcessor.DragSelectOn2 = false;
                    viewPort.Invalidate();
                }
                else
                {
                    Shape temp = dialogProcessor.ContainsPoint(e.Location);
                    if (pickUpSpeedButton.Checked)
                    {
                        if (dialogProcessor.Selection.Contains(temp))
                        {
                            statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                            dialogProcessor.IsDragging = true;
                            dialogProcessor.LastLocation = e.Location;
                            viewPort.Invalidate();
                        }
                        else if (temp != null)
                        {
                            dialogProcessor.Selection.Add(temp);
                            temp.IsSelected = true;

                            statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                            dialogProcessor.IsDragging = true;
                            dialogProcessor.LastLocation = e.Location;
                            viewPort.Invalidate();

                            if (dialogProcessor.Selection.Count == 1)
                            {
                                trackBar1.Value = temp.FillColorOpacity;
                                borderWidthTrackBar.Value = temp.BorderWidth;
                                trackBar2.Value = (int)temp.Angle;
                            }
                        }
                        else
                        {
                            dialogProcessor.DragSelectOn2 = true;
                        }
                    }
                    else
                    {
                        if (temp != null)
                        {
                            foreach (Shape shape in dialogProcessor.Selection) { shape.IsSelected = false; }
                            dialogProcessor.Selection.Clear();

                            dialogProcessor.Selection.Add(temp);
                            temp.IsSelected = true;

                            statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                            dialogProcessor.IsDragging = true;
                            dialogProcessor.LastLocation = e.Location;
                            viewPort.Invalidate();

                            trackBar1.Value = temp.FillColorOpacity;
                            borderWidthTrackBar.Value = temp.BorderWidth;
                            trackBar2.Value = (int)temp.Angle;
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                Shape temp = dialogProcessor.ContainsPoint(e.Location);
                if (temp != null)
                {
                    optionsMenu.Items[0].Visible = true;
                    optionsMenu.Items[2].Visible = true;
                    optionsMenu.Show(Cursor.Position);
                    dialogProcessor.NotSavedShape = temp;
                }
                else
                {
                    optionsMenu.Items[0].Visible = false;
                    optionsMenu.Items[2].Visible = false;
                    optionsMenu.Show(Cursor.Position);
                }
            }
            viewPort.Invalidate();
        }
        /// <summary>
        /// Прихващане на преместването на мишката.
        /// Ако сме в режм на "влачене", то избрания елемент се транслира.
        /// </summary>
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dialogProcessor.CurrentPoint = e.Location;
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.CurrentShape != null)
                {
                    statusBar.Items[0].Text = "Последно действие: Промяна на размер";
                    dialogProcessor.ChangeSize(e.Location);
                }
                else if (dialogProcessor.Selection != null)
                {
                    statusBar.Items[0].Text = "Последно действие: Влачене";
                    dialogProcessor.TranslateTo(e.Location);
                }
            }
            if (dialogProcessor.DragSelectOn2)
            {
                //dialogProcessor.DragSelectDraw(e.Location);
                //DrawRectangle(new Pen(Color.Black), Rectangle.X, Rectangle.Y, 8, 8);
            }
            viewPort.Invalidate();
        }
        /// <summary>
        /// Прихващане на отпускането на бутона на мишката.
        /// Излизаме от режим "влачене".
        /// </summary>
        void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dialogProcessor.IsDragging = false;
            dialogProcessor.CurrentShape = null;
            if (dialogProcessor.ContainsBorder(e.Location) == null)
            {
                dialogProcessor.DragSelectEnd();
            }
            viewPort.Invalidate();
        }

        private void DrawEllipseSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomEllipse(borderWidthTrackBar.Value);
            ShapeNameComboBoxPanel.Items.Add("Ellipse " + dialogProcessor.ShapeNumber);
            ShapeNameComboBoxPanel.SelectedIndex = ShapeNameComboBoxPanel.FindStringExact("Ellipse " + dialogProcessor.ShapeNumber);
            statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

            viewPort.Invalidate();
        }

        private void ColorDialogBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color pickerColor = colorDialog1.Color;
                if (dialogProcessor.Selection.Count > 0)
                {
                    foreach (Shape shp in dialogProcessor.Selection)
                    {
                        shp.FillColor = pickerColor;

                        if (shp.GradientActive == false)
                        {
                            shp.GradientColor = pickerColor;
                        }
                    }
                }
                statusBar.Items[0].Text = "Последно действие: Оцветяване на фигура";
                viewPort.Invalidate();
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();

            if (dialogProcessor.Selection.Count > 0)
            {
                foreach (Shape shp in dialogProcessor.Selection)
                {
                    shp.FillColorOpacity = trackBar1.Value;
                }
                statusBar.Items[0].Text = "Последно действие: Промяна на прозрачност";
                viewPort.Invalidate();
            }
        }

        private void GradientColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color pickerColor = colorDialog1.Color;
                if (dialogProcessor.Selection.Count > 0)
                {
                    foreach (Shape shp in dialogProcessor.Selection)
                    {
                        shp.GradientActive = true;
                        shp.GradientColor = pickerColor;
                    }
                }
                statusBar.Items[0].Text = "Последно действие: Оцветяване на градиент";
                viewPort.Invalidate();
            }
        }

        private void Switch_Gradient_Click(object sender, EventArgs e)
        {
            foreach (Shape shp in dialogProcessor.Selection)
            {
                shp.GradientActive = false;
            }
            statusBar.Items[0].Text = "Последно действие: Премахване на градиент";
            viewPort.Invalidate();
        }


        private void pickUpSpeedButton_Click(object sender, EventArgs e)
        {
            drawPolygonSpeedButton.Checked = false;
            DrawLineBtn.Checked = false;
            statusBar.Items[0].Text = "Последно действие: Оцветяване на фигура";
        }

        private void rotationBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.RotateAt(90);
            int temp = trackBar2.Value + 90;
            if (temp >= 360) temp -= 360;
            trackBar2.Value = temp;
            statusBar.Items[0].Text = "Последно действие: Завъртане на фигура";
            viewPort.Invalidate();
        }

        private void GroupBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.GroupSelected();
            statusBar.Items[0].Text = "Последно действие: Групиране на фигури";
            viewPort.Invalidate();
        }

        private void DrawStarSpeedBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomStar(borderWidthTrackBar.Value);
            ShapeNameComboBoxPanel.Items.Add("Star " + dialogProcessor.ShapeNumber);
            ShapeNameComboBoxPanel.SelectedIndex = ShapeNameComboBoxPanel.FindStringExact("Star " + dialogProcessor.ShapeNumber);
            statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";

            viewPort.Invalidate();
        }

        private void drawPolygonSpeedButton_Click(object sender, EventArgs e)
        {
            pickUpSpeedButton.Checked = false;
            DrawLineBtn.Checked = false;
            statusBar.Items[0].Text = "Последно действие: Рисуване на многоъгълник";
        }

        private void DrawLineSpeedBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomLine(borderWidthTrackBar.Value);
            ShapeNameComboBoxPanel.Items.Add("Line " + dialogProcessor.ShapeNumber);
            ShapeNameComboBoxPanel.SelectedIndex = ShapeNameComboBoxPanel.FindStringExact("Line " + dialogProcessor.ShapeNumber);
            statusBar.Items[0].Text = "Последно действие: Рисуване на линия";

            viewPort.Invalidate();
        }

        private void placeOnTopBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.PlaceOnTop();
            statusBar.Items[0].Text = "Последно действие: Преместване на фигура над останалите";
            viewPort.Invalidate();
        }

        private void borderWidthTrackBar_ValueChanged(object sender, EventArgs e)
        {
            borderWidthLabel.Text = borderWidthTrackBar.Value.ToString();

            if (dialogProcessor.Selection.Count > 0)
            {
                foreach (Shape shp in dialogProcessor.Selection)
                {
                    shp.BorderWidth = borderWidthTrackBar.Value;
                }
                statusBar.Items[0].Text = "Последно действие: Промяна на дебелината на очертанията";
                viewPort.Invalidate();
            }
        }

        private void UngroupBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.UngroupSelected();
            statusBar.Items[0].Text = "Последно действие: Разгрупиране на групова фигура";
            viewPort.Invalidate();
        }

        private void BorderColorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                Color pickerColor = colorDialog3.Color;
                if (dialogProcessor.Selection.Count > 0)
                {
                    foreach (Shape shp in dialogProcessor.Selection)
                    {
                        shp.StrokeColor = pickerColor;
                    }
                }
                statusBar.Items[0].Text = "Последно действие: Оцветяване на очертания на фигура";
                viewPort.Invalidate();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SaveFile(saveFileDialog1.FileName);
                statusBar.Items[0].Text = "Последно действие: Запазване на файл";
            }           
        }

        private void LoadFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.LoadFile(openFileDialog1.FileName   );
                LayerComboBoxPanel.Items.Clear();
                MultiLayerComboBoxPanel.Items.Clear();
                foreach (Layer layer in dialogProcessor.Layers)
                {
                    LayerComboBoxPanel.Items.Add(layer.Name);
                    MultiLayerComboBoxPanel.Items.Add(layer.Name);
                }
                LayerComboBoxPanel.SelectedIndex = LayerComboBoxPanel.FindStringExact("Base Layer");
                MultiLayerComboBoxPanel.SelectedIndex = MultiLayerComboBoxPanel.FindStringExact("Base Layer");
                statusBar.Items[0].Text = "Последно действие: Отваряне на файл";
            }          
            viewPort.Invalidate();
        }

        private void MassSelectBtn_Click(object sender, EventArgs e)
        {
            dialogProcessor.Selection.Clear();
            foreach (Shape shape in dialogProcessor.ShapeList)
            {
                dialogProcessor.Selection.Add(shape);
            }

            foreach (Shape shape in dialogProcessor.Selection) shape.IsSelected = true;
            statusBar.Items[0].Text = "Последно действие: Селектиране на всички фигури";
            viewPort.Update();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Последно действие: Копиране на фигура";
            dialogProcessor.SaveShape();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.Paste();
            statusBar.Items[0].Text = "Последно действие: Поставяне на копирана фигура";
            viewPort.Invalidate();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.ShapeList.Remove(dialogProcessor.NotSavedShape);
            dialogProcessor.Selection.Remove(dialogProcessor.NotSavedShape);
            foreach (Layer layer in dialogProcessor.CurrentLayers)
            {
                layer.Shapes.Remove(dialogProcessor.NotSavedShape);
            }
            statusBar.Items[0].Text = "Последно действие: Изтриване на фигура";
            viewPort.Invalidate(true);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            RotationLabel.Text = trackBar2.Value.ToString();
            dialogProcessor.SetRotate(trackBar2.Value);
            statusBar.Items[0].Text = "Последно действие: Завъртане на фигура";
            viewPort.Invalidate();
        }

        private void DrawLineBtn_Click(object sender, EventArgs e)
        {
            pickUpSpeedButton.Checked = false;
            drawPolygonSpeedButton.Checked = false;
            statusBar.Items[0].Text = "Последно действие: Рисуване на линия";
        }

        private void deleteLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.CurrentLayer.Name != "Base Layer")
            {
                foreach (Shape shape in dialogProcessor.CurrentLayer.Shapes)
                {
                    dialogProcessor.Selection.Remove(shape);
                    dialogProcessor.ShapeList.Remove(shape);
                }
                dialogProcessor.Layers.Remove(dialogProcessor.CurrentLayer);
                dialogProcessor.CurrentLayers.RemoveAt(0);
                dialogProcessor.CurrentLayers.RemoveAt(0);

                MultiLayerComboBoxPanel.Items.Remove(LayerComboBoxPanel.SelectedItem);
                LayerComboBoxPanel.Items.Remove(LayerComboBoxPanel.SelectedItem);
                if (dialogProcessor.CurrentLayers.Count > 0)
                {
                    dialogProcessor.CurrentLayer = dialogProcessor.CurrentLayers[0];
                    LayerComboBoxPanel.SelectedIndex = LayerComboBoxPanel.FindStringExact(dialogProcessor.CurrentLayer.Name);
                }
                else
                {
                    dialogProcessor.CurrentLayer = dialogProcessor.Layers[0];
                    LayerComboBoxPanel.SelectedIndex = LayerComboBoxPanel.FindStringExact("Base Layer");
                    dialogProcessor.ShapeList = dialogProcessor.CurrentLayer.Shapes;
                }
                statusBar.Items[0].Text = "Последно действие: Изтриване на слой";
            }
            viewPort.Invalidate();
        }

        private void PreciseRotationBtnPanel_Click(object sender, EventArgs e)
        {
            if (RotateTextBoxPanel.Text.Length > 0)
            {
                dialogProcessor.RotateAt(int.Parse(RotateTextBoxPanel.Text));
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Delete))
            {
                foreach (Shape shape in dialogProcessor.Selection)
                {
                    dialogProcessor.ShapeList.Remove(shape);
                    foreach (Layer layer in dialogProcessor.CurrentLayers) layer.Shapes.Remove(shape);
                }
                dialogProcessor.Selection.Clear();
                
                statusBar.Items[0].Text = "Последно действие: Изтриване на фигура/и";
                viewPort.Invalidate(true);
                return true;
            }
            if (keyData == (Keys.Control | Keys.A) && pickUpSpeedButton.Checked)
            {
                dialogProcessor.Selection.Clear();
                foreach (Shape shape in dialogProcessor.ShapeList)
                {
                    dialogProcessor.Selection.Add(shape);
                }

                foreach (Shape shape in dialogProcessor.Selection) shape.IsSelected = true;
                statusBar.Items[0].Text = "Последно действие: Селектиране на всички фигури";
                viewPort.Update();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SaveFile(saveFileDialog1.FileName);
                statusBar.Items[0].Text = "Последно действие: Запазване на файл";
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.LoadFile(openFileDialog1.FileName);
                LayerComboBoxPanel.Items.Clear();
                MultiLayerComboBoxPanel.Items.Clear();
                foreach (Layer layer in dialogProcessor.Layers)
                {
                    LayerComboBoxPanel.Items.Add(layer.Name);
                    MultiLayerComboBoxPanel.Items.Add(layer.Name);
                }
                LayerComboBoxPanel.SelectedIndex = LayerComboBoxPanel.FindStringExact("Base Layer");
                MultiLayerComboBoxPanel.SelectedIndex = MultiLayerComboBoxPanel.FindStringExact("Base Layer");
                statusBar.Items[0].Text = "Последно действие: Отваряне на файл";
            }
            viewPort.Invalidate();
        }

        private void AddLayerBtnPanel_Click(object sender, EventArgs e)
        {
            if (AddLayerTextBoxPanel.Text.Length > 0)
            {
                foreach (Layer layerCh in dialogProcessor.Layers) if (layerCh.Name == AddLayerTextBoxPanel.Text) return;

                Layer layer = new Layer(AddLayerTextBoxPanel.Text);
                dialogProcessor.Layers.Add(layer);
                dialogProcessor.CurrentLayer = layer;
                dialogProcessor.ShapeList = layer.Shapes;
                foreach (Shape shape in dialogProcessor.Selection)
                {
                    shape.IsSelected = false;
                }
                dialogProcessor.Selection = new List<Shape>();
                LayerComboBoxPanel.Items.Add(layer.Name);
                MultiLayerComboBoxPanel.Items.Add(layer.Name);
                LayerComboBoxPanel.SelectedIndex = LayerComboBoxPanel.FindStringExact(layer.Name);
                MultiLayerComboBoxPanel.SelectedIndex = MultiLayerComboBoxPanel.FindStringExact(layer.Name);
                AddLayerTextBoxPanel.Text = "";

                statusBar.Items[0].Text = "Последно действие: Нов слой";
            }
            viewPort.Invalidate();
        }

        private void LayerComboBoxPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Layer layer in dialogProcessor.Layers)
            {
                if (LayerComboBoxPanel.SelectedItem.ToString() == layer.Name)
                {
                    dialogProcessor.CurrentLayer = layer;
                    dialogProcessor.CurrentLayers = new List<Layer> { layer };
                    dialogProcessor.ShapeList = layer.Shapes;
                    foreach (Shape shape in dialogProcessor.Selection)
                    {
                        shape.IsSelected = false;
                    }
                    dialogProcessor.Selection = new List<Shape>();
                    MultiLayerComboBoxPanel.SelectedIndex = MultiLayerComboBoxPanel.FindStringExact(layer.Name);
                    ShapeNameComboBoxPanel.Items.Clear();
                    ShapeNameComboBoxPanel.Text = "";
                    foreach (Shape shape in layer.Shapes)
                    {
                        ShapeNameComboBoxPanel.Items.Add(shape.Name);
                    }
                    break;
                }
            }
            statusBar.Items[0].Text = "Последно действие: Сменяне на слой";
            viewPort.Invalidate();
        }

        private void MultiLayerComboBoxPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Layer layer in dialogProcessor.Layers)
            {
                if (MultiLayerComboBoxPanel.SelectedItem.ToString() == layer.Name)
                {
                    if (!dialogProcessor.CurrentLayers.Contains(layer))
                    {
                        dialogProcessor.CurrentLayers.Add(layer);
                        //dialogProcessor.ShapeList.Add(layer.Shapes);
                        dialogProcessor.ShapeList = Enumerable.Concat(dialogProcessor.ShapeList, layer.Shapes).ToList();
                        foreach (Shape shape in layer.Shapes)
                        {
                            ShapeNameComboBoxPanel.Items.Add(shape.Name);
                        }
                        foreach (Shape shape in dialogProcessor.Selection)
                        {
                            shape.IsSelected = false;
                        }
                        dialogProcessor.Selection = new List<Shape>();
                        break;
                    }
                }
            }
            statusBar.Items[0].Text = "Последно действие: Добавяне на слой";
            viewPort.Invalidate();
        }

        private void RenameShapeBtnPanel_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in dialogProcessor.ShapeList)
            {
                if (shape.Name == ShapeNameComboBoxPanel.SelectedItem.ToString())
                {
                    ShapeNameComboBoxPanel.Items.Remove(shape.Name);
                    shape.Name = RenameShapeTextBoxPanel.Text;
                    ShapeNameComboBoxPanel.Items.Add(shape.Name);
                    ShapeNameComboBoxPanel.SelectedIndex = ShapeNameComboBoxPanel.FindStringExact(shape.Name);
                    RenameShapeTextBoxPanel.Text = "";
                }
            }
            statusBar.Items[0].Text = "Последно действие: Преименуване на фигура";
        }

        private void ShapeNameComboBoxPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Shape shape in dialogProcessor.Selection) shape.IsSelected = false;
            dialogProcessor.Selection.Clear();
            foreach (Shape shape in dialogProcessor.ShapeList)
            {
                if (shape.Name == ShapeNameComboBoxPanel.SelectedItem.ToString())
                {
                    shape.IsSelected = true;
                    dialogProcessor.Selection.Add(shape);

                    trackBar1.Value = shape.FillColorOpacity;
                    borderWidthTrackBar.Value = shape.BorderWidth;
                    trackBar2.Value = (int)shape.Angle;
                    break;
                }
                statusBar.Items[0].Text = "Последно действие: Селектиране на фигура";
            }
            viewPort.Invalidate();
        }

        private void ColorButtonPanel_Click(object sender, EventArgs e)
        {
            if (ColorTextBoxPanel.Text.Length > 0)
            {
                Color color = Color.FromName(ColorTextBoxPanel.Text);
                foreach (Shape shape in dialogProcessor.Selection)
                {
                    shape.FillColor = color;
                }
            }
        }
    }
}

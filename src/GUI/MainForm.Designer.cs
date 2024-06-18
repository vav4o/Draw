namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawEllipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.DrawStarSpeedBtn = new System.Windows.Forms.ToolStripButton();
            this.DrawLineSpeedBtn = new System.Windows.Forms.ToolStripButton();
            this.drawPolygonSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.DrawLineBtn = new System.Windows.Forms.ToolStripButton();
            this.ColorDialogBtn = new System.Windows.Forms.ToolStripButton();
            this.GradientColorBtn = new System.Windows.Forms.ToolStripButton();
            this.Switch_Gradient = new System.Windows.Forms.ToolStripButton();
            this.rotationBtn = new System.Windows.Forms.ToolStripButton();
            this.GroupBtn = new System.Windows.Forms.ToolStripButton();
            this.UngroupBtn = new System.Windows.Forms.ToolStripButton();
            this.placeOnTopBtn = new System.Windows.Forms.ToolStripButton();
            this.BorderColorBtn = new System.Windows.Forms.ToolStripButton();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.LoadFileBtn = new System.Windows.Forms.ToolStripButton();
            this.MassSelectBtn = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderWidthTrackBar = new System.Windows.Forms.TrackBar();
            this.borderWidthLabel = new System.Windows.Forms.Label();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.RotationLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.RotateTextBoxPanel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PreciseRotationBtnPanel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ColorTextBoxPanel = new System.Windows.Forms.TextBox();
            this.ColorButtonPanel = new System.Windows.Forms.Button();
            this.ShapeNameComboBoxPanel = new System.Windows.Forms.ComboBox();
            this.RenameShapeTextBoxPanel = new System.Windows.Forms.TextBox();
            this.RenameShapeBtnPanel = new System.Windows.Forms.Button();
            this.AddLayerTextBoxPanel = new System.Windows.Forms.TextBox();
            this.LayerComboBoxPanel = new System.Windows.Forms.ComboBox();
            this.AddLayerBtnPanel = new System.Windows.Forms.Button();
            this.MultiLayerComboBoxPanel = new System.Windows.Forms.ComboBox();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.optionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1623, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 925);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(1623, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // speedMenu
            // 
            this.speedMenu.AutoSize = false;
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleSpeedButton,
            this.pickUpSpeedButton,
            this.drawEllipseSpeedButton,
            this.DrawStarSpeedBtn,
            this.DrawLineSpeedBtn,
            this.drawPolygonSpeedButton,
            this.DrawLineBtn,
            this.ColorDialogBtn,
            this.GradientColorBtn,
            this.Switch_Gradient,
            this.rotationBtn,
            this.GroupBtn,
            this.UngroupBtn,
            this.placeOnTopBtn,
            this.BorderColorBtn,
            this.SaveBtn,
            this.LoadFileBtn,
            this.MassSelectBtn});
            this.speedMenu.Location = new System.Drawing.Point(0, 28);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(1623, 37);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(29, 34);
            this.drawRectangleSpeedButton.Text = "Draw Random Rectangle";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(29, 34);
            this.pickUpSpeedButton.Text = "Multi Select";
            this.pickUpSpeedButton.Click += new System.EventHandler(this.pickUpSpeedButton_Click);
            // 
            // drawEllipseSpeedButton
            // 
            this.drawEllipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEllipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEllipseSpeedButton.Image")));
            this.drawEllipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawEllipseSpeedButton.Name = "drawEllipseSpeedButton";
            this.drawEllipseSpeedButton.Size = new System.Drawing.Size(29, 34);
            this.drawEllipseSpeedButton.Text = "Draw Random Ellipse";
            this.drawEllipseSpeedButton.Click += new System.EventHandler(this.DrawEllipseSpeedButtonClick);
            // 
            // DrawStarSpeedBtn
            // 
            this.DrawStarSpeedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawStarSpeedBtn.Image = ((System.Drawing.Image)(resources.GetObject("DrawStarSpeedBtn.Image")));
            this.DrawStarSpeedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawStarSpeedBtn.Name = "DrawStarSpeedBtn";
            this.DrawStarSpeedBtn.Size = new System.Drawing.Size(29, 34);
            this.DrawStarSpeedBtn.Text = "Draw Random Star";
            this.DrawStarSpeedBtn.Click += new System.EventHandler(this.DrawStarSpeedBtn_Click);
            // 
            // DrawLineSpeedBtn
            // 
            this.DrawLineSpeedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawLineSpeedBtn.Image = ((System.Drawing.Image)(resources.GetObject("DrawLineSpeedBtn.Image")));
            this.DrawLineSpeedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawLineSpeedBtn.Name = "DrawLineSpeedBtn";
            this.DrawLineSpeedBtn.Size = new System.Drawing.Size(29, 34);
            this.DrawLineSpeedBtn.Text = "Draw Random Line";
            this.DrawLineSpeedBtn.Click += new System.EventHandler(this.DrawLineSpeedBtn_Click);
            // 
            // drawPolygonSpeedButton
            // 
            this.drawPolygonSpeedButton.CheckOnClick = true;
            this.drawPolygonSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawPolygonSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawPolygonSpeedButton.Image")));
            this.drawPolygonSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawPolygonSpeedButton.Name = "drawPolygonSpeedButton";
            this.drawPolygonSpeedButton.Size = new System.Drawing.Size(29, 34);
            this.drawPolygonSpeedButton.Text = "Draw Polygon";
            this.drawPolygonSpeedButton.Click += new System.EventHandler(this.drawPolygonSpeedButton_Click);
            // 
            // DrawLineBtn
            // 
            this.DrawLineBtn.CheckOnClick = true;
            this.DrawLineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawLineBtn.Image = ((System.Drawing.Image)(resources.GetObject("DrawLineBtn.Image")));
            this.DrawLineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawLineBtn.Name = "DrawLineBtn";
            this.DrawLineBtn.Size = new System.Drawing.Size(29, 34);
            this.DrawLineBtn.Text = "Draw Line";
            this.DrawLineBtn.Click += new System.EventHandler(this.DrawLineBtn_Click);
            // 
            // ColorDialogBtn
            // 
            this.ColorDialogBtn.AutoSize = false;
            this.ColorDialogBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ColorDialogBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColorDialogBtn.Image = ((System.Drawing.Image)(resources.GetObject("ColorDialogBtn.Image")));
            this.ColorDialogBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColorDialogBtn.Name = "ColorDialogBtn";
            this.ColorDialogBtn.Padding = new System.Windows.Forms.Padding(10);
            this.ColorDialogBtn.Size = new System.Drawing.Size(29, 27);
            this.ColorDialogBtn.Text = "Shape Color";
            this.ColorDialogBtn.Click += new System.EventHandler(this.ColorDialogBtn_Click);
            // 
            // GradientColorBtn
            // 
            this.GradientColorBtn.AutoSize = false;
            this.GradientColorBtn.BackColor = System.Drawing.SystemColors.Control;
            this.GradientColorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GradientColorBtn.Image = ((System.Drawing.Image)(resources.GetObject("GradientColorBtn.Image")));
            this.GradientColorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GradientColorBtn.Name = "GradientColorBtn";
            this.GradientColorBtn.Size = new System.Drawing.Size(29, 27);
            this.GradientColorBtn.Text = "Gradient Color";
            this.GradientColorBtn.Click += new System.EventHandler(this.GradientColorBtn_Click);
            // 
            // Switch_Gradient
            // 
            this.Switch_Gradient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Switch_Gradient.Image = ((System.Drawing.Image)(resources.GetObject("Switch_Gradient.Image")));
            this.Switch_Gradient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Switch_Gradient.Name = "Switch_Gradient";
            this.Switch_Gradient.Size = new System.Drawing.Size(29, 34);
            this.Switch_Gradient.Text = "Remove Gradient";
            this.Switch_Gradient.Click += new System.EventHandler(this.Switch_Gradient_Click);
            // 
            // rotationBtn
            // 
            this.rotationBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotationBtn.Image = ((System.Drawing.Image)(resources.GetObject("rotationBtn.Image")));
            this.rotationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotationBtn.Name = "rotationBtn";
            this.rotationBtn.Size = new System.Drawing.Size(29, 34);
            this.rotationBtn.Text = "Rotate 90° to the right";
            this.rotationBtn.Click += new System.EventHandler(this.rotationBtn_Click);
            // 
            // GroupBtn
            // 
            this.GroupBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GroupBtn.Image = ((System.Drawing.Image)(resources.GetObject("GroupBtn.Image")));
            this.GroupBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GroupBtn.Name = "GroupBtn";
            this.GroupBtn.Size = new System.Drawing.Size(29, 34);
            this.GroupBtn.Text = "Group Shapes";
            this.GroupBtn.Click += new System.EventHandler(this.GroupBtn_Click);
            // 
            // UngroupBtn
            // 
            this.UngroupBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UngroupBtn.Image = ((System.Drawing.Image)(resources.GetObject("UngroupBtn.Image")));
            this.UngroupBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UngroupBtn.Name = "UngroupBtn";
            this.UngroupBtn.Size = new System.Drawing.Size(29, 34);
            this.UngroupBtn.Text = "Ungroup";
            this.UngroupBtn.Click += new System.EventHandler(this.UngroupBtn_Click);
            // 
            // placeOnTopBtn
            // 
            this.placeOnTopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.placeOnTopBtn.Image = ((System.Drawing.Image)(resources.GetObject("placeOnTopBtn.Image")));
            this.placeOnTopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.placeOnTopBtn.Name = "placeOnTopBtn";
            this.placeOnTopBtn.Size = new System.Drawing.Size(29, 34);
            this.placeOnTopBtn.Text = "Place on top";
            this.placeOnTopBtn.Click += new System.EventHandler(this.placeOnTopBtn_Click);
            // 
            // BorderColorBtn
            // 
            this.BorderColorBtn.AutoSize = false;
            this.BorderColorBtn.BackColor = System.Drawing.SystemColors.Control;
            this.BorderColorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BorderColorBtn.Image = ((System.Drawing.Image)(resources.GetObject("BorderColorBtn.Image")));
            this.BorderColorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BorderColorBtn.Name = "BorderColorBtn";
            this.BorderColorBtn.Size = new System.Drawing.Size(29, 27);
            this.BorderColorBtn.Text = "Border Color";
            this.BorderColorBtn.Click += new System.EventHandler(this.BorderColorBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(29, 34);
            this.SaveBtn.Text = "Save";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // LoadFileBtn
            // 
            this.LoadFileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("LoadFileBtn.Image")));
            this.LoadFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadFileBtn.Name = "LoadFileBtn";
            this.LoadFileBtn.Size = new System.Drawing.Size(29, 34);
            this.LoadFileBtn.Text = "Load File";
            this.LoadFileBtn.Click += new System.EventHandler(this.LoadFileBtn_Click);
            // 
            // MassSelectBtn
            // 
            this.MassSelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MassSelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("MassSelectBtn.Image")));
            this.MassSelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MassSelectBtn.Name = "MassSelectBtn";
            this.MassSelectBtn.Size = new System.Drawing.Size(29, 34);
            this.MassSelectBtn.Text = "Select All";
            this.MassSelectBtn.Click += new System.EventHandler(this.MassSelectBtn_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(41, 98);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 100;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "100";
            // 
            // optionsMenu
            // 
            this.optionsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.deleteLayerToolStripMenuItem});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(214, 100);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.CopyToolStripMenuItem.Text = "Copy";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.PasteToolStripMenuItem.Text = "Paste";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // deleteLayerToolStripMenuItem
            // 
            this.deleteLayerToolStripMenuItem.Name = "deleteLayerToolStripMenuItem";
            this.deleteLayerToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.deleteLayerToolStripMenuItem.Text = "Delete Current Layer";
            this.deleteLayerToolStripMenuItem.Click += new System.EventHandler(this.deleteLayerToolStripMenuItem_Click);
            // 
            // borderWidthTrackBar
            // 
            this.borderWidthTrackBar.Location = new System.Drawing.Point(235, 98);
            this.borderWidthTrackBar.Minimum = 1;
            this.borderWidthTrackBar.Name = "borderWidthTrackBar";
            this.borderWidthTrackBar.Size = new System.Drawing.Size(109, 56);
            this.borderWidthTrackBar.TabIndex = 8;
            this.borderWidthTrackBar.Value = 1;
            this.borderWidthTrackBar.ValueChanged += new System.EventHandler(this.borderWidthTrackBar_ValueChanged);
            // 
            // borderWidthLabel
            // 
            this.borderWidthLabel.AutoSize = true;
            this.borderWidthLabel.Location = new System.Drawing.Point(286, 157);
            this.borderWidthLabel.Name = "borderWidthLabel";
            this.borderWidthLabel.Size = new System.Drawing.Size(14, 16);
            this.borderWidthLabel.TabIndex = 9;
            this.borderWidthLabel.Text = "1";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(3, 301);
            this.trackBar2.Maximum = 360;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(360, 56);
            this.trackBar2.TabIndex = 10;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // RotationLabel
            // 
            this.RotationLabel.AutoSize = true;
            this.RotationLabel.Location = new System.Drawing.Point(180, 360);
            this.RotationLabel.Name = "RotationLabel";
            this.RotationLabel.Size = new System.Drawing.Size(14, 16);
            this.RotationLabel.TabIndex = 11;
            this.RotationLabel.Text = "0";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JSON format|*.json|Binary file|*.dat";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JSON format|*.json|Binary file|*.dat";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.RotateTextBoxPanel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PreciseRotationBtnPanel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ColorTextBoxPanel);
            this.panel1.Controls.Add(this.trackBar2);
            this.panel1.Controls.Add(this.ColorButtonPanel);
            this.panel1.Controls.Add(this.RotationLabel);
            this.panel1.Controls.Add(this.ShapeNameComboBoxPanel);
            this.panel1.Controls.Add(this.borderWidthLabel);
            this.panel1.Controls.Add(this.RenameShapeTextBoxPanel);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.RenameShapeBtnPanel);
            this.panel1.Controls.Add(this.borderWidthTrackBar);
            this.panel1.Controls.Add(this.AddLayerTextBoxPanel);
            this.panel1.Controls.Add(this.LayerComboBoxPanel);
            this.panel1.Controls.Add(this.AddLayerBtnPanel);
            this.panel1.Controls.Add(this.MultiLayerComboBoxPanel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1247, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 860);
            this.panel1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Rotation";
            // 
            // RotateTextBoxPanel
            // 
            this.RotateTextBoxPanel.Location = new System.Drawing.Point(223, 432);
            this.RotateTextBoxPanel.Name = "RotateTextBoxPanel";
            this.RotateTextBoxPanel.Size = new System.Drawing.Size(121, 22);
            this.RotateTextBoxPanel.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Border Width";
            // 
            // PreciseRotationBtnPanel
            // 
            this.PreciseRotationBtnPanel.Location = new System.Drawing.Point(41, 421);
            this.PreciseRotationBtnPanel.Name = "PreciseRotationBtnPanel";
            this.PreciseRotationBtnPanel.Size = new System.Drawing.Size(120, 45);
            this.PreciseRotationBtnPanel.TabIndex = 22;
            this.PreciseRotationBtnPanel.Text = "Rotate by set degrees";
            this.PreciseRotationBtnPanel.UseVisualStyleBackColor = true;
            this.PreciseRotationBtnPanel.Click += new System.EventHandler(this.PreciseRotationBtnPanel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Opacity";
            // 
            // ColorTextBoxPanel
            // 
            this.ColorTextBoxPanel.Location = new System.Drawing.Point(223, 522);
            this.ColorTextBoxPanel.Name = "ColorTextBoxPanel";
            this.ColorTextBoxPanel.Size = new System.Drawing.Size(121, 22);
            this.ColorTextBoxPanel.TabIndex = 21;
            // 
            // ColorButtonPanel
            // 
            this.ColorButtonPanel.Location = new System.Drawing.Point(41, 510);
            this.ColorButtonPanel.Name = "ColorButtonPanel";
            this.ColorButtonPanel.Size = new System.Drawing.Size(121, 46);
            this.ColorButtonPanel.TabIndex = 20;
            this.ColorButtonPanel.Text = "Set Color from Text";
            this.ColorButtonPanel.UseVisualStyleBackColor = true;
            this.ColorButtonPanel.Click += new System.EventHandler(this.ColorButtonPanel_Click);
            // 
            // ShapeNameComboBoxPanel
            // 
            this.ShapeNameComboBoxPanel.FormattingEnabled = true;
            this.ShapeNameComboBoxPanel.Location = new System.Drawing.Point(128, 671);
            this.ShapeNameComboBoxPanel.Name = "ShapeNameComboBoxPanel";
            this.ShapeNameComboBoxPanel.Size = new System.Drawing.Size(144, 24);
            this.ShapeNameComboBoxPanel.TabIndex = 19;
            this.ShapeNameComboBoxPanel.SelectedIndexChanged += new System.EventHandler(this.ShapeNameComboBoxPanel_SelectedIndexChanged);
            // 
            // RenameShapeTextBoxPanel
            // 
            this.RenameShapeTextBoxPanel.Location = new System.Drawing.Point(223, 616);
            this.RenameShapeTextBoxPanel.Name = "RenameShapeTextBoxPanel";
            this.RenameShapeTextBoxPanel.Size = new System.Drawing.Size(121, 22);
            this.RenameShapeTextBoxPanel.TabIndex = 18;
            // 
            // RenameShapeBtnPanel
            // 
            this.RenameShapeBtnPanel.Location = new System.Drawing.Point(41, 615);
            this.RenameShapeBtnPanel.Name = "RenameShapeBtnPanel";
            this.RenameShapeBtnPanel.Size = new System.Drawing.Size(121, 23);
            this.RenameShapeBtnPanel.TabIndex = 17;
            this.RenameShapeBtnPanel.Text = "Rename Shape";
            this.RenameShapeBtnPanel.UseVisualStyleBackColor = true;
            this.RenameShapeBtnPanel.Click += new System.EventHandler(this.RenameShapeBtnPanel_Click);
            // 
            // AddLayerTextBoxPanel
            // 
            this.AddLayerTextBoxPanel.Location = new System.Drawing.Point(223, 750);
            this.AddLayerTextBoxPanel.Name = "AddLayerTextBoxPanel";
            this.AddLayerTextBoxPanel.Size = new System.Drawing.Size(121, 22);
            this.AddLayerTextBoxPanel.TabIndex = 14;
            // 
            // LayerComboBoxPanel
            // 
            this.LayerComboBoxPanel.FormattingEnabled = true;
            this.LayerComboBoxPanel.Location = new System.Drawing.Point(41, 804);
            this.LayerComboBoxPanel.Name = "LayerComboBoxPanel";
            this.LayerComboBoxPanel.Size = new System.Drawing.Size(121, 24);
            this.LayerComboBoxPanel.TabIndex = 15;
            this.LayerComboBoxPanel.SelectedIndexChanged += new System.EventHandler(this.LayerComboBoxPanel_SelectedIndexChanged);
            // 
            // AddLayerBtnPanel
            // 
            this.AddLayerBtnPanel.Location = new System.Drawing.Point(41, 750);
            this.AddLayerBtnPanel.Name = "AddLayerBtnPanel";
            this.AddLayerBtnPanel.Size = new System.Drawing.Size(121, 23);
            this.AddLayerBtnPanel.TabIndex = 13;
            this.AddLayerBtnPanel.Text = "Add Layer";
            this.AddLayerBtnPanel.UseVisualStyleBackColor = true;
            this.AddLayerBtnPanel.Click += new System.EventHandler(this.AddLayerBtnPanel_Click);
            // 
            // MultiLayerComboBoxPanel
            // 
            this.MultiLayerComboBoxPanel.FormattingEnabled = true;
            this.MultiLayerComboBoxPanel.Location = new System.Drawing.Point(223, 804);
            this.MultiLayerComboBoxPanel.Name = "MultiLayerComboBoxPanel";
            this.MultiLayerComboBoxPanel.Size = new System.Drawing.Size(121, 24);
            this.MultiLayerComboBoxPanel.TabIndex = 16;
            this.MultiLayerComboBoxPanel.SelectedIndexChanged += new System.EventHandler(this.MultiLayerComboBoxPanel_SelectedIndexChanged);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 65);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1623, 860);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1623, 947);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.optionsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton drawEllipseSpeedButton;
        private System.Windows.Forms.ToolStripButton ColorDialogBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton GradientColorBtn;
        private System.Windows.Forms.ToolStripButton Switch_Gradient;
        private System.Windows.Forms.ToolStripButton rotationBtn;
        private System.Windows.Forms.ToolStripButton GroupBtn;
        private System.Windows.Forms.ToolStripButton DrawStarSpeedBtn;
        private System.Windows.Forms.ToolStripButton drawPolygonSpeedButton;
        private System.Windows.Forms.ToolStripButton DrawLineSpeedBtn;
        private System.Windows.Forms.ToolStripButton placeOnTopBtn;
        private System.Windows.Forms.ContextMenuStrip optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.TrackBar borderWidthTrackBar;
        private System.Windows.Forms.Label borderWidthLabel;
        private System.Windows.Forms.ToolStripButton UngroupBtn;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.ToolStripButton BorderColorBtn;
        private System.Windows.Forms.ToolStripButton SaveBtn;
        private System.Windows.Forms.ToolStripButton LoadFileBtn;
        private System.Windows.Forms.ToolStripButton MassSelectBtn;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label RotationLabel;
        private System.Windows.Forms.ToolStripButton DrawLineBtn;
        private System.Windows.Forms.ToolStripMenuItem deleteLayerToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddLayerBtnPanel;
        private System.Windows.Forms.TextBox AddLayerTextBoxPanel;
        private System.Windows.Forms.ComboBox LayerComboBoxPanel;
        private System.Windows.Forms.ComboBox MultiLayerComboBoxPanel;
        private System.Windows.Forms.Button RenameShapeBtnPanel;
        private System.Windows.Forms.TextBox RenameShapeTextBoxPanel;
        private System.Windows.Forms.ComboBox ShapeNameComboBoxPanel;
        private System.Windows.Forms.Button ColorButtonPanel;
        private System.Windows.Forms.TextBox ColorTextBoxPanel;
        private System.Windows.Forms.Button PreciseRotationBtnPanel;
        private System.Windows.Forms.TextBox RotateTextBoxPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

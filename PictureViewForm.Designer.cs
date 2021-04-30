namespace Image_Gallery
{
    partial class PictureViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SladeShow = new System.Windows.Forms.Button();
            this.P_V_F_pictureBox = new System.Windows.Forms.PictureBox();
            this.PanelButtonRight = new MetroFramework.Controls.MetroPanel();
            this.B_Right = new MetroFramework.Controls.MetroButton();
            this.PanelButtonLeft = new MetroFramework.Controls.MetroPanel();
            this.B_Left = new MetroFramework.Controls.MetroButton();
            this.PanelDown = new MetroFramework.Controls.MetroPanel();
            this.P_V_F_ListView = new System.Windows.Forms.ListView();
            this.P_V_F_imageList = new System.Windows.Forms.ImageList(this.components);
            this.B_Show_Panel = new MetroFramework.Controls.MetroButton();
            this.tim_Panel_Open = new System.Windows.Forms.Timer(this.components);
            this.tim_Panel_Close = new System.Windows.Forms.Timer(this.components);
            this.timerSlideShow = new System.Windows.Forms.Timer(this.components);
            this.metroPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P_V_F_pictureBox)).BeginInit();
            this.PanelButtonRight.SuspendLayout();
            this.PanelButtonLeft.SuspendLayout();
            this.PanelDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metroPanel1.Controls.Add(this.panel1);
            this.metroPanel1.Controls.Add(this.PanelButtonRight);
            this.metroPanel1.Controls.Add(this.PanelButtonLeft);
            this.metroPanel1.Controls.Add(this.PanelDown);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(760, 370);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SladeShow);
            this.panel1.Controls.Add(this.P_V_F_pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(42, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 300);
            this.panel1.TabIndex = 6;
            // 
            // SladeShow
            // 
            this.SladeShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SladeShow.Location = new System.Drawing.Point(0, 279);
            this.SladeShow.Name = "SladeShow";
            this.SladeShow.Size = new System.Drawing.Size(676, 21);
            this.SladeShow.TabIndex = 6;
            this.SladeShow.Text = "Play";
            this.SladeShow.UseVisualStyleBackColor = true;
            this.SladeShow.Click += new System.EventHandler(this.SladeShow_Click);
            // 
            // P_V_F_pictureBox
            // 
            this.P_V_F_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_V_F_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.P_V_F_pictureBox.Name = "P_V_F_pictureBox";
            this.P_V_F_pictureBox.Size = new System.Drawing.Size(676, 300);
            this.P_V_F_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.P_V_F_pictureBox.TabIndex = 5;
            this.P_V_F_pictureBox.TabStop = false;
            // 
            // PanelButtonRight
            // 
            this.PanelButtonRight.Controls.Add(this.B_Right);
            this.PanelButtonRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButtonRight.HorizontalScrollbarBarColor = true;
            this.PanelButtonRight.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelButtonRight.HorizontalScrollbarSize = 10;
            this.PanelButtonRight.Location = new System.Drawing.Point(718, 0);
            this.PanelButtonRight.Name = "PanelButtonRight";
            this.PanelButtonRight.Size = new System.Drawing.Size(42, 300);
            this.PanelButtonRight.TabIndex = 4;
            this.PanelButtonRight.VerticalScrollbarBarColor = true;
            this.PanelButtonRight.VerticalScrollbarHighlightOnWheel = false;
            this.PanelButtonRight.VerticalScrollbarSize = 10;
            // 
            // B_Right
            // 
            this.B_Right.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.B_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Right.ForeColor = System.Drawing.Color.DarkRed;
            this.B_Right.Location = new System.Drawing.Point(0, 0);
            this.B_Right.Name = "B_Right";
            this.B_Right.Size = new System.Drawing.Size(42, 300);
            this.B_Right.TabIndex = 2;
            this.B_Right.Text = " ";
            this.B_Right.UseSelectable = true;
            this.B_Right.Click += new System.EventHandler(this.B_Right_Click);
            this.B_Right.MouseLeave += new System.EventHandler(this.B_Right_MouseLeave);
            this.B_Right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.B_Right_MouseMove);
            // 
            // PanelButtonLeft
            // 
            this.PanelButtonLeft.Controls.Add(this.B_Left);
            this.PanelButtonLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelButtonLeft.HorizontalScrollbarBarColor = true;
            this.PanelButtonLeft.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelButtonLeft.HorizontalScrollbarSize = 10;
            this.PanelButtonLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelButtonLeft.Name = "PanelButtonLeft";
            this.PanelButtonLeft.Size = new System.Drawing.Size(42, 300);
            this.PanelButtonLeft.TabIndex = 3;
            this.PanelButtonLeft.VerticalScrollbarBarColor = true;
            this.PanelButtonLeft.VerticalScrollbarHighlightOnWheel = false;
            this.PanelButtonLeft.VerticalScrollbarSize = 10;
            this.PanelButtonLeft.MouseEnter += new System.EventHandler(this.PanelButtonLeft_MouseEnter);
            this.PanelButtonLeft.MouseLeave += new System.EventHandler(this.PanelButtonLeft_MouseLeave);
            // 
            // B_Left
            // 
            this.B_Left.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.B_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Left.ForeColor = System.Drawing.Color.DarkRed;
            this.B_Left.Location = new System.Drawing.Point(0, 0);
            this.B_Left.Name = "B_Left";
            this.B_Left.Size = new System.Drawing.Size(42, 300);
            this.B_Left.TabIndex = 2;
            this.B_Left.Text = " ";
            this.B_Left.UseSelectable = true;
            this.B_Left.Click += new System.EventHandler(this.B_Left_Click);
            this.B_Left.MouseLeave += new System.EventHandler(this.B_Left_MouseLeave);
            this.B_Left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.B_Left_MouseMove);
            // 
            // PanelDown
            // 
            this.PanelDown.Controls.Add(this.P_V_F_ListView);
            this.PanelDown.Controls.Add(this.B_Show_Panel);
            this.PanelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelDown.HorizontalScrollbarBarColor = true;
            this.PanelDown.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelDown.HorizontalScrollbarSize = 10;
            this.PanelDown.Location = new System.Drawing.Point(0, 300);
            this.PanelDown.Name = "PanelDown";
            this.PanelDown.Size = new System.Drawing.Size(760, 70);
            this.PanelDown.TabIndex = 2;
            this.PanelDown.VerticalScrollbarBarColor = true;
            this.PanelDown.VerticalScrollbarHighlightOnWheel = false;
            this.PanelDown.VerticalScrollbarSize = 10;
            // 
            // P_V_F_ListView
            // 
            this.P_V_F_ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_V_F_ListView.FullRowSelect = true;
            this.P_V_F_ListView.HideSelection = false;
            this.P_V_F_ListView.LargeImageList = this.P_V_F_imageList;
            this.P_V_F_ListView.Location = new System.Drawing.Point(0, 20);
            this.P_V_F_ListView.MultiSelect = false;
            this.P_V_F_ListView.Name = "P_V_F_ListView";
            this.P_V_F_ListView.Size = new System.Drawing.Size(760, 50);
            this.P_V_F_ListView.SmallImageList = this.P_V_F_imageList;
            this.P_V_F_ListView.StateImageList = this.P_V_F_imageList;
            this.P_V_F_ListView.TabIndex = 4;
            this.P_V_F_ListView.UseCompatibleStateImageBehavior = false;
            this.P_V_F_ListView.SelectedIndexChanged += new System.EventHandler(this.P_V_F_ListView_SelectedIndexChanged_1);
            // 
            // P_V_F_imageList
            // 
            this.P_V_F_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.P_V_F_imageList.ImageSize = new System.Drawing.Size(50, 50);
            this.P_V_F_imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // B_Show_Panel
            // 
            this.B_Show_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.B_Show_Panel.ForeColor = System.Drawing.Color.DarkRed;
            this.B_Show_Panel.Location = new System.Drawing.Point(0, 0);
            this.B_Show_Panel.Name = "B_Show_Panel";
            this.B_Show_Panel.Size = new System.Drawing.Size(760, 20);
            this.B_Show_Panel.Style = MetroFramework.MetroColorStyle.Orange;
            this.B_Show_Panel.TabIndex = 3;
            this.B_Show_Panel.Text = "^";
            this.B_Show_Panel.UseSelectable = true;
            this.B_Show_Panel.Click += new System.EventHandler(this.B_Show_Panel_Click);
            this.B_Show_Panel.MouseLeave += new System.EventHandler(this.B_Show_Panel_MouseLeave);
            this.B_Show_Panel.MouseHover += new System.EventHandler(this.B_Show_Panel_MouseHover);
            // 
            // tim_Panel_Open
            // 
            this.tim_Panel_Open.Interval = 22;
            this.tim_Panel_Open.Tick += new System.EventHandler(this.tim_Panel_Open_Tick);
            // 
            // tim_Panel_Close
            // 
            this.tim_Panel_Close.Interval = 22;
            this.tim_Panel_Close.Tick += new System.EventHandler(this.tim_Panel_Close_Tick);
            // 
            // timerSlideShow
            // 
            this.timerSlideShow.Interval = 1000;
            this.timerSlideShow.Tick += new System.EventHandler(this.timerSlideShow_Tick);
            // 
            // PictureViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroPanel1);
            this.Name = "PictureViewForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Просмотр изображений";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PictureViewForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.P_V_F_pictureBox)).EndInit();
            this.PanelButtonRight.ResumeLayout(false);
            this.PanelButtonLeft.ResumeLayout(false);
            this.PanelDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox P_V_F_pictureBox;
        private MetroFramework.Controls.MetroPanel PanelButtonRight;
        private MetroFramework.Controls.MetroPanel PanelButtonLeft;
        private MetroFramework.Controls.MetroPanel PanelDown;
        private System.Windows.Forms.ImageList P_V_F_imageList;
        private MetroFramework.Controls.MetroButton B_Right;
        private MetroFramework.Controls.MetroButton B_Left;
        private MetroFramework.Controls.MetroButton B_Show_Panel;
        private System.Windows.Forms.Timer tim_Panel_Open;
        private System.Windows.Forms.Timer tim_Panel_Close;
        private System.Windows.Forms.ListView P_V_F_ListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SladeShow;
        private System.Windows.Forms.Timer timerSlideShow;
    }
}
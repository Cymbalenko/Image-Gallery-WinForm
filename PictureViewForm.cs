using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Image_Gallery.Models;

namespace Image_Gallery
{
    public partial class PictureViewForm : MetroFramework.Forms.MetroForm
    {
        public List<string> ImageFormats;
        public string FullPatch { get; set; }
        public string SelectImage { set; get; }
        public ushort SliderSize { get; set; } = 20;
        public bool OpenedPanel { get; set; } = false;
        public ushort MoveSpeed { get; set; } = 10;
        public ushort CoefScr { get; set; } = 7;
        public int IndexImage { set; get; } = 0;
        public Settings settings { set; get; }
        public List<string> ListVi { set; get; }
        public List<string> ImageLi { set; get; }
        public PictureViewForm()
        {
            InitializeComponent(); 
            InitDefaultImageFormats();
            ListVi = new List<string>();
            ImageLi = new List<string>();
        }

        private void PanelButtonLeft_MouseEnter(object sender, EventArgs e)
        {
            PanelButtonLeft.Enabled = true;
        }

        private void PanelButtonLeft_MouseLeave(object sender, EventArgs e)
        {
            PanelButtonLeft.Enabled = false;
        }

        private void B_Show_Panel_Click(object sender, EventArgs e)
        {

        }

        private void tim_Panel_Open_Tick(object sender, EventArgs e)
        {
            if (PanelDown.Height >= this.Height / CoefScr)
            {
                tim_Panel_Open.Stop();
                OpenedPanel = true;
                P_V_F_ListView.Visible = true;
            }
            else
            {
                PanelDown.Height += MoveSpeed;
                
            }
        }
        private void UpdateListViewFiles(string path)
        {
            foreach (var item in ImageLi)
            {
                P_V_F_imageList.Images.Add(item, Image.FromFile(item));
                ListViewItem lviItem = new ListViewItem(Path.GetFileName(item), item);
                P_V_F_ListView.Items.Add(lviItem);
            } 
        }
        public void InitDefaultImageFormats()
        {
            if (ImageFormats == null)
            {
                ImageFormats = new List<string>();
                ImageFormats.Add(".jpeg");
                ImageFormats.Add(".jpg");
                ImageFormats.Add(".png");
                ImageFormats.Add(".ico");
                ImageFormats.Add(".gif");
                ImageFormats.Add(".bmp");
                ImageFormats.Add(".tif");
            }
        }
        private void tim_Panel_Close_Tick(object sender, EventArgs e)
        {
            if (PanelDown.Height <= SliderSize)
            {
                tim_Panel_Close.Stop();
                OpenedPanel = false;
            }
            else
            {
                P_V_F_ListView.Visible = false;
                PanelDown.Height -= MoveSpeed; 
            }
        }

        private void B_Show_Panel_MouseHover(object sender, EventArgs e)
        {
            if (PanelDown.Height <= this.Height / (CoefScr * 2))
            {
                tim_Panel_Open.Start();
                B_Show_Panel.Text = char.ConvertFromUtf32(11167);
            }

        }

        private void B_Show_Panel_MouseLeave(object sender, EventArgs e)
        {
            if (PanelDown.Height >= this.Height / (CoefScr * 2))
            {
                tim_Panel_Close.Start();
                B_Show_Panel.Text = char.ConvertFromUtf32(11165);
            }
        }

        private void B_Left_Click(object sender, EventArgs e)
        {
            B_Left.Text = char.ConvertFromUtf32(11164);
            if (IndexImage != 0) 
                IndexImage--; 
            else 
                IndexImage = P_V_F_ListView.Items.Count-1;
            P_V_F_ListView.Items[IndexImage].Selected = true;
        }

        private void B_Left_MouseMove(object sender, MouseEventArgs e)
        {
            B_Left.Text = char.ConvertFromUtf32(11164); 
        }

        private void B_Left_MouseLeave(object sender, EventArgs e)
        {
            B_Left.Text = "";
            B_Left.Style = MetroFramework.MetroColorStyle.Default; 
        }

        private void B_Right_Click(object sender, EventArgs e)
        {
            ShowNext();
        }
        private void ShowNext()
        {
            if (IndexImage < P_V_F_ListView.Items.Count - 1)
                IndexImage++;
            else
                IndexImage = 0;
            P_V_F_ListView.Items[IndexImage].Selected = true;
        }
        private void B_Right_MouseMove(object sender, MouseEventArgs e)
        { 
            B_Right.Text = char.ConvertFromUtf32(11166);
            B_Right.Style=MetroFramework.MetroColorStyle.Green;
        }

        private void B_Right_MouseLeave(object sender, EventArgs e)
        { 
            B_Right.Text = "";
            B_Right.Style = MetroFramework.MetroColorStyle.Default;
        }

        private void PictureViewForm_Load(object sender, EventArgs e)
        {
            B_Show_Panel.Text = char.ConvertFromUtf32(11167);
            B_Right.Text = char.ConvertFromUtf32(11166);
            B_Left.Text = char.ConvertFromUtf32(11164);
            UpdateListViewFiles(FullPatch);
            LoadImage();
            P_V_F_ListView.Items[IndexImage].Selected = true;
             
            B_Show_Panel_MouseLeave(sender, e);
            switch (settings.WindowColor)
            {
                case 1:
                    this.Style = settings.SelectWindowColor(1);
                    this.Refresh();
                    break;
                case 2:
                    this.Style = settings.SelectWindowColor(2);
                    this.Refresh();
                    break;
                case 3:
                    this.Style = settings.SelectWindowColor(3);
                    this.Refresh();
                    break;
                case 4:
                    this.Style = settings.SelectWindowColor(4);
                    this.Refresh();
                    break;
                case 5:
                    this.Style = settings.SelectWindowColor(5);
                    this.Refresh();
                    break;
                case 6:
                    this.Style = settings.SelectWindowColor(6);
                    this.Refresh();
                    break;
            }
        }

        private void P_V_F_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void P_V_F_ListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void LoadImage()
        {
            try
            {
                  
                if (P_V_F_ListView.SelectedItems.Count > 0)
                {
                    string Path = ImageLi[P_V_F_ListView.SelectedItems[0].Index];
                    //string Path = FullPatch + "\\" + P_V_F_ListView.SelectedItems[0].Text;
                    P_V_F_pictureBox.Image = Image.FromFile(Path); 
                    if (P_V_F_pictureBox.Image.Size.Width < P_V_F_pictureBox.Size.Width &&
                        P_V_F_pictureBox.Image.Size.Height < P_V_F_pictureBox.Size.Height)
                    {
                        P_V_F_pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    else
                    {
                        P_V_F_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    IndexImage = P_V_F_ListView.SelectedItems[0].Index;
                    //P_V_F_ListView.Update();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void timerSlideShow_Tick(object sender, EventArgs e)
        {
            ShowNext();
        }

        private void SladeShow_Click(object sender, EventArgs e)
        {
            if(SladeShow.Text=="Play")
            {
                timerSlideShow.Start();
                SladeShow.Text = "Stop";
            }
            else
            {
                timerSlideShow.Stop();
                SladeShow.Text = "Play";
            }
        }
    }
}

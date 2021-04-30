using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Image_Gallery.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.DirectoryServices;
using System.Data;

namespace Image_Gallery
{
    public partial class G_I_form : MetroFramework.Forms.MetroForm
    {
        List<string> selectedNode = new List<string>();
        string connectionString;
        SqlConnection connection;
        List<Tags> Tags;
        List<HistorySearch> HistorySearches;
        List<PictureTags> PictureTags;
        List<string> ImageFormats;
        string Copy;
        string NameFile;
        bool MoveFile = false;
        Settings Settings;
        public G_I_form()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            connection = new SqlConnection(connectionString);
            Tags = new List<Tags>();
            HistorySearches = new List<HistorySearch>();
            PictureTags = new List<PictureTags>();
            var root = new TreeNode() { Text = "C:\\", Tag = "c:\\" };
            G_I_TreeView.Nodes.Add(root);
            Build(root);
            root.Expand();
            InitDefaultImageFormats(); 


        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

         

        private void Build(TreeNode parent)
        {
            var path = parent.Tag as string;

            parent.Nodes.Clear();

            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {

                    var buf = new TreeNode(Path.GetFileName(dir), new[] { new TreeNode("...",1,2) }) { Tag = dir };
                    FileInfo fi = new FileInfo(dir);
                    if (!(fi.Attributes.HasFlag(FileAttributes.System)) &&
                        !(fi.Attributes.HasFlag(FileAttributes.Hidden)))
                            parent.Nodes.Add(buf);
                } 
            }
            catch
            {

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
        private void UpdateListViewFiles(string path)
        {
            imageList1.Images.Clear();
            G_I_listView.Items.Clear();
            try
            {
                if (Directory.GetFiles(path).Count() > 0)
                {
                    foreach (string item in Directory.GetFiles(path))
                    {
                        if (ImageFormats.Contains(Path.GetExtension(item)))
                        {
                            imageList1.Images.Add(item, Image.FromFile(item));
                            ListViewItem lviItem = new ListViewItem(Path.GetFileName(item), item);
                            selectedNode.Add(item);
                            G_I_listView.Items.Add(lviItem);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

        }
        
        private void SearchViewFiles(string path, string SearchText)
        {

            try
            {
                if (Directory.GetFiles(path).Count() > 0)
                {
                    foreach (string item in (Directory.GetFiles(path)))
                    {
                        FileInfo buf = new FileInfo(item);
                         
                        if ((!buf.Attributes.HasFlag(FileAttributes.Hidden)) &&
                                (!buf.Attributes.HasFlag(FileAttributes.System)))
                        {
                            if ((item).Contains(SearchText))
                            {
                                if (ImageFormats.Contains(Path.GetExtension(item)))
                                {
                                    imageList1.Images.Add(item, Image.FromFile(item));
                                    ListViewItem lviItem = new ListViewItem(Path.GetFileName(item), item);
                                    selectedNode.Add(item);
                                    G_I_listView.Items.Add(lviItem);
                                }
                            }
                        }
                    }

                }
                if (Directory.GetDirectories(path).Count() > 0)
                {
                    foreach (string d in (Directory.GetDirectories(path)))
                    {
                        FileInfo buf = new FileInfo(d);
                        if ((buf.Attributes.HasFlag(FileAttributes.Directory)) &&
                            (!buf.Attributes.HasFlag(FileAttributes.Hidden)) &&
                            (!buf.Attributes.HasFlag(FileAttributes.System)))
                        {
                            SearchViewFiles(d, SearchText);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

        }

        private void G_I_TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Build(e.Node);

            UpdateListViewFiles(e.Node.FullPath);
            ShowProperty();
        }

        private void G_I_listView_ItemDrag(object sender, ItemDragEventArgs e)
        { 
        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;
            return ContainsNode(node1, node2.Parent);
        }

        private void G_I_listView_DragOver(object sender, DragEventArgs e)
        {
        }

        private void G_I_listView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool imgExist = false;
                if (paths != null && paths.Count() > 0)
                {
                    foreach (string path in paths)
                    {
                        if (imgExist)
                            break;
                        if (ImageFormats.Contains(Path.GetExtension(path).ToLower()))
                            imgExist = true;
                    }
                    if (imgExist)
                        e.Effect = DragDropEffects.Move;
                }
            }
            else
                e.Effect = DragDropEffects.None;
        
    }

        private void G_I_proGrid_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
             
        }

        private void G_I_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(G_I_listView.SelectedItems.Count>0)
            {
                string buf = G_I_TreeView.SelectedNode.FullPath + "\\" + G_I_listView.SelectedItems[0].Text;
                FileInfo fi = new FileInfo(buf);
                G_I_TextBox_Property.Text = "";
                G_I_TextBox_Property.AppendText("Имя файла: " + fi.Name);
                G_I_TextBox_Property.AppendText("Полный путь к файлу: " + fi.DirectoryName);
                G_I_TextBox_Property.AppendText("Расширение файла: " + fi.Extension);
                G_I_TextBox_Property.AppendText("Время создание файла: " + fi.CreationTime);
                G_I_TextBox_Property.AppendText("Размер файла в байтах: " + fi.Length);
                
                    ShowProperty();
            } 
        }

        private void G_I_listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureViewForm pvf = new PictureViewForm();
            pvf.settings = Settings; 
            
            foreach (var item in selectedNode)
            {
                pvf.ImageLi.Add(item);
            }
             pvf.FullPatch = G_I_TreeView.SelectedNode.FullPath;
           pvf.SelectImage = G_I_listView.SelectedItems[0].Text; 
            pvf.IndexImage = G_I_listView.SelectedItems[0].Index;
            pvf.Show();

        }

        private void TSB_Copy_Click(object sender, EventArgs e)
        {
            if (G_I_listView.SelectedItems.Count > 0)
            {
                Copy = G_I_TreeView.SelectedNode.FullPath + "\\" + G_I_listView.SelectedItems[0].Text;
                NameFile = G_I_listView.SelectedItems[0].Text;
                TSB_Insert.Enabled = true;
                TSB_Move.Enabled = false;
                TSB_Copy.Enabled = false;
            }
        }

        private void TSB_Delete_Click(object sender, EventArgs e)
        {
            if (G_I_listView.SelectedItems.Count > 0)
            {
                string buf = G_I_TreeView.SelectedNode.FullPath + "\\" + G_I_listView.SelectedItems[0].Text;
                G_I_listView.Clear();
                File.Delete(buf);
                UpdateListViewFiles(G_I_TreeView.SelectedNode.FullPath);
            }
        }

        private void TSB_Insert_Click(object sender, EventArgs e)
        {
            try
            {

                File.Copy(Copy, G_I_TreeView.SelectedNode.FullPath + "\\" + NameFile);
                TSB_Insert.Enabled = false;
                TSB_Move.Enabled = true;
                TSB_Copy.Enabled = true;
                if (MoveFile)
                {
                    File.Delete(Copy);
                    MoveFile = false;
                }
                UpdateListViewFiles(G_I_TreeView.SelectedNode.FullPath);

            }
            catch (Exception)
            {
                MessageBox.Show("Такой файл уже существует!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void TSB_Move_Click(object sender, EventArgs e)
        {
            TSB_Copy_Click(sender, e);
            MoveFile = true;
            TSB_Insert.Enabled = true;
            TSB_Move.Enabled = false;
            TSB_Copy.Enabled = false;
        }

        private void TSB_Cancel_Click(object sender, EventArgs e)
        {
            TSB_Insert.Enabled = false;
            TSB_Move.Enabled = true;
            TSB_Copy.Enabled = true;
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            if (TS_TextBox.Text.Length > 0)
            {
                imageList1.Images.Clear();
                G_I_listView.Items.Clear();
                selectedNode.Clear();
                AddHistorySearch();
                SearchViewFiles(G_I_TreeView.SelectedNode.FullPath, TS_TextBox.Text);

            }
            else
                MessageBox.Show("Введите текст для поиска!!!");
        }
        private void TSB_AddTag_Click(object sender, EventArgs e)
        {
            AddTag addTag = new AddTag();
            addTag.settings = Settings;
            if (addTag.ShowDialog() == DialogResult.OK)
            {
                LoadPictureTags();
                PictureTags buf;
                if (G_I_listView.SelectedItems.Count > 0)
                {
                    buf = new PictureTags { IdTags = addTag.S_Tags, URL = G_I_listView.SelectedItems[0].Text };
                }
                else
                {
                    buf = new PictureTags { IdTags = addTag.S_Tags, URL = G_I_TreeView.SelectedNode.FullPath };
                }
                PictureTags.Add(buf);
                string query = "insert into PictureTags (URL,IdTag) values(@URL,@IdTag)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@URL", SqlDbType.NVarChar, 50).Value = buf.URL; ;
                cmd.Parameters.Add("@IdTag", SqlDbType.NVarChar, 50).Value = buf.IdTags;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Тег успешно добавлен");
                connection.Close();
            }
        }
        private void ShowProperty()
        {
            try
            {
 
            G_I_TextBox_Property.Text = "";
            foreach (var item in PictureTags)
            {
                if (G_I_listView.SelectedItems.Count > 0)
                {
                    if (item.URL == G_I_listView.SelectedItems[0].Text.ToString())
                    {
                        string buf = Tags.Where(a => a.Id == item.IdTags).FirstOrDefault().Name;
                        if (buf != "")
                            G_I_TextBox_Property.Text = buf;
                    }
                }
                else
                   if (item.URL == G_I_TreeView.SelectedNode.FullPath)
                {
                    string buf = Tags.Where(a => a.Id == item.IdTags).FirstOrDefault().Name;
                    if (buf != "")
                        G_I_TextBox_Property.Text = buf;
                }
            }

            }
            catch (Exception)
            {
                 
            }

        }

        private void G_I_listView_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void G_I_listView_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (paths != null && paths.Count() > 0)
            {
                foreach (string file in paths)
                {
                    if (ImageFormats.Contains(Path.GetExtension(file).ToLower()))
                    {
                        try
                        {
                             
                            FileInfo fi = new FileInfo(file);
                            NameFile = $"{Path.GetDirectoryName(G_I_TreeView.Tag as string)}/{fi.Name}";
                            string newPath = G_I_TreeView.SelectedNode.FullPath + NameFile;
                            //fi.MoveTo(NameFile);
                            File.Copy(file, G_I_TreeView.SelectedNode.FullPath+ NameFile);
                            imageList1.Images.Add(newPath, Image.FromFile(newPath));
                            ListViewItem lviItem = new ListViewItem(Path.GetFileName(newPath), newPath);
                            G_I_listView.Items.Add(lviItem); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void G_I_form_Load(object sender, EventArgs e)
        {
            TS_ComboBox.SelectedIndex = 0;
            TS_ComboBox_Search.SelectedIndex = 0;
            LoadPictureTags();
            LoadSettings(sender,e);
        }

        private void TSB_Conver_Click(object sender, EventArgs e)
        {
            if (G_I_listView.SelectedItems.Count <= 0)
            {
                return;
            }
            var check = MessageBox.Show("Сохранить исходный файл?", "Преобразование файла", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (check == DialogResult.Cancel)
            {
                return;
            }
            try
            {
 
            string ex = G_I_listView.SelectedItems[0].Text.Substring(G_I_listView.SelectedItems[0].Text.LastIndexOf('.')); ;
            string buf = G_I_TreeView.SelectedNode.FullPath + "\\" + G_I_listView.SelectedItems[0].Text;
            Bitmap bitmap = new Bitmap(buf);
            string NewImage = buf.Replace(ex, TS_ComboBox.SelectedItem.ToString());
            switch (TS_ComboBox.SelectedItem.ToString())
            {
                case ".jpeg":
                    bitmap.Save(NewImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".png":
                    bitmap.Save(NewImage, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case ".ico":
                    bitmap.Save(NewImage, System.Drawing.Imaging.ImageFormat.Icon);
                    break;
                case ".gif":
                    bitmap.Save(NewImage, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case ".bmp":
                    bitmap.Save(NewImage, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case ".tif":
                    bitmap.Save(NewImage, System.Drawing.Imaging.ImageFormat.Tiff);
                    break;
            } 
            if (check == DialogResult.No)
            {
                bitmap.Dispose();
                G_I_listView.Clear();
                File.Delete(buf);
            }
            UpdateListViewFiles(G_I_TreeView.SelectedNode.FullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void G_I_listView_DragLeave(object sender, EventArgs e)
        {

        }
        private void LoadPictureTags()
        {
            LoadTags();
            string query = "select * from PictureTags";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            PictureTags.Clear();
            while (reader.Read())
            {
                PictureTags c = new PictureTags()
                {
                    Id = (int)reader["Id"],
                    IdTags = (int)reader["IdTag"],
                    URL = (string)reader["URL"]
                };
                PictureTags.Add(c);
            }
            connection.Close();
        }
        private void LoadTags()
        {
            string query = "select * from Tags";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Tags.Clear();
            while (reader.Read())
            {
                Tags c = new Tags()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                };
                Tags.Add(c);
            }
            connection.Close();
        }
        private void LoadSettings(object sender, EventArgs e)
        {
            string query = "select * from Settings";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Tags.Clear();
            while (reader.Read())
            {
                Settings = new Settings()
                {
                    Id = (int)reader["Id"],
                    WindowColor = (int)reader["WindowColor"],
                    SizeFont = (int)reader["SizeFont"],
                    SizeIcon = (int)reader["SizeIcon"],
                    MenuColor = (int)reader["MenuColor"],
                };
                 
            }
            connection.Close();
            ApplySetings(sender,e);
        }
        private void SaveSettings()
        { 
            string query = "UPDATE Settings set WindowColor=@WindowColor, SizeFont=@SizeFont,SizeIcon=@SizeIcon,MenuColor=@MenuColor where Id=@Id";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Settings.Id;
            cmd.Parameters.Add("@WindowColor", SqlDbType.Int).Value = Settings.WindowColor;
            cmd.Parameters.Add("@SizeFont", SqlDbType.Int).Value = Settings.SizeFont;
            cmd.Parameters.Add("@SizeIcon", SqlDbType.Int).Value = Settings.SizeIcon;
            cmd.Parameters.Add("@MenuColor", SqlDbType.Int).Value = Settings.MenuColor;
            cmd.ExecuteNonQuery();
            connection.Close();
            LoadHistorySearch();
        }
        private void LoadHistorySearch()
        {
            string query = "select * from HistorySearch";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            HistorySearches.Clear();
            while (reader.Read())
            {
                HistorySearch c = new HistorySearch()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                };
                HistorySearches.Add(c);
            }
            connection.Close();
        }
        private void AddHistorySearch()
        {
            string query = "insert into HistorySearch (Name) values(@name)";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            string name = TS_TextBox.Text;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            cmd.ExecuteNonQuery();
            connection.Close();
            LoadHistorySearch();
        }
        private void G_I_ListView_MenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void скопироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Copy_Click(sender,e);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Delete_Click(sender, e);
        }

        private void переместитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Move_Click(sender, e);
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Insert_Click(sender, e);
        }

        private void добавитьТегToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_AddTag_Click(sender,e);
        }

        private void конвертироватьВToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Conver_Click(sender, e);
        }

        private void jpegToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TSB_Conver_Click(sender, e);
        }

        private void icoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Conver_Click(sender, e);
        }

        private void gifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Conver_Click(sender, e);
        }

        private void bmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Conver_Click(sender, e);
        }

        private void tifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Conver_Click(sender, e);
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSB_Cancel_Click(sender,e);
        }

        private void добавитьТегToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TSB_AddTag_Click(sender, e);
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TSB_Insert_Click(sender, e);
        }

        private void G_I_listView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Collections.Specialized.StringCollection filePath = new
        System.Collections.Specialized.StringCollection();
                if (G_I_listView.SelectedItems.Count > 0)
                {
                    List<string> buf = new List<string>();
                    try
                    {
                        buf.Add(G_I_listView.SelectedItems[0].ImageKey);
                    filePath.AddRange(buf.ToArray());
                    DataObject dataObject = new DataObject();
                    dataObject.SetFileDropList(filePath);
                    G_I_listView.DoDragDrop(dataObject, DragDropEffects.Copy);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void TS_TextBox_Enter(object sender, EventArgs e)
        {
            G_I_TextBox_Property.Clear(); 
            G_I_TextBox_Property.AppendText("История поиска\n\n");
            int i = 1;
            foreach (var item in HistorySearches)
            {
                G_I_TextBox_Property.AppendText(i.ToString()+".)  "+item.Name+ "\n");
                i++;
            }
        }
         

        private void thistleToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            this.Style = Settings.SelectWindowColor(1);
            this.Refresh();
            SaveSettings();
        }

        private void лимонныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Style = Settings.SelectWindowColor(2);
            this.Refresh();
            SaveSettings();
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Style = Settings.SelectWindowColor(3);
            this.Refresh();
            SaveSettings();
        }

        private void голубойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Style = Settings.SelectWindowColor(4);
            this.Refresh();
            SaveSettings();
        }

        private void черныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Style = Settings.SelectWindowColor(5);
            this.Refresh();
            SaveSettings();
        }

        private void зелёныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Style = Settings.SelectWindowColor(6);
            this.Refresh();
            SaveSettings();
        }

        private void маленькийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float buf = Settings.SelectSizeFont(1);
            Font f = new Font(G_I_TreeView.Font.FontFamily, buf);
            G_I_TreeView.Font = f;
            G_I_TextBox_Property.Font = f;
            G_I_MenuStrip.Font = f;
            G_I_listView.Font = f;
            G_I_bindNav.Font = f;
            SaveSettings();
        }

        private void среднийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float buf = Settings.SelectSizeFont(2);
            Font f= new Font(G_I_TreeView.Font.FontFamily, buf);
            G_I_TreeView.Font = f;
            G_I_TextBox_Property.Font = f;
            G_I_MenuStrip.Font = f;
            G_I_listView.Font = f;
            G_I_bindNav.Font = f;
            SaveSettings();
        }

        private void большойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float buf = Settings.SelectSizeFont(3);
            Font f = new Font(G_I_TreeView.Font.FontFamily, buf);
            G_I_TreeView.Font = f;
            G_I_TextBox_Property.Font = f;
            G_I_MenuStrip.Font = f;
            G_I_listView.Font = f;
            G_I_bindNav.Font = f;
            SaveSettings();
        }

        private void маленькиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int buf = Settings.SelectSizeIcon(1);
            imageList1.ImageSize = new Size { Height = buf, Width = buf };
            SaveSettings();
            if(G_I_TreeView.SelectedNode !=null)
                UpdateListViewFiles(G_I_TreeView.SelectedNode.FullPath);
        }

        private void средниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int buf = Settings.SelectSizeIcon(2);
            imageList1.ImageSize = new Size { Height = buf, Width = buf };
            SaveSettings();
            if (G_I_TreeView.SelectedNode != null)
                UpdateListViewFiles(G_I_TreeView.SelectedNode.FullPath);
        }

        private void большиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int buf = Settings.SelectSizeIcon(3);
            imageList1.ImageSize = new Size { Height = buf, Width = buf };
            SaveSettings();
            if (G_I_TreeView.SelectedNode != null)
                UpdateListViewFiles(G_I_TreeView.SelectedNode.FullPath);
        }

        private void огромныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int buf = Settings.SelectSizeIcon(4);
            imageList1.ImageSize = new Size { Height = buf, Width = buf };
            SaveSettings();
            UpdateListViewFiles(G_I_TreeView.SelectedNode.FullPath);
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_I_MenuStrip.BackColor = Settings.SelectMenuColor(1);
            G_I_bindNav.BackColor= Settings.SelectMenuColor(1);
        }

        private void лимонныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            G_I_MenuStrip.BackColor = Settings.SelectMenuColor(2);
            G_I_bindNav.BackColor = Settings.SelectMenuColor(2);
        }

        private void синийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            G_I_MenuStrip.BackColor = Settings.SelectMenuColor(3);
            G_I_bindNav.BackColor = Settings.SelectMenuColor(3);
        }

        private void серебренныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_I_MenuStrip.BackColor = Settings.SelectMenuColor(4);
            G_I_bindNav.BackColor = Settings.SelectMenuColor(4);
        }

        private void черныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            G_I_MenuStrip.BackColor = Settings.SelectMenuColor(5);
            G_I_bindNav.BackColor = Settings.SelectMenuColor(5);
        }

        private void зелёныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            G_I_MenuStrip.BackColor = Settings.SelectMenuColor(6);
            G_I_bindNav.BackColor = Settings.SelectMenuColor(6);
        }
        private void ApplySetings(object sender, EventArgs e)
        {
            switch (Settings.MenuColor)
            {
                case 1:
                    красныйToolStripMenuItem_Click(sender,e);
                    break;
                case 2:
                    лимонныйToolStripMenuItem1_Click(sender, e);
                    break;
                case 3:
                    синийToolStripMenuItem1_Click(sender, e);
                    break;
                case 4:
                    серебренныйToolStripMenuItem_Click(sender, e);
                    break;
                case 5:
                    черныйToolStripMenuItem1_Click(sender, e);
                    break;
                case 6:
                    зелёныйToolStripMenuItem1_Click(sender, e);
                    break;
            }
            switch (Settings.WindowColor)
            {
                case 1:
                    thistleToolStripMenuItem_Click(sender, e);
                    break;
                case 2:
                    лимонныйToolStripMenuItem_Click(sender, e);
                    break;
                case 3:
                    синийToolStripMenuItem_Click(sender, e);
                    break;
                case 4:
                    голубойToolStripMenuItem_Click(sender, e);
                    break;
                case 5:
                    черныйToolStripMenuItem_Click(sender, e);
                    break;
                case 6:
                    зелёныйToolStripMenuItem_Click(sender, e);
                    break;
            }
            switch (Settings.SizeIcon)
            {
                case 1:
                    маленькиеToolStripMenuItem_Click(sender, e);
                    break;
                case 2:
                    средниеToolStripMenuItem_Click(sender, e);
                    break;
                case 3:
                    большиеToolStripMenuItem_Click(sender, e);
                    break;
                case 4:
                    огромныеToolStripMenuItem_Click(sender, e);
                    break;
            }
            switch (Settings.SizeFont)
            {
                case 1:
                    маленькийToolStripMenuItem_Click(sender, e);
                    break;
                case 2:
                    среднийToolStripMenuItem_Click(sender, e);
                    break;
                case 3:
                    большойToolStripMenuItem_Click(sender, e);
                    break;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureViewForm pvf = new PictureViewForm();
            pvf.settings = Settings;

            foreach (var item in selectedNode)
            {
                pvf.ImageLi.Add(item);
            }
            pvf.FullPatch = G_I_TreeView.SelectedNode.FullPath;
            pvf.SelectImage = G_I_listView.SelectedItems[0].Text;
            pvf.IndexImage = G_I_listView.SelectedItems[0].Index;
            pvf.Show();
        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

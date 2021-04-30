namespace Image_Gallery
{
    partial class AddTag
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
            this.A_T_TextBox = new MetroFramework.Controls.MetroTextBox();
            this.A_T_SelectTag = new MetroFramework.Controls.MetroButton();
            this.A_T_Cancel = new MetroFramework.Controls.MetroButton();
            this.A_T_AddTag = new MetroFramework.Controls.MetroButton();
            this.A_T_DelTag = new MetroFramework.Controls.MetroButton();
            this.A_T_ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // A_T_TextBox
            // 
            // 
            // 
            // 
            this.A_T_TextBox.CustomButton.Image = null;
            this.A_T_TextBox.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.A_T_TextBox.CustomButton.Name = "";
            this.A_T_TextBox.CustomButton.Size = new System.Drawing.Size(89, 89);
            this.A_T_TextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.A_T_TextBox.CustomButton.TabIndex = 1;
            this.A_T_TextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.A_T_TextBox.CustomButton.UseSelectable = true;
            this.A_T_TextBox.CustomButton.Visible = false;
            this.A_T_TextBox.Lines = new string[0];
            this.A_T_TextBox.Location = new System.Drawing.Point(23, 181);
            this.A_T_TextBox.MaxLength = 50;
            this.A_T_TextBox.Multiline = true;
            this.A_T_TextBox.Name = "A_T_TextBox";
            this.A_T_TextBox.PasswordChar = '\0';
            this.A_T_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.A_T_TextBox.SelectedText = "";
            this.A_T_TextBox.SelectionLength = 0;
            this.A_T_TextBox.SelectionStart = 0;
            this.A_T_TextBox.ShortcutsEnabled = true;
            this.A_T_TextBox.Size = new System.Drawing.Size(219, 91);
            this.A_T_TextBox.TabIndex = 1;
            this.A_T_TextBox.UseSelectable = true;
            this.A_T_TextBox.Visible = false;
            this.A_T_TextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.A_T_TextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // A_T_SelectTag
            // 
            this.A_T_SelectTag.Location = new System.Drawing.Point(26, 295);
            this.A_T_SelectTag.Name = "A_T_SelectTag";
            this.A_T_SelectTag.Size = new System.Drawing.Size(75, 23);
            this.A_T_SelectTag.TabIndex = 2;
            this.A_T_SelectTag.Text = "Выбрать";
            this.A_T_SelectTag.UseSelectable = true;
            this.A_T_SelectTag.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // A_T_Cancel
            // 
            this.A_T_Cancel.Location = new System.Drawing.Point(167, 295);
            this.A_T_Cancel.Name = "A_T_Cancel";
            this.A_T_Cancel.Size = new System.Drawing.Size(75, 23);
            this.A_T_Cancel.TabIndex = 3;
            this.A_T_Cancel.Text = "Отмена";
            this.A_T_Cancel.UseSelectable = true;
            this.A_T_Cancel.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // A_T_AddTag
            // 
            this.A_T_AddTag.Location = new System.Drawing.Point(23, 128);
            this.A_T_AddTag.Name = "A_T_AddTag";
            this.A_T_AddTag.Size = new System.Drawing.Size(219, 23);
            this.A_T_AddTag.TabIndex = 5;
            this.A_T_AddTag.Text = "Добавить Тег";
            this.A_T_AddTag.UseSelectable = true;
            this.A_T_AddTag.Click += new System.EventHandler(this.A_T_AddTag_Click);
            // 
            // A_T_DelTag
            // 
            this.A_T_DelTag.Location = new System.Drawing.Point(23, 157);
            this.A_T_DelTag.Name = "A_T_DelTag";
            this.A_T_DelTag.Size = new System.Drawing.Size(219, 23);
            this.A_T_DelTag.TabIndex = 6;
            this.A_T_DelTag.Text = "Удалить Тег";
            this.A_T_DelTag.UseSelectable = true;
            this.A_T_DelTag.Click += new System.EventHandler(this.A_T_DelTag_Click);
            // 
            // A_T_ComboBox
            // 
            this.A_T_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.A_T_ComboBox.FormattingEnabled = true;
            this.A_T_ComboBox.Location = new System.Drawing.Point(23, 78);
            this.A_T_ComboBox.Name = "A_T_ComboBox";
            this.A_T_ComboBox.Size = new System.Drawing.Size(219, 21);
            this.A_T_ComboBox.TabIndex = 7;
            // 
            // AddTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 330);
            this.Controls.Add(this.A_T_ComboBox);
            this.Controls.Add(this.A_T_DelTag);
            this.Controls.Add(this.A_T_AddTag);
            this.Controls.Add(this.A_T_Cancel);
            this.Controls.Add(this.A_T_SelectTag);
            this.Controls.Add(this.A_T_TextBox);
            this.Name = "AddTag";
            this.Text = "Добавление тега";
            this.Load += new System.EventHandler(this.AddTag_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox A_T_TextBox;
        private MetroFramework.Controls.MetroButton A_T_SelectTag;
        private MetroFramework.Controls.MetroButton A_T_Cancel;
        private MetroFramework.Controls.MetroButton A_T_AddTag;
        private MetroFramework.Controls.MetroButton A_T_DelTag;
        private System.Windows.Forms.ComboBox A_T_ComboBox;
    }
}
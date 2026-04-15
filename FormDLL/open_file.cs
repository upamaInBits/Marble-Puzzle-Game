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
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic;
using System.Diagnostics;




namespace FormDLL
{
    public partial class open_file : Form
    {

        public string SelectedFileName
        {
            get { return listView1.SelectedItems[0].Text; }
        }

        public string FullPath;
        //  public string FullPath;
        private string tempLocation = string.Empty;
        private string GamePath;
      

        public open_file()
        {
            InitializeComponent();
            textBox1.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    // handle key press event
                }
            };
            FullPath = Directory.GetCurrentDirectory();
            GetDirectory();
        }

        public string gamepath
        {
            set
            {
                GamePath = value;
            }
            get
            {
                return GamePath;
            }
        }

     
        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void GetDirectory()
        {
            try
            {
                listView1.Items.Clear();

                var dirInfo = new DirectoryInfo(FullPath);

                if (string.IsNullOrEmpty(FullPath))
                {
                    MessageBox.Show("At Root Directory");
                }
                else
                {
                    textBox1.Text = FullPath;
                }

                foreach (var directory in dirInfo.GetDirectories())
                {
                    AddListViewItem(directory.Name, directory.LastWriteTime.ToString(), "Folder", 3);
                }

                foreach (var file in dirInfo.GetFiles())
                {
                    AddListViewItem(file.Name, file.LastWriteTime.ToString(), FileSize(file.Length), FileIconIndex(file.Extension));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to get the directory listing: {ex.Message}");
            }
        }
        private void AddListViewItem(string name, string date, string type, int iconIndex)
        {
            ListViewItem item = new ListViewItem(new[] { name, type, date });
            item.ImageIndex = iconIndex;
            listView1.Items.Add(item);
        }
        private string FileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.#} {sizes[order]}";
        }
        private static readonly Dictionary<string, int> ExtensionToIconIndex = new Dictionary<string, int>
        {
        { ".mrb", 0 },
        { ".jpg", 1 },
        { ".png", 1 },
        { ".txt", 2 },
        { ".cs", 4},


        { ".zip", 5}

        }; private int FileIconIndex(string extension)
        {
            return ExtensionToIconIndex.TryGetValue(extension, out int iconIndex) ? iconIndex : 6;
        }
        private void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                var dirInfo = new DirectoryInfo(FullPath);
                var parentDir = dirInfo.Parent;

                if (parentDir == null)
                {
                    MessageBox.Show("Reached the Root!");
                }
                else
                {
                    FullPath = parentDir.FullName;
                    ClearPreview();
                    GetDirectory();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"An error occurred while accessing the parent directory: {ex.Message}");
            }
        }
        private void ClearPreview()
        {
            picbox.Image = null;
            lbl_size.Text = lbl_ball.Text = lbl_wall.Text = string.Empty;
        }
        public void DisplaySelectedFile(string path)
        {
            ClearPreview();

            var selectedFileType = Path.GetExtension(path);

            if (selectedFileType != ".mrb") return;

            try
            {
                using (var archive = ZipFile.OpenRead(path))
                {
                    var tempLocation = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    Directory.CreateDirectory(tempLocation);

                    foreach (var file in archive.Entries)
                    {
                        file.ExtractToFile(Path.Combine(tempLocation, file.FullName), true);
                    }

                    var lines = File.ReadAllLines(Path.Combine(tempLocation, archive.Entries[1].ToString()));
                    var gameInfo = lines[0].Split(' ');

                    lbl_size.Text = $"Size: {gameInfo[0]}";
                    lbl_ball.Text = $"Balls: {gameInfo[1]}";
                    lbl_wall.Text = $"Walls: {gameInfo[2]}";

                    using (var tmpImage = Image.FromFile(Path.Combine(tempLocation, "puzzle.jpg")))
                    {
                        var ratio = Math.Max((float)tmpImage.Height / 240, (float)tmpImage.Width / 240);
                        var newHeight = tmpImage.Height / ratio;
                        var newWidth = tmpImage.Width / ratio;

                        var bm = new Bitmap(picbox.Width, picbox.Height);
                        var r = new Rectangle(0, 0, (int)newWidth, (int)newHeight);
                        using (var g = Graphics.FromImage(bm))
                        {
                            g.DrawImage(tmpImage, r, 0, 0, tmpImage.Width, tmpImage.Height, GraphicsUnit.Pixel);
                        }
                        picbox.Image = bm;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"An error occurred while loading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedItem = listView1.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (selectedItem == null) return;

            var selectedFile = selectedItem.Text;
            var nextPath = Path.Combine(textBox1.Text, selectedFile);

            DisplaySelectedFile(nextPath);
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            var selectedItem = listView1.SelectedItems[0];
            var selectedFile = selectedItem.Text;
            var selectedFilePath = Path.Combine(FullPath, selectedFile);
            var selectedFileType = Path.GetExtension(selectedFile);

            if (selectedFileType == ".zip" || selectedFileType == ".mrb")
            {
                MessageBox.Show(textBox1.Text, selectedFile);
            }
            else if (selectedFileType == "")
            {
                FullPath = selectedFilePath;
                GetDirectory();
            }
            else
            {
                MessageBox.Show("Nothing happens here");
            }
        }
        private void SearchKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var newFullPath = textBox1.Text;
                try
                {
                    if (Directory.Exists(newFullPath))
                    {
                        FullPath = newFullPath;
                        GetDirectory();
                    }
                    else
                    {
                        MessageBox.Show("Invalid directory path!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while trying to change the directory: {ex.Message}");
                }
            }
        }

        public void btn_open_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            var selectedFile = listView1.SelectedItems[0].Text;
            var nextPath = Path.Combine(FullPath, selectedFile);

            switch (Path.GetExtension(selectedFile))
            {
                case ".mrb":
                    this.Hide();
                    this.DialogResult = DialogResult.Yes;
                    extract(nextPath);
                    this.Close(); // add this line to close the form
                    this.Show();

                    break;

                case "":
                    FullPath = nextPath;
                    GetDirectory();
                    break;
            }
        }
        private void extract(string mrbFile)
        {
            if (tempLocation != null)
            {
                RemoveTempDirectory();
            }
            tempLocation = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            Directory.CreateDirectory(tempLocation);

            using (ZipArchive archive = ZipFile.OpenRead(mrbFile))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(tempLocation, entry.FullName), true);
                }
            }
            gamepath = tempLocation;
        }

        private void RemoveTempDirectory()
        {
            if (string.IsNullOrEmpty(tempLocation)) return;

            DirectoryInfo dirInfo = new DirectoryInfo(tempLocation);
            FileInfo[] fileList = dirInfo.GetFiles();
            foreach (FileInfo file in fileList)
            {
                File.Delete(file.FullName);
            }
            Directory.Delete(tempLocation);
        }


    }
}
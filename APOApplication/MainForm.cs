using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APOApplication
{
    public partial class MainForm : Form
    {
        private ContextMenu rightClickMenu = new ContextMenu();
        public MainForm()
        {
            InitializeComponent();

            rightClickMenu.MenuItems.Add("Open new image", new EventHandler(openNewImage_Click));
            rightClickMenu.MenuItems.Add("Open from csv", new EventHandler(openFromCsv_Click));
            rightClickMenu.MenuItems.Add("Open from xslx", new EventHandler(openFromXslx_Click));

            this.ContextMenu = rightClickMenu;
        }

        private void openNewImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\%username%\Images";
            openFileDialog.Filter = "bitmap files (*.bmp)|*.bmp";
            openFileDialog.Title = "Open file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                ImageForm imageForm = new ImageForm(bitmap);
                imageForm.MdiParent = this;
                imageForm.Show();
            }
        }

        private void openFromCsv_Click(object sender, EventArgs e)
        {

        }

        private void openFromXslx_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {

            }
        }
    }
}

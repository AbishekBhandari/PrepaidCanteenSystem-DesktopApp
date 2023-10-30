using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canteen_Management_System.UI
{
    public partial class UpdateCategory : Form
    {
        public UpdateCategory()
        {
            InitializeComponent();
        }
        int CategoryID;
        string CategoryName,CategoryDescription;
        
        byte[] CategoryPicture;
        string Active;

        public UpdateCategory(int GivenProductID, string GivenProductName, string GivenProductDescription, byte[] GivenProductPicture,string Active1)
        {
            InitializeComponent();
            CategoryID = GivenProductID;
            CategoryName = GivenProductName;
            CategoryDescription = GivenProductDescription;
            CategoryPicture = GivenProductPicture;
            Active = Active1;
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {

            CategoryNameBox.Text = CategoryName;
            CategoryIDBox.Text = CategoryID.ToString();
            CategoryDescriptionBox.Text = CategoryDescription;
            MemoryStream ms = new MemoryStream(CategoryPicture);
            CategoryPictureBox.Image = Image.FromStream(ms);
            ActiveComboBox.Text = Active;

        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want to Update this Category?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataAccess _DataAccess = new DataAccess();

                int ProductID = Convert.ToInt32(CategoryIDBox.Text);

                string ProductName = CategoryNameBox.Text;

                string ProductDescription = CategoryDescriptionBox.Text;

                string Active = ActiveComboBox.Text;

                /*initializing memory stream class for creating a stream of binary numbers*/
                MemoryStream ms = new MemoryStream();

                /*saving the image in raw format from picture box*/
                CategoryPictureBox.Image.Save(ms, CategoryPictureBox.Image.RawFormat);

                /*Array of Binary numbers that have been converted*/
                byte[] MyProductPicture = ms.GetBuffer();

                /*closing the memory stream*/
                ms.Close();

                if (_DataAccess.UpdateCategory(ProductID, ProductName, ProductDescription, MyProductPicture,Active))
                {
                    this.Close();
                    frmAdmin a = new frmAdmin();
                    a.refresh();

                }
                else MessageBox.Show("Poduct Not Updated", "Error", MessageBoxButtons.OK);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadPictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select Image file..";
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "Media Files|*.jpg;*.png;*.gif;*.bmp;*.jpeg|All Files|*.*";

            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                /*if picture selected then load in the picture box*/
                CategoryPictureBox.Load(ofd.FileName);
            }
        }

    
            
     
    }
}

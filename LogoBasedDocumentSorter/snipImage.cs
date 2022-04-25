using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogoBasedDocumentSorter
{
    public partial class snipImage : Form
    {
        public snipImage()
        {
            InitializeComponent();
            Central_Static_Value.snipImage = this;
            refrech_ideal_set_comboBox();

        }
        ImageProcessor ImageProcessor = new ImageProcessor();
        Image orginal_Image { get; set; }

        List<Bitmap> SelectedImages = new List<Bitmap>();

        List<string> IdealSets = new List<string>(); 

        int CurrentImageIndex { get; set; }

        string AvilebleIdealSets = string.Empty;

        Rectangle rect;

        Point StartLocation;
        
        Point EndLocation;
        
        bool IsMouseDown = false;

        private void Open_image_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImag = new OpenFileDialog();

            getImag.Filter = "JPG,PNG|*.png;*.jpg";

            DialogResult result = getImag.ShowDialog();

            string Source_Logo_Link = string.Empty;


            if (result == DialogResult.OK)
            {


                orginal_image_pictureBox.Image = ImageProcessor.ResizeImage(Image.FromFile(getImag.FileName), orginal_image_pictureBox.Width, orginal_image_pictureBox.Height);

                orginal_Image = orginal_image_pictureBox.Image;              

            }
        }

       private void Extract_Blobs_button_Click(object sender, EventArgs e)
        {
            if (orginal_Image != null)
            {

                List<Blob> selectedImages = ImageProcessor.getBiggestBlobsInImage(new Bitmap(orginal_Image), 220, 20, 30, 500, 500);

                this.SelectedImages = selectedImages.Select(x => x.BMP).ToList();

                try
                {
                    foreach (Rectangle rectangle in selectedImages.Select(x => x.Rectangle).ToList())
                    {

                        using (var graphics = Graphics.FromImage(orginal_Image))
                        {
                            graphics.DrawRectangle(Pens.Black, rectangle);
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

                orginal_image_pictureBox.Image = orginal_Image;
                CurrentImageIndex = selectedImages.Count - 1;
                sniped_image_pictureBox.Image = selectedImages[CurrentImageIndex].BMP;
                this.current_selected_image.Text = (selectedImages.Count - CurrentImageIndex).ToString() + @"\" + (selectedImages.Count - 1).ToString();
            }
        }
        private void Image_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {

            IsMouseDown = true;

            StartLocation = e.Location;

        }

        private void Image_pictureBox_MouseMove(object sender, MouseEventArgs e)
        {

            if (IsMouseDown == true)
            {

                EndLocation = e.Location;

                orginal_image_pictureBox.Invalidate();

            }

        }

        private void Image_pictureBox_Paint(object sender, PaintEventArgs e)
        {

            if (rect != null)
            {

                e.Graphics.DrawRectangle(Pens.Black, GetRectangle());

            }

        }


        private Rectangle GetRectangle()
        {
            rect = new Rectangle();
            rect.X = Math.Min(StartLocation.X, EndLocation.X);
            rect.Y = Math.Min(StartLocation.Y, EndLocation.Y);
            rect.Width = Math.Abs(StartLocation.X - EndLocation.X);
            rect.Height = Math.Abs(StartLocation.Y - EndLocation.Y);

            return rect;
        }

        private void Image_pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            if (IsMouseDown == true)
            {

                EndLocation = e.Location;

                IsMouseDown = false;

                if (rect != null)
                {

                    if (rect.Width > 1 || rect.Height > 1 || this.orginal_image_pictureBox.Image != null)
                    {

                        AddDefaultLogo addDefaultLogo = new AddDefaultLogo();

                        addDefaultLogo.Orginal_Image=
                            ImageProcessor.CutImage(
                                rect,
                                new Bitmap(this.orginal_image_pictureBox.Image)
                                .ToImage<Bgr, byte>());

                        addDefaultLogo.showForm();

                    }
                   

                }


            }

        }

        private void next_button_Click(object sender, EventArgs e)
        {

            if (CurrentImageIndex != 0)
            {
                CurrentImageIndex -= 1;
                sniped_image_pictureBox.Image = SelectedImages[CurrentImageIndex];
                this.current_selected_image.Text = (SelectedImages.Count - CurrentImageIndex).ToString() + @"\" + (SelectedImages.Count - 1).ToString();


            }
            else CurrentImageIndex = SelectedImages.Count - 1;

        }

        private void back_button_Click(object sender, EventArgs e)
        {

            if (CurrentImageIndex != (SelectedImages.Count - 1))
            {
                CurrentImageIndex += 1;
                sniped_image_pictureBox.Image = SelectedImages[CurrentImageIndex];
                this.current_selected_image.Text = (SelectedImages.Count - CurrentImageIndex).ToString() + @"\" + (SelectedImages.Count - 1).ToString();


            }
            else CurrentImageIndex = 0;
        }

        public void refrech_ideal_set_comboBox()
        {

            foreach (KeyValuePair<int, string> keyValue in Central_Static_Value.Train_Model.neuron2identity)
                if(!Ideal_Set_comboBox.Items.Contains(keyValue.Value))
                         Ideal_Set_comboBox.Items.Add(keyValue.Value);
            

        }

        int AssignIdentity(String identity)
        {
            if (Central_Static_Value.Train_Model.identity2neuron.ContainsKey(identity.ToLower()))
            {
                return Central_Static_Value.Train_Model.identity2neuron[identity.ToLower()];
            }

            int result = Central_Static_Value.Train_Model.outputCount;

            Central_Static_Value.Train_Model.identity2neuron[identity.ToLower()] = result;

            Central_Static_Value.Train_Model.neuron2identity[result] = identity.ToLower();

            Central_Static_Value.Train_Model.outputCount++;

            return result;

        }

        private void Export_button_Click(object sender, EventArgs e)
        {

            try
            {

                if (!string.IsNullOrEmpty(Image_name_textBox.Text)||Ideal_Set_comboBox.SelectedIndex!=-1)
                {

                    string imageName = Image_name_textBox.Text;

                    string selecteditem = Ideal_Set_comboBox.SelectedItem.ToString();

                    int match = AssignIdentity(selecteditem);

                    Central_Static_Value.Train_Model.to_Train_Images_dataGridView.Rows.Add(imageName, match, ImageProcessor.ResizeImage(sniped_image_pictureBox.Image, 32, 32));

                    TrainingSet trainingSet = new TrainingSet(imageName,match, ImageProcessor.ResizeImage(sniped_image_pictureBox.Image, 32, 32),false);

                    Central_Static_Value.Train_Model.TrainingSetList.Add(trainingSet);

                }
                else
                {

                    MessageBox.Show("please fill all requiret Felds");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void ShowAvelableIdealSets_Click(object sender, EventArgs e)
        {

            MessageBox.Show(AvilebleIdealSets+"outputs Count = "+ Central_Static_Value.Train_Model.outputCount);
        }

        private void Ideal_Set_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

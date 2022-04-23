using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tensorflow.Keras.Engine;
using Tensorflow.NumPy;

namespace LogoBasedDocumentSorter
{
    public partial class ModelTesting : Form
    {
        public ModelTesting()
        {
            InitializeComponent();
        }

        ImageProcessor ImageProcessor = new ImageProcessor();

        Image orginal_Image { get; set; }

        Functional Model => Central_Static_Value.Train_Model.Model;

        List<Bitmap> SelectedImages = new List<Bitmap>();

        int CurrentImageIndex { get; set; }

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

        Winner getWinnerNeuron(NDArray nDarray)
        {

            Tensorflow.Tensor tensor = Model.predict(x:nDarray);

            List<float> valueslist = tensor[0].ToArray<float>().ToList();

            var winner = valueslist[0];

            int index = 0;
            
            for (int i = 0; i < (valueslist.Count); i++)
            {

                if (valueslist[i]> winner)
                {
                    winner = valueslist[i];
                    index = i;

                }
             
            }

              return new Winner(index,winner);
            
        }

        private void Test_button_Click(object sender, EventArgs e)
        {
           
            List<Blob> selectedBlobs = ImageProcessor.getBiggestBlobsInImage(new Bitmap(orginal_Image), 220, 20, 30, 500, 500);

            SelectedImages = selectedBlobs.Select(x => x.BMP).ToList();

            try
            {
                for (int i = 0; i < selectedBlobs.Count; i++)
                {

                    using (var graphics = Graphics.FromImage(orginal_Image))
                    {
                        graphics.DrawRectangle(Pens.Black, selectedBlobs[i].Rectangle);

                        using (Font arialFont = new Font("Arial", 9))
                        {

                            var bitmap = ImageProcessor.ResizeImage(selectedBlobs[i].BMP, 32, 32);

                            NDArray nDarray = addimagepixelstoarray(new Bitmap(bitmap));

                            nDarray = nDarray.astype(np.float32);

                            nDarray /= 255;

                            string result = Central_Static_Value.Train_Model.neuron2identity[getWinnerNeuron(nDarray).Neuron];

                            graphics.DrawString(result+" , "+i.ToString(), arialFont, Brushes.Red, selectedBlobs[i].Rectangle.X, selectedBlobs[i].Rectangle.Y);

                        }
                    }
                }


                orginal_image_pictureBox.Image = orginal_Image;
                CurrentImageIndex = selectedBlobs.Count - 1;
                sniped_image_pictureBox.Image = selectedBlobs[CurrentImageIndex].BMP;
                var bmp = ImageProcessor.ResizeImage(selectedBlobs[CurrentImageIndex].BMP, 32, 32);
                NDArray nDa = addimagepixelstoarray(new Bitmap(bmp));
                nDa = nDa.astype(np.float32);
                nDa /= 255;
                Winner winner = getWinnerNeuron(nDa);
                string rslt = Central_Static_Value.Train_Model.neuron2identity[winner.Neuron];
                this.Neuron_textBox.Text = rslt;
                this.value_textBox.Text = winner.Value.ToString();
                this.current_selected_image.Text = (selectedBlobs.Count - CurrentImageIndex).ToString() + @"\" + (selectedBlobs.Count - 1).ToString();
                next_button.Enabled = true;
                back_button.Enabled = true;



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            


        }

        public int[,,] getPixels(Bitmap image)
        {

            int[,,] pixels = new int[image.Width, image.Height, 3];



            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {

                    Color pixel = image.GetPixel(i, j);

                    pixels[i, j, 0] = pixel.R;
                    pixels[i, j, 1] = pixel.G;
                    pixels[i, j, 2] = pixel.B;

                }

            }

            return pixels;

        }

        public NDArray addimagepixelstoarray(Bitmap bitmap)
        {

            int[,,,] imagespixels = new int[1, bitmap.Width, bitmap.Height, 3];

            for (int bi = 0; bi < 1; bi++)
            {

                int[,,] pixels = getPixels(bitmap);

                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Width; y++)
                    {

                        for (int z = 0; z < 3; z++)
                        {

                            imagespixels[bi, x, y, z] = pixels[x, y, z];


                        }

                    }


                }


            }

            return np.array(imagespixels);


        }

        private void next_button_Click(object sender, EventArgs e)
        {
            if (CurrentImageIndex != 0)
            {
                CurrentImageIndex -= 1;
                sniped_image_pictureBox.Image = SelectedImages[CurrentImageIndex];
                var bitmap = ImageProcessor.ResizeImage(SelectedImages[CurrentImageIndex], 32, 32);
                NDArray nDarray = addimagepixelstoarray(new Bitmap(bitmap));
                nDarray = nDarray.astype(np.float32);
                nDarray /= 255;
                Winner winner = getWinnerNeuron(nDarray);
                string rslt = Central_Static_Value.Train_Model.neuron2identity[winner.Neuron];
                this.Neuron_textBox.Text = rslt;
                this.value_textBox.Text = winner.Value.ToString();
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
                var bitmap = ImageProcessor.ResizeImage(SelectedImages[CurrentImageIndex], 32, 32);
                NDArray nDarray = addimagepixelstoarray(new Bitmap(bitmap));
                nDarray = nDarray.astype(np.float32);
                nDarray /= 255;
                Winner winner = getWinnerNeuron(nDarray);
                string rslt = Central_Static_Value.Train_Model.neuron2identity[winner.Neuron];
                this.Neuron_textBox.Text = rslt;
                this.value_textBox.Text = winner.Value.ToString();
                this.current_selected_image.Text = (SelectedImages.Count - CurrentImageIndex).ToString() + @"\" + (SelectedImages.Count - 1).ToString();


            }
            else CurrentImageIndex = 0;
        }

    }

    public class Winner
    { 
    
        public int Neuron { get; set; }

        public double Value { get; set; }

        public Winner(int neuron ,double value)
        {

            this.Neuron = neuron;
            this.Value = value;
        
        }
    
    
    }

}

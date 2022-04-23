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
using Tensorflow.Keras.Engine;
using Tensorflow.NumPy;

namespace LogoBasedDocumentSorter
{
    public partial class LogoBasedDocumentsSorter : Form
    {
        public LogoBasedDocumentsSorter()
        {
            InitializeComponent();
            Central_Static_Value.LogoBasedDocuSorter = this;
        }

        
        public Functional Model { get; set; }

        List<string> FilesPath = new List<string>();

        public IDictionary<String, int> identity2neuron { get; set; }

        public IDictionary<int, String> neuron2identity { get; set; }

        private void Train_Networks_button_Click(object sender, EventArgs e)
        {
            Train_Model train_Model = new Train_Model();
            train_Model.ShowDialog();
        }

        private void Images_folder_button_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    this.Image_Folder_path.Text = fbd.SelectedPath;

                }
            }

            getFielslFromFolderInDatagrid();

        }

        private void Target_folder_button_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    this.Target_Folder_path.Text = fbd.SelectedPath;

                }
            }

        }



        private void getFielslFromFolderInDatagrid()
        {

            try
            {

                string supportedExtensions = "*.jpg,*.gif,*.png,*.bmp,*.jpe,*.jpeg,*.tif,*.tiff";

                if (this.Sorted_document_dataGridView.Rows.Count == 0)
                {
                    string[] files = Directory.GetFiles(this.Image_Folder_path.Text, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();

                    if (files != null)
                    {
                        for (int i = 0; i < files.Length; i++)
                        {

                            FilesPath.Add(files[i]);

                            string fileName = Path.GetFileName(files[i]);

                            this.Sorted_document_dataGridView.Rows.Add((i + 1).ToString(), fileName);

                        }
                    }
                }
                else
                {

                    this.Sorted_document_dataGridView.Rows.Clear();

                    string[] files = Directory.GetFiles(this.Image_Folder_path.Text).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();

                    if (files != null)
                    {
                        for (int i = 0; i < files.Length; i++)
                        {

                            FilesPath.Add(files[i]);

                            string fileName = Path.GetFileName(files[i]);

                            this.Sorted_document_dataGridView.Rows.Add((i + 1).ToString(), fileName);

                        }
                    }

                }
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

        private void start_button_Click(object sender, EventArgs e)
        {

            if (FilesPath.Count != 0)
            {


                for (int i = 0; i < FilesPath.Count; i++)
                {
                    try
                    {

                        string logoname = string.Empty;

                        using (Bitmap refs = new Bitmap(FilesPath[i]))
                        {

                            logoname = checkDocument(refs);

                            ImageProcessor imageProcessor = new ImageProcessor();

                            Invoke(new Action(() => { this.Sorted_document_dataGridView.Rows[i].Cells[2].Value = logoname; }));

                            string templatename = logoname;

                            string targetPath = this.Target_Folder_path.Text + "/" + (i + 1).ToString() + " - " + " " + templatename + ".png";

                            refs.Save(targetPath);

                        }


                    }
                    catch (Exception ex)
                    {

                        if (this.Sorted_document_dataGridView.Rows.Count != 0)

                            Invoke(new Action(() => { this.Sorted_document_dataGridView.Rows[i].Cells[2].Value = ex.Message; }));



                    }



                    progressBar1.Value=((((i + 1) * 100) / FilesPath.Count));

                }
            }

        }

        Winner getWinnerNeuron(NDArray nDarray)
        {

            Tensorflow.Tensor tensor = Model.predict(x: nDarray);

            List<float> valueslist = tensor[0].ToArray<float>().ToList();

            var winner = valueslist[0];

            int index = 0;

            for (int i = 0; i < (valueslist.Count); i++)
            {

                if (valueslist[i] > winner)
                {
                    winner = valueslist[i];
                    index = i;

                }

            }

            return new Winner(index, winner);

        }
        private string checkDocument(Bitmap docu)
        {

            ImageProcessor imgp = new ImageProcessor();

            List<Blob> blobs = imgp.getBiggestBlobsInImage(docu, 220, 20, 30, 500, 500);

            string result = neuron2identity[0];

            foreach (Blob blob in blobs)
            {

                Bitmap img = imgp.ResizeImage(blob.BMP, 32, 32);

                NDArray nDarray = addimagepixelstoarray(new Bitmap(img));

                nDarray = nDarray.astype(np.float32);

                nDarray /= 255;

               result = neuron2identity[getWinnerNeuron(nDarray).Neuron];

                if (result != neuron2identity[0])
                    break;


            }


            return result;



        }
        private void start_sorting_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (FilesPath.Count != 0)
            {


                for (int i = 0; i < FilesPath.Count; i++)
                {
                    try
                    {
                        
                        string logoname = string.Empty;

                        using (Bitmap refs = new Bitmap(FilesPath[i]))
                        {

                            logoname = checkDocument(refs);

                            ImageProcessor imageProcessor = new ImageProcessor();

                            Invoke(new Action(() => { this.Sorted_document_dataGridView.Rows[i].Cells[2].Value = logoname; })); 
                            
                            string templatename = logoname;
                            
                            string targetPath = this.Target_Folder_path.Text + "/" + (i + 1).ToString() + " - " + " " + templatename + ".png";

                            refs.Save(targetPath);

                        }


                    }
                    catch (Exception ex)
                    {

                        if (this.Sorted_document_dataGridView.Rows.Count != 0)

                            Invoke(new Action(() => { this.Sorted_document_dataGridView.Rows[i].Cells[2].Value = ex.Message; }));



                    }

                   

                    start_sorting_backgroundWorker.ReportProgress((((i + 1) * 100) / FilesPath.Count));

                }
            }

        }

        private void start_sorting_backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tensorflow.Keras.Layers;
using static Tensorflow.Binding;
using static Tensorflow.KerasApi;
using Tensorflow;
using Tensorflow.NumPy;
using Tensorflow.Keras.Utils;
using Tensorflow.Keras.Engine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LogoBasedDocumentSorter
{
    public partial class Train_Model : Form
    {
        public Train_Model()
        {
            InitializeComponent();
            Central_Static_Value.Train_Model = this;
            Console.SetOut(new ControlWriter(log_textBox));
            inti_negative_value();
        }

        public Functional Model { get; set; }

        public List<TrainingSet> TrainingSetList = new List<TrainingSet>();

        public List<Logo> Logos = new List<Logo>();

        public int outputCount = 0;

        public IDictionary<String, int> identity2neuron = new Dictionary<String, int>();

        public IDictionary<int, String> neuron2identity = new Dictionary<int, String>();

        private void add_image_button_Click(object sender, EventArgs e)
        {

            snipImage snipImage = new snipImage();
            snipImage.ShowDialog();

        }

        private void Export_Model_button_Click(object sender, EventArgs e)
        {

            foreach (TrainingSet logo in TrainingSetList)
                if(logo.isLogo)
                   Central_Static_Value.LogoBasedDocuSorter.Trained_Networks_dataGridView.Rows.Add(logo.ImageName, logo.Image, logo.Match);

            Central_Static_Value.LogoBasedDocuSorter.identity2neuron = identity2neuron;

            Central_Static_Value.LogoBasedDocuSorter.neuron2identity = neuron2identity;

            Central_Static_Value.LogoBasedDocuSorter.Model = Model;

            this.Close();

        }

        void inti_negative_value()
        {

            int result = outputCount;

            identity2neuron["Negative".ToLower()] = result;

            neuron2identity[result] = "Negative".ToLower();

            outputCount++;

        }

        public NDArray addidelavaluestoarray(List<TrainingSet> images)
        {

            int[,] idealvalues = new int[images.Count, outputCount];

            for (int i = 0; i < images.Count; i++)
            {
                for (int j = 0; j < outputCount; j++)
                {

                    if (j == images[i].Match)
                        idealvalues[i, j] = 1;

                    else idealvalues[i, j] = 0;

                }

            }


            return np.array(idealvalues);

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


        public NDArray addimagepixelstoarray(List<TrainingSet> bitmaps, int width, int height)
        {

            int[,,,] imagespixels = new int[bitmaps.Count, width, height, 3];

            for (int bi = 0; bi < bitmaps.Count; bi++)
            {

                Bitmap bitmap = bitmaps[bi].Image;

                int[,,] pixels = getPixels(bitmap);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
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

        private void start_learning_button_Click(object sender, EventArgs e)
        {

            try
            {
                var layers = new LayersApi();

                var inputs = keras.Input(shape: (32, 32, 3), name: "img");

                var x = layers.Conv2D(32, (3, 3), activation: "relu", padding: "same").Apply(inputs);

                x = layers.Conv2D(32, (3, 3), activation: "relu", padding: "same").Apply(x);

                x = layers.MaxPooling2D(pool_size: (2, 2)).Apply(x);

                x = layers.Dropout(0.25f).Apply(x);

                x = layers.Conv2D(64, (3, 3), activation: "relu", padding: "same").Apply(x);

                x = layers.Conv2D(64, (3, 3), activation: "relu", padding: "same").Apply(x);

                x = layers.MaxPooling2D(pool_size: (2, 2)).Apply(x);

                x = layers.Dropout(0.25f).Apply(x);

                x = layers.Conv2D(128, (3, 3), activation: "relu", padding: "same").Apply(x);

                x = layers.Conv2D(128, (3, 3), activation: "relu", padding: "same").Apply(x);

                x = layers.MaxPooling2D(pool_size: (2, 2)).Apply(x);

                x = layers.Dropout(0.25f).Apply(x);
                x = layers.Flatten().Apply(x);

                x = layers.Dense(256, activation: "relu").Apply(x);

                x = layers.Dense(128, activation: "relu").Apply(x);

                var outputs = layers.Dense(outputCount, activation: "softmax").Apply(x);

                NDArray x_train = addimagepixelstoarray(this.TrainingSetList, 32, 32);

                NDArray y_train = addidelavaluestoarray(this.TrainingSetList);

                x_train = x_train.astype(np.float32);

                x_train /= 255;

                Model = keras.Model(inputs, outputs, name: "toy_resnet");

                var opt = new Tensorflow.Keras.Optimizers.Adam(learning_rate: 0.001f);

                Model.compile(optimizer: opt,
                              loss: keras.losses.CategoricalCrossentropy(),
                              metrics: new[] { "acc" });

                Model.fit(x_train, y_train, epochs: (int)Epoches_numericUpDown.Value);

                Invoke(new Action(() => { this.Test_network_button.Enabled = true; }));

                Invoke(new Action(() => { this.Export_Model_button.Enabled = true; }));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void start_learning_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {


        }

        private void Test_network_button_Click(object sender, EventArgs e)
        {
            ModelTesting modelTesting = new ModelTesting();
            modelTesting.ShowDialog();
        }

        private void to_Train_Images_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
              e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 2)
                {

                }

                if (e.ColumnIndex == 3)
                {

                    this.TrainingSetList.RemoveAt(e.RowIndex);
                    this.to_Train_Images_dataGridView.Rows.Clear();
                    foreach(TrainingSet trainingSet in this.TrainingSetList)
                          this.to_Train_Images_dataGridView.Rows.Add(trainingSet.ImageName,trainingSet.Match,trainingSet.Image);
                    this.to_Train_Images_dataGridView.Refresh();


                }


            }

        }


        private void to_Train_Images_dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
              e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 3)
                {

                    to_Train_Images_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;

                }



            }
        }

        private void to_Train_Images_dataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
              e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 3)
                {

                    to_Train_Images_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;

                }



            }

        }

        private void Save_Train_Data_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileStream stream = new FileStream(folderDlg.SelectedPath+ "/TrainingSetList.logosorterdataset", FileMode.Create, FileAccess.Write, FileShare.None);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, TrainingSetList);
                stream.Close();
            }
           
            
        }

        private void Load_Train_Data_Click(object sender, EventArgs e)
        {

            OpenFileDialog getdataset = new OpenFileDialog();

            getdataset.Filter = "logosorterdataset|*.logosorterdataset;";

            DialogResult result = getdataset.ShowDialog();

            if (result == DialogResult.OK)
            {

                FileStream stream = new FileStream(getdataset.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                IFormatter formatter = new BinaryFormatter();
                List<TrainingSet> TrainingSets = (List<TrainingSet>)formatter.Deserialize(stream);
                this.TrainingSetList = TrainingSets;
                this.to_Train_Images_dataGridView.Rows.Clear();
                outputCount = 0;
                identity2neuron.Clear();
                neuron2identity.Clear();
                inti_negative_value();
                foreach (TrainingSet trainingSet in this.TrainingSetList)
                { 
                    
                    this.to_Train_Images_dataGridView.Rows.Add(trainingSet.ImageName, trainingSet.Match, trainingSet.Image);
                    if (trainingSet.isLogo)
                    {

                        AssignIdentity(trainingSet.ImageName);

                    }
                    
                } 
                this.to_Train_Images_dataGridView.Refresh();
               

                stream.Close();
            }

        }

        int AssignIdentity(String identity)
        {

            if (identity2neuron.ContainsKey(identity.ToLower()))
            {
                return identity2neuron[identity.ToLower()];
            }

            int result = outputCount;

            identity2neuron[identity.ToLower()] = result;

            neuron2identity[result] = identity.ToLower();

            outputCount++;

            return result;

        }
    }


    [Serializable]
    public class TrainingSet
    {
        public string ImageName { get; set; }
        public int Match { get; set; }

        public Bitmap Image { get; set; }

        public bool isLogo { get; set; }

            public TrainingSet(string ImgName, int match, Bitmap image,bool islogo)
            {

                this.ImageName = ImgName;
               
                this.Match = match;

                this.Image = image;

                this.isLogo = islogo;

            }

        }

        public class Logo
        {

            public string Name { get; set; }

            public Bitmap Image { get; set; }

            public string Neuron { get; set; }

            public Logo(string name, Bitmap image, string neuron)
            {

                this.Name = name;
                this.Image = image;
                this.Neuron = neuron;
            }


        }

    
    
}

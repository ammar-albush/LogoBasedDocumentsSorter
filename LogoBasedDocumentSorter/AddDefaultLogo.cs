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
    public partial class AddDefaultLogo : Form
    {

        public Bitmap Orginal_Image { get; set; }

        ImageProcessor ImageProcessor = new ImageProcessor();

        public AddDefaultLogo()
        {
            InitializeComponent();
          
        }

       public void showForm()
        {

            if(Orginal_Image!=null)
                    this.sniped_image_pictureBox.Image = Orginal_Image;

            this.ShowDialog();
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
          
            if (!string.IsNullOrEmpty(Image_name_textBox.Text) || !string.IsNullOrEmpty(Ideal_Set_textBox.Text))
            {

                Central_Static_Value.Train_Model.Logos.Add(new Logo(Image_name_textBox.Text, ImageProcessor.ResizeImage(sniped_image_pictureBox.Image, 32, 32),Ideal_Set_textBox.Text));
                
                int match = AssignIdentity(Ideal_Set_textBox.Text);
                
                Central_Static_Value.snipImage.refrech_ideal_set_comboBox();

                Central_Static_Value.Train_Model.to_Train_Images_dataGridView.Rows.Add(Image_name_textBox.Text, match, ImageProcessor.ResizeImage(sniped_image_pictureBox.Image, 32, 32));
                
                TrainingSet trainingSet = new TrainingSet(Image_name_textBox.Text,match, ImageProcessor.ResizeImage(sniped_image_pictureBox.Image, 32, 32),true);

                Central_Static_Value.Train_Model.TrainingSetList.Add(trainingSet);

                
            }
            else
            {

                MessageBox.Show("please fill all requiret Felds");

            }

            this.Close();

        }
    }
}

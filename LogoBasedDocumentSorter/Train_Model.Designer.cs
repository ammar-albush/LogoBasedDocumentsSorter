
namespace LogoBasedDocumentSorter
{
    partial class Train_Model
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Train_Model));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Load_Train_Data = new System.Windows.Forms.Button();
            this.Save_Train_Data = new System.Windows.Forms.Button();
            this.Test_network_button = new System.Windows.Forms.Button();
            this.Export_Model_button = new System.Windows.Forms.Button();
            this.log_textBox = new System.Windows.Forms.TextBox();
            this.start_learning_button = new System.Windows.Forms.Button();
            this.Epoches_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.to_Train_Images_dataGridView = new System.Windows.Forms.DataGridView();
            this.Img_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img_Match = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.train_img = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete_bmp = new System.Windows.Forms.DataGridViewImageColumn();
            this.add_image_button = new System.Windows.Forms.Button();
            this.start_learning_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Epoches_numericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.to_Train_Images_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Load_Train_Data);
            this.panel1.Controls.Add(this.Save_Train_Data);
            this.panel1.Controls.Add(this.Test_network_button);
            this.panel1.Controls.Add(this.Export_Model_button);
            this.panel1.Controls.Add(this.log_textBox);
            this.panel1.Controls.Add(this.start_learning_button);
            this.panel1.Controls.Add(this.Epoches_numericUpDown);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.add_image_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 856);
            this.panel1.TabIndex = 2;
            // 
            // Load_Train_Data
            // 
            this.Load_Train_Data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.Load_Train_Data.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Load_Train_Data.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Load_Train_Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_Train_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_Train_Data.ForeColor = System.Drawing.Color.White;
            this.Load_Train_Data.Location = new System.Drawing.Point(67, 105);
            this.Load_Train_Data.Name = "Load_Train_Data";
            this.Load_Train_Data.Size = new System.Drawing.Size(125, 30);
            this.Load_Train_Data.TabIndex = 14;
            this.Load_Train_Data.Text = "Load Train Data";
            this.Load_Train_Data.UseVisualStyleBackColor = false;
            this.Load_Train_Data.Click += new System.EventHandler(this.Load_Train_Data_Click);
            // 
            // Save_Train_Data
            // 
            this.Save_Train_Data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.Save_Train_Data.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Save_Train_Data.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Save_Train_Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Train_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Train_Data.ForeColor = System.Drawing.Color.White;
            this.Save_Train_Data.Location = new System.Drawing.Point(498, 297);
            this.Save_Train_Data.Name = "Save_Train_Data";
            this.Save_Train_Data.Size = new System.Drawing.Size(125, 30);
            this.Save_Train_Data.TabIndex = 13;
            this.Save_Train_Data.Text = "Save Train Data";
            this.Save_Train_Data.UseVisualStyleBackColor = false;
            this.Save_Train_Data.Click += new System.EventHandler(this.Save_Train_Data_Click);
            // 
            // Test_network_button
            // 
            this.Test_network_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.Test_network_button.Enabled = false;
            this.Test_network_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Test_network_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Test_network_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Test_network_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Test_network_button.ForeColor = System.Drawing.Color.White;
            this.Test_network_button.Location = new System.Drawing.Point(83, 502);
            this.Test_network_button.Name = "Test_network_button";
            this.Test_network_button.Size = new System.Drawing.Size(109, 30);
            this.Test_network_button.TabIndex = 12;
            this.Test_network_button.Text = "Test Network";
            this.Test_network_button.UseVisualStyleBackColor = false;
            this.Test_network_button.Click += new System.EventHandler(this.Test_network_button_Click);
            // 
            // Export_Model_button
            // 
            this.Export_Model_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.Export_Model_button.Enabled = false;
            this.Export_Model_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Export_Model_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Export_Model_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export_Model_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export_Model_button.ForeColor = System.Drawing.Color.White;
            this.Export_Model_button.Location = new System.Drawing.Point(658, 688);
            this.Export_Model_button.Name = "Export_Model_button";
            this.Export_Model_button.Size = new System.Drawing.Size(109, 30);
            this.Export_Model_button.TabIndex = 11;
            this.Export_Model_button.Text = "Exprot Model";
            this.Export_Model_button.UseVisualStyleBackColor = false;
            this.Export_Model_button.Click += new System.EventHandler(this.Export_Model_button_Click);
            // 
            // log_textBox
            // 
            this.log_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.log_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log_textBox.ForeColor = System.Drawing.Color.White;
            this.log_textBox.Location = new System.Drawing.Point(219, 448);
            this.log_textBox.Multiline = true;
            this.log_textBox.Name = "log_textBox";
            this.log_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log_textBox.Size = new System.Drawing.Size(548, 212);
            this.log_textBox.TabIndex = 9;
            // 
            // start_learning_button
            // 
            this.start_learning_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.start_learning_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.start_learning_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.start_learning_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_learning_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_learning_button.ForeColor = System.Drawing.Color.White;
            this.start_learning_button.Location = new System.Drawing.Point(83, 448);
            this.start_learning_button.Name = "start_learning_button";
            this.start_learning_button.Size = new System.Drawing.Size(109, 30);
            this.start_learning_button.TabIndex = 8;
            this.start_learning_button.Text = "Start Learning";
            this.start_learning_button.UseVisualStyleBackColor = false;
            this.start_learning_button.Click += new System.EventHandler(this.start_learning_button_Click);
            // 
            // Epoches_numericUpDown
            // 
            this.Epoches_numericUpDown.Location = new System.Drawing.Point(217, 357);
            this.Epoches_numericUpDown.Name = "Epoches_numericUpDown";
            this.Epoches_numericUpDown.Size = new System.Drawing.Size(128, 20);
            this.Epoches_numericUpDown.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Epochs : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(121)))));
            this.panel2.Controls.Add(this.to_Train_Images_dataGridView);
            this.panel2.Location = new System.Drawing.Point(217, 59);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(406, 219);
            this.panel2.TabIndex = 5;
            // 
            // to_Train_Images_dataGridView
            // 
            this.to_Train_Images_dataGridView.AllowUserToAddRows = false;
            this.to_Train_Images_dataGridView.AllowUserToDeleteRows = false;
            this.to_Train_Images_dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.to_Train_Images_dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.to_Train_Images_dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.to_Train_Images_dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.to_Train_Images_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.to_Train_Images_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Img_Name,
            this.Img_Match,
            this.train_img,
            this.delete_bmp});
            this.to_Train_Images_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.to_Train_Images_dataGridView.Location = new System.Drawing.Point(2, 2);
            this.to_Train_Images_dataGridView.Name = "to_Train_Images_dataGridView";
            this.to_Train_Images_dataGridView.ReadOnly = true;
            this.to_Train_Images_dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.to_Train_Images_dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.to_Train_Images_dataGridView.Size = new System.Drawing.Size(402, 215);
            this.to_Train_Images_dataGridView.TabIndex = 2;
            this.to_Train_Images_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.to_Train_Images_dataGridView_CellContentClick);
            this.to_Train_Images_dataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.to_Train_Images_dataGridView_CellMouseLeave);
            this.to_Train_Images_dataGridView.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.to_Train_Images_dataGridView_CellMouseMove);
            // 
            // Img_Name
            // 
            this.Img_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Img_Name.HeaderText = "Name";
            this.Img_Name.Name = "Img_Name";
            this.Img_Name.ReadOnly = true;
            // 
            // Img_Match
            // 
            this.Img_Match.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Img_Match.HeaderText = "Match";
            this.Img_Match.Name = "Img_Match";
            this.Img_Match.ReadOnly = true;
            this.Img_Match.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Img_Match.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // train_img
            // 
            this.train_img.HeaderText = "Image";
            this.train_img.Name = "train_img";
            this.train_img.ReadOnly = true;
            // 
            // delete_bmp
            // 
            this.delete_bmp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.delete_bmp.DefaultCellStyle = dataGridViewCellStyle5;
            this.delete_bmp.HeaderText = "Delete";
            this.delete_bmp.Image = global::LogoBasedDocumentSorter.Properties.Resources.icons8_löschen_24;
            this.delete_bmp.Name = "delete_bmp";
            this.delete_bmp.ReadOnly = true;
            this.delete_bmp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // add_image_button
            // 
            this.add_image_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.add_image_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.add_image_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.add_image_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_image_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_image_button.ForeColor = System.Drawing.Color.White;
            this.add_image_button.Location = new System.Drawing.Point(67, 59);
            this.add_image_button.Name = "add_image_button";
            this.add_image_button.Size = new System.Drawing.Size(125, 30);
            this.add_image_button.TabIndex = 4;
            this.add_image_button.Text = "Add Image";
            this.add_image_button.UseVisualStyleBackColor = false;
            this.add_image_button.Click += new System.EventHandler(this.add_image_button_Click);
            // 
            // start_learning_backgroundWorker
            // 
            this.start_learning_backgroundWorker.WorkerReportsProgress = true;
            this.start_learning_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.start_learning_backgroundWorker_DoWork);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.Image = global::LogoBasedDocumentSorter.Properties.Resources.icons8_löschen_24;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Train_Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 856);
            this.Controls.Add(this.panel1);
            this.Name = "Train_Model";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Train_Model";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Epoches_numericUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.to_Train_Images_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Test_network_button;
        private System.Windows.Forms.Button Export_Model_button;
        private System.Windows.Forms.TextBox log_textBox;
        private System.Windows.Forms.Button start_learning_button;
        private System.Windows.Forms.NumericUpDown Epoches_numericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView to_Train_Images_dataGridView;
        private System.Windows.Forms.Button add_image_button;
        private System.ComponentModel.BackgroundWorker start_learning_backgroundWorker;
        private System.Windows.Forms.Button Load_Train_Data;
        private System.Windows.Forms.Button Save_Train_Data;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Img_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Img_Match;
        private System.Windows.Forms.DataGridViewImageColumn train_img;
        private System.Windows.Forms.DataGridViewImageColumn delete_bmp;
    }
}
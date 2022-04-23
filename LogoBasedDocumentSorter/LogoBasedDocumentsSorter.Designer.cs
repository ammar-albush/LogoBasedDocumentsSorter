
namespace LogoBasedDocumentSorter
{
    partial class LogoBasedDocumentsSorter
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.start_button = new System.Windows.Forms.Button();
            this.Target_Folder_path = new System.Windows.Forms.Button();
            this.Image_Folder_path = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Sorted_document_dataGridView = new System.Windows.Forms.DataGridView();
            this.id_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target_Folder_button = new System.Windows.Forms.Button();
            this.Image_Folder_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Trained_Networks_dataGridView = new System.Windows.Forms.DataGridView();
            this.Train_Networks_button = new System.Windows.Forms.Button();
            this.Logo_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logo_Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Logo_neuron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_sorting_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sorted_document_dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Trained_Networks_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.start_button);
            this.panel1.Controls.Add(this.Target_Folder_path);
            this.panel1.Controls.Add(this.Image_Folder_path);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Target_Folder_button);
            this.panel1.Controls.Add(this.Image_Folder_button);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Train_Networks_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 888);
            this.panel1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(259, 493);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(358, 30);
            this.progressBar1.TabIndex = 11;
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.start_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.start_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.ForeColor = System.Drawing.Color.White;
            this.start_button.Location = new System.Drawing.Point(533, 763);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(84, 30);
            this.start_button.TabIndex = 10;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Target_Folder_path
            // 
            this.Target_Folder_path.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(121)))));
            this.Target_Folder_path.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Target_Folder_path.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Target_Folder_path.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Target_Folder_path.Location = new System.Drawing.Point(259, 433);
            this.Target_Folder_path.Name = "Target_Folder_path";
            this.Target_Folder_path.Size = new System.Drawing.Size(356, 30);
            this.Target_Folder_path.TabIndex = 9;
            this.Target_Folder_path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Target_Folder_path.UseVisualStyleBackColor = true;
            // 
            // Image_Folder_path
            // 
            this.Image_Folder_path.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(121)))));
            this.Image_Folder_path.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Image_Folder_path.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Image_Folder_path.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Image_Folder_path.Location = new System.Drawing.Point(259, 365);
            this.Image_Folder_path.Name = "Image_Folder_path";
            this.Image_Folder_path.Size = new System.Drawing.Size(356, 30);
            this.Image_Folder_path.TabIndex = 8;
            this.Image_Folder_path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Image_Folder_path.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(121)))));
            this.panel3.Controls.Add(this.Sorted_document_dataGridView);
            this.panel3.Location = new System.Drawing.Point(259, 529);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(358, 219);
            this.panel3.TabIndex = 6;
            // 
            // Sorted_document_dataGridView
            // 
            this.Sorted_document_dataGridView.AllowUserToAddRows = false;
            this.Sorted_document_dataGridView.AllowUserToDeleteRows = false;
            this.Sorted_document_dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Sorted_document_dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Sorted_document_dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Sorted_document_dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Sorted_document_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Sorted_document_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Column,
            this.Name_Column,
            this.status_column});
            this.Sorted_document_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sorted_document_dataGridView.Location = new System.Drawing.Point(2, 2);
            this.Sorted_document_dataGridView.Name = "Sorted_document_dataGridView";
            this.Sorted_document_dataGridView.ReadOnly = true;
            this.Sorted_document_dataGridView.RowHeadersVisible = false;
            this.Sorted_document_dataGridView.Size = new System.Drawing.Size(354, 215);
            this.Sorted_document_dataGridView.TabIndex = 2;
            // 
            // id_Column
            // 
            this.id_Column.HeaderText = "id";
            this.id_Column.Name = "id_Column";
            this.id_Column.ReadOnly = true;
            // 
            // Name_Column
            // 
            this.Name_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name_Column.HeaderText = "Name";
            this.Name_Column.Name = "Name_Column";
            this.Name_Column.ReadOnly = true;
            // 
            // status_column
            // 
            this.status_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status_column.HeaderText = "Status";
            this.status_column.Name = "status_column";
            this.status_column.ReadOnly = true;
            this.status_column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Target_Folder_button
            // 
            this.Target_Folder_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.Target_Folder_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Target_Folder_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Target_Folder_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Target_Folder_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Target_Folder_button.ForeColor = System.Drawing.Color.White;
            this.Target_Folder_button.Location = new System.Drawing.Point(126, 433);
            this.Target_Folder_button.Name = "Target_Folder_button";
            this.Target_Folder_button.Size = new System.Drawing.Size(109, 30);
            this.Target_Folder_button.TabIndex = 5;
            this.Target_Folder_button.Text = "Target Folder";
            this.Target_Folder_button.UseVisualStyleBackColor = false;
            this.Target_Folder_button.Click += new System.EventHandler(this.Target_folder_button_Click);
            // 
            // Image_Folder_button
            // 
            this.Image_Folder_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.Image_Folder_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Image_Folder_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Image_Folder_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Image_Folder_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Image_Folder_button.ForeColor = System.Drawing.Color.White;
            this.Image_Folder_button.Location = new System.Drawing.Point(126, 365);
            this.Image_Folder_button.Name = "Image_Folder_button";
            this.Image_Folder_button.Size = new System.Drawing.Size(109, 30);
            this.Image_Folder_button.TabIndex = 4;
            this.Image_Folder_button.Text = "Image Folder";
            this.Image_Folder_button.UseVisualStyleBackColor = false;
            this.Image_Folder_button.Click += new System.EventHandler(this.Images_folder_button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(121)))));
            this.panel2.Controls.Add(this.Trained_Networks_dataGridView);
            this.panel2.Location = new System.Drawing.Point(259, 75);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(358, 219);
            this.panel2.TabIndex = 3;
            // 
            // Trained_Networks_dataGridView
            // 
            this.Trained_Networks_dataGridView.AllowUserToAddRows = false;
            this.Trained_Networks_dataGridView.AllowUserToDeleteRows = false;
            this.Trained_Networks_dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Trained_Networks_dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Trained_Networks_dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Trained_Networks_dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Trained_Networks_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Trained_Networks_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Logo_Name,
            this.Logo_Image,
            this.Logo_neuron});
            this.Trained_Networks_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Trained_Networks_dataGridView.Location = new System.Drawing.Point(2, 2);
            this.Trained_Networks_dataGridView.Name = "Trained_Networks_dataGridView";
            this.Trained_Networks_dataGridView.ReadOnly = true;
            this.Trained_Networks_dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.Trained_Networks_dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Trained_Networks_dataGridView.Size = new System.Drawing.Size(354, 215);
            this.Trained_Networks_dataGridView.TabIndex = 2;
            // 
            // Train_Networks_button
            // 
            this.Train_Networks_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.Train_Networks_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Train_Networks_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.Train_Networks_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Train_Networks_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Train_Networks_button.ForeColor = System.Drawing.Color.White;
            this.Train_Networks_button.Location = new System.Drawing.Point(126, 75);
            this.Train_Networks_button.Name = "Train_Networks_button";
            this.Train_Networks_button.Size = new System.Drawing.Size(109, 30);
            this.Train_Networks_button.TabIndex = 1;
            this.Train_Networks_button.Text = "Train Networks";
            this.Train_Networks_button.UseVisualStyleBackColor = false;
            this.Train_Networks_button.Click += new System.EventHandler(this.Train_Networks_button_Click);
            // 
            // Logo_Name
            // 
            this.Logo_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Logo_Name.HeaderText = "Logo Name";
            this.Logo_Name.Name = "Logo_Name";
            this.Logo_Name.ReadOnly = true;
            // 
            // Logo_Image
            // 
            this.Logo_Image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Logo_Image.HeaderText = "Logo Image";
            this.Logo_Image.Name = "Logo_Image";
            this.Logo_Image.ReadOnly = true;
            // 
            // Logo_neuron
            // 
            this.Logo_neuron.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Logo_neuron.HeaderText = "Neuron";
            this.Logo_neuron.Name = "Logo_neuron";
            this.Logo_neuron.ReadOnly = true;
            // 
            // start_sorting_backgroundWorker
            // 
            this.start_sorting_backgroundWorker.WorkerReportsProgress = true;
            this.start_sorting_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.start_sorting_backgroundWorker_DoWork);
            this.start_sorting_backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.start_sorting_backgroundWorker_ProgressChanged);
            // 
            // LogoBasedDocumentsSorter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 888);
            this.Controls.Add(this.panel1);
            this.Name = "LogoBasedDocumentsSorter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Sorter";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Sorted_document_dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Trained_Networks_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button Target_Folder_path;
        private System.Windows.Forms.Button Image_Folder_path;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView Sorted_document_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_column;
        private System.Windows.Forms.Button Target_Folder_button;
        private System.Windows.Forms.Button Image_Folder_button;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView Trained_Networks_dataGridView;
        private System.Windows.Forms.Button Train_Networks_button;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Logo_Name;
        private System.Windows.Forms.DataGridViewImageColumn Logo_Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Logo_neuron;
        private System.ComponentModel.BackgroundWorker start_sorting_backgroundWorker;
    }
}


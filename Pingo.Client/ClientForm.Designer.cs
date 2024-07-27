namespace Pingo.Client
{
    partial class ClientForm
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
            dgvClients = new DataGridView();
            txtId = new TextBox();
            txtGender = new TextBox();
            txtName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            btnAddClient = new Button();
            btnUpdateClient = new Button();
            btnDeleteClient = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(12, 288);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(776, 150);
            dgvClients.TabIndex = 0;
            dgvClients.CellContentClick += dgvClients_CellContentClick;
            // 
            // txtId
            // 
            txtId.Location = new Point(12, 15);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;
            // 
            // txtGender
            // 
            txtGender.Location = new Point(568, 15);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(100, 23);
            txtGender.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(171, 15);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 3;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(320, 12);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 23);
            dtpDateOfBirth.TabIndex = 4;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(320, 243);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(75, 23);
            btnAddClient.TabIndex = 5;
            btnAddClient.Text = "Add";
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // btnUpdateClient
            // 
            btnUpdateClient.Location = new Point(423, 243);
            btnUpdateClient.Name = "btnUpdateClient";
            btnUpdateClient.Size = new Size(75, 23);
            btnUpdateClient.TabIndex = 6;
            btnUpdateClient.Text = "Update";
            btnUpdateClient.UseVisualStyleBackColor = true;
            btnUpdateClient.Click += btnUpdateClient_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(532, 243);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(75, 23);
            btnDeleteClient.TabIndex = 7;
            btnDeleteClient.Text = "Delete";
            btnDeleteClient.UseVisualStyleBackColor = true;
            btnDeleteClient.Click += btnDeleteClient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(569, 76);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 8;
            label1.Text = "Gender";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 76);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 9;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 10;
            label3.Text = "Surname";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteClient);
            Controls.Add(btnUpdateClient);
            Controls.Add(btnAddClient);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtName);
            Controls.Add(txtGender);
            Controls.Add(txtId);
            Controls.Add(dgvClients);
            Name = "ClientForm";
            Text = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClients;
        private TextBox txtId;
        private TextBox txtGender;
        private TextBox txtName;
        private DateTimePicker dtpDateOfBirth;
        private Button btnAddClient;
        private Button btnUpdateClient;
        private Button btnDeleteClient;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
using System.Xml.Linq;

namespace Pingo.Client
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            dgvAddresses = new DataGridView();
            btnAddAddress = new Button();
            btnRemoveAddress = new Button();
            lblSelectedAddress = new Label();
            dgvContacts = new DataGridView();
            btnAddContact = new Button();
            btnRemoveContact = new Button();
            lblSelectedContact = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAddresses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            SuspendLayout();
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(11, 374);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(1050, 215);
            dgvClients.TabIndex = 0;
            dgvClients.CellContentClick += dgvClients_CellContentClick;
            // 
            // txtId
            // 
            txtId.Location = new Point(11, 35);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;
            // 
            // txtGender
            // 
            txtGender.Location = new Point(507, 35);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(100, 23);
            txtGender.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(145, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 3;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(283, 35);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 23);
            dtpDateOfBirth.TabIndex = 4;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(1076, 374);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(75, 23);
            btnAddClient.TabIndex = 5;
            btnAddClient.Text = "Add";
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // btnUpdateClient
            // 
            btnUpdateClient.Location = new Point(1076, 403);
            btnUpdateClient.Name = "btnUpdateClient";
            btnUpdateClient.Size = new Size(75, 23);
            btnUpdateClient.TabIndex = 6;
            btnUpdateClient.Text = "Update";
            btnUpdateClient.UseVisualStyleBackColor = true;
            btnUpdateClient.Click += btnUpdateClient_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(1076, 453);
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
            label1.Location = new Point(507, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 8;
            label1.Text = "Gender";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 12);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 9;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 12);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 10;
            label3.Text = "Surname";
            // 
            // dgvAddresses
            // 
            dgvAddresses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAddresses.Location = new Point(12, 129);
            dgvAddresses.Name = "dgvAddresses";
            dgvAddresses.Size = new Size(283, 100);
            dgvAddresses.TabIndex = 13;
            dgvAddresses.CellContentClick += dgvAddresses_CellContentClick;
            // 
            // btnAddAddress
            // 
            btnAddAddress.Location = new Point(12, 235);
            btnAddAddress.Name = "btnAddAddress";
            btnAddAddress.Size = new Size(75, 23);
            btnAddAddress.TabIndex = 14;
            btnAddAddress.Text = "Add Address";
            btnAddAddress.UseVisualStyleBackColor = true;
            btnAddAddress.Click += btnAddAddress_Click;
            // 
            // btnRemoveAddress
            // 
            btnRemoveAddress.Location = new Point(114, 235);
            btnRemoveAddress.Name = "btnRemoveAddress";
            btnRemoveAddress.Size = new Size(100, 23);
            btnRemoveAddress.TabIndex = 15;
            btnRemoveAddress.Text = "Remove Address";
            btnRemoveAddress.UseVisualStyleBackColor = true;
            btnRemoveAddress.Click += btnRemoveAddress_Click;
            // 
            // lblSelectedAddress
            // 
            lblSelectedAddress.AutoSize = true;
            lblSelectedAddress.Location = new Point(12, 270);
            lblSelectedAddress.Name = "lblSelectedAddress";
            lblSelectedAddress.Size = new Size(99, 15);
            lblSelectedAddress.TabIndex = 16;
            lblSelectedAddress.Text = "Selected Address:";
            // 
            // dgvContacts
            // 
            dgvContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContacts.Location = new Point(605, 129);
            dgvContacts.Name = "dgvContacts";
            dgvContacts.Size = new Size(279, 100);
            dgvContacts.TabIndex = 19;
            dgvContacts.CellContentClick += dgvContacts_CellContentClick;
            // 
            // btnAddContact
            // 
            btnAddContact.Location = new Point(605, 235);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(75, 23);
            btnAddContact.TabIndex = 20;
            btnAddContact.Text = "Add Contact";
            btnAddContact.UseVisualStyleBackColor = true;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // btnRemoveContact
            // 
            btnRemoveContact.Location = new Point(711, 235);
            btnRemoveContact.Name = "btnRemoveContact";
            btnRemoveContact.Size = new Size(100, 23);
            btnRemoveContact.TabIndex = 21;
            btnRemoveContact.Text = "Remove Contact";
            btnRemoveContact.UseVisualStyleBackColor = true;
            btnRemoveContact.Click += btnRemoveContact_Click;
            // 
            // lblSelectedContact
            // 
            lblSelectedContact.AutoSize = true;
            lblSelectedContact.Location = new Point(605, 279);
            lblSelectedContact.Name = "lblSelectedContact";
            lblSelectedContact.Size = new Size(99, 15);
            lblSelectedContact.TabIndex = 22;
            lblSelectedContact.Text = "Selected Contact:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(283, 9);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 23;
            label4.Text = "Date of Birth";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 615);
            Controls.Add(label4);
            Controls.Add(lblSelectedContact);
            Controls.Add(btnRemoveContact);
            Controls.Add(btnAddContact);
            Controls.Add(dgvContacts);
            Controls.Add(lblSelectedAddress);
            Controls.Add(btnRemoveAddress);
            Controls.Add(btnAddAddress);
            Controls.Add(dgvAddresses);
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
            ((System.ComponentModel.ISupportInitialize)dgvAddresses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

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
        private DataGridView dgvAddresses;
        private Button btnAddAddress;
        private Button btnRemoveAddress;
        private Label lblSelectedAddress;
        private DataGridView dgvContacts;
        private Button btnAddContact;
        private Button btnRemoveContact;
        private Label lblSelectedContact;
        private Label label4;
    }
}
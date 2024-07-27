namespace Pingo.Client
{
    partial class AddressForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvAddresses = new DataGridView();
            txtCountry = new TextBox();
            txtId = new TextBox();
            txtStreetAddress = new TextBox();
            txtProvince = new TextBox();
            txtPostalCode = new TextBox();
            txtCity = new TextBox();
            cmbAddressType = new ComboBox();
            btnAddAddress = new Button();
            btnUpdateAddress = new Button();
            btnDeleteAddress = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAddresses).BeginInit();
            SuspendLayout();
            // 
            // dgvAddresses
            // 
            dgvAddresses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAddresses.Location = new Point(12, 278);
            dgvAddresses.Name = "dgvAddresses";
            dgvAddresses.Size = new Size(776, 150);
            dgvAddresses.TabIndex = 0;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(170, 180);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(100, 23);
            txtCountry.TabIndex = 1;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(170, 12);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 2;
            // 
            // txtStreetAddress
            // 
            txtStreetAddress.Location = new Point(170, 65);
            txtStreetAddress.Name = "txtStreetAddress";
            txtStreetAddress.Size = new Size(100, 23);
            txtStreetAddress.TabIndex = 3;
            // 
            // txtProvince
            // 
            txtProvince.Location = new Point(170, 133);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(100, 23);
            txtProvince.TabIndex = 4;
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(486, 133);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(100, 23);
            txtPostalCode.TabIndex = 5;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(486, 65);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 6;
            // 
            // cmbAddressType
            // 
            cmbAddressType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAddressType.FormattingEnabled = true;
            cmbAddressType.Location = new Point(486, 12);
            cmbAddressType.Name = "cmbAddressType";
            cmbAddressType.Size = new Size(121, 23);
            cmbAddressType.TabIndex = 7;
            // 
            // btnAddAddress
            // 
            btnAddAddress.Location = new Point(391, 224);
            btnAddAddress.Name = "btnAddAddress";
            btnAddAddress.Size = new Size(75, 23);
            btnAddAddress.TabIndex = 8;
            btnAddAddress.Text = "Add";
            btnAddAddress.UseVisualStyleBackColor = true;
            btnAddAddress.Click += btnAddAddress_Click;
            // 
            // btnUpdateAddress
            // 
            btnUpdateAddress.Location = new Point(511, 224);
            btnUpdateAddress.Name = "btnUpdateAddress";
            btnUpdateAddress.Size = new Size(75, 23);
            btnUpdateAddress.TabIndex = 9;
            btnUpdateAddress.Text = "Update";
            btnUpdateAddress.UseVisualStyleBackColor = true;
            btnUpdateAddress.Click += btnUpdateAddress_Click;
            // 
            // btnDeleteAddress
            // 
            btnDeleteAddress.Location = new Point(636, 224);
            btnDeleteAddress.Name = "btnDeleteAddress";
            btnDeleteAddress.Size = new Size(75, 23);
            btnDeleteAddress.TabIndex = 10;
            btnDeleteAddress.Text = "Delete";
            btnDeleteAddress.UseVisualStyleBackColor = true;
            btnDeleteAddress.Click += btnDeleteAddress_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 183);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 11;
            label1.Text = "Country";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 136);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 12;
            label2.Text = "Province";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 73);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 13;
            label3.Text = "Street Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 20);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 14;
            label4.Text = "ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 136);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 15;
            label5.Text = "Postal Code";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(322, 73);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 16;
            label6.Text = "City";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(322, 20);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 17;
            label7.Text = "Address Type";
            // 
            // AddressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteAddress);
            Controls.Add(btnUpdateAddress);
            Controls.Add(btnAddAddress);
            Controls.Add(cmbAddressType);
            Controls.Add(txtCity);
            Controls.Add(txtPostalCode);
            Controls.Add(txtProvince);
            Controls.Add(txtStreetAddress);
            Controls.Add(txtId);
            Controls.Add(txtCountry);
            Controls.Add(dgvAddresses);
            Name = "AddressForm";
            Text = "AddressForm";
            Load += AddressForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAddresses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAddresses;
        private TextBox txtCountry;
        private TextBox txtId;
        private TextBox txtStreetAddress;
        private TextBox txtProvince;
        private TextBox txtPostalCode;
        private TextBox txtCity;
        private ComboBox cmbAddressType;
        private Button btnAddAddress;
        private Button btnUpdateAddress;
        private Button btnDeleteAddress;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}

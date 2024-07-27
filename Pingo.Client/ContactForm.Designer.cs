namespace Pingo.Client
{
    partial class ContactForm
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
            dgvContacts = new DataGridView();
            txtValue = new TextBox();
            cmbContactType = new ComboBox();
            txtId = new TextBox();
            btnAddContact = new Button();
            btnUpdateContact = new Button();
            btnDeleteContact = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            SuspendLayout();
            // 
            // dgvContacts
            // 
            dgvContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContacts.Location = new Point(12, 275);
            dgvContacts.Name = "dgvContacts";
            dgvContacts.Size = new Size(776, 150);
            dgvContacts.TabIndex = 0;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(134, 84);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(100, 23);
            txtValue.TabIndex = 1;
            // 
            // cmbContactType
            // 
            cmbContactType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContactType.FormattingEnabled = true;
            cmbContactType.Location = new Point(389, 12);
            cmbContactType.Name = "cmbContactType";
            cmbContactType.Size = new Size(121, 23);
            cmbContactType.TabIndex = 2;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(134, 12);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 3;
            // 
            // btnAddContact
            // 
            btnAddContact.Location = new Point(45, 231);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(75, 23);
            btnAddContact.TabIndex = 4;
            btnAddContact.Text = "Add";
            btnAddContact.UseVisualStyleBackColor = true;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // btnUpdateContact
            // 
            btnUpdateContact.Location = new Point(311, 231);
            btnUpdateContact.Name = "btnUpdateContact";
            btnUpdateContact.Size = new Size(75, 23);
            btnUpdateContact.TabIndex = 5;
            btnUpdateContact.Text = "Update";
            btnUpdateContact.UseVisualStyleBackColor = true;
            btnUpdateContact.Click += btnUpdateContact_Click;
            // 
            // btnDeleteContact
            // 
            btnDeleteContact.Location = new Point(603, 231);
            btnDeleteContact.Name = "btnDeleteContact";
            btnDeleteContact.Size = new Size(75, 23);
            btnDeleteContact.TabIndex = 6;
            btnDeleteContact.Text = "Delete";
            btnDeleteContact.UseVisualStyleBackColor = true;
            btnDeleteContact.Click += btnDeleteContact_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 20);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 7;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 92);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 8;
            label2.Text = "Value";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(297, 20);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 9;
            label3.Text = "Contact Type";
            // 
            // ContactForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteContact);
            Controls.Add(btnUpdateContact);
            Controls.Add(btnAddContact);
            Controls.Add(txtId);
            Controls.Add(cmbContactType);
            Controls.Add(txtValue);
            Controls.Add(dgvContacts);
            Name = "ContactForm";
            Text = "ContactForm";
            Load += ContactForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvContacts;
        private TextBox txtValue;
        private ComboBox cmbContactType;
        private TextBox txtId;
        private Button btnAddContact;
        private Button btnUpdateContact;
        private Button btnDeleteContact;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}

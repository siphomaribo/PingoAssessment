namespace Pingo.Client
{
    partial class Form1
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
            btnManageClients = new Button();
            btnManageAddresses = new Button();
            btnManageContacts = new Button();
            SuspendLayout();
            // 
            // btnManageClients
            // 
            btnManageClients.Location = new Point(51, 38);
            btnManageClients.Name = "btnManageClients";
            btnManageClients.Size = new Size(97, 23);
            btnManageClients.TabIndex = 0;
            btnManageClients.Text = "Manage Clients";
            btnManageClients.UseVisualStyleBackColor = true;
            btnManageClients.Click += btnManageClients_Click;
            // 
            // btnManageAddresses
            // 
            btnManageAddresses.Location = new Point(174, 38);
            btnManageAddresses.Name = "btnManageAddresses";
            btnManageAddresses.Size = new Size(135, 23);
            btnManageAddresses.TabIndex = 1;
            btnManageAddresses.Text = "Manage Addresses";
            btnManageAddresses.UseVisualStyleBackColor = true;
            btnManageAddresses.Click += btnManageAddresses_Click;
            // 
            // btnManageContacts
            // 
            btnManageContacts.Location = new Point(336, 38);
            btnManageContacts.Name = "btnManageContacts";
            btnManageContacts.Size = new Size(138, 23);
            btnManageContacts.TabIndex = 2;
            btnManageContacts.Text = "Manage Contacts";
            btnManageContacts.UseVisualStyleBackColor = true;
            btnManageContacts.Click += btnManageContacts_Click;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnManageContacts);
            Controls.Add(btnManageAddresses);
            Controls.Add(btnManageClients);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageClients;
        private Button btnManageAddresses;
        private Button btnManageContacts;
    }
}
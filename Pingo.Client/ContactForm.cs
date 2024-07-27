using Pingo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pingo.Client
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
            LoadContacts();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            cmbContactType.DataSource = Enum.GetValues(typeof(ContactTypeEnum));
        }

        private async void LoadContacts()
        {
            var contacts = await ApiClient.GetAsync<IEnumerable<Contact>>("contact");
            dgvContacts.DataSource = contacts;
        }

        private async void btnAddContact_Click(object sender, EventArgs e)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                ContactType = (ContactTypeEnum)cmbContactType.SelectedItem,
                Value = txtValue.Text
            };

            await ApiClient.PostAsync("contact", contact);
            LoadContacts();
        }

        private async void btnUpdateContact_Click(object sender, EventArgs e)
        {
            var contact = new Contact
            {
                Id = Guid.Parse(txtId.Text),
                ContactType = (ContactTypeEnum)cmbContactType.SelectedItem,
                Value = txtValue.Text
            };

            await ApiClient.PutAsync($"contact/{contact.Id}", contact);
            LoadContacts();
        }

        private async void btnDeleteContact_Click(object sender, EventArgs e)
        {
            var contactId = Guid.Parse(txtId.Text);
            await ApiClient.DeleteAsync($"contact/{contactId}");
            LoadContacts();
        }
    }
}

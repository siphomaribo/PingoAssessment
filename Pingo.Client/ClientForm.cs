using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Pingo.Models;

namespace Pingo.Client
{
    public partial class ClientForm : Form
    {
        private Pingo.Models.Client _currentClient;

        public ClientForm()
        {
            InitializeComponent();
            LoadClients();
            LoadAddress();
            LoadContacts();
        }

        private async void LoadClients()
        {
            var clients = await ApiClient.GetAsync<IEnumerable<Pingo.Models.Client>>("client");
            dgvClients.DataSource = clients;
        }

        private async void LoadAddress()
        {
            var addresses = await ApiClient.GetAsync<IEnumerable<Models.Address>>("address");
            dgvAddresses.DataSource = addresses;
        }

        private async void LoadContacts()
        {
            var contacts = await ApiClient.GetAsync<IEnumerable<Contact>>("contact");
            dgvContacts.DataSource = contacts;
        }

        private async void btnAddClient_Click(object sender, EventArgs e)
        {
            var client = new Pingo.Models.Client
            {
                Id = Guid.NewGuid(),
                Name = txtName.Text,
                Gender = txtGender.Text,
                DateOfBirth = dtpDateOfBirth.Value,
                AddressIds = new List<Guid>(),
                ContactIds = new List<Guid>()
            };

            await ApiClient.PostAsync("client", client);
            LoadClients();
        }

        private async void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (_currentClient == null)
                return;

            _currentClient.Name = txtName.Text;
            _currentClient.Gender = txtGender.Text;
            _currentClient.DateOfBirth = dtpDateOfBirth.Value;

            await ApiClient.PutAsync($"client/{_currentClient.Id}", _currentClient);
            LoadClients();
        }

        private async void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (_currentClient == null)
                return;

            await ApiClient.DeleteAsync($"client/{_currentClient.Id}");
            LoadClients();
        }

        private void dgvAddresses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Assuming the first column is the select button
            {
                var addressId = (Guid)dgvAddresses.Rows[e.RowIndex].Cells["Id"].Value; // Replace "Id" with the actual column name
                if (!_currentClient.AddressIds.Contains(addressId))
                {
                    _currentClient.AddressIds.Add(addressId);
                    lblSelectedAddress.Text = $"Selected Address ID: {addressId}";
                }
            }
        }

        private void dgvContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Assuming the first column is the select button
            {
                var contactId = (Guid)dgvContacts.Rows[e.RowIndex].Cells["Id"].Value; // Replace "Id" with the actual column name
                if (!_currentClient.ContactIds.Contains(contactId))
                {
                    _currentClient.ContactIds.Add(contactId);
                    lblSelectedContact.Text = $"Selected Contact ID: {contactId}";
                }
            }
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            // Logic to add selected address to the client
            // This could be handled by selecting from DataGridView and adding to the collection
        }

        private void btnRemoveAddress_Click(object sender, EventArgs e)
        {
            // Logic to remove selected address from the client
            // This could be handled by removing from AddressIds
            var addressId = GetSelectedAddressId();
            if (addressId != Guid.Empty)
            {
                _currentClient.AddressIds.Remove(addressId);
                lblSelectedAddress.Text = "Address removed.";
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // Logic to add selected contact to the client
            // This could be handled by selecting from DataGridView and adding to the collection
        }

        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            // Logic to remove selected contact from the client
            // This could be handled by removing from ContactIds
            var contactId = GetSelectedContactId();
            if (contactId != Guid.Empty)
            {
                _currentClient.ContactIds.Remove(contactId);
                lblSelectedContact.Text = "Contact removed.";
            }
        }

        private Guid GetSelectedAddressId()
        {
            // Implement logic to get selected address ID
            return Guid.Empty;
        }

        private Guid GetSelectedContactId()
        {
            // Implement logic to get selected contact ID
            return Guid.Empty;
        }
        private async void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var clientId = (Guid)dgvClients.Rows[e.RowIndex].Cells["Id"].Value; // Adjust "Id" to match your column name
                _currentClient = await ApiClient.GetAsync<Models.Client>($"client/{clientId}");
                PopulateClientDetails();
            }
        }

        private void PopulateClientDetails()
        {
            if (_currentClient != null)
            {
                txtId.Text = _currentClient.Id.ToString();
                txtName.Text = _currentClient.Name;
                txtGender.Text = _currentClient.Gender;
                dtpDateOfBirth.Value = _currentClient.DateOfBirth ?? DateTime.Now;

                // Update Address and Contact displays based on _currentClient.AddressIds and _currentClient.ContactIds
            }
        }
    }
}

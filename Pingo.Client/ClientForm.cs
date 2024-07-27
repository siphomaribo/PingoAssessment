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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            LoadClients();

        }

        private async void LoadClients()
        {
            var clients = await ApiClient.GetAsync<IEnumerable<Models.Client>>("client");
            dgvClients.DataSource = clients;
        }



        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnAddClient_Click(object sender, EventArgs e)
        {
            var client = new Models.Client
            {
                Id = Guid.NewGuid(),
                Name = txtName.Text,
                Gender = txtGender.Text,
                DateOfBirth = dtpDateOfBirth.Value
            };

            await ApiClient.PostAsync("client", client);
            LoadClients();
        }

        private async void btnUpdateClient_Click(object sender, EventArgs e)
        {
            var client = new Models.Client
            {
                Id = Guid.Parse(txtId.Text),
                Name = txtName.Text,
                Gender = txtGender.Text,
                DateOfBirth = dtpDateOfBirth.Value
            };

            await ApiClient.PutAsync($"client/{client.Id}", client);
            LoadClients();
        }

        private async void btnDeleteClient_Click(object sender, EventArgs e)
        {
            var clientId = Guid.Parse(txtId.Text);
            await ApiClient.DeleteAsync($"client/{clientId}");
            LoadClients();
        }
    }
}

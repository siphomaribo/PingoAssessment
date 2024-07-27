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
    public partial class AddressForm : Form
    {
        public AddressForm()
        {
            InitializeComponent();
            LoadAddresses();
        }

        private void AddressForm_Load(object sender, EventArgs e)
        {
            cmbAddressType.DataSource = Enum.GetValues(typeof(AddressTypeEnum));
        }
        private async void LoadAddresses()
        {
            var addresses = await ApiClient.GetAsync<IEnumerable<Models.Address>>("address");
            dgvAddresses.DataSource = addresses;
        }
        private async void btnAddAddress_Click(object sender, EventArgs e)
        {
            var address = new Models.Address
            {
                Id = Guid.NewGuid(),
                AddressType = (AddressTypeEnum)cmbAddressType.SelectedItem,
                StreetAddress = txtStreetAddress.Text,
                City = txtCity.Text,
                Province = txtProvince.Text,
                PostalCode = txtPostalCode.Text,
                Country = txtCountry.Text
            };

            await ApiClient.PostAsync("address", address);
            LoadAddresses();
        }

        private async void btnUpdateAddress_Click(object sender, EventArgs e)
        {

            var address = new Models.Address
            {
                Id = Guid.Parse(txtId.Text),
                AddressType = (AddressTypeEnum)cmbAddressType.SelectedItem,
                StreetAddress = txtStreetAddress.Text,
                City = txtCity.Text,
                Province = txtProvince.Text,
                PostalCode = txtPostalCode.Text,
                Country = txtCountry.Text
            };

            await ApiClient.PutAsync($"address/{address.Id}", address);
            LoadAddresses();
        }

        private async void btnDeleteAddress_Click(object sender, EventArgs e)
        {
            var addressId = Guid.Parse(txtId.Text);
            await ApiClient.DeleteAsync($"address/{addressId}");
            LoadAddresses();
        }
    }
}

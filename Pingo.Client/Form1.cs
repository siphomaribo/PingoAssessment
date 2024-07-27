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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnManageClients_Click(object sender, EventArgs e)
        {
            var clientForm = new ClientForm();
            clientForm.Show();
        }

        private void btnManageAddresses_Click(object sender, EventArgs e)
        {
            var addressForm = new AddressForm();
            addressForm.Show();
        }

        private void btnManageContacts_Click(object sender, EventArgs e)
        {
            var contactForm = new ContactForm();
            contactForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

  
    }
}

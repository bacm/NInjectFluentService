using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsClient.ServiceReference1;

namespace FormsClient
{
    public partial class Form1 : Form, IForm
    {
        private AbsenteeismbeServiceClient _client;
        private Presenter _presenter;

        public Form1()
        {
            InitializeComponent();

            _presenter = new Presenter(this);

            FormClosing += CloseClient;
        }

        private void CloseClient(object sender, FormClosingEventArgs e)
        {
            if (_client == null)
            {
                return;
            }
            
            if (_client.State == CommunicationState.Opened)
            {
                _client.Close();
            }

            _client = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _client = new AbsenteeismbeServiceClient();

            _client.AddAbsenceCompleted += (o, args) => DisplayAddFoldResult(args);
        }

        private void DisplayAddFoldResult(AddAbsenceCompletedEventArgs e)
        {
            btnSubmit.Enabled = true;
            toolStripStatus.Text = @"Status";

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }

            MessageBox.Show(e.Result.AddAbsenceResult);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var addFold = new AddFoldRequest
                {
                    Start = dateTimePicker1.Value, 
                    End = dateTimePicker2.Value, 
                    PersonId = 1
                };

            _client.AddAbsenceAsync(new AddAbsenceRequest(addFold));

            btnSubmit.Enabled = false;
            toolStripStatus.Text = string.Format("Adding absence for the employee Id {0}", addFold.PersonId);
        }
    }
}

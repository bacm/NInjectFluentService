using System;
using System.ServiceModel;
using System.Windows.Forms;
using FormsClient.ServiceReference1;

namespace FormsClient
{
    public sealed partial class Form1 : Form, IForm, IAbsenteeismbeServiceCallback
    {
        private AbsenteeismbeServiceClient _client;
        private Presenter _presenter;

        public Form1()
        {
            InitializeComponent();

            _presenter = new Presenter(this);

            Text = Guid.NewGuid().ToString();
            FormClosing += CloseClient;
        }

        private void CloseClient(object sender, FormClosingEventArgs e)
        {
            if (_client == null)
            {
                return;
            }
            
            try
            {
                if (_client.State == CommunicationState.Opened)
                {
                    _client.Close();
                } 
            }
            finally
            {
                _client = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _client = new AbsenteeismbeServiceClient(new InstanceContext(this));

            _client.AddAbsenceCompleted += (o, args) => DisplayAddFoldResult(args);
        }

        private void DisplayAddFoldResult(AddAbsenceCompletedEventArgs e)
        {
            btnSubmit.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }

            toolStripStatus.Text = e.Result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var addFold = new AddFoldRequest
                {
                    Start = dateTimePicker1.Value, 
                    End = dateTimePicker2.Value, 
                    PersonId = 1,
                    Description = Text
                };

            _client.AddAbsenceAsync(addFold);

            btnSubmit.Enabled = false;
            toolStripStatus.Text = @"Status";
        }

        public void OnCallback(string message)
        {
            this.toolStripStatus.Text = message;
        }

        public IAsyncResult BeginOnCallback(string status, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndOnCallback(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}

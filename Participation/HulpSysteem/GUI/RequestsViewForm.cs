using System;
using System.Windows.Forms;
using Participation.HulpSysteem.Logic;
using Participation.SharedModels;

namespace Participation.HulpSysteem.GUI
{
    public partial class RequestsViewForm : Form
    {
        /// <summary>
        ///     Create a new instance of HPSLogic.
        /// </summary>
        public HPSLogic _hpsLogic = new HPSLogic();

        public RequestsViewForm()
        {
            InitializeComponent();

            foreach (var request in _hpsLogic.GetRequests(FormProvider.LoggedInUser))
            {
                lbxRequests.Items.Add(request.ToString());
            }
        }

        /// <summary>
        ///     Adds request on click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            FormProvider.RequestsViewForm.Hide();
            FormProvider.RequestForm.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormProvider.RequestsViewForm.Hide();
            FormProvider.ProfileForm.Show();
        }
    }
}
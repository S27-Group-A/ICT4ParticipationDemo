using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.HulpSysteem.Logic;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;

namespace Participation.HulpSysteem.GUI
{
    public partial class RequestsViewForm : Form
    {
        public HPSLogic _hpsLogic = new HPSLogic();

        public RequestsViewForm()
        {
            InitializeComponent();
            //TODO Implement this

            foreach (var request in _hpsLogic.GetRequests(FormProvider.LoggedInUser))
            {
                lbxRequests.Items.Add(request.ToString());
            }

        }


    }
}

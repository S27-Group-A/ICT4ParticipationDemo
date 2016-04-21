using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.HulpSysteem.Logic;
using Participation.InlogSysteem.Interfaces;

namespace Participation.HulpSysteem.GUI
{
    public partial class RequestsViewForm : Form
    {
        public HPSLogic _hpsLogic = new HPSLogic();
        
        public RequestsViewForm(IUser LoggedInUser)
        {
            InitializeComponent();
            foreach (var request in _hpsLogic.GetRequests())
            {
                
            }
        }


    }
}

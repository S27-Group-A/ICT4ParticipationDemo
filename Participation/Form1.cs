﻿using Participation.VrijwilligersSysteem.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.VrijwilligersSysteem;
using Participation.SharedModels;
using UI;

namespace Participation
{
    public partial class Startmenu : Form
    {
        
        public Startmenu()
        {
            InitializeComponent();
            VolunteerForm test = new VolunteerForm();
            RequestForm reqtest = new RequestForm();
            test.Show();
            reqtest.Show();
            this.Hide();
        }
    }
}

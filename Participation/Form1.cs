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

namespace Participation
{
    public partial class Startmenu : Form
    {
        
        public Startmenu()
        {
            InitializeComponent();
            VolunteerForm test = new VolunteerForm();
            test.Show();
            this.Hide();
        }
    }
}

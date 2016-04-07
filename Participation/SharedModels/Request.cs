﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation.SharedModels
{
    public class Request
    {
        private string _title, _text, _location;
        private int _urgency;
        private DateTime _date;
        private List<string> _perks = new List<string>();
        private string title;
        private string text;
        private List<string> perks;
        private string location;
        private DateTime date;
        private int urgency;

        public Request(string title, string text, List<string> perks, string location, DateTime date, int urgency)
        {
            _title = title;
            _text = text;
            _perks = perks;
            _location = location;
            _date = date;
            _urgency = urgency;
        }

        public Request(string title, string text, string location)
        {
            _title = title;
            _text = text;
            _location = location;
        }


    }
}

﻿using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class Patients : IModel
    {
        public int TotalValue { get; set; }
        public int PotentialValue { get; set; }
    }
}

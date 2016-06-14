using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindToListViewDemo
{
    internal class Medications
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MedName { get; set; }
        public string MedDose { get; set; }
        public int AM { get; set; }
        public int Noon { get; set; }
        public int Supper { get; set; }
        public int Night { get; set; }
        public int PRN { get; set; }
        public int Other { get; set; }
        public string WhatFor { get; set; }
    }
}
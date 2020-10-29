using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Poznamky.Model
{
    [Table("poznamky")]
    class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime Creation_Date { get; set; }

        public DateTime? Edit_Date { get; set; }
    }
}

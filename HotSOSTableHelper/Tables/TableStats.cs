using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


    public class TableStats
    {
        [Key]
        public string Name { get; set; }
        public string RecordCount { get; set; }
        public string ReservedSize { get; set; }
        public string DataSize { get; set; }
        public string IndexSize { get; set; }
        public string UnusedSize { get; set; }

    }

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VitalFew.Transdev.Australasia.Data.Core.Result
{
    public class TableObject
    {
        public DataTable Result { get; set; }

        public int RecordCount { get; set; }
    }
}

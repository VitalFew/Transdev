using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces
{
    public interface ISqlServerTableParameters : IParameters
    {
        string UserID { get; set; }
        string Password { get; set; }
        string InitialCatalog { get; set; }
        string DataSource { get; set; }
        bool? IntegratedSecurity { get; set; }
        string SchemaName { get; set; }
        string ObjectName { get; set; }
    }
}

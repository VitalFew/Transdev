using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;

namespace VitalFew.Transdev.Australasia.Data.Core.Parameters
{
    public class SqlServerTableParameters : ISqlServerTableParameters
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string InitialCatalog { get; set; }
        public string DataSource { get; set; }
        public bool? IntegratedSecurity { get; set; }
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VitalFew.Transdev.Australasia.Data.Core.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class VF_API_CLIENT_OBJECTS
    {
        [Required]
        public System.Guid CLIENT_OBJECT_ID { get; set; }
        [Required]
        public int TRANSDEV_ID { get; set; }
        [DisplayName("Transdev Param")]
        [Required]
        public string TRANSDEV_PARAM { get; set; }
        [DisplayName("Data Provider")]
        [Required]
        public int DATA_PROVIDER_ID { get; set; }
        [DisplayName("Server Name")]
        [Required]
        public string DB_SERVER_NAME { get; set; }
        [DisplayName("Instance Name")]
        [Required]
        public string DB_INSTANCE_NAME { get; set; }
        [DisplayName("Server Port")]
        public string DB_SERVER_PORT { get; set; }
        [DisplayName("DB NAME")]
        [Required]
        public string DB_NAME { get; set; }
        [DisplayName("DB User")]
        public string DB_USER { get; set; }
        [DisplayName("DB User Password")]
        public string DB_USER_PASSWORD { get; set; }
        [DisplayName("DB Authentication Type")]
        public string DB_AUTHENTICATION_TYPE { get; set; }
        [DisplayName("Integrated Security")]
        public Nullable<bool> DB_INTEGRATED_SECURITY { get; set; }
        [DisplayName("Db Schema")]
        public string DB_SCHEMA { get; set; }
        [DisplayName("DB Object Name")]
        public string DB_OBJECT_NAME { get; set; }
        public System.DateTime DB_OBJECT_CREATED_DATE { get; set; }
        public System.DateTime DB_OBJECT_MODIFIED_DATE { get; set; }
    
        public virtual VF_API_CATALOG_CLIENTS VF_API_CATALOG_CLIENTS { get; set; }
        public virtual VF_DATA_PROVIDER VF_DATA_PROVIDER { get; set; }
    }
}

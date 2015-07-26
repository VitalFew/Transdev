﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public VF_API_CLIENT_OBJECTS Get(Guid clientId, string parama)
        {
            using (var context = new Models.Database.Entities())
            {
                return context.VF_API_CLIENT_OBJECTS.Where(e => 
                        e.VF_API_CATALOG_CLIENTS.CLIENT_ID == clientId &&
                        e.TRANSDEV_PARAM == parama).FirstOrDefault();
            }
        }
    }

}
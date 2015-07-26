﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Result;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
{
    public interface IDataProvider
    {

        /// <summary>
        /// Execute DataProvide
        /// </summary>
        /// <param name="clients">VF_API_CLIENT_OBJECTS</param>
        /// <returns>QueryResult of DataTable</returns>
        Task<QueryResult<DataTable>> Execute(VF_API_CLIENT_OBJECTS clients);
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VitalFew.Transdev.Australasia.Data.Api.Models;

namespace VitalFew.Transdev.Australasia.Data.Api.Infrastructure.Conveters
{
    /// <summary>
    /// DataTableConverter Class
    /// </summary>
    public class DataTableConverter : JsonConverter
    {
        /// <summary>
        /// Can Convert
        /// </summary>
        /// <param name="objectType">Type</param>
        /// <returns>bool</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(JsonDataTable).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Read Json
        /// </summary>
        /// <param name="reader">JsonReader</param>
        /// <param name="objectType">Type</param>
        /// <param name="existingValue">object</param>
        /// <param name="serializer">JsonSerializer</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write Json
        /// </summary>
        /// <param name="writer">JsonWriter</param>
        /// <param name="value">object</param>
        /// <param name="serializer">JsonSerializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JsonDataTable myDataTable = value as JsonDataTable;
            DataTable dt = myDataTable.Data.Result;

            writer.WriteStartArray();

            foreach (DataRow row in dt.Rows)
            {
                writer.WriteStartObject();
                foreach (DataColumn column in row.Table.Columns)
                {
                    writer.WritePropertyName(column.ColumnName);
                    serializer.Serialize(writer, row[column]);
                }
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
        }
    }
}
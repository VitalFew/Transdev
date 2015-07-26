using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VitalFew.Transdev.Australasia.DataPublisher.Models;

namespace VitalFew.Transdev.Australasia.DataPublisher.Infrastructure.Conveters
{
    public class DataTableConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return typeof(JsonDataTable).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

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
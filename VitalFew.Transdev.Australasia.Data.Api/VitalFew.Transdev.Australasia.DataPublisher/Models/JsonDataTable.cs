using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using VitalFew.Transdev.Australasia.Data.Core.Result;

namespace VitalFew.Transdev.Australasia.DataPublisher.Models
{
    [JsonConverter(typeof(DataTableConverter))]
    [XmlRoot("Result")]
    public class JsonDataTable : IXmlSerializable
    {
        public JsonDataTable(TableObject datatable)
        {
            this.Data = datatable;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("RecordCount", this.Data.RecordCount.ToString());

            foreach (DataRow row in Data.Result.Rows)
            {
                writer.WriteStartElement(Data.Result.TableName);
                foreach (DataColumn column in row.Table.Columns)
                {
                    string columnName = XmlConvert.EncodeName(column.ColumnName);
                    writer.WriteElementString(columnName, row[column].ToString());
                }
                writer.WriteEndElement();
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        private string XmlEscape(string unescaped)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateElement("root");
            node.InnerText = unescaped;
            return node.InnerXml;
        }

        public TableObject Data { get; set; }
    }
}
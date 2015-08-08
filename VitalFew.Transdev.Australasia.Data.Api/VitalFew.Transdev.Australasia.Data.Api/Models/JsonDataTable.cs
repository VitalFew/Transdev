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

namespace VitalFew.Transdev.Australasia.Data.Api.Models
{
    //[JsonConverter(typeof(DataTableConverter))]
    [XmlRoot("Data")]
    public class JsonDataTable : IXmlSerializable
    {

        /// <summary>
        /// JsonDataTable
        /// </summary>
        /// <param name="datatable">QueryResult of DataTable</param>
        public JsonDataTable(QueryResult<DataTable> datatable)
        {
            this.Data = datatable;
        }

        /// <summary>
        /// Write Xml
        /// </summary>
        /// <param name="writer">XmlWriter</param>
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

        /// <summary>
        /// Get Schema
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Read Xml
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Xml Escape
        /// </summary>
        /// <param name="unescaped"></param>
        /// <returns></returns>
        private string XmlEscape(string unescaped)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateElement("root");
            node.InnerText = unescaped;
            return node.InnerXml;
        }

        /// <summary>
        /// QueryResult of DataTable
        /// </summary>
        public QueryResult<DataTable> Data { get; set; }
    }
}
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using IO = System.IO;

namespace Bener.DataVisualizer
{
    class VisualizerDataSource
    {
        public DataTable DataTable { get; private set; }

        public VisualizerDataSource(IVisualizerObjectProvider objectProvider)
        {
            DataTable = new DataTable();
            var data = ReadData(objectProvider);
            AddColumns(data);
            AddRows(data);
        }

        private XElement ReadData(IVisualizerObjectProvider objectProvider)
        {
            var data = new XElement("Result");
            using (var sr = new IO.StreamReader(objectProvider.GetData()))
            {
                data = XElement.Parse(sr.ReadToEnd());
            }
            return data;
        }

        private void AddColumns(XElement data)
        {
            var properties = data.Element("Properties");
            foreach (var prp in properties.Elements())
            {
                var name = prp.Attribute("Name").Value;
                //var type = prp.Attribute("Type").Value;
                //DataTable.Columns.Add(name, System.Type.GetType(type));
                DataTable.Columns.Add(name, typeof(string));
            }
        }

        private void AddRows(XElement data)
        {
            var items = data.Element("Items");
            foreach (var item in items.Elements())
            {
                var row = DataTable.NewRow();
                foreach (var att in item.Attributes())
                {
                    row[att.Name.ToString()] = att.Value;
                }
                DataTable.Rows.Add(row);
            }
        }
    }
}

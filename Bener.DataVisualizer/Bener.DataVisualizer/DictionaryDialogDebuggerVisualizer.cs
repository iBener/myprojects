using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using IO = System.IO;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(Bener.DataVisualizer.DictionaryDialogDebuggerVisualizer),
    typeof(Bener.DataVisualizer.DictionaryVisualizerObjectSource),
    Target = typeof(Dictionary<,>),
    Description = "Bener Dictionary Visualizer")]

namespace Bener.DataVisualizer
{

    public class DictionaryDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {

        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            try
            {
                var data = new XElement("Result");
                using (var sr = new IO.StreamReader(objectProvider.GetData()))
                {
                    data = XElement.Parse(sr.ReadToEnd());
                }
                var dt = new DataTable();
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class DictionaryVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, IO.Stream outgoingData)
        {
            var dict = target as IDictionary;
            if (dict != null)
            {
                var sonuc = new XElement("Data");
                var t = new XElement("TypeInfo");
                var types = dict.GetType().GetGenericArguments();
                t.SetAttributeValue("KeyType", types[0].FullName);
                t.SetAttributeValue("ValueType", types[1].FullName);
                sonuc.Add(t);
                XElement prpt = null;
                var items = new XElement("Items");
                foreach (var key in dict.Keys)
                {
                    var data = new XElement("Item");
                    data.SetAttributeValue("key", key);
                    var obj = dict[key];
                    if (prpt == null)
                    {
                        prpt = new XElement("Properties");
                        foreach (var prp in obj.GetType().GetProperties())
                        {
                            var p = new XElement("Property");
                            p.SetAttributeValue("Name", prp.Name);
                            p.SetAttributeValue("Type", prp.DeclaringType.FullName);
                            prpt.Add(p);
                        }
                    }
                    foreach (var prp in obj.GetType().GetProperties())
                    {
                        var objData = prp.GetValue(obj, null);
                        if (objData != null)
                        {
                            data.SetAttributeValue(prp.Name, objData.ToString());
                        }
                    }
                    items.Add(data);
                }
                sonuc.Add(prpt);
                sonuc.Add(items);
                var writer = new IO.StreamWriter(outgoingData);
                writer.Write(sonuc.ToString());
                writer.Flush();
            }
        }
    }
}

using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
                var sr = new StreamReader(objectProvider.GetData());
                var obj = sr.ReadToEnd();
                MessageBox.Show(obj.Substring(0, 500));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class DictionaryVisualizerObjectSource : VisualizerObjectSource
    {

        public override void GetData(object target, Stream outgoingData)
        {
            var dict = target as IDictionary;
            if (dict != null)
            {
                var sonuc = new System.Xml.Linq.XElement("Result");
                foreach (var key in dict.Keys)
                {
                    var data = new System.Xml.Linq.XElement("Data");
                    data.SetAttributeValue("key", key);
                    var obj = dict[key];
                    foreach (var prp in obj.GetType().GetProperties())
                    {
                        var objData = prp.GetValue(obj, null);
                        if (objData != null)
                        {
                            data.SetAttributeValue(prp.Name, objData.ToString());
                        }
                    }
                    sonuc.Add(data);
                }
                var writer = new StreamWriter(outgoingData);
                writer.Write(sonuc.ToString());
                writer.Flush();
            }
        }

    }
}

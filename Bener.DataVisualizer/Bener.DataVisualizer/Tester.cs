using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bener.DataVisualizer
{
    public class Tester
    {
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = 
                new VisualizerDevelopmentHost(objectToVisualize, 
                    typeof(DictionaryDialogDebuggerVisualizer), typeof(DictionaryVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }
    }
}

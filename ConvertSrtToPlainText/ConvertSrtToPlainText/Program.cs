using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IO = System.IO;

namespace ConvertSrtToPlainText
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                return;
            }
            var lines = IO.File.ReadAllLines(args[0]);
            var line = String.Empty;
            var result = new List<string>();
            var stepLine = 2;
            foreach (var l in lines)
            {
                if (stepLine > 0)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        result.Add(line.Trim());
                        line = String.Empty;
                    }
                    stepLine -= 1;
                    continue;
                }
                if (String.IsNullOrWhiteSpace(l))
                {
                    stepLine = 2;
                    continue;
                }
                line += l + " ";
            }
            IO.File.WriteAllLines(args[1], result.ToArray());
        }
    }
}

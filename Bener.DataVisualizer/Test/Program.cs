using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bener.DataVisualizer;
using System.Windows.Forms;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //Bener.DataVisualizer.ControlVisualizer.TestShowVisualizer(new Control("Hello World!"));

            var dic = new Dictionary<int, Person>();
            dic.Add(3, new Person() { Id = 3, Name = "Hacı Hüsrev" });
            dic.Add(5, new Person() { Id = 5, Name = "Naci" });
            Tester.TestShowVisualizer(dic);
        }
    }


    //[Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    struct KartBilgisi
    {
        public System.Data.DataSet DataSet { get; set; }
        public System.Data.DataRow Row { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bener.DataVisualizer;
using System.Windows.Forms;
using System.Data;

namespace Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var lst = new List<Person>();
            lst.Add(new Person() { Id = 3, Name = "Hacı Hüsrev", Age = 18, Price = 23.42M });
            lst.Add(new Person() { Id = 5, Name = "Naci", Age = 23, Price = 13.83M });
            lst.Add(new Person() { Id = 8, Name = "Muhittin", Age = 31, Price = 42.71M });

            //Bener.DataVisualizer.ControlVisualizer.TestShowVisualizer(new Control("Hello World!"));

            var dic = new Dictionary<int, Person>();
            foreach (var item in lst)
            {
                dic.Add(item.Id, item);
            }
            Tester.TestShowVisualizer(dic);

            var ds = new DataSet();
            ds.Tables.Add("TestMe");
            ds.Tables["TestMe"].Columns.Add("Id", typeof(int));
            ds.Tables["TestMe"].Columns.Add("Name", typeof(string));
            var t = ds.Tables["TestMe"];
        }
    }

    //[Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public decimal Price { get; set; }
    }

    struct KartBilgisi
    {
        public System.Data.DataSet DataSet { get; set; }
        public System.Data.DataRow Row { get; set; }
    }
}

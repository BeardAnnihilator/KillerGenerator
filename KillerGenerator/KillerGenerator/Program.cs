using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        Random r = new Random();

        static void Main(string[] args)
        {
            string expDate = "02/08";
            Random r = new Random();
            XDocument xml = XDocument.Load("C:/Users/Periph_a/Desktop/COLO/Killer.xml");
            XDocument xml2 = XDocument.Load("C:/Users/Periph_a/Desktop/COLO/listnoms.xml");
            List<String> Action = new List<string>();
            List<String> Names = new List<string>();

            foreach (var toto in xml.Descendants("Data"))
            {
                if (toto.Value.ToString() != "")
                Action.Add(toto.Value.ToString());
            }
            foreach (var toto in xml2.Descendants("Data"))
            {
                if (toto.Value.ToString() != "")
                    Names.Add(toto.Value.ToString());
            }

            Shuffle<string>(Names);

            int u = 0;
            foreach (string n in Names)
            {
                u++;
                Console.WriteLine("Nom du killer : " + n);
                Console.WriteLine("Methode :" + randomValue<string>(Action, r));
                Console.WriteLine("Ta cible :" + Names.ElementAt(u % Names.Count));
                Console.WriteLine("Expiration:" + expDate);
                Console.WriteLine();
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/Users/Periph_a/Desktop/COLO/missions.txt"))
            {
                int i = 0;
                foreach (string n in Names)
                {
                    i++;
                    file.WriteLine("Nom du killer : " + n);
                    file.WriteLine("Methode :" + randomValue<string>(Action, r));
                    file.WriteLine("Ta cible :" + Names.ElementAt(i % Names.Count));
                    file.WriteLine("Expiration:" + expDate);
                        file.WriteLine();

                }
            }

            Console.ReadLine();
        }

        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        

        public static T randomValue<T>(IList<T> list, Random r)
        {
            return list[r.Next(list.Count)];
        }
    }
}

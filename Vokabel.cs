using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Vokabeltrainer
{
    [Serializable]
    public class Vokabel
    {
        public Vokabel(string lang1, string lang2)
        {
            this.lang1 = lang1;
            this.lang2 = lang2;
        }
        public string lang1, lang2;
    }

    public class Unit
    {
        public List<Vokabel> vokabels;
        private string language;
        public Unit()
        {
            vokabels = new List<Vokabel>();
            language = "de-en";
        }

        public Unit(string language)
        {
            vokabels = new List<Vokabel>();
            this.language = language;
        }

        public String GetLanguage()
        {
            return language;
        }

        public static void Save(List<Vokabel> unit, string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, unit);
            stream.Close();
        }

        public static List<Vokabel> Read(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            return (List<Vokabel>)formatter.Deserialize(stream);
        }
    }
}

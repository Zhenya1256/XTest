using Exceptionless.Json;
using Hurricane.XTest.Core.Abstract.Entities;
using Hurricane.XTest.Core.Entities;
using Hurricane.XTest.Core.Holders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hurricane.XTest.Core.Processors
{
    public class JsonParser<T> where T : IQuestionEntity
    {
        public static List<int> SaveList = new List<int>();
        public static Random _random = new Random();

        public IQuestionEntity GetIQuestionEntity(int start, int end, string name)
        {
                int value = 1;

                if (SaveList.Count == end - start)
                {
                    SaveList.RemoveAt(0);
                }

                do
                {

                    value = _random.Next(start, end);
                }
                while (SaveList.Contains(value));

                SaveList.Add(value);
                string path = Path.Combine(GenerateProcess.BasePath,
                     LanguageHolder.Lan, name, value + ".json");
        
                using (StreamReader st = new StreamReader(path, Encoding.UTF8))
                {

                    string json = st.ReadToEnd();

                    return JsonConvert.DeserializeObject<T>(json);
                }
        }
    }
}

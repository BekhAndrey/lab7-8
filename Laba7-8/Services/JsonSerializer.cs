using Laba7_8.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Laba7_8.Services
{
    class JsonSerializer
    {
        private readonly string Path;
        public JsonSerializer(string path)
        {
            Path = path;
        }
        public ObservableCollection<TodoModel> Deserialize()
        {
            var Exists = File.Exists(Path);
            if(!Exists)
            {
                File.CreateText(Path).Dispose();
                return new ObservableCollection<TodoModel>();
            }
            using(var reader = File.OpenText(Path))
            {
                var text = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<TodoModel>>(text);
            }
        }
        public void Serialize(object TodoDataList)
        {
            using(StreamWriter writter = File.CreateText(Path))
            {
                string result = JsonConvert.SerializeObject(TodoDataList);
                writter.Write(result);
            }
        }
    }
}

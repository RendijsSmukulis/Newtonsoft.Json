using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Newtonsoft.Json

{
    class Wrapper
    {
        public int a { get; set; }

        public string b { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var jsonstr = "{\"a\":5, \"b\":\"str val\"}";
            object z = null;

            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

            // by default DeserializeObject should check for additional content
            if (!jsonSerializer.IsCheckAdditionalContentSet())
            {
                jsonSerializer.CheckAdditionalContent = true;
            }

            using (JsonTextReader reader = new JsonTextReader(new StringReader(jsonstr)))
            {
                z = jsonSerializer.Deserialize(reader, typeof(Wrapper));
            }

            var deserred = JsonConvert.DeserializeObject<Wrapper>(jsonstr);

            Debugger.Break();
        }
    }
}

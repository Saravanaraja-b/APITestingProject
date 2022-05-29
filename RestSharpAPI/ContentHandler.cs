﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public static  class ContentHandler
    {
        public static T GetContent<T>(IRestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
        public static string SerializeJsonString(dynamic content)
        {
            return JsonConvert.SerializeObject(content, Formatting.Indented);
        }

        public static T ParseJson<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JTE.Views;
using Newtonsoft.Json;
namespace JTE.EpubBuilder
{
    public class BuildEpub
    
    {
    private object?  _chapters ;
        public class Chapter
        {
            public string Title { get; set; }
            public string Data { get; set;  }
            public bool Read { get; set; }
            public int Scroll { get; set; }
        }
        
        public BuildEpub(string json)
        
        {
            var chapters = JsonConvert.DeserializeObject(json);
            _chapters = chapters;
        }
        
       
      

        public void BuildBook()
        {
            Console.WriteLine(_chapters);
            }
        }
    }

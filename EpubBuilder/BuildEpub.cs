using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JTE.Views;
using Newtonsoft.Json;
using net.vieapps.Components.Utility.Epub;
namespace JTE.EpubBuilder
{
    public class BuildEpub

    {
        
        private List<Chapter>? _chapters ;
        private string? _path;
        public class Chapter
        {
            public string Title { get; set; }
            public string Data { get; set;  }
            public bool Read { get; set; }
            public int Scroll { get; set; }
        }
        
        
        public BuildEpub(string json, string path)

        {
	        _path = path;
            // net.vieapps.Components.Utility.Epub
            var epub = new Document();
            epub.AddTitle("WIP");
            
            var pageTemplate = @"<!DOCTYPE html>
	<html xmlns=""http://www.w3.org/1999/xhtml"">
		<head>
			<title>{0}</title>
			<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""/>
			<link type=""text/css"" rel=""stylesheet"" href=""style.css""/>
			<style type=""text/css"">
				@page {
					padding: 0;
					margin: 0;
				}
			</style>
		</head>
		<body>
			{1}

{2}
		</body>
	</html>".Trim().Replace("\t", "");

            
  

            
            var chapters = JsonConvert.DeserializeObject<List<Chapter>>(json);
            _chapters = chapters;
            for (var index = 0; index < _chapters.Count; index++)
            {
	            var name = string.Format("page{0}.xhtml", index + 1);
	            var title = _chapters[index].Title;
	            var content = _chapters[index].Data;
	            epub.AddXhtmlData(name, pageTemplate.Replace("{0}", title)
		            .Replace("{1}", content));
	            epub.AddNavPoint($"{index} - {title}", name, index + 1);
	            Console.WriteLine($"{index} of {_chapters.Count} generated.");

            }
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            epub.Generate($"{AppDomain.CurrentDomain.BaseDirectory}chapters.epub");
        }
        
        
        }
    }

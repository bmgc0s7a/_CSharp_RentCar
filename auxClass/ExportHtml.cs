using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrabalhoPratico.auxClass
{
    class ExportHtml
    {
        StreamWriter file;

        // Construct
        public ExportHtml(string name)
        { 
            file = new StreamWriter($@"{name}.html");
        }

        // Generate simple elem html tag
        public void elem(string elem, string txt, string style){
            file.WriteLine($"<{elem} style='{style}'>{txt}</{elem}>");
        }
        
        // Generate complex elem html tag
        public void elemSingle(string elem, string style, bool close = false)
        {
            if(!close)
                file.WriteLine($"<{elem} style='{style}'>");
            else
                file.WriteLine($"</{elem}>");
        }

        // Close File
        public void closeFile()
        {
            file.Close();
        }

       
    }
}

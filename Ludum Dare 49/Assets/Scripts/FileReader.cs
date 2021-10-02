using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assets.Scripts
{
    public class FileReader
    {
        public string[] ReadFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            return lines;
        }
    }
}

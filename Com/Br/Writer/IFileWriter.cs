using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Br.Writer
{
    public interface IFileWriter
    {
        Task WriteOutputFile(string outputFilePath, string outputText);
    }
}

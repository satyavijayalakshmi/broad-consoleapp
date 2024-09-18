using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchApp.Com.Br
{
    public interface IFileAnalyzer
    {
        Task ProcessFile(string inputFilePath, string outputFilePath);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Br.Reader
{
    public interface IFileReader
    {
        IAsyncEnumerable<string> ReadInputFile(string inputFilePath);
    }
}

using DinamycSQL.TO;
using System.IO;

namespace DinamycSQL.BO.Interfaces
{
    public interface IDataFileProcessorBO
    {
        void OpenFile(string fileName);

        void ProcessFile();

        DataFileHeaderTO GetFileHeader();

        DataFileContentTO GetFileContent();
    }
}

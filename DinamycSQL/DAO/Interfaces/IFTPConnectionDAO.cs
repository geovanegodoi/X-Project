using DinamycSQL.TO;
using System.IO;

namespace DinamycSQL.DAO.Interfaces
{
    public interface IFTPConnectionDAO
    {
        void OpenConnection(FTPConnectionTO to);

        File DownloadFile(string fileName);

        string GenerateCRC(File file);

        void CheckCRC(File file);

        void CloseConnection();
    }
}

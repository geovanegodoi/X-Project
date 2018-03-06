using DinamycSQL.TO;
using System.Data.Common;

namespace DinamycSQL.DAO.Interfaces
{
    public interface DBConnection
    {
        DbConnection OpenConnection(DBConnectionTO to);

        void InitTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        void CloseConnection();
    }
}

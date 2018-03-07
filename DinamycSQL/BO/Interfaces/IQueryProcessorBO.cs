using DinamycSQL.DAO.Interfaces;

namespace DinamycSQL.BO.Interfaces
{
    public interface IQueryProcessorBO
    {
        void LoadQueries();

        void ProcessQueries(DBConnection connection);
    }
}

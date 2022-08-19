using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IReportsRepository
    {
        Task<int> Create(Report reports);
        // Task<Report> Read(int id);
        // Task<IList<Report>> ReadAll();
    }
}
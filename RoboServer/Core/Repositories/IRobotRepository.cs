using Core.Entities;

namespace Core.Repositories;

public interface IRobotRepository
{
    Robot GetById(int id);
    int Create();
    void Save();
}

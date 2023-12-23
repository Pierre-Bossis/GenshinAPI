using Genshin.DAL.Entities;

namespace Genshin.DAL.Repositories
{
    public interface IAptitudesRepository
    {
        IEnumerable<AptitudesEntity> GetAll(int personnageId);
        void Create(AptitudesEntity aptitude);
    }
}

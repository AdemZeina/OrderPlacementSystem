using Microsoft.EntityFrameworkCore;

namespace Order.Domain.Sequences
{
    public interface ISequenceCreator
    {
        void Create(DbContext dbContext);
    }
}

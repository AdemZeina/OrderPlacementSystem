using Microsoft.EntityFrameworkCore;

namespace Order.Domain.Sequences
{
    public class CommonCreator : ICommonCreator
    {
        readonly DbContext _dbContext;
        readonly ISequenceCreator _sequenceCreator;
        public CommonCreator(DbContext dbContext, ISequenceCreator sequenceCreator) {
            _sequenceCreator = sequenceCreator;
            _dbContext = dbContext;
        }
        public void Create() {
            _sequenceCreator.Create(_dbContext);
        }
    }
}

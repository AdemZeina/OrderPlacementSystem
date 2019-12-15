using System;
using Microsoft.EntityFrameworkCore;

namespace Order.Domain.Sequences
{
    public class SequenceProvider : ISequenceProvider
    {
        private readonly DbContext _dbContext;

        public SequenceProvider(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetCode(Sequence sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            long value = -1;
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select next value for " + sequence.Name + " as seq";
                _dbContext.Database.OpenConnection();
               
                using (var result = command.ExecuteReader())
                {
                    value = Convert.ToInt64(result["seq"]);
                }
            }

            if (!string.IsNullOrWhiteSpace(sequence.Format))
                return string.Format(sequence.Format, value);
            return $"{sequence.CodePrefix}-{value}";
        }
    }
}

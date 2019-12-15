using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Order.Domain.Sequences
{
    public class SequenceCreator : ISequenceCreator
    {
        public void Create(DbContext dbContext) {

            StringBuilder stringBuilder = new StringBuilder();
            foreach (Sequence sequence in GetSequences()) {
                stringBuilder.AppendLine(string.Format("if not exists (select 1 from sys.sequences where name = '{0}')", sequence.Name));
                stringBuilder.AppendLine(string.Format("CREATE SEQUENCE {0} START WITH 1 INCREMENT BY 1", sequence.Name));
            }
            dbContext.Database.ExecuteSqlCommand(stringBuilder.ToString());
        }

        protected virtual IEnumerable<Sequence> GetSequences() {
            return GetSequencesFromFieldsOf<Sequence>();
              
        }

        protected IEnumerable<Sequence> GetSequencesFromFieldsOf<T>() {
            return ((IEnumerable<FieldInfo>)typeof(T).GetFields()).Select(f => f.GetValue(null)).OfType<Sequence>();
        }
    }
}

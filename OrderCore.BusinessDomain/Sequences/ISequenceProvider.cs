namespace Order.Domain.Sequences
{
    public interface ISequenceProvider
    {
        string GetCode(Sequence sequence);
    }
}

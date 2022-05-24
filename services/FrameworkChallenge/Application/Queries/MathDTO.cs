namespace FrameworkChallenge.API.Application.Queries
{
    public sealed class MathDTO
    {
        public ICollection<int> Dividers { get; set; }
        public ICollection<int> PrimeDividers { get; set; }
    }
}

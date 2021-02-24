namespace Next.Steps.Domain.Entities
{
    public class Hobby : IIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
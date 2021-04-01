namespace Warehouse.Persistence.Entities.Quality
{
    public sealed class Quality : Entity
    {
        public QualityLevel QualityLevel { get; set; }
        public string Description { get; set; }
    }
}

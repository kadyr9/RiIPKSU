namespace MvcApp.Models
{
    public class Cloth
    {
        public int Id { get; set; }
        public int Id_type_cloth { get; set; }
        public Cloth_type? Cloth_type { get; set; }//тип одежды
        public string? Cloth_size { get; set; }//размер одежды
        public string? Cloth_brand { get; set; }//бренд одежды

    }
    public class Cloth_type
    {

        public int Id { get; set; }
        public string? Name_cloth_type { get; set; }
        public List<Cloth> Clothes { get; set; } = new();
    }
}

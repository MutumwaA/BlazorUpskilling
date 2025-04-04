namespace Domain.EntityVM
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRegistered { get; set; } = false;
    }
}

namespace WebAPI.Dto
{
    public class EventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }
        public Guid OrganizerId { get; set; }
        public decimal Price { get; set; }
    }
}

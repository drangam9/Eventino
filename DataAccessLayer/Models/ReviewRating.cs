namespace DataAccessLayer.Models
{
    public class ReviewRating
    {
        public Guid ReviewRatingId { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}

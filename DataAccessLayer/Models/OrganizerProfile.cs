using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class OrganizerProfile
    {
        [Key]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public virtual User User { get; set; }
    }
}

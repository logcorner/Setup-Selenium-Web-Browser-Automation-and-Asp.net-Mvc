namespace LogCorner.BlogPost.Data.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class AspNetUserClaim
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
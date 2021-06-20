using System;

namespace ConsoleSqlLiteEfCore
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
using System;

namespace check.Models
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}

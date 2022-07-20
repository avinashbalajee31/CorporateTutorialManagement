using System;
using System.Collections.Generic;

namespace CorporateTutorialManagement.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public sbyte? Role { get; set; }
        public string Password { get; set; } = null!;
    }
}

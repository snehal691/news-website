using System;
using System.Collections.Generic;

namespace News
{
    public partial class PersonRole
    {
        public uint Id { get; set; }
        public uint PersonId { get; set; }
        public uint RoleId { get; set; }

        public Person Person { get; set; }
        public Role Role { get; set; }
    }
}

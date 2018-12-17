using System;
using System.Collections.Generic;

namespace News
{
    public partial class Role
    {
        public Role()
        {
            PersonRole = new HashSet<PersonRole>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public ICollection<PersonRole> PersonRole { get; set; }
    }
}

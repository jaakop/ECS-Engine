using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MGPhysics;

namespace ReeGame.Dictionaries
{
    class GroupMemberDictionary : Dictionary<Entity, Entity>
    {
        public new void Add(Entity groupMemberEntity, Entity groupEntity)
        {
            base.Add(groupEntity, groupMemberEntity);
        }

        public new Entity this[Entity groupEntity]
        {
            get { return base[groupEntity]; }
            set { base[groupEntity] = value; }
        }
    }
}

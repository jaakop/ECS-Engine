using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MGPhysics;

using ReeGame.Components;

namespace ReeGame.Dictionaries
{
    public class GroupDictionary : Dictionary<Entity, GroupComponent>
    {
        public new void Add(Entity groupEntity, GroupComponent groupComponent)
        {
            base.Add(groupEntity, groupComponent);
        }
        
        public new GroupComponent this[Entity groupEntity]
        {
            get { return base[groupEntity]; }
            set { base[groupEntity] = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class Engine
    {

        List<MoveAction> actions = new List<MoveAction>();

        public Engine(List<MoveAction> actions) {
            this.actions = actions;
        }

        public List<CheroAction> transform()
        {
            // TODO implementation
            return new List<CheroAction>();
        }
    }
}

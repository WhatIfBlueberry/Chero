using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class CheroAction
    {
        private Chero chero;
        private Field from;
        private Field to;
        public CheroAction(Chero chero, Field from, Field to)
        {
            this.chero = chero;
            this.from = from;
            this.to = to;
        }

        public void execute()
        {
            this.chero.moveFromTo(from, to, true);
        }
    }
}

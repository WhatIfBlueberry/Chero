using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    abstract class AbstractChessPiece : IChessPiece
    {
        protected Field field;

        public AbstractChessPiece(Field field)
        {
            this.field = field;
        }

        public virtual bool canReach(Field field, bool takes)
        {
            return true;
        }

        public virtual bool isUnknown()
        {
            return false;
        }

        public virtual Field getField()
        {
            return this.field;
        }

        public void setField(Field field)
        {
            this.field = field;
        }

    }


}

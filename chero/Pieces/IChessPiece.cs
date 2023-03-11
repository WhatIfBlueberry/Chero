using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal interface IChessPiece
    {
        Field getField();

        void setField(Field field);

        Boolean canReach(Field field, Boolean takes);
    }
}

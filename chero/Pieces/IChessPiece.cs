using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    public interface IChessPiece
    {
        public Field getField();

        public void setField(Field field);

        public bool canReach(Field field, bool takes);

        public bool isUnknown();
    }
}

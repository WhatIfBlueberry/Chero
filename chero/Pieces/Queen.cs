using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace chero
{
    internal class Queen : AbstractChessPiece
    {
        public Queen(Field field) : base(field)
        {
        }

        public override Field getField()
        {
            if(base.getField() == Field.UNKNOWN)
            {
                return this.field;
            }
            return this.field;
        }

        public override string ToString()
        {
            return "Queen";
        }

    }
}

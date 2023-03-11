﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    abstract class AbstractChessPiece : IChessPiece
    {
        Field field;

        public AbstractChessPiece(Field field)
        {
            this.field = field;
        }

        public virtual bool canReach(Field field, bool takes)
        {
            return true;
        }

        public Field getField()
        {
            return this.field;
        }

        public void setField(Field field)
        {
            this.field = field;
        }
    }


}

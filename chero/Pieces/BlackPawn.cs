﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class BlackPawn : AbstractChessPiece
    {
        public override bool canReach(Field field, bool takes)
        {
            return true;
        }
    }
}

using chero.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    internal class Engine
    {
        Chero chero;

        List<MoveAction> actions = new List<MoveAction>();

        public Engine(Chero chero, List<MoveAction> actions) {
            this.chero = chero;
            this.actions = actions;
        }

        public List<CheroAction> transform()
        {
            List<CheroAction> ret = new List<CheroAction>();
            foreach (MoveAction action in actions)
            {
                ret.Add(moveToChero(action));
            }
            return ret;
        }

        private CheroAction moveToChero(MoveAction action)
        {
            IChessPiece piece = action.getPiece();
            Field target = action.getTarget();
            if (piece.isUnknown())
            {
                return new CheroAction(chero, new UnknownPiece(Field.UNKNOWN), Field.UNKNOWN, Field.UNKNOWN, true);
            }
            piece = determinePiece(piece, target, action.getTakes());
            CheroAction ret = new CheroAction(chero, piece, piece.getField(), target, action.getIsWhite());
            piece.setField(target);
            return ret;
        }

        private IChessPiece determinePiece(IChessPiece piece, Field target, bool takes)
        {
            HashSet<IChessPiece> equals = Helper.getEquals(piece);
            foreach (IChessPiece piece2 in equals) 
            {
                if (piece2.canReach(target, takes))
                {
                    return piece2;
                }
            }
            // this return is just a blank and will throw NPE.
            // this case should never happen
            throw new InvalidOperationException("Engine found impossible move");


        }
    }
}

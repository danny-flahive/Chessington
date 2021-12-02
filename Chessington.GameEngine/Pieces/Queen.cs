using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            moves.AddRange(GetDiagonalMovement(board));
            moves.AddRange(GetLateralMovement(board));
            return moves;
        }
    }
}
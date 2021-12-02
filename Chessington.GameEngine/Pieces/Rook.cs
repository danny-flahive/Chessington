using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            for (var i = 0; i < 8; i++)
            {
                if (currentSquare.Row != i)
                {
                    moves.Add(Square.At(i, currentSquare.Col));
                }
                if (currentSquare.Col != i)
                {
                    moves.Add(Square.At(currentSquare.Row, i));
                }
            }
            return moves;
        }
    }
}
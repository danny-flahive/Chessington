using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            int row = currentSquare.Row;
            int col = currentSquare.Col;

            moves.Add(Square.At(row + 1, col + 1));
            moves.Add(Square.At(row + 1, col));
            moves.Add(Square.At(row + 1, col - 1));
            moves.Add(Square.At(row, col + 1));
            moves.Add(Square.At(row, col - 1));
            moves.Add(Square.At(row - 1, col + 1));
            moves.Add(Square.At(row - 1, col));
            moves.Add(Square.At(row - 1, col - 1));

            return moves;
        }
    }
}
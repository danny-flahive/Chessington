using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            int row = currentSquare.Row;
            int col = currentSquare.Col;
            if (this.Player == Player.Black && board.GetPiece(Square.At(row + 1, col)) == null)
            {
                moves.Add(Square.At(row + 1, col));
                if (!this.Moved && board.GetPiece(Square.At(row + 2, col)) == null)
                {
                    moves.Add(Square.At(row + 2, col));
                }
            } else if (this.Player == Player.White && board.GetPiece(Square.At(row - 1, col)) == null)
            {
                moves.Add(Square.At(row - 1, col));
                if (!this.Moved && board.GetPiece(Square.At(row - 2, col)) == null)
                {
                    moves.Add(Square.At(row - 2, col));
                }
            }
            return moves;
        }
    }
}
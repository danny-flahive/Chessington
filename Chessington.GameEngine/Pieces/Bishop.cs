using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            int row = currentSquare.Row;
            int col = currentSquare.Col;
            for (int i = 1; i < 8; i++)
            {
                if (row - i >= 0)
                {
                    if (col - i >= 0)
                    {
                        moves.Add(Square.At(row - i, col - i));     //Move to upper left
                    }
                    if (col + i <= 7)
                    {
                        moves.Add(Square.At(row - i, col + i));     //Move to upper right
                    }
                }
                if (row + i <= 7)
                {
                    if (col - i >= 0)
                    {
                        moves.Add(Square.At(row + i, col - i));     //Move to lower left
                    }
                    if (col + i <= 7)
                    {
                        moves.Add(Square.At(row + i, col + i));     //Move to lower right
                    }
                }
            }

            return moves;
        }
    }
}
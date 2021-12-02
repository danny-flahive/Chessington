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
            Square currentSquare = board.FindPiece(this);
            int row = currentSquare.Row;
            int col = currentSquare.Col;

            //Diagonal movement
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
            //Lateral movement
            for (int i = 0; i < 8; i++)
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
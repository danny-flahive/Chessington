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
            if (row + 1 < 8)
            {
                if (ValidMoveSpace(board, Square.At(row + 1, col)))
                {
                    moves.Add(Square.At(row + 1, col));
                }
                if (col + 1 < 8)
                {
                    if (ValidMoveSpace(board, Square.At(row + 1, col + 1)))
                    {
                        moves.Add(Square.At(row + 1, col + 1));
                    }
                }
                if (col - 1 >= 0)
                {
                    if (ValidMoveSpace(board, Square.At(row + 1, col - 1)))
                    {
                        moves.Add(Square.At(row + 1, col - 1));
                    }
                }
            }
            if (row - 1 >= 0)
            {
                if (ValidMoveSpace(board, Square.At(row - 1, col)))
                {
                    moves.Add(Square.At(row - 1, col));
                }
                if (col + 1 < 8)
                {
                    if (ValidMoveSpace(board, Square.At(row - 1, col + 1)))
                    {
                        moves.Add(Square.At(row - 1, col + 1));
                    }
                }
                if (col - 1 >= 0)
                {
                    if (ValidMoveSpace(board, Square.At(row - 1, col - 1)))
                    {
                        moves.Add(Square.At(row - 1, col - 1));
                    }
                }
            }
            if (col - 1 >= 0)
            {
                if (ValidMoveSpace(board, Square.At(row, col - 1)))
                {
                    moves.Add(Square.At(row, col - 1));
                }
            }
            if (col + 1 < 8)
            {
                if (ValidMoveSpace(board, Square.At(row, col + 1)))
                {
                    moves.Add(Square.At(row, col + 1));
                }
            }
            return moves;
        }
    }
}
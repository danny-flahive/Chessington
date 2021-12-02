using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            int row = currentSquare.Row;
            int col = currentSquare.Col;
            if (row + 2 < 8)
            {
                if (col + 1 < 8)
                {
                    if(ValidMoveSpace(board, Square.At(row + 2, col + 1)))
                    {
                        moves.Add(Square.At(row + 2, col + 1));
                    }
                }
                if (col - 1 > 0)
                {
                    if (ValidMoveSpace(board, Square.At(row + 2, col - 1)))
                    {
                        moves.Add(Square.At(row + 2, col - 1));
                    }
                }
            }
            if (row - 2 >= 0)
            {
                if (col + 1 < 8)
                {
                    if (ValidMoveSpace(board, Square.At(row - 2, col + 1)))
                    {
                        moves.Add(Square.At(row - 2, col + 1));
                    }
                }
                if (col - 1 > 0)
                {
                    if (ValidMoveSpace(board, Square.At(row - 2, col - 1)))
                    {
                        moves.Add(Square.At(row - 2, col - 1));
                    }
                }
            }
            if (col + 2 < 8)
            {
                if (row + 1 < 8)
                {
                    if (ValidMoveSpace(board, Square.At(row + 1, col + 2)))
                    {
                        moves.Add(Square.At(row + 1, col + 2));
                    }
                }
                if (row - 1 > 0)
                {
                    if (ValidMoveSpace(board, Square.At(row - 1, col + 2)))
                    {
                        moves.Add(Square.At(row - 1, col + 2));
                    }
                }
            }
            if (col - 2 >= 0)
            {
                if (row + 1 < 8)
                {
                    if (ValidMoveSpace(board, Square.At(row + 1, col - 2)))
                    {
                        moves.Add(Square.At(row + 1, col - 2));
                    }
                }
                if (row - 1 > 0)
                {
                    if (ValidMoveSpace(board, Square.At(row - 1, col - 2)))
                    {
                        moves.Add(Square.At(row - 1, col - 2));
                    }
                }
            }
            return moves;
        }
    }
}
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
            int[,] offsets = new int[,]
            {
                {1, 1},
                {1, 0},
                {1, -1},
                {0, 1},
                {0, -1},
                {-1, -1},
                {-1, 1},
                {-1, 0}
            };
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            int row = currentSquare.Row;
            int col = currentSquare.Col;
            for (int i = 0; i < offsets.GetLength(0); i++)
            {
                if (ValidMoveSpace(board, Square.At(row + offsets[i, 0], col + offsets[i, 1])))
                {
                    moves.Add(Square.At(row + offsets[i, 0], col + offsets[i, 1]));
                }
            }
            return moves;
        }
    }
}
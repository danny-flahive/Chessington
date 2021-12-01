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
            int whiteStartSpace = 7;
            int blackStartSpace = 1;
            Square currentSquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            if (this.Player == Player.Black)
            {
                moves.Add(Square.At((currentSquare.Row + 1), currentSquare.Col));
                if (currentSquare.Row == blackStartSpace)
                {
                    moves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                }
            } else
            {
                moves.Add(Square.At((currentSquare.Row - 1), currentSquare.Col));
                if (currentSquare.Row == whiteStartSpace)
                {
                    moves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                }
            }
            return moves;
        }
    }
}
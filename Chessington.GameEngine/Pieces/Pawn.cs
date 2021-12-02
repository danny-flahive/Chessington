using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        //TODO: Add promotion
        //If a pawn hits the end row (opposite where you started) it turns into another piece
        //User can choose any piece except king or pawn
        //Most people choose queen - start by only promoting to queen, then consider taking in user input
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            int row = currentSquare.Row;
            int col = currentSquare.Col;
            if (this.Player == Player.Black && row + 1 < 8)
            {
                if (board.GetPiece(Square.At(row + 1, col)) == null)
                {
                    moves.Add(Square.At(row + 1, col));
                    if (!this.Moved && row + 2 < 8 && board.GetPiece(Square.At(row + 2, col)) == null)
                    {
                        moves.Add(Square.At(row + 2, col));
                    }
                }
                if (col + 1 < 8 && board.GetPiece(Square.At(row + 1, col + 1)) != null && board.GetPiece(Square.At(row + 1, col + 1)).Player != this.Player)
                {
                    moves.Add(Square.At(row + 1, col + 1));
                }
                if (col - 1 >= 0 && board.GetPiece(Square.At(row + 1, col - 1)) != null && board.GetPiece(Square.At(row + 1, col - 1)).Player != this.Player)
                {
                    moves.Add(Square.At(row + 1, col - 1));
                }
            } else if (this.Player == Player.White && row - 1 >= 0)
            {
                if (board.GetPiece(Square.At(row - 1, col)) == null)
                {
                    moves.Add(Square.At(row - 1, col));
                    if (!this.Moved && row - 2 >= 0 && board.GetPiece(Square.At(row - 2, col)) == null)
                    {
                        moves.Add(Square.At(row - 2, col));
                    }
                }
                if (col + 1 < 8 && board.GetPiece(Square.At(row - 1, col + 1)) != null && board.GetPiece(Square.At(row - 1, col + 1)).Player != this.Player)
                {
                    moves.Add(Square.At(row - 1, col + 1));
                }
                if (col - 1 >= 0 && board.GetPiece(Square.At(row - 1, col - 1)) != null && board.GetPiece(Square.At(row - 1, col - 1)).Player != this.Player)
                {
                    moves.Add(Square.At(row - 1, col - 1));
                }
            }
            return moves;
        }
    }
}
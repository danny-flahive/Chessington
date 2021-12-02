using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }
        protected bool Moved = false;

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            if (!Moved)
            {
                Moved = true;
            }
        }

        public IEnumerable<Square> GetLateralMovement(Board board)
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

        public IEnumerable<Square> GetDiagonalMovement(Board board)
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
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
            int row = currentSquare.Row;
            int col = currentSquare.Col;
            for (int i = 1; i < 8; i++)
            {
                if (!(row + i < 8 && board.GetPiece(Square.At(row + i, col)) == null))
                {
                    if (row + i < 8)
                    {
                        Piece piece = board.GetPiece(Square.At(row + i, col));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row + i, col));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row + i, col));
            }
            for (int i = 1; i < 8; i++)
            {
                
                if (!(row - i >= 0 && board.GetPiece(Square.At(row - i, col)) == null))
                {
                    if (row - i >= 0)
                    {
                        Piece piece = board.GetPiece(Square.At(row - i, col));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row - i, col));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row - i, col));
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(col + i < 8 && board.GetPiece(Square.At(row, col + i)) == null))
                {
                    if (col + i < 8)
                    {
                        Piece piece = board.GetPiece(Square.At(row, col + i));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row, col + i));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row, col + i));
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(col - i >= 0 && board.GetPiece(Square.At(row, col - i)) == null))
                {
                    if (col - i >= 0)
                    {
                        Piece piece = board.GetPiece(Square.At(row, col - i));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row, col - i));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row, col - i));
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
                if (!(row - i >= 0 && col - i >= 0 && board.GetPiece(Square.At(row - i, col - i)) == null))
                {
                    if (row - i >= 0 && col - i >= 0)
                    {
                        Piece piece = board.GetPiece(Square.At(row - i, col - i));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row - i, col - i));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row - i, col - i));     //Move to upper left
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(row - i >= 0 && col + i < 8 && board.GetPiece(Square.At(row - i, col + i)) == null))
                {
                    if (row - i >= 0 && col + i < 8)
                    {
                        Piece piece = board.GetPiece(Square.At(row - i, col + i));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row - i, col + i));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row - i, col + i));     //Move to upper right
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(row + i < 8 && col - i >= 0 && board.GetPiece(Square.At(row + i, col - i)) == null))
                {
                    if (row + i < 8 && col - i >= 0)
                    {
                        Piece piece = board.GetPiece(Square.At(row + i, col - i));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row + i, col - i));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row + i, col - i));     //Move to lower left
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(row + i < 8 && col + i < 8 && board.GetPiece(Square.At(row + i, col + i)) == null))
                {
                    if (row + i < 8 && col + i < 8)
                    {
                        Piece piece = board.GetPiece(Square.At(row + i, col + i));
                        if (piece != null && piece.Player != this.Player)
                        {
                            moves.Add(Square.At(row + i, col + i));
                        }
                    }
                    break;
                }
                moves.Add(Square.At(row + i, col + i));     //Move to lower right
            }

            return moves;
        }
    }
}
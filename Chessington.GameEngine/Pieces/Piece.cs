﻿using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

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
            //Pawn promotion is handled here - could handle this elsewhere but this works for now
            if (this.GetType() == typeof(Pawn))
            {
                if ((this.Player == Player.Black && newSquare.Row == 7) || (this.Player == Player.White && newSquare.Row == 0))
                {
                    Piece newPiece = GetUserPiece();
                    board.AddPiece(newSquare, newPiece);
                }
            }
        }

        private Piece GetUserPiece()
        {
            string promptText = "Enter a piece to promote to: ";
            while (true)
            {
                string choice = Interaction.InputBox(promptText, "Pawn Promotion", "Queen");
                switch (choice.ToLower())
                {
                    case "rook":
                        return new Rook(this.Player);
                    case "bishop":
                        return new Bishop(this.Player);
                    case "knight":
                        return new Knight(this.Player);
                    case "queen":
                        return new Queen(this.Player);
                    default:
                        promptText = "Enter a valid piece to promote to: ";
                        break;
                }
            }
        }

        public IEnumerable<Square> GetLateralMovement(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            int row = currentSquare.Row;
            int col = currentSquare.Col;
            for (int i = 1; row + i < 8; i++)
            {
                Piece piece = board.GetPiece(Square.At(row + i, col));
                if (piece != null)
                { 
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row + i, col));
                    }
                    break;
                }
                moves.Add(Square.At(row + i, col));
            }
            for (int i = 1; row - i >= 0; i++)
            {
                Piece piece = board.GetPiece(Square.At(row - i, col));
                if (piece != null)
                {
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row - i, col));
                    }
                    break;
                }
                moves.Add(Square.At(row - i, col));
            }
            for (int i = 1; col + i < 8; i++)
            {
                Piece piece = board.GetPiece(Square.At(row, col + i));
                if (piece != null)
                {
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row, col + i));
                    }
                    break;
                }
                moves.Add(Square.At(row, col + i));
            }
            for (int i = 1; col - i >= 0; i++)
            {
                Piece piece = board.GetPiece(Square.At(row, col - i));
                if (piece != null)
                {
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row, col - i));
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

            for (int i = 1; row - i >= 0 && col - i >= 0; i++)      //Move to upper left
            {
                Piece piece = board.GetPiece(Square.At(row - i, col - i));
                if (piece != null)
                {
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row - i, col - i));
                    }
                    break;
                }
                moves.Add(Square.At(row - i, col - i));
            }
            for (int i = 1; row - i >= 0 && col + i < 8; i++)       //Move to upper right
            {
                Piece piece = board.GetPiece(Square.At(row - i, col + i));
                if (piece != null)
                { 
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row - i, col + i));
                    }
                    break;
                }
                moves.Add(Square.At(row - i, col + i));
            }
            for (int i = 1; row + i < 8 && col - i >= 0; i++)       //Move to lower left
            {
                Piece piece = board.GetPiece(Square.At(row + i, col - i));
                if (piece != null)
                {
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row + i, col - i));
                    }
                    break;
                }
                moves.Add(Square.At(row + i, col - i));
            }
            for (int i = 1; row + i < 8 && col + i < 8; i++)        //Move to lower right
            {
                Piece piece = board.GetPiece(Square.At(row + i, col + i));
                if (piece != null)
                {
                    if (piece.Player != this.Player)
                    {
                        moves.Add(Square.At(row + i, col + i));
                    }
                    break;
                }
                moves.Add(Square.At(row + i, col + i));
            }
            return moves;
        }

        public bool ValidMoveSpace(Board board, Square square)
        {
            return (square.Row >= 0 && square.Row < 8 && square.Col >= 0 && square.Col < 8) && (board.GetPiece(square) == null || board.GetPiece(square).Player != this.Player);
        }
    }
}
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void PawnCanBeAddedToBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(0, 0), pawn);

            board.GetPiece(Square.At(0, 0)).Should().BeSameAs(pawn);
        }

        [Test]
        public void PawnCanBeFoundOnBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            var square = Square.At(6, 4);
            board.AddPiece(square, pawn);

            var location = board.FindPiece(pawn);

            location.Should().Be(square);
        }

        [Test]
        public void StalemateIsFound_PawnsFacingEachother()
        {
            Board board = new Board();
            board.AddPiece(Square.At(5, 3), new Pawn(Player.White));
            board.AddPiece(Square.At(4, 3), new Pawn(Player.Black));

            Assert.IsTrue(board.IsStalemate());
        }

        [Test]
        public void StalemateIsFound_WhiteKingInCheck()
        {
            Board board = new Board();
            board.AddPiece(Square.At(7, 0), new King(Player.White));
            board.AddPiece(Square.At(6, 2), new Queen(Player.Black));

            Assert.IsTrue(board.IsStalemate());
        }

        [Test]
        public void StalemateIsFound_BlackKingInCheck()
        {
            Board board = new Board();
            board.AddPiece(Square.At(7, 0), new King(Player.Black));
            board.AddPiece(Square.At(6, 2), new Queen(Player.White));

            Assert.IsTrue(board.IsStalemate());
        }

        [Test]
        public void StalemateIsFound_AfterMovement_PawnsFacingEachother()
        {
            Board board = new Board();
            board.AddPiece(Square.At(6, 3), new Pawn(Player.White));
            board.AddPiece(Square.At(4, 3), new Pawn(Player.Black));

            Assert.IsFalse(board.IsStalemate());

            board.MovePiece(Square.At(6, 3), Square.At(5, 3));
            Assert.IsTrue(board.IsStalemate());
        }

        [Test]
        public void StalemateIsFound_AfterMoving_BlackKingInCheck()
        {
            Board board = new Board();
            board.AddPiece(Square.At(7, 0), new King(Player.Black));
            board.AddPiece(Square.At(6, 3), new Queen(Player.White));

            Assert.IsFalse(board.IsStalemate());

            board.MovePiece(Square.At(6, 3), Square.At(6, 2));
            Assert.IsTrue(board.IsStalemate());
        }

        [Test]
        public void StalemateIsFound_AfterMoving_WhiteKingInCheck()
        {
            Board board = new Board(Player.Black);
            board.AddPiece(Square.At(7, 0), new King(Player.White));
            board.AddPiece(Square.At(6, 3), new Queen(Player.Black));

            Assert.IsFalse(board.IsStalemate());

            board.MovePiece(Square.At(6, 3), Square.At(6, 2));
            Assert.IsTrue(board.IsStalemate());
        }
    }
}

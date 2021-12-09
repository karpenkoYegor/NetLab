using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace CardGame.Tests
{
    [TestFixture]
    public class UnitTests1
    {
        private readonly IDesk _desk;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public UnitTests1()
        {
            _player1 = new Player("player1");
            _player2 = new Player("player2");
            _desk = new Desk(_player1, _player2);
        }

        [Test]
        public void Desk_TrySetCountOfCardEqual40_Return40()
        {
            var countOfCard = 40;
            var desk = _desk;
            desk.CountOfCards = countOfCard;

            var result = desk.CountOfCards;

            Assert.AreEqual(result, countOfCard);
        }

        [Test]
        public void Desk_TrySetCountOfCardNotEqual40_ReturnException()
        {
            var countOfCard = 20;
            var desk = _desk;
            

            Assert.Throws<Exception>(() => desk.CountOfCards = countOfCard);
        }

        [Test]
        public void Desk_CheckShuffleCard_ReturnShuffleList()
        {
            _desk.GenerateCards();
            var notShuffleList = _desk.GetCards();
            var list1 = new List<ICard>();
            list1.AddRange(notShuffleList);
            _desk.ShuffleCard();
            
            var shuffleList = _desk.GetCards();
            
            Assert.IsFalse(list1.SequenceEqual(shuffleList));
        }

        [Test]
        public void Player_CheckFillCards_ReturnQueueWithCards()
        {
            _player1.Discard = new List<ICard>();
            _player1.Discard.Add(new Card(5));
            _player1.Discard.Add(new Card(5));
            _player1.Discard.Add(new Card(5));
            _player1.Discard.Add(new Card(5));
            _player1.Cards.Enqueue(new Card(6));

            _player2.Cards.Enqueue(new Card(7));
            _player2.Cards.Enqueue(new Card(7));

            var expectedCountPlayer1Card = 4;

            _desk.CheckCards(_player1.GetCard(), _player2.GetCard());

            Assert.AreEqual(expectedCountPlayer1Card, _player1.GetCountCards());
        }

        [Test]
        public void Desk_CheckCardBattle_ReturnTwoDiscardCards()
        {
            var cardWithMoreValue = Substitute.For<ICard>();
            cardWithMoreValue.Value = 7;
            var cardWithLessValue = Substitute.For<ICard>();
            cardWithLessValue.Value = 4;
            _desk.CheckCards(cardWithMoreValue, cardWithLessValue);

            var expected = 2;

            Assert.AreEqual(expected, _player1.Discard.Count);
        }

        [Test]
        public void Desk_CheckDraw_ReturnFourDiscardCards()
        {
            var card1 = Substitute.For<ICard>();
            var card2 = Substitute.For<ICard>();
            card1.Value = 1;
            card2.Value = 1;
            _desk.CheckCards(card1,card2);
            card1.Value = 7;
            card2.Value = 8;
            _desk.CheckCards(card1,card2);

            var expected = 4;

            Assert.AreEqual(expected, _player2.Discard.Count);
        } 
    }
}

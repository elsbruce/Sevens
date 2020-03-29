using System;
using System.Collections.Generic;
using System.Linq;

namespace Sevens
{
    //difficult player inherits from AI Player, overriding the determineCardToBePlayed, and adding Count, SameSide and getNextAIPlayer which only exist within the difficult player class
    class DifficultPlayer : AIPlayer
    {

        public DifficultPlayer()
        {

        }

        public override void determineCardToBePlayed(Board board)
        {
            //AI players gang up
            //counts cards of each suit in human player, then plays card of that suit
            List<Card> possibleMoves = getPossibleMoves(board);
            List<Card> bestMoves = new List<Card>();

            if (possibleMoves.Count == 0)
            {
                setCardToBePlayed(base.getCards().FirstOrDefault());
            }
            else
            {
                List<int> humanValues = board.getQueue().GetHumanPlayer().cardsSuitCounts().OfType<int>().ToList();

                //finds suit of min value in human values, removes this min value from human values, if there is a card of this suit in valid moves, then returns this
                //loops through 4 times, to go through each of the 4 suits in order of how beneficial they are to the human player- but loop is broken when a card of the suit being searched for is found
                for (int suitCounter = 0; suitCounter < 4; suitCounter++)
                {
                    int suitOfHumanMin = humanValues.IndexOf(humanValues.Min());
                    humanValues[suitOfHumanMin] = 99; //replaces the minimum value, such that it is no longer the minimum
                    bestMoves = possibleMoves.FindAll(item => item.getSuit() == suitOfHumanMin); //all possible moves of worst suit for human player

                    if (bestMoves.Count == 1) //one move of human's worst possible suit
                    {
                        setCardToBePlayed(bestMoves.FirstOrDefault());
                        suitCounter = 100; //breaks out of the for loop
                    }
                    else if (bestMoves.Count > 1) //more than one move of worst possible suit
                    { //calculates using other AIs
                        int[] moveScores = new int[bestMoves.Count];
                        int max = 0;

                        Player temp = GetNextAIPlayer(board);

                        for (int i = 0; i < bestMoves.Count; i++) //loops through each move of the human's worst suit and finds benefit of each one to the next AI Player
                        {
                            moveScores[i] = CalculateBenefit(temp, bestMoves.ElementAt(i));


                            if (moveScores[i] > max) //if score is the biggest of the possible moves so far, then update cardToReturn
                            {
                                max = moveScores[i];
                                setCardToBePlayed(bestMoves.ElementAt(i));
                            }
                        }

                        suitCounter = 100; //breaks out of the for loop
                    }
                    //if no moves of current human's worst suit, then go to next worst suit by returning to the start of the for loop 
                }
            }
        }

        //Count takes parameters Player which holds the player which the value of the card's benefit is being found for, and Card parameter holds the possibleMoveCard which the value is being found for
        //returns an integer which represents the value of the card parsed to it, to the player parsed to the method
        //the value is calculated through the use of a counter which increments by one each time another card of the same suit and the same side of the seven is found in the hand of the player, this counter is then returned when all cards in the player's hand have been looped through

        public int CalculateBenefit(Player player, Card possibleMoveCard)
        {
            int counter = 0;

            for (int i = 0; i < player.getCurrentSize(); i++)
            {
                if ((player.getCards()[i].getSuit() == possibleMoveCard.getSuit()) && SameSide(possibleMoveCard, player.getCards()[i]))
                {
                    counter++;
                }
            }

            return counter;
        }

        //takes parameters of two cards
        //returns a Boolean which is true is both cards are on the same side of the seven, or if the possibleMoveCard is a seven, or false if the cards are not
        //returns false if the comparison card is a 7, as the possibleMove card being placed does not enable the placing of the comparisonCard
        public Boolean SameSide(Card possibleMoveCard, Card comparisonCard) //checks whether both cards are the same side of the seven
        {
            if (((possibleMoveCard.getValue() < 7) && (comparisonCard.getValue() < 7)) || ((possibleMoveCard.getValue() > 7) && (comparisonCard.getValue() > 7)))
            {
                return true;
            }
            else if (possibleMoveCard.getValue() == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //getNextAIPlayer takes the board which holds the current position of the game, including the queue of players
        //returns the next AI player in the queue
        //finds the next AI player by getting the next player, and if this player is a human Player then getting the next player after that
        //the currentPlayerMinsOne is called the same number of times as getNextPlayer has been called to cancel out the incrememntations to the currentPlayerIndex, such that the same player remains as the current player
        public Player GetNextAIPlayer(Board board)
        {
            Player temp = new DifficultPlayer();

            temp = board.getQueue().GetNextPlayer();
            if (board.getQueue().GetCurrentPlayer().GetType().ToString() == "HumanPlayer")
            {
                temp = board.getQueue().GetNextPlayer();
                board.getQueue().CurrentPlayerMinusOne();
            }
            board.getQueue().CurrentPlayerMinusOne();

            return temp;
        }
    }
}
        
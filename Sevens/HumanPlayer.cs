using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class HumanPlayer : Player
    {

        public override Card Move()
        {
            return (base.getCards())[0];
        }

        private Card[] MergeValue(Card[] CommunityCards, int start, int mid, int end)
        {
            Card[] temp = new Card[end - start + 1];
            int i = start, j = mid + 1, k = 0;
            while (i <= mid && j <= end)
            {
                if (CommunityCards[i].getValue() <= CommunityCards[j].getValue())
                {
                    temp[k] = CommunityCards[i];
                    k += 1; i += 1;
                }
                else
                {
                    temp[k] = CommunityCards[j];
                    k += 1; j += 1;
                }
            }
            while (i <= mid)
            {
                temp[k] = CommunityCards[i];
                k += 1; i += 1;
            }
            while (j <= end)
            {
                temp[k] = CommunityCards[j];
                k += 1; j += 1;
            }


            for (i = start; i <= end; i += 1)
            {
                CommunityCards[i] = temp[i - start];
            }
            return CommunityCards;
        }
        private Card[] CardSortValue(Card[] CoummunityCards, int start, int end)
        {

            if (start < end)
            {
                int mid = (start + end) / 2;
                CardSortValue(CoummunityCards, start, mid);
                CardSortValue(CoummunityCards, mid + 1, end);
                MergeValue(CoummunityCards, start, mid, end);
            }
            return CoummunityCards;
        }
        private Card[] MergeSuit(Card[] cards, int start, int mid, int end)
        {
            Card[] temp = new Card[end - start + 1];
            int i = start, j = mid + 1, k = 0;
            while (i <= mid && j <= end)
            {
                if (cards[i].getSuit() <= cards[j].getSuit())
                {
                    temp[k] = cards[i];
                    k += 1; i += 1;
                }
                else
                {
                    temp[k] = cards[j];
                    k += 1; j += 1;
                }
            }
            while (i <= mid)
            {
                temp[k] = cards[i];
                k += 1; i += 1;
            }
            while (j <= end)
            {
                temp[k] = cards[j];
                k += 1; j += 1;
            }


            for (i = start; i <= end; i += 1)
            {
                cards[i] = temp[i - start];
            }
            return cards;
        }
        private Card[] CardSortSuit(Card[] cards, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                CardSortSuit(cards, start, mid);
                CardSortSuit(cards,mid + 1, end);
                MergeSuit(cards, start, mid, end);
            }
            return cards;
        }

    }
    }

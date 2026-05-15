using UnityEngine;
using UnityEngine.InputSystem;
using Study.CardSelector;

namespace Study.PairMatchingGame
{
    public class CardSelector : MonoBehaviour
    {
        private Card[] cards; //외부에서(PairMatchingGame)에서 주입 받습니다
        public UnityEngine.Transform cursor;
        public int currentIndex = 2;

        private Card selectCardA;
        private Card selectCardB;

        private void Update()
        {
            wasSelectionCompleted = false;

            if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
            {
                MoveCursor(true);
            }
            else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
            {
                MoveCursor(false);
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                SelectCard();
            }
        }

        private void MoveCursor(bool isLeft)
        {
            currentIndex += isLeft ? -1 : +1;

            if (currentIndex < 0) currentIndex = cards.Length - 1;
            if (currentIndex >= cards.Length) currentIndex = 0;

            float cardX = cards[currentIndex].transform.position.x;
            cursor.position = new Vector3(cardX, cursor.position.y);
        }

        private void SelectCard()
        {
            Card currentCard = cards[currentIndex];

            if (selectCardA == null) selectCardA = currentCard;
            else
            {
                selectCardB = currentCard;
                wasSelectionCompleted = true;
            }
                
            cards[currentIndex].Flip();
        }

        /// <summary>
        /// 0번은 첫번째로 선택한 카드, 1번은 두번째로 선택한 카드
        /// </summary>
        /// <returns></returns>
        public Card[] GetSelectedCards()
        {
            return new[] { selectCardA, selectCardB };
        }

        public void Clear()
        {
            selectCardA = null;
            selectCardB = null;
        }

        // 이번 프레임에 카드 선택이 완료되었는지 체크하는 bool 변수
        public bool wasSelectionCompleted = false;


        // cards 배열에 존재하지 않는 개체를 건너뛰는 기능을 만들어야 합니다

        public void SetBoard(Card[] cardArray)
        {
            cards = cardArray;
        }
    }
}



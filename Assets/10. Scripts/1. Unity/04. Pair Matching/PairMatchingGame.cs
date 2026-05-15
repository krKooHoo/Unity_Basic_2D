using Study.CardSelector;
using UnityEngine;


namespace Study.PairMatchingGame
{
    public class PairMatchingGame : MonoBehaviour
    {
        // Card Selector에 의해 선택된 두 카드를 비교합니다.
        // 같으면 지우고, 다르면 뒤집습니다.

        public CardSelector cardSelector;

        // CardSelector가 갖고 있던 Card[]을 PairMatchingGame 객체가 관리하도록
        // 코드를 수정합니다. CardSelector는 외부에서 Card[]을 주입받아서
        // 동작하게 됩니다
        
        public Card[] board; // 게임 보드라는 의미입니다

        private void Awake()
        {
            cardSelector.SetBoard(board);
        }


        private void LateUpdate()
        {
            if (cardSelector.wasSelectionCompleted)
            {
                Card[] selectedCard = cardSelector.GetSelectedCards();
                CheckPairMatching(selectedCard[0], selectedCard[1]);
            }
        }

        private void CheckPairMatching(Card a, Card b)
        {
            // 같으면 지우고
            if(a.myNumber == b.myNumber)
            {
                Destroy(a.gameObject); // a 컴포넌트가 부착된 게임오브젝트를 삭제합니다
                Destroy(b.gameObject); // b 컴포넌트가 부착된 게임오브젝트를 삭제합니다

                Debug.Log("두 카드가 같습니다");
            }
            else // 다르면 뒤집어라
            {
                a.Flip();
                b.Flip();

                Debug.Log("두 카드가 다릅니다");
            }

            cardSelector.Clear();
        }

        // 객체를 안전하게 삭제하는 기능을 넣어봅시다
        private void DeleteCard(Card target)
        {

        }
    }
}



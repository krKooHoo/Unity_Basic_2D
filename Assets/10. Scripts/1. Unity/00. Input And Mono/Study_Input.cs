using UnityEngine;
using UnityEngine.InputSystem;


// 클래스명 중복방지를 위해 namespace를 사용합니다
namespace Study.Input 
{
    public class Study_Input : MonoBehaviour
    {
        private void Update()
        {
            SpaceInputTest();
        }

        private void SpaceInputTest()
        {
            // 키보드에 Space Input을 받아봅시다!

            bool isPressed = Keyboard.current.spaceKey.isPressed;
            Debug.Log($"isPressed = {isPressed}");
        }

        private void ArrowInputTest()
        {

        }
    }
}
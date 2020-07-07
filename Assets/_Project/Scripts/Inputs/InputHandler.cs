using UnityEngine;

namespace Scripts.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public bool GetForwardButton() => Input.GetButton("Forward");

        public bool GetTouch()
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                return true;
            }
            return false;
        }
    }
}
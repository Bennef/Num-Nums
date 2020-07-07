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
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
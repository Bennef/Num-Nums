using UnityEngine;

namespace Scripts.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public bool GetForwardButton() => Input.GetButton("Forward");
    }
}
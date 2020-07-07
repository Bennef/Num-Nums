using UnityEngine;

namespace Scripts.UI
{
    public class BackgroundColor : MonoBehaviour
    {
        float _hueValue;

        void Start()
        {
            _hueValue = Random.Range(0, 10) / 10.0f;
            SetBackgroundColor();
        }

        public void SetBackgroundColor()
        {
            Camera.main.backgroundColor = Color.HSVToRGB(_hueValue, 0.6f, 0.8f);
            _hueValue += 0.1f;

            if (_hueValue >= 1)
            {
                _hueValue = 0;
            }
        }
    }
}
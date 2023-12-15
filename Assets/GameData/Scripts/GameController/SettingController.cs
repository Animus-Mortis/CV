using UnityEngine;

namespace Game.GameController
{
    public class SettingController : MonoBehaviour
    {
        private float mouseSensitiveMultiplier = 1;
        private float speedClipboardMultiplier = 1;

        public void SetMouseSensetive(float value)
        {
            mouseSensitiveMultiplier = value;
        }

        public void SetSpeedClipboard(float value)
        {
            speedClipboardMultiplier = value;
        }

        public float GetMouseSensitiveMultiplier()
        {
            return mouseSensitiveMultiplier;
        }

        public float GetSpeedClipboardMultiplier()
        {
            return speedClipboardMultiplier;
        }
    }
}
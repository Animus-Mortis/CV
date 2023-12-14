using UnityEngine;

namespace Game.GameController
{
    public class SettingController : MonoBehaviour
    {
        [SerializeField] private SettingData settingData;

        public void SetMouseSensetive(float value)
        {
            settingData.mouseSensitiveMultiplier = value;
        }

        public void SetSpeedClipboard(float value)
        {
            settingData.speedClipboardMultiplier = value;
        }
    }
}
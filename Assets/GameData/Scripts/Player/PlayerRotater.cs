using Game.GameController;
using Game.UI;
using UnityEngine;

namespace Game.Player
{
    public class PlayerRotater : MonoBehaviour
    {
        [SerializeField] private MouseInput mouseInput;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform body;
        [SerializeField] private float mouseSpeed;
        [SerializeField] private Vector2 turnXLimiter;

        [HideInInspector] public bool CanRotate;

        private Vector2 mouseRotate;
        private float xRotate;
        private SettingController setting;

        public void SetMenu(Menu menu)
        {
            menu.Rotater = this;
        }

        public void SetSettingController(SettingController controller)
        {
            setting = controller;
        }

        private void LateUpdate()
        {
            if (!CanRotate) return;

            mouseRotate = MouseInput.MouseRotate(mouseSpeed * setting.GetMouseSensitiveMultiplier() * Time.fixedDeltaTime);

            xRotate += mouseRotate.x;
            xRotate = Mathf.Clamp(xRotate, turnXLimiter.x, turnXLimiter.y);
            cameraTransform.localEulerAngles = Vector3.left * xRotate;

            body.Rotate(Vector3.up * mouseRotate.y);
        }
    }
}
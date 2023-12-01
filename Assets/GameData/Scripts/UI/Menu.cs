using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingPanel;
        [SerializeField] private PlayerMover mover;
        [SerializeField] private PlayerRotater rotater;
        [SerializeField] private KeyCode openMenuKey;
        [SerializeField] private string CV_URL_English;

        private void Start()
        {
            StartCoroutine(CheckOpenMenu());
        }

        private IEnumerator CheckOpenMenu()
        {
            while (true)
            {
                if (Input.GetKeyDown(openMenuKey))
                {
                    if (!menuPanel.activeSelf)
                        OpenMenu();
                    else
                        PlayGame();
                }
                yield return null;
            }
        }

        private void OpenMenu()
        {
            CursorController.LockCursor(false);
            ActiveControle(false);
            menuPanel.SetActive(true);
        }

        public void PlayGame()
        {
            CursorController.LockCursor(true);
            ActiveControle(true);
            menuPanel.SetActive(false);
            settingPanel.SetActive(false);
        }

        public void OpenSettingPanel()
        {
            settingPanel.SetActive(true);
        }

        public void OpenResume()
        {
            Application.OpenURL(CV_URL_English); //English verion
        }

        private void ActiveControle(bool active)
        {
            mover.CanMove = active;
            rotater.CanRotate = active;
        }
    }
}
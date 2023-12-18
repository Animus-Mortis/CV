using Game.Localization;
using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingPanel;
        [SerializeField] private KeyCode openMenuKey;
        [SerializeField] private string CV_URL_English;
        [SerializeField] private string CV_URL_Russian;
        [SerializeField] private string URL_Git;
        [SerializeField] private string URL_Telegram;

        public PlayerMover Mover
        {
            set { mover = value; }
        }
        [SerializeField] private PlayerMover mover;

        public PlayerRotater Rotater
        {
            set { rotater = value; }
        }
        [SerializeField] private PlayerRotater rotater;

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
            switch (Translator.GetLanguageID())
            {
                case 0:
                    Application.OpenURL(CV_URL_English);
                    break;
                case 1:
                    Application.OpenURL(CV_URL_Russian);
                    break;
            }
        }

        public void OpenGit()
        {
            Application.OpenURL(URL_Git);
        }

        public void OpenTelegram()
        {
            Application.OpenURL(URL_Telegram);
        }

        private void ActiveControle(bool active)
        {
            mover.CanMove = active;
            rotater.CanRotate = active;
        }
    }
}
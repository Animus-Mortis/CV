using UnityEngine;

namespace Game.Localization
{
    public class ChooseLanguage : MonoBehaviour
    {
        public void LanguageChange(int languageID)
        {
            Translator.SelectLanguage(languageID);
        }
    }
}
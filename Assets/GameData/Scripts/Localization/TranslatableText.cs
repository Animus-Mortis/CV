using TMPro;
using UnityEngine;

namespace Game.Localization
{
    public class TranslatableText : MonoBehaviour
    {
        public int textID;

        private TextMeshProUGUI UIText;
        private TextMeshPro Text;

        private void Awake()
        {
            UIText = GetComponent<TextMeshProUGUI>();
            Text = GetComponent<TextMeshPro>();
            Translator.Add(this);
            Translator.UpdateTexts();
        }

        public void GetText(string newText)
        {
            if (UIText != null)
                UIText.text = newText;
            else if (Text != null)
                Text.text = newText;
        }

        private void OnEnable()
        {
            Translator.UpdateTexts();
        }

        public void ChooseID(int newID)
        {
            textID = newID;
        }
    }
}
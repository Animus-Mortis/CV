using UnityEngine;

namespace Game.Interactable
{
    public class Clipboard : MonoBehaviour, IInteractable
    {
        public void Action()
        {
            gameObject.SetActive(false);
        }

        public bool CanUse()
        {
            return true;
        }
    }
}
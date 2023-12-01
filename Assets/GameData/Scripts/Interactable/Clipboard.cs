using Game.Player;
using UnityEngine;

namespace Game.Interactable
{
    public class Clipboard : MonoBehaviour, IInteractable
    {
        [SerializeField] private InspectObject inspectObject;

        public bool canUse = true;

        public void Action()
        {
            inspectObject.Inspect(transform);
        }

        public bool CanUse()
        {
            return canUse;
        }
    }
}
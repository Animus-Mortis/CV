using Game.Player;
using System.Collections;
using UnityEngine;

namespace Game.Interactable
{
    public class Clipboard : MonoBehaviour, IInteractable
    {
        [SerializeField] private SpawnPlayer spawnPlayer;

        private InspectObject inspectObject;

        public bool canUse = true;

        private void Start()
        {
            StartCoroutine(WaitPlayer());
        }

        private IEnumerator WaitPlayer()
        {
            while (spawnPlayer.GetPlayer() == null)
                yield return null;

            inspectObject = spawnPlayer.GetPlayer().GetComponent<InspectObject>();
        }

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
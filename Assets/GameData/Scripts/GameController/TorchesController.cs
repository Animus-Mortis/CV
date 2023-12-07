using Game.Effects;
using System.Collections;
using UnityEngine;

namespace Game.GameController
{
    public class TorchesController : MonoBehaviour
    {
        [SerializeField] private Transform leftTorches;
        [SerializeField] private Transform rightTorches;
        [SerializeField] private float fireDelay;
        [SerializeField] private Bonfire bonfire;

        private FireLight[] leftFire;
        private FireLight[] rightFire;

        private void Start()
        {
            leftFire = leftTorches.GetComponentsInChildren<FireLight>();
            rightFire = rightTorches.GetComponentsInChildren<FireLight>();
        }

        public void LightOneByOne()
        {
            StartCoroutine(Lighting());
        }

        private IEnumerator Lighting()
        {
            for (int i = 0; i < leftFire.Length; i++)
            {
                leftFire[i].StartFlickering();
                rightFire[i].StartFlickering();
                yield return new WaitForSeconds(fireDelay);
            }

            yield return new WaitForSeconds(fireDelay);
            bonfire.Play();
        }
    }
}
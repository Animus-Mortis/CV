using UnityEngine;

namespace Game.Effects
{
    public class Bonfire : MonoBehaviour
    {
        [SerializeField] private Light[] lights;
        [SerializeField] private ParticleSystem fireParticle;

        public void Play()
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = true;
            }
            fireParticle.Play();
        }
    }
}
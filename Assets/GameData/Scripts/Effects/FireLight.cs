using System.Collections;
using UnityEngine;

namespace Game.Effects
{
    public class FireLight : MonoBehaviour
    {
        [SerializeField] private Light fireLight;
        [SerializeField] private ParticleSystem fireParticle;
        [SerializeField] private WaveFunction waveFunction;
        [SerializeField] private float amplitude;
        [SerializeField] private float phase;
        [SerializeField] private float delay;
        [SerializeField] private float basic;

        private Color startColor;

        private void Awake()
        {
            startColor = fireLight.color;
        }

        public void StartFlickering()
        {
            fireLight.enabled = true;
            fireParticle.Play();
            StartCoroutine(FireChange());
        }


        private IEnumerator FireChange()
        {
            while (true)
            {
                fireLight.color = startColor * FireWave();
                yield return new WaitForSeconds(delay);
            }
        }

        private float FireWave()
        {
            float x = (Time.time * phase);
            float y = 0;

            x = x - Mathf.Floor(x);

            switch (waveFunction)
            {
                case WaveFunction.Sin:
                    y = Mathf.Sin(x * 2 * Mathf.PI);
                    break;
                case WaveFunction.Triangel:
                    if (x < 0.5f)
                        y = 4.0f * x - 1.0f;
                    else
                        y = -4.0f * x + 3.0f;
                    break;
                case WaveFunction.Square:
                    if (x < 0.5f)
                        y = 1.0f;
                    else
                        y = -1.0f;
                    break;
                case WaveFunction.Sawtooth:
                    y = x;
                    break;
                case WaveFunction.Inverted:
                    y = 1.0f - x;
                    break;
                case WaveFunction.Noise:
                    y = 1 - (Random.value * 2);
                    break;
                case WaveFunction.None:
                    y = 1;
                    break;
            }

            return (y * amplitude) + basic;
        }

        private enum WaveFunction
        {
            Sin,
            Triangel,
            Square,
            Sawtooth,
            Inverted,
            Noise,
            None
        }
    }
}
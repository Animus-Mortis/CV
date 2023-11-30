using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactable
{
    public class Lighter : MonoBehaviour, IInteractable
    {
        [SerializeField] private Light[] lights;
        [SerializeField] private Renderer[] lightRenders;

        private List<Material> lightMaterials = new List<Material>();

        public void Action()
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = !lights[i].enabled;
            }

            if (lightRenders != null)
            {
                for (int i = 0; i < lightRenders.Length; i++)
                {
                    lightRenders[i].GetMaterials(lightMaterials);
                    for (int j = 0; j < lightMaterials.Count; j++)
                    {
                        if (lights[0].enabled)
                            lightMaterials[j].EnableKeyword("_EMISSION");
                        else
                            lightMaterials[j].DisableKeyword("_EMISSION");
                    }
                }
            }
        }

        public bool CanUse()
        {
            return true;
        }
    }
}
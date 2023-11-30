using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private KeyCode activateKey;

    private Light lightPoin;

    private void Awake()
    {
        lightPoin = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(activateKey))
        {
            lightPoin.enabled = !lightPoin.enabled;
        }
    }
}

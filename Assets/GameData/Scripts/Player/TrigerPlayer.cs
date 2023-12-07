using UnityEngine;
using UnityEngine.Events;

public class TrigerPlayer : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private UnityEvent triggerEvent;
    [SerializeField] private bool isDisposable;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        triggerEvent?.Invoke();

        if (isDisposable)
            Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UnityEvent _action;

    public void Interact()
    {
        _action?.Invoke();
    }
}

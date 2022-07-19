using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{       
    [SerializeField] private Hero _hero;

    /*
    private void Update()
        {   
            var horizontal = Input.GetAxis("Horizontal");
            _hero.SetDirection(horizontal);

            if (Input.GetButtonUp("Fire1"))
            {
                _hero.SaySomesthing();
            }
            if (Input.GetKey(KeyCode.A))
            {
                _hero.SetDirection(-1);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                _hero.SetDirection(1);
            }
            else
            {
                _hero.SetDirection(0);
            }      
      
        }   
    */
    
    public void OnMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            _hero.Interact();
        }
    }
    
    public void OnSaySomesthing(InputAction.CallbackContext context)
    {   
        if(context.canceled)
        {
            Debug.Log("Somesthing!");
        }
    }
}

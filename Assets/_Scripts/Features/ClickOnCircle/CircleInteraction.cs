using _Scripts.Core.Events.Types;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Features.ClickOnCircle
{
    public class CircleInteraction : MonoBehaviour
    {
        [SerializeField] private IntEvent _onClickCircleEvent;

        [UsedImplicitly]
        public void OnClick(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            // Get the mouse position in world space
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
            
            // raycast to check if the click is on a circle
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                // Check if the clicked object has the Circle component
                if (hit.collider.TryGetComponent<CircleInteraction>(out var circle))
                {
                    Debug.Log("Circle clicked");
                    _onClickCircleEvent.Raise(1);
                    circle.gameObject.SetActive(false);
                };
                
            }
        }
    }
}
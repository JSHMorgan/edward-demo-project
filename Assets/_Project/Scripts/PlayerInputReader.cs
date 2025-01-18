using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Project.Scripts
{
    public interface IPlayerInputReader
    {
        Vector2 Direction { get; }
        void EnablePlayerActions();
    }
    [CreateAssetMenu(fileName = "PlayerInputReader", menuName = "Scriptable Objects/PlayerInputReader")]
    public class PlayerInputReader : ScriptableObject, IPlayerInputReader, InputSystem_Actions.IPlayerActions
    {
        public event UnityAction<Vector2> Move = delegate { };
        public event UnityAction Attack = delegate { };
        private InputSystem_Actions inputActions;
    
        public Vector2 Direction => inputActions.Player.Move.ReadValue<Vector2>();
        
        public void EnablePlayerActions()
        {
            if (inputActions == null)
            {
                inputActions = new InputSystem_Actions();
                inputActions.Player.SetCallbacks(this);
            }
            inputActions.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Move.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            //no op
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            Attack.Invoke();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            //no op
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            //no op
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            //no op
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            //no op
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            //no op
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            //no op
        }
    }
}
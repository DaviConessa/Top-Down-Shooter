using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

namespace Goatfeeder.Controls
{

    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerControler))]
    public class Player : MonoBehaviour
    {

        private PlayerInput _playerInput;
        private PlayerControler _playerControler;
        private Gun_Controler _gunControler;

        #region  Actions
        private InputAction _move;
        private InputAction _mousePosition;
        private InputAction _shoot;
        #endregion


        [SerializeField] private float speed = 5f;

        void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerControler = GetComponent<PlayerControler>();
            _gunControler = GetComponent<Gun_Controler>();


            _move = _playerInput.actions["Move"];
            _mousePosition = _playerInput.actions["Point"];
            _shoot = _playerInput.actions ["Shoot"];
            

        }
        void OnEnable()
        {
            _playerInput?.ActivateInput();
        }
        void OnDisable()
        {
            _playerInput?.DeactivateInput();
        }

        void Update()
        {
            Vector2 move2D = _move.ReadValue<Vector2>();
            Vector3 move3d = new Vector3(move2D.x, 0, move2D.y);
            _playerControler.Move(move3d);

            Vector2 screenPoint = _mousePosition.ReadValue<Vector2>();

            Ray ray = Camera.main.ScreenPointToRay(screenPoint);

            Plane graundPlane = new Plane(Vector3.up, Vector3.zero);

            if (graundPlane.Raycast(ray, out float rayDistance))
            {
                Vector3 wordPoint = ray.GetPoint(rayDistance);

                Debug.DrawLine(ray.origin, wordPoint, Color.red);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

                _playerControler.LookAt(wordPoint);
            }

            if (_shoot.IsPressed())
            {
                _gunControler.Shoot();
            }
        }
        
    }
}

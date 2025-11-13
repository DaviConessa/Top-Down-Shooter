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
        private InputAction _move;
        private InputAction _mousePosition;
        [SerializeField] private float speed = 5f;

        void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerControler = GetComponent<PlayerControler>();
            _move = _playerInput.actions["Move"];
            _mousePosition = _playerInput.actions["Point"];

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
        }
        
    }
}
//ler o point e mostrar no console, na classe palyer controler fazer referencia ao rigidbody,
//limpar a classe controler
//DESAFIOOO!!!!!!! FAZER A MOVIMENTAÇÃO NO PLAYER CONTROLER!!

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _moveInput;
    [SerializeField] private float speed;
     void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 direction)
    {
        _moveInput = direction;
    }
    void FixedUpdate()
    {
        Vector3 velocity = _moveInput * speed;
        Vector3 newPosition = _rb.position + velocity * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);
    }
        public void LookAt(Vector3 worldPoint)
    {
        Vector3 target = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

        transform.LookAt(target);
    }
}
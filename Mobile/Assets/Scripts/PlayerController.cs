using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick _joystick;
    private Rigidbody _rigidbody;

    private float _moveSpeed = 5f;
    public float _rotationSpeed = 120f; // un peu plus rapide

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_joystick == null)
        {
            _joystick = GameObject.FindFirstObjectByType<FixedJoystick>();

            if (_joystick == null)
            {
                Debug.LogError("No FixedJoystick found in the scene. Please add one.");
            }
        }
    }

    private void FixedUpdate()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        float horizontal = _joystick.Horizontal;  // gauche / droite
        float vertical = _joystick.Vertical;    // avant / arrière

        // 1) Rotation en Y (gauche/droite) en continu
        if (Mathf.Abs(horizontal) > 0.2f)
        {
            float yRotation = horizontal * _rotationSpeed * Time.deltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0f, yRotation, 0f);
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }

        // 2) Mouvement dans la direction actuelle du joueur (avant/arrière)
        Vector3 moveDir = transform.forward * vertical;
        Vector3 move = moveDir * _moveSpeed * Time.deltaTime;

        _rigidbody.MovePosition(_rigidbody.position + move);
    }
}

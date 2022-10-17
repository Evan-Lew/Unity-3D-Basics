using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    private bool _jumpKeyWasPressed;
    private float _horizontalInput;
    private Rigidbody _rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpKeyWasPressed = true;
        }

        _horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }
        
        if (_jumpKeyWasPressed)
        {
            _rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            _jumpKeyWasPressed = false;
        }

        _rigidbodyComponent.velocity = new Vector3(_horizontalInput, _rigidbodyComponent.velocity.y, 0);
    }
}

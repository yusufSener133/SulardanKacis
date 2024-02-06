using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private CharacterController _characterController;
    private Animator _animator;

    private float _sprintSpeed = 2f;
    private bool _haveAxe = false, end = false;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            _haveAxe = true;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MissionTree"))
        {
            if (!_haveAxe)
                other.GetComponent<MissionTree>().ActiveUI();
            else
            {
                other.GetComponent<MissionTree>().CutTree();
                end = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MissionTree"))
            other.GetComponent<MissionTree>().PassiveUI();
    }
    private void Move()
    {
        if (end)
        {
            _animator.SetFloat("Speed", 0);
            _animator.SetBool("isRunning", false);

            return;
        }

        float _hor = Input.GetAxis("Horizontal");
        float _ver = Input.GetAxis("Vertical");
        Vector3 _dir = new Vector3(_hor, 0f, _ver);

        Vector3 velocity = _dir * Time.deltaTime * _moveSpeed * _sprintSpeed;
        if (_dir.magnitude >= .1f)
        {
            transform.rotation = Quaternion.LookRotation(_dir);
            _characterController.Move(velocity);
        }
        _animator.SetFloat("Speed", velocity.magnitude);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _sprintSpeed = 3;
            _animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _sprintSpeed = 1;
            _animator.SetBool("isRunning", false);
        }
    }
}

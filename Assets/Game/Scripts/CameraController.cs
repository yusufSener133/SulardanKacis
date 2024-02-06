using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _offSetZ = 5f;
    [SerializeField] private float _smooting = 2f;
    private Transform _playerPos;
    private void Start()
    {
        _playerPos = FindObjectOfType<PlayerController>().transform;
        

    }
    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPos = new Vector3(_playerPos.position.x, transform.position.y, _playerPos.position.z - _offSetZ);
        transform.position = Vector3.Lerp(transform.position, targetPos, _smooting * Time.deltaTime);

    }
}

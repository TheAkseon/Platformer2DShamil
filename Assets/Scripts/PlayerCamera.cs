using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Player _target;

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z);
    }
}

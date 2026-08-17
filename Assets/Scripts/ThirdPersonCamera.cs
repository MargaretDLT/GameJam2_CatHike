using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 150f;

    float yaw;
    float pitch = 20f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();

        yaw += mouse.x * mouseSensitivity * Time.deltaTime * 0.5f;
        pitch -= mouse.y * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -46f, 30f);

        transform.localPosition = new Vector3(0, 1.5f, 0);
        transform.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}

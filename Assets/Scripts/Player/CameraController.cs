using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {


    [Header ("Cam Settings")]
    public float mouseSensitibity = 1.0f;
    public float mouseX;
    public float mouseY;
    public float maxRotationX = 40f;
    public float minRotationX = -30f;
    

    [Header ("Player Bindings")]
    public Transform player;
    public Transform lookAt;


    void Start()
    {
       
    }

    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        mouseX += Input.GetAxis ("Mouse X") * mouseSensitibity;
        mouseY += Input.GetAxis ("Mouse Y") * mouseSensitibity;

        mouseY = Mathf.Clamp (mouseY, minRotationX, maxRotationX); //limita el movimiento vertical de la camara.

        transform.LookAt (lookAt); //la camara mira al objetivo lookAt.

        lookAt.rotation = Quaternion.Euler (mouseY, mouseX, 0f); //rotacion de la camara
        player.rotation = Quaternion.Euler (0f, mouseX, 0f); //el player rota en el eje Y al unisono que la camara
    }
}

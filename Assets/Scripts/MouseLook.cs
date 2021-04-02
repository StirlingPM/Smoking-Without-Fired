using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [Range(0, 200)]
    public float sensitivity = 100;
    public float minY = -60, maxY = 60;
    private float _rotY;
    public bool x;



    void Update()
    {
        if (GameManager.gameState == CurrentGameState.Game)
        {
            if (x)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            }
            else
            {

                _rotY += Input.GetAxis("Mouse Y") * sensitivity;
                _rotY = Mathf.Clamp(_rotY, minY, maxY);
                transform.localEulerAngles = new Vector3(-_rotY, 0, 0);

            }
        }
       
    }

}

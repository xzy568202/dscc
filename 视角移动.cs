using UnityEngine;
using System.Collections;

public class 视角移动 : MonoBehaviour {

    Camera mCamera;
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9f;
    public float sensitivityVert = 9f;

    public float minmumVert = -60f;
    public float maxmumVert = 60f;

    private float _rotationX = 0;
    // Use this for initialization




        



    void Start () {
        

       
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButton(1))
        {
            Rot_move();


        }

        
    }

    
    void Rot_move()
    {
    if (axes == RotationAxes.MouseX)
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
    }
    else if (axes == RotationAxes.MouseY)
    {
        _rotationX = _rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

        float rotationY = transform.localEulerAngles.y;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
    else
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }

        mCamera = gameObject.GetComponent<Camera>();

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (mCamera.fieldOfView >= 20)
            {
                gameObject.GetComponent<Camera>().fieldOfView -= 5;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (mCamera.fieldOfView <= 100)
            {
                gameObject.GetComponent<Camera>().fieldOfView += 5;
            }
        }


    }
}

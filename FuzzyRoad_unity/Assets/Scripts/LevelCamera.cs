using UnityEngine;
using System.Collections;

public class LevelCamera : MonoBehaviour {

   
    public Transform car;
    public float check;



    public Vector3 Offset = new Vector3(-4.5f,4.0f,5.0f);
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        check = car.eulerAngles.y - transform.eulerAngles.y;
        this.transform.position = car.transform.position + transform.right * Offset.x;
        this.transform.position += car.up * Offset.y - (car.up * Mathf.Sin(car.eulerAngles.x * Mathf.Deg2Rad) * Offset.y);
        this.transform.position += car.forward * Offset.z;

        if (check < -180)
            check += 180;
        if (check > 180)
            check -= 180;
        transform.Rotate(new Vector3(0, check * .1f, 0));

        print(car.eulerAngles.y);
        print(transform.eulerAngles.y);
    }
}
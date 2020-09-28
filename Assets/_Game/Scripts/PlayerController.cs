using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData PlayerData;
    public Vector3 mOffset;
    public string InputAxisName;

    

    [SerializeField] Rigidbody _characterRb;

    private float mZCoord;
    void Start()
    {

    }
    
    void Update()
    {

    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            var rbColl = collision.collider.GetComponent<Rigidbody>();

            rbColl.AddForce(rbColl.transform.forward * PlayerData.Hitforce, ForceMode.VelocityChange);
        }
    }

}

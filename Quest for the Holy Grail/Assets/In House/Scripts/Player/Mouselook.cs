﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    public float yawSpeed = 300f;
    public float pitchSpeed = 600f;
    public Transform playerBody;
    [SerializeField] private Camera camera;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * pitchSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        LookingAt();
    }

    //Raises PlayerLooked event and passes whatever object has been looked at
    void LookingAt()
    {
      Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            EventManager.CallPlayerLooked(hit);
            if(Input.GetButtonDown("Fire1")){
              EventManager.CallEnemyDamaged(10f, hit.transform.gameObject);
              // print("fired");
            }
        }
    }
  
    
}

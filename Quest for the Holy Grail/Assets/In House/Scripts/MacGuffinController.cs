﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacGuffinController : MonoBehaviour, IOnHit
{
    [SerializeField] private float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, rotateSpeed * Time.deltaTime, 0f));
    }

    public void OnHit(float damage)
    {
        EventManager.CallStaggerBoss();
        // gameObject.SetActive(false);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{

    [SerializeField] private MeshRenderer Renderer;

    public float MaxOutlineWidth = 1f;
    public Color color = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.PlayerLooked += PlayerLooked;
        if (Renderer == null)
            Renderer = GetComponent<MeshRenderer>();


    }

    void Update() {
        HideOutline();
    }

    public void ShowOutline()
    {
        Renderer.material.SetFloat("_Outline", MaxOutlineWidth);
        Renderer.material.SetColor("_OutlineColor", color);
    }

    public void HideOutline()
    {
        Renderer.material.SetFloat("_Outline", 0f);
        Renderer.material.SetColor("_OutlineColor", Color.black);
    }

    //PlayerLooked event callback
    public void PlayerLooked(RaycastHit hit)
    {
        
        if (hit.transform.gameObject == gameObject){
            ShowOutline();
        }
        else {
            HideOutline();
        }
    }
}

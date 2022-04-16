using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_Speed = 0.3f;

    private MeshRenderer mesh_Renderer;

    private void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);
    }

    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_Speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVLight : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] Texture2D texture;
    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, layerMask ))
            return;

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
            return;

        Texture2D tex = rend.material.GetTexture("_SplatTex") as Texture2D;
        Debug.Log(tex);
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= texture.width;
        pixelUV.y *= texture.height;

        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.white);
        tex.Apply();
    }
}

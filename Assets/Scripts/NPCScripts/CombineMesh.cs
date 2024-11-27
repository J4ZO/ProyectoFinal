using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMesh : MonoBehaviour
{
    public List<Material> objMaterials;

    // Update is called once per frame
    void Update()
    {
        CombineMeshMaterial();
    }

    private void CombineMeshMaterial()
    {
        MeshFilter[] meshFilters = transform.GetComponentsInChildren<MeshFilter>();
        List<Mesh> subMeshes = new List<Mesh>();
        List<Material> materials = new List<Material>();
    }
}

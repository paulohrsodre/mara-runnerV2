using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavingFlag : MonoBehaviour
{

    [SerializeField] MeshRenderer flagMeshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeAmplitude()
    {
        flagMeshRenderer.material.SetFloat("_amplitude", 5);
    }
}

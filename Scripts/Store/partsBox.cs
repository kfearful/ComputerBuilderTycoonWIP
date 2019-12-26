using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partsBox : MonoBehaviour
{
    public GameObject g;
    GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
    }

    public void Openbox()
    {
        Instantiate(g, transform.position, Quaternion.identity);
        Destroy(self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

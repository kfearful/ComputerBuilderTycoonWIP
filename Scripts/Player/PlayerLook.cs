using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public float Sensitivity;
    public Transform playerbody;
    float xRotation = 0f;
    public GameObject Holding;
    public Text lookingat;
    public Image Crosshair;
    public PlayerController pc;

    public Canvas PCconfigCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookingat.enabled = false;
        Crosshair.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    void Look()
    {
        if (!pc.Shopping)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            lookingat.enabled = false;
            Crosshair.color = Color.red;
            if (!Crosshair.enabled)
            {
                Crosshair.enabled = true;
            }
            InteractionRay();
            float mouseX = Input.GetAxisRaw("Mouse X") * Sensitivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Sensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerbody.Rotate(Vector3.up * mouseX);
        }
        else
        {           
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            lookingat.enabled = false;
            Crosshair.enabled = false;
        }
    }

    void InteractionRay()
    {
        DropShit();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2.7f))
        {
            lookingat.enabled = false;
            Crosshair.color = Color.red;
            var selection = hit.transform;
            lookingat.text = "" + selection.name;
            if (Holding == null)
            {
                if (selection.tag == "CASE")
                {
                    changecolor();
                    lookingat.enabled = true;
                    var w = selection.GetComponent<Case>();
                    lookingat.text = "" + w.name;
                    if (Input.GetMouseButtonDown(0) && w.placed == false)
                    {
                        Holding = selection.gameObject;
                        var r = Holding.GetComponent<Rigidbody>();
                        var c = Holding.GetComponent<BoxCollider>();
                        c.enabled = false;
                        r.useGravity = false;
                        r.isKinematic = true;
                        Holding.transform.parent = GameObject.Find("holdingpos").transform;
                        Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                    }
                }
                if (selection.tag == "partsBox")
                {
                    changecolor();
                    lookingat.enabled = true;
                    lookingat.text = "Part Box";
                    var w = selection.GetComponent<partsBox>();
                    if (Input.GetMouseButtonDown(0))
                    {
                        Holding = selection.gameObject;
                        var r = Holding.GetComponent<Rigidbody>();
                        var c = Holding.GetComponent<BoxCollider>();
                        c.enabled = false;
                        r.useGravity = false;
                        r.isKinematic = true;
                        Holding.transform.parent = GameObject.Find("holdingpos").transform;
                        Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        w.Openbox();
                    }
                }
                if (selection.tag == "Memory")
                {
                    changecolor();
                    lookingat.enabled = true;
                    var w = selection.GetComponent<Memory>();
                    lookingat.text = "" + w.name;
                    if (Input.GetMouseButtonDown(0) && w.placed == false)
                    {
                        Holding = selection.gameObject;
                        var r = Holding.GetComponent<Rigidbody>();
                        r.useGravity = false;
                        r.isKinematic = true;
                        Holding.transform.parent = GameObject.Find("holdingpos").transform;
                        Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                    }
                }
                if (selection.tag == "GPU")
                {
                    changecolor();
                    lookingat.enabled = true;
                    var w = selection.GetComponent<Gpu>();
                    lookingat.text = "" + w.name;
                    if (Input.GetMouseButtonDown(0) && w.placed == false)
                    {
                        Holding = selection.gameObject;
                        var r = Holding.GetComponent<Rigidbody>();
                        r.useGravity = false;
                        r.isKinematic = true;
                        Holding.transform.parent = GameObject.Find("holdingpos").transform;
                        Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                    }
                }
                if (selection.tag == "CPU")
                {
                    changecolor();
                    lookingat.enabled = true;
                    var w = selection.GetComponent<Cpu>();
                    lookingat.text = "" + w.name;
                    if (Input.GetMouseButtonDown(0) && w.placed == false)
                    {
                        Holding = selection.gameObject;
                        var r = Holding.GetComponent<Rigidbody>();
                        r.useGravity = false;
                        r.isKinematic = true;
                        Holding.transform.parent = GameObject.Find("holdingpos").transform;
                        Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                    }
                }
                if (selection.tag == "Storage")
                {
                    changecolor();
                    lookingat.enabled = true;
                    if (selection.GetComponent<Hdd>())
                    {
                        var w = selection.GetComponent<Hdd>();
                        lookingat.text = "" + w.name;
                        if (Input.GetMouseButtonDown(0) && w.placed == false)
                        {
                            Holding = selection.gameObject;
                            var r = Holding.GetComponent<Rigidbody>();
                            r.useGravity = false;
                            r.isKinematic = true;
                            Holding.transform.parent = GameObject.Find("holdingpos").transform;
                            Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                        }
                    }
                    else if (selection.GetComponent<SSD>())
                    {
                        var w = selection.GetComponent<SSD>();
                        lookingat.text = "" + w.name;
                        if (Input.GetMouseButtonDown(0) && w.placed == false)
                        {
                            Holding = selection.gameObject;
                            var r = Holding.GetComponent<Rigidbody>();
                            r.useGravity = false;
                            r.isKinematic = true;
                            Holding.transform.parent = GameObject.Find("holdingpos").transform;
                            Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                        }
                    }
                }
                if (selection.tag == "Motherboard")
                {
                    changecolor();
                    lookingat.enabled = true;
                    var w = selection.GetComponent<Motherboard>();
                    lookingat.text = "" + w.name;
                    if (Input.GetMouseButtonDown(0) && w.placed == false)
                    {
                        Holding = selection.gameObject;
                        var r = Holding.GetComponent<Rigidbody>();
                        r.useGravity = false;
                        r.isKinematic = true;
                        Holding.transform.parent = GameObject.Find("holdingpos").transform;
                        Holding.transform.position = GameObject.Find("holdingpos").transform.position;
                    }
                }
            }
        }
    }

    void DropShit()
    {
        if (Holding != null){
            CheckMotherboard();
        }
        if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Q) && Holding != null)
        {
            var r = Holding.GetComponent<Rigidbody>();
            var c = Holding.GetComponent<BoxCollider>();
            c.enabled = true;
            r.useGravity = true;
            r.isKinematic = false;
            Holding.transform.parent = null;
            Holding = null;
        }
        if (Holding != null && Holding.gameObject.transform.parent != transform.GetChild(0))
        {
            Holding = null;
        }
    }
    //F remove memory / HDD
    //V remove gpu / SSD
    //C remove cpu / Motherboard from Case.
    void CheckMotherboard(){
        if (Holding.transform.tag == "Motherboard"){
            if (Input.GetKeyDown(KeyCode.F)){
                var g = Holding.GetComponent<Motherboard>();
                if (g.hasRam){
                    for (int i = 0; i < g.ramSticks.Length; i++){
                        if (g.ramSticks[i] != null){
                            g.RemoveRam(i);                  
                      }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.V)){
                var g = Holding.GetComponent<Motherboard>();
                if (g.hasGpu){
                    for (int i = 0; i < g.gpuSticks.Length; i++){
                        if (g.gpuSticks[i] != null){
                            g.RemoveGpu(i);
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.C)){
                var g = Holding.GetComponent<Motherboard>();
                if (g.hasCpu){
                    for (int i = 0; i < g.cpuSticks.Length; i++){
                        if (g.cpuSticks[i] != null){
                            g.RemoveCpu(i);
                        }
                    }
                }
            }
        }
        if (Holding.transform.tag == "CASE"){
            if (Input.GetKeyDown(KeyCode.C)){
                var g = Holding.GetComponent<Case>();
                if (g.hasMotherboard){
                    for (int i = 0; i < g.motherboardOBJ.Length; i++){
                        if (g.motherboardOBJ[i] != null){
                            g.RemoveMotherboard(i);
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.V)){
                var g = Holding.GetComponent<Case>();
                    if (g.GetComponentInChildren<SSD>()){
                        for (int i = 0; i < g.ssdOBJ.Length; i++){
                            if (g.ssdOBJ[i] != null){
                                g.RemoveSSD(i);
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F)){
                var g = Holding.GetComponent<Case>();
                if (g.GetComponentInChildren<Hdd>()){
                    for (int i = 0; i < g.hddOBJ.Length; i++){
                        if (g.hddOBJ[i] != null){
                            g.RemoveHDD(i);
                        }
                    }
                }
            }
        }
    }

    void changecolor()
    {
        Crosshair.color = Color.white;
    }

}

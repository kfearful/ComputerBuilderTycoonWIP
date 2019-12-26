using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float Money;
    public Text money;
    public bool Shopping;
    public Canvas shopcanvas;
    // Start is called before the first frame update
    void Start()
    {
        shopcanvas.enabled = false;
    }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update()
    {
        checkshopping();
        money.text = "Money: $"+ Money;
    }
    void checkcheats()
    {
        foreach (Process pro in Process.GetProcesses())
        {
            if (pro.ProcessName.ToLower().Contains("cheat") && pro.ProcessName.ToLower().Contains("engine"))
            {
                Application.Quit();
            }
        }
    }
    void checkshopping()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!Shopping)
            {
                Shopping = true;
                UnityEngine.Debug.Log("Opening Shop");
                shopcanvas.enabled = true;
            }
            else
            {
                Shopping = false;
                UnityEngine.Debug.Log("Closing Shop");
                shopcanvas.enabled = false;
            }
        }
    }
}

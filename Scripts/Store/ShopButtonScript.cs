using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    public Button button;
    public Text itemname;
    public Text price;
    public Text type;
    public PlayerController pc;
    public GameObject g;
    public GameObject partbox;
    // Start is called before the first frame update
    void Start()
    {
        PCPart p;
        p = g.GetComponent<PCPart>();
        type.text = p.type;
        if (g.GetComponent<Hdd>())
        {
            type.text = "Hard Drive";
        }else if (g.GetComponent<SSD>())
        {
            type.text = "Solid State Drive";
        }
        pc = GameObject.Find("Player").GetComponent<PlayerController>();        
        itemname.text = p.name;
        price.text = "Price: $" + p.price;
        Transform spawn = GameObject.Find("partsboxspawn").transform;
    }

    public void Buy()
    {
        PCPart s;
        s = g.GetComponent<PCPart>();
        Transform spawn = GameObject.Find("partsboxspawn").transform;
        var p = partbox.GetComponent<partsBox>();
        p.g = g;
        if (pc.Money >= s.price)
        {
            Instantiate(partbox, spawn);
            pc.Money -= s.price;
            price.text = "Price: $"+s.price;
            Debug.Log("Purchased " + s.name + " for " + price.text);
        }
    }

    void Update()
    {
        
    }
}

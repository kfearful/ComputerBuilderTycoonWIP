using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPC : MonoBehaviour
{
    public PlayerController cp;
    Case pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "CASE")
        {
            Sell(collision);
        }else{
            var t =  GameObject.Find("SellReject");
            collision.transform.position = t.transform.position;
            Debug.Log("The game doesn't like incomplete computers. Build a PC then sell it.");
        }
    }

    void Sell(Collision c)
    {
        pc = c.gameObject.GetComponent<Case>();
        if (pc.pcFinished)
        {
            float moneytogive = 0;
            moneytogive += pc.TotalWorth * .5f + pc.TotalAppeal / 1.5f;
            Round(moneytogive, 2);
            cp.Money += moneytogive;
            pc.Sell();
            Debug.Log("PC Sold for $" + moneytogive);
        }
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text counttext;
    public Color mycolor;
    private Rigidbody rb;
    private int count;

	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        counttext.text = "count: " + count.ToString();
	}

     void FixedUpdate()
    {
        float a = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(a, 0.0f, b);

        rb.AddForce(move*speed);
    }

 

       void OnTriggerEnter(Collider other)
       {
          if(other.gameObject.CompareTag("pickup"))
           {
            
            other.gameObject.GetComponent<Renderer>().material.color = mycolor;
            count++;
               counttext.text = "count: " + count.ToString();
           }
       }

       void OnTriggerExit(Collider other)
       {
        if (other.gameObject.CompareTag("pickup"))
        {         
            other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            
        }
    }
      
}

using UnityEngine;
using System.Collections;

public class OnCollisonPickup : MonoBehaviour {

    private bool drawGUI = false;
    public GameObject inventory;
    public GameObject ball;

    //void OnCollisionEnter(Collision c)
    //{
    //    if (c.gameObject.tag == "Pick Up")
    //    {
    //        print("Yay");
    //        inventory.GetComponent<PlayerInventory>().inventory.Add(gameObject);
    //        c.transform.parent = gameObject.transform;
    //        c.transform.position = new Vector3(0, 0, 0);
    //        c.transform.localPosition = new Vector3(0, 2, 0);
    //        c.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //    }
    //}

    void OnTriggerEnter(Collision c)
    {
        if (c.gameObject.tag == "Pick Up")
        {
            print("Yay");
            inventory.GetComponent<PlayerInventory>().inventory.Add(gameObject);
            c.transform.parent = gameObject.transform;
            c.transform.position = new Vector3(0, 0, 0);
            c.transform.localPosition = new Vector3(0, 2, 0);
            c.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	      
        if(Input.GetKeyDown("o"))
        {
            Application.LoadLevel("ddol2");
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(ball);
        }

        if (Input.GetKeyDown("p"))
        {
            Application.LoadLevel("ddol");
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(ball);
        }
	}

}

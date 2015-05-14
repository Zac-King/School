using UnityEngine;
using System.Collections;

public class OnCollisonPickup : MonoBehaviour {

    private bool drawGUI = false;
    private bool picked  = false;

    public GameObject inventory;
    GameObject held;
    Collider recent;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Pick Up")
        {
            drawGUI = true;
            recent = c;
        }


    }
    void OnTriggerExit()
    {
        drawGUI = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (drawGUI && (Input.GetKeyDown(KeyCode.E)) && held == null)
        {
            picked = true;
            held = recent.gameObject;
            inventory.GetComponent<PlayerInventory>().inventory.Add(gameObject);
            held.transform.parent = gameObject.transform;
            held.transform.position = new Vector3(0, 0, 0);
            held.transform.localPosition = new Vector3(0.45f, 0.2f, 0.7f);
            held.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        if ((Input.GetKeyDown(KeyCode.U)) && held)
        {
            held.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            held.transform.parent = null;
            held = null;
            picked = false;

            held.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 20);
            //Camera.main.transform.forward

            // Camera's Forward
            // held object's rigidbody to addForce(forward * joules)
        }

        //if (Input.GetKeyDown("o"))
        //{
        //    Application.LoadLevel("ddol2");
        //    DontDestroyOnLoad(gameObject);
        //    //DontDestroyOnLoad(ball);
        //}

        //if (Input.GetKeyDown("p"))
        //{
        //    Application.LoadLevel("ddol");
        //    DontDestroyOnLoad(gameObject);
        //    //DontDestroyOnLoad(ball);
        //}
	}

    void OnGUI()
    {
        if(drawGUI && !picked)
            GUI.Box(new Rect(Screen.width / 2 - 50, 200, 102, 22), "E to pick up");
    }

}

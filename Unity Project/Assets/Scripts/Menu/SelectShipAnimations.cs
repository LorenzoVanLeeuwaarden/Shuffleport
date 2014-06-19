using UnityEngine;
using System.Collections;

public class SelectShipAnimations : MonoBehaviour {

    private Color TextColor = Color.white;
    private int counter = 0;

    // Use this for initialization
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = new Color(TextColor.r, TextColor.g, TextColor.b, 0);	
	}
	
	// Update is called once per frame
	void Update () {
        startAnimation();
	}

    private void startAnimation()
    {
        
        if (transform.position.x >= 0)
        {
            transform.position = new Vector3(transform.position.x-0.01f,0,0);
            GetComponent<MeshRenderer>().material.color = new Color(TextColor.r, TextColor.g, TextColor.b, 0.02f*counter);
            counter++;
        }
    }
}

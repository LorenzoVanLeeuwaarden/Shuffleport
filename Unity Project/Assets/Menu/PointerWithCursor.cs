using UnityEngine;
using System.Collections;

public class PointerWithCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
	}
}

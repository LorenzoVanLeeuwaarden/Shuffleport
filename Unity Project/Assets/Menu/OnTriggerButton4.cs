using UnityEngine;
using System.Collections;

public class OnTriggerButton4 : MonoBehaviour
{

    public Button4Test button;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        button.OnClick();
    }

}

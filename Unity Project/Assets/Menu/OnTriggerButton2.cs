using UnityEngine;
using System.Collections;

public class OnTriggerButton2 : MonoBehaviour
{

    public Button2Test button;

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

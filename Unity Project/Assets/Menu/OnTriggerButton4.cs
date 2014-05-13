using UnityEngine;
using System.Collections;

public class OnTriggerButton4 : MonoBehaviour
{
    int i = 0;
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
        i = 0;
    }

    void OnTriggerStay(Collider other)
    {

        i++;
        if (i > 30)
        {

            button.OnClick();
        }
    }

}

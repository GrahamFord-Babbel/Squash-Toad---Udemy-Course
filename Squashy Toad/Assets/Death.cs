using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public GameObject UICanvas;
    public GameObject Reticule;

    public void OnDeath()
        {
        UICanvas.SetActive(true);
        GetComponent<Rigidbody>().isKinematic = true;
        Reticule.SetActive(true);
    }
}

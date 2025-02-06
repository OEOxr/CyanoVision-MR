using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{

    public bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleobj()
    {
        state = !state;
        this.gameObject.SetActive(state);
    }

    public void setobj(bool s)
    {
        state = s;
        this.gameObject.SetActive(state);

    }
}

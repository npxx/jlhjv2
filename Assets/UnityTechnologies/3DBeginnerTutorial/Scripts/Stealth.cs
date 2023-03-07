using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public SkinnedMeshRenderer rend;
    public Material inVis;
    public Material OG;

    float initXAngle = 30f;
    float newT = 0f;
    float newTT = 0f;
    public static bool isPicked = false;

    void Start()
    {
        // if ( rend != null )
        // {
        //     rend.material = inVis;
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            Debug.Log("le liyaa\n");
            rend.material = inVis;
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            isPicked = true;
            Debug.Log("dusri baar liya kya??");
            newTT = 0;
        }
    }
    // void OnTriggerExit(Collider other)
    // {
    //     if(other.transform == player)
    //     {
    //         isPicked = false;
    //     }
    // }
    // Update is called once per frame
    void Update()
    {
        Quaternion tilt = Quaternion.Euler(initXAngle,newT * 60f,0);
        newT += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, tilt, newT);
        if(isPicked)
        {
            newTT += Time.deltaTime;
            if(newTT >= 15f)
            {
                rend.material = OG;
                isPicked = false;
                newTT = 0f;
            }
        }
        //Debug.Log("Now TT is " + newTT);
        //float xAngle = transform.rotation
        //this.transform.rotation =
    }
}

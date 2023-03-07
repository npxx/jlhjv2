using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;
    // public Text scoryy;
    // public int gKills;
    GameObject ghoos;


    // Start is called before the first frame update
    // void Start()
    // {
    //     gKills = 0;
    //     if(scoryy)
    //     {
    //     scoryy.text = "KILLS : " + gKills + "/4";
    //     }
    //     else
    //     {
    //         Debug.Log("No founddd");
    //         scoryy = GameObject.Find("scoryy").GetComponent<Text>();
    //         scoryy.text = "KILLS : " + gKills + "/4";
    //         Debug.Log("doneeee");
    //     }
    // }

    // Update is called once per frame
    // public void updateScore(int pScore)
    // {
    // }


    public void OnTriggerEnter(Collider other)
    {
        if(other.transform == player && !(Stealth.isPicked))
        {
            m_IsPlayerInRange = true;
        }
        if(other.transform == player && Stealth.isPicked)
        {
            Scoree.gKills++;
            // scoryy.text = "KILLS : " + gKills + "/4";
            Debug.Log(this.name);
            ghoos = this.gameObject.transform.parent.gameObject;
            Debug.Log(ghoos.name);
            Debug.Log(ghoos.GetType());
            Destroy(ghoos);
            // ghoos.GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    public void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}

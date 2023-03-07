using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoree : MonoBehaviour
{
    public Text scoryy;
    public Text lyff;
    public static int gKills = 0;
    public static int lives = 3;

    [SerializeField]
    private Sprite [] _livesS;

    [SerializeField]
    private Image _livesImg;
    
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        if(scoryy)
        {
        scoryy.text = "KILLS : " + gKills;
        // lyff.text = "LIVES REMAINING : " + lives;
        updateLives(lives);
        }
        else
        {
            Debug.Log("No founddd");
            scoryy = GameObject.Find("scoryy").GetComponent<Text>();
            scoryy.text = "KILLS : " + gKills;
            // lyff.text = "LIVES REMAINING : " + lives;
        updateLives(lives);
            Debug.Log("doneeee");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoryy.text = "KILLS : " + gKills;
        // lyff.text = "LIVES REMAINING : " + lives;
        updateLives(lives);
    }

    public void updateLives(int cLives)
    {
        _livesImg.sprite = _livesS[cLives];
    }
}

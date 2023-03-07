using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public CanvasGroup GOBGC;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            Endlevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if(Scoree.lives <= 0)
        {
            Endlevel(GOBGC, false, caughtAudio);
        }
        else if(m_IsPlayerCaught)
        {
            Endlevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void Endlevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        if(Scoree.lives == 1) GOBGC.alpha = m_Timer/fadeDuration;
        else imageCanvasGroup.alpha = m_Timer/fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if(doRestart && (--Scoree.lives) > 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                if(Scoree.lives <= 0) GOBGC.alpha = 1;
                Application.Quit();
            }
        }
    }
}

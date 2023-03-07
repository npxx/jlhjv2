using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;

    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);

        if(isWalking)
        {
            m_AudioSource.Play();
        }
        else
        {
            m_AudioSource.Stop();
        }
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}


// public class PlayerMovement : MonoBehaviour
// {
//     public float turnSpeed = 20f; //3f ~ 1 sec
//     Animator m_Animator;
//     Rigidbody m_Rigidbody;
//     Vector3 m_Movement;
//     Quaternion m_Rotation = Quaternion.identity;
//     // Start is called before the first frame update
//     void Start()
//     {
//         m_Animator = GetComponent<Animator>();
//         m_Rigidbody = GetComponent<Rigidbody>();
        
//     }

//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         float hoo = Input.GetAxis("Horizontal");
//         float vee = Input.GetAxis("Vertical");
//         m_Movement.Set(hoo,0f,vee);
//         m_Movement.Normalize();

//         bool hhi = !Mathf.Approximately(hoo, 0f);
//         bool hvi = !Mathf.Approximately(vee, 0f);
//         bool IsWalking = hhi || hvi;

//         m_Animator.SetBool("IsWalking",IsWalking);
//         Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement,turnSpeed * Time.deltaTime, 0f);
//         m_Rotation = Quaternion.LookRotation (desiredForward);

//     }

//     void OnAnimatorMove ()
//     {
//         m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
//         m_Rigidbody.MoveRotation(m_Rotation);
//     }
// }

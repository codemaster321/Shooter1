using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol_Anim : MonoBehaviour
{
    [SerializeField]Canvas ob;
    private bool m_isAxisInUse = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")>0|| Input.GetAxisRaw("Vertical")>0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            anim.SetFloat("Walk_Mag",0.2f);
            
        }
       else  if (Input.GetAxisRaw("Horizontal") ==0  && Input.GetAxisRaw("Vertical") == 0)
        {
          
            anim.SetFloat("Walk_Mag", 0.0f);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("run");
            ob.enabled = false;


        }

        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.ResetTrigger("run");
            ob.enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("idle");
        }

        
    }
    
}

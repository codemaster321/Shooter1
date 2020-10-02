using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol_Anim : MonoBehaviour
{
    bool flag = true;
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
            anim.SetFloat("w_key", 2f);
          


        }
       else  if (Input.GetAxisRaw("Horizontal") ==0  && Input.GetAxisRaw("Vertical") == 0)
        {
          
            anim.SetFloat("Walk_Mag", 0.0f);
            anim.SetFloat("w_key", 0.5f);
            anim.SetBool("idle", true);
           
            
           
        }

       

        if(Input.GetKeyDown(KeyCode.LeftShift ))
        {
            
            

                anim.SetBool("run", true);
            anim.SetBool("move", false);

               
                ob.enabled = false;

            

        }

        else if(Input.GetKeyUp(KeyCode.LeftShift) )
        {
            anim.SetBool("run",false);
            anim.SetBool("move", true);

            ob.enabled = true;
        }

        //if(anim.GetFloat("w_key")>1)
        //{
        //    anim.SetBool("move", true);

        //}

        //else if(anim.GetFloat("w_key")< 1)
        //{
        //    anim.SetBool("run", false);
        //}

        if(Input.GetKeyDown(KeyCode.Space) )
        {
            anim.SetBool("idle",true);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("idle", false);

        }





    }
    
}

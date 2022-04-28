using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AvatarAnimator : MonoBehaviour
{
    [SerializeField] Animator anim;


    private void Awake()
    {
        if(anim == null) { anim.GetComponent<Animator>(); }
    }

    public void UpdateMovementDirection(Vector3 direction)
    {
        //anim.SetFloat("Velocity X", direction.x);
        anim.SetFloat("Velocity Z", direction.Flat().magnitude);
    }

    public async void Interact()
    {
        anim.SetBool("Gesture", true);
        await Task.Delay(10);
        anim.SetBool("Gesture", false);
    }

    public void StartTalking()
    {
        anim.SetBool("Talking", true);
    }
     public void StopTalking()
    {
        anim.SetBool("Talking", false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

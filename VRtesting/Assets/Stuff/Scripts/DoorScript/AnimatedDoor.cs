using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedDoor : MonoBehaviour
{

    public Animator AniDoor;

    // Start is called before the first frame update
    void Start()
    {
        AniDoor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        AniDoor.SetBool("Open", true);
    }
}

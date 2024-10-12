using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ShotShell : MonoBehaviour
{
    public GameObject shellPrefab;
    public AudioClip sound;
 
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * 500);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(shell, 3.0f);
        }
    }
}
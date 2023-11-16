using Ghostery;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepAudioSource : MonoBehaviour
{
    public List<AudioClip> stepSounds;
    public AudioClip swooshSound;
    private AudioSource audioSource;
    public PlayerScript player;
    private bool isGrounded = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isGrounded = player.isOnGround;
    }

    public void Step(float value)
    {
        audioSource.PlayOneShot(stepSounds[Random.Range(0, stepSounds.Count)], value);
    }

    public void Swoosh()
    {
        audioSource.PlayOneShot(swooshSound, 0.3f);
    }

    void FixedUpdate()
    {
        var newGrounded = player.isOnGround;
        if (newGrounded != isGrounded)
        {
            if (newGrounded)
            {
                Step(3);
            }
            isGrounded = newGrounded;
        }
    }
}

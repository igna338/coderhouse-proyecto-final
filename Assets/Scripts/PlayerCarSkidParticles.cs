using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarSkidParticles : MonoBehaviour
{
    public PlayerCarController carController;
    public List<ParticleSystem> skidParticles;
    private bool isPlaying;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && carController.carSpeed > 30)
        {
            if (!isPlaying)
            {
                foreach (var skidParticle in skidParticles)
                {
                    skidParticle.Play();
                    isPlaying = true;
                }
            }
        }
        else
        {
            foreach (var skidParticle in skidParticles)
            {
                isPlaying = false;
                skidParticle.Stop();
            }
        }
    }
}

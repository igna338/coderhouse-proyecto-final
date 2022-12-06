using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarSkidAudio : MonoBehaviour
{
    public PlayerCarController carController;
    public List<AudioSource> audioSources;
    private bool isAudioPlaying;
    private int audioN;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && carController.carSpeed > 30)
        {
            if (!isAudioPlaying)
            {
                StartCoroutine(PlaySkidAudio());
            }
        }
        else
        {
            audioSources[audioN].Stop();
        }
    }

    IEnumerator PlaySkidAudio()
    {
        isAudioPlaying = true;
        audioSources[audioN].Play();
        var audioLength = audioSources[audioN].clip.length;
        yield return new WaitForSeconds(audioLength);
        NextSkidAudio();
        yield return null;
    }

    private void NextSkidAudio()
    {
        audioN++;
        if (audioN == audioSources.Count)
        {
            audioN = 0;
        }
        isAudioPlaying = false;
    }
}

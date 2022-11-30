using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    public GameEvents gameEvents;

    public List<AudioSource> engineSFX;
    public List<AudioSource> engineInteriorSFX;
    public List<AudioSource> skidSFX;

    private int engineN;
    private bool isEnginePlaying;
    private bool isInteriorCam;

    private int skidN;
    private bool isSkidPlaying;

    private Rigidbody rb;
    private PlayerCarController carController;

    private void Awake()
    {
        gameEvents.InteriorCameraEvent.AddListener(OnInteriorCamera);
        rb = GetComponent<Rigidbody>();
        carController = GetComponent<PlayerCarController>();
    }

    private void OnInteriorCamera(bool isInterior)
    {
        isInteriorCam = isInterior;
        if (isInterior)
        {
            engineSFX[engineN].Stop();
            NextEngineAudio();
        }
        else
        {
            engineInteriorSFX[engineN].Stop();
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            if (!isEnginePlaying)
            {
                StartCoroutine(PlayEngineAudio(isInteriorCam));
            }
        }
        else
        {

        }

        if (Input.GetAxis("Horizontal") != 0 && rb.velocity.magnitude > 30)
        {
            if (!isSkidPlaying)
            {
                StartCoroutine(PlaySkidAudio());
            }
        }
        else
        {
            skidSFX[skidN].Stop();
            NextSkidAudio();
        }
    }

    IEnumerator PlayEngineAudio(bool isInteriorCam)
    {
        isEnginePlaying = true;
        if (!isInteriorCam)
        {
        engineSFX[engineN].Play();
        var audioLength = engineSFX[engineN].clip.length;
        yield return new WaitForSeconds(audioLength);
        }
        else
        {
            engineInteriorSFX[engineN].Play();
            var audioLength = engineInteriorSFX[engineN].clip.length;
            yield return new WaitForSeconds(audioLength);
        }
        NextEngineAudio();
        yield return null;
    }

    private void NextEngineAudio()
    {
        engineN++;
        if (engineN == engineSFX.Count)
        {
            engineN = 0;
        }
        isEnginePlaying = false;
    }

    IEnumerator PlaySkidAudio()
    {
        isSkidPlaying = true;
        skidSFX[skidN].Play();
        var audioLength = skidSFX[skidN].clip.length;
        yield return new WaitForSeconds(audioLength);
        NextSkidAudio();
        yield return null;
    }

    private void NextSkidAudio()
    {
        skidN++;
        if (skidN == skidSFX.Count)
        {
            skidN = 0;
        }
        isSkidPlaying = false;
    }
}

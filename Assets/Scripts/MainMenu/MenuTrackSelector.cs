using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTrackSelector : MonoBehaviour
{
    public List<Image> selectedTrackImgs = new();
    public Button playButton;
    public static int trackSelected;

    private void Awake()
    {
        foreach (var img in selectedTrackImgs)
        {
            img.enabled = false;
        }

        playButton.interactable = false;
    }

    public void SelectTrack(int trackNumber)
    {
        for (int i = 0; i < selectedTrackImgs.Count; i++)
        {
            if (i == trackNumber)
            {
                selectedTrackImgs[i].enabled = true;
            }
            else
            {
                selectedTrackImgs[i].enabled = false;
            }
        }

        playButton.interactable = true;

        trackSelected = trackNumber;
    }
}

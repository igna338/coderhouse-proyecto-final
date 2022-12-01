using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAttribute : PropertyAttribute { }

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public MenuCarColor carColorManager;
    public MenuTrackSelector trackSelectorManager;
    [Header("Set by managers:")]
    public Color carColorSelected;
    public int trackSelected;
    
    [Scene]
    public List<string> TrackScenes = new();

    #region Singleton and DontDestroyOnLoad
    public static GameManager inst;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public void UpdateColorSelected()
    {
        carColorSelected = MenuCarColor.carColor;
    }

    public void UpdateTrackSelected()
    {
        trackSelected = MenuTrackSelector.trackSelected;
    }

    public void PlayRace()
    {
        UpdateColorSelected();
        UpdateTrackSelected();
        SceneManager.LoadScene(TrackScenes[trackSelected]);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class MenuCarColor : MonoBehaviour
{
    float m_Tone;
    float m_Saturation;
    float m_Value;

    public Slider m_SliderTone, m_SliderSaturation, m_SliderValue;
    public static Color carColor;

    Renderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();

        m_SliderTone.maxValue = 1;
        m_SliderSaturation.maxValue = 1;
        m_SliderValue.maxValue = 1;

        m_SliderTone.minValue = 0;
        m_SliderSaturation.minValue = 0;
        m_SliderValue.minValue = 0;
    }

    void Update()
    {
        m_Tone = m_SliderTone.value;
        m_Saturation = m_SliderSaturation.value;
        m_Value = m_SliderValue.value;

        m_Renderer.materials[1].color = Color.HSVToRGB(m_Tone, m_Saturation, m_Value);
        carColor = Color.HSVToRGB(m_Tone, m_Saturation, m_Value);
    }
}

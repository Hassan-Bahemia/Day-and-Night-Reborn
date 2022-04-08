using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [Header("Time Settings")] 
    [SerializeField] private float m_timeMultiplier;
    [SerializeField] private float m_startHour;
    [SerializeField] private TextMeshProUGUI m_timerText;
    [SerializeField] private DateTime m_currentTime;
    [SerializeField] private TimeSpan m_sunriseTime;
    [SerializeField] private TimeSpan m_sunsetTime;

    [Header("Sun Settings")]
    [SerializeField] private float m_sunriseHour;
    [SerializeField] private float m_sunsetHour;
    [SerializeField] private Light m_sunLight;
    [SerializeField] private Light m_moonLight;
    [SerializeField] private float m_maxSunLightIntensity;
    [SerializeField] private float m_maxMoonLightIntensity;

    [Header("Sun Color Settings")] 
    [SerializeField] private Color m_dayAmbientLight;
    [SerializeField] private Color m_nightAmbientLight;
    [SerializeField] private AnimationCurve m_lightChangeCurve;
    
    

    private void Start()
    {
        m_currentTime = DateTime.Now.Date + TimeSpan.FromHours(m_startHour);
        
        m_sunriseTime = TimeSpan.FromHours(m_sunriseHour);
        m_sunsetTime = TimeSpan.FromHours(m_sunsetHour);
    }

    private void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        m_currentTime = m_currentTime.AddSeconds(Time.deltaTime * m_timeMultiplier);

        if (m_timerText != null) {
            m_timerText.text = "Day: " + m_currentTime.ToString("HH:mm");
        }
    }

    private void RotateSun()
    {
        float sunLightRotation;

        if (m_currentTime.TimeOfDay > m_sunriseTime && m_currentTime.TimeOfDay < m_sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(m_sunriseTime, m_sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(m_sunriseTime, m_currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(m_sunsetTime, m_sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(m_sunsetTime, m_currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        m_sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(m_sunLight.transform.forward, Vector3.down);
        m_sunLight.intensity = Mathf.Lerp(0, m_maxSunLightIntensity, m_lightChangeCurve.Evaluate(dotProduct));
        m_moonLight.intensity = Mathf.Lerp(m_maxMoonLightIntensity, 0, m_lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight =
            Color.Lerp(m_nightAmbientLight, m_dayAmbientLight, m_lightChangeCurve.Evaluate(dotProduct));
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0) {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}

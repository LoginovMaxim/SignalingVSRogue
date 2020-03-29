using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private UnityEvent _played;

    private bool _isActive = true;

    public void Play()
    {
        StartCoroutine(SoundPlay());
    }

    public void SetActive(bool value)
    {
        _isActive = value;
    }

    private IEnumerator SoundPlay()
    {
        int steps = 50;
        float delay = 0.05f;

        if(_audio.volume == 0)
        {
            for (int i = 0; i < steps; i++)
            {
                _audio.volume = (i + 1f) / steps;
                yield return new WaitForSeconds(delay);
            }

            _audio.volume = 1;

            if(_isActive)
                _played.Invoke();
        }
        else if (_audio.volume == 1)
        {
            for (int i = steps; i > 0; i--)
            {
                _audio.volume = (i - 1f) / steps;
                yield return new WaitForSeconds(delay);
            }

            _audio.volume = 0;

            if(_isActive)
                _played.Invoke();
        }
    }
}

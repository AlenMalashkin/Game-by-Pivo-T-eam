using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemySFX : MonoBehaviour
{
    [SerializeField] private AudioClip _idleSFX;
    [SerializeField] private AudioClip _attackSFX;
    [SerializeField] private AudioClip _hitedSFX;
    [SerializeField] private AudioClip _dieSFX;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayIdleSFX()
    {
        _audioSource.PlayOneShot(_idleSFX);
    }

    public void PlayAttackSFX()
    {
        _audioSource.PlayOneShot(_attackSFX);
    }

    public void PlayHitedSFX()
    {
        _audioSource.PlayOneShot(_hitedSFX);
    }

    public void PlayDieSFX()
    {
        _audioSource.PlayOneShot(_dieSFX);
    }
}

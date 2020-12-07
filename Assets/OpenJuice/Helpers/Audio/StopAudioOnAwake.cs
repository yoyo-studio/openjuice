// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace OpenJuice
{
    public class StopAudioOnAwake : MonoBehaviour
    {
        [SerializeField] AudioClip clip;
        private void Awake() => Juicer.Instance.StopSFX(clip);
    }
}
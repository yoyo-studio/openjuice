// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace YoYoStudio.OpenJuice
{
    public class PlayAudioOnAwake : MonoBehaviour
    {
        [SerializeField] AudioClip clip = null;
        [SerializeField] bool loop = true;
        // [SerializeField] bool stopOnDestroy = true;
        [SerializeField] bool stopOnDisable = true;
        private void Awake() => Juicer.Instance.PlaySfx(clip, loop);
        // private void OnDestroy() => Juicer.Instance.StopSFX(clip);
        private void OnDisable() { if (stopOnDisable) Juicer.Instance.StopSFX(clip); }
    }
}
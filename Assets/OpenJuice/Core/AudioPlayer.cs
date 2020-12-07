// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
namespace OpenJuice
{
    public class AudioPlayer
    {
        private ObjectPool<AudioSource> audioSourcePool;
        public AudioPlayer(Transform parentGameObject, string name)
        {
            audioSourcePool = new ObjectPool<AudioSource>(1, () =>
                                       {
                                           var _audioSource = new GameObject(name + "-audio-source").AddComponent<AudioSource>();
                                           _audioSource.playOnAwake = false;
                                           _audioSource.transform.SetParent(parentGameObject, false);
                                           _audioSource.gameObject.SetActive(false);
                                           return _audioSource;
                                       }, (audioSource) => { audioSource.gameObject.SetActive(true); }
                                       , (audioSource) => { audioSource.gameObject.SetActive(false); });
        }
        internal AudioSource GetFreeAudioSource(AudioClip clip)
        {
            AudioSource audioSource = audioSourcePool.Get();
            audioSource.clip = clip;
            audioSource.loop = false;
            audioSource.Play();
            return audioSource;
        }
        internal void ReleaseSource(AudioSource audioSource)
        {
            audioSource.Stop();
            audioSourcePool.Release(audioSource);
        }
        public void ReleaseSource(AudioClip clip)
        {
            AudioSource source = null;
            foreach (var audioSource in audioSourcePool.ActiveObjects)
            {
                if (audioSource.clip == clip)
                {
                    source = audioSource;
                    break;
                }
            }
            if (source != null) ReleaseSource(source);
        }
        public AudioSource Play(AudioClip clip, bool loop)
        {
            AudioSource audioSource = GetFreeAudioSource(clip);
            audioSource.loop = loop;
            if (loop == false) StopAudio(clip.length, audioSource);
            return audioSource;
        }
        public AudioSource Play(AudioClip clip, Action onComplete)
        {
            var audioSource = GetFreeAudioSource(clip);
            StopAudio(clip.length, audioSource, onComplete);
            return audioSource;
        }

        private async void StopAudio(float length, AudioSource audioSource, Action onComplete = null)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(length));
            onComplete?.Invoke();
            ReleaseSource(audioSource);
        }
    }
}
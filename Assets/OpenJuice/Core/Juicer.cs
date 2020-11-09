// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OpenJuice
{
    public class Juicer : Singleton<Juicer>
    {
        private Dictionary<string, ObjectPool<Effect>> effectsPool;
        private List<Effect> effectPrefabs;
        private ObjectPool<AudioSource> audioSourcePool;
        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }

        private void Initialize()
        {
            effectsPool = new Dictionary<string, ObjectPool<Effect>>();
            effectPrefabs = new List<Effect>();
            LoadAllEffectPrefabs();
            CreateObjectPoolForEachEffect();
            CreateAudioSourcePool();
        }

        private void CreateAudioSourcePool()
        {
            audioSourcePool = new ObjectPool<AudioSource>(1, () =>
                                                {
                                                    var _audioSource = new GameObject("audio-source").AddComponent<AudioSource>();
                                                    _audioSource.playOnAwake = false;
                                                    _audioSource.transform.SetParent(transform, false);
                                                    _audioSource.gameObject.SetActive(false);
                                                    return _audioSource;
                                                }, (audioSource) => { audioSource.gameObject.SetActive(true); }
                                                , (audioSource) => { audioSource.gameObject.SetActive(false); });
        }

        private void CreateObjectPoolForEachEffect()
        {
            for (int i = 0; i < effectPrefabs.Count; i++)
            {
                var effectPrefab = effectPrefabs[i];
                ObjectPool<Effect> effectPool = new ObjectPool<Effect>(1, () =>
                                                    {
                                                        var effect = Instantiate(effectPrefab);
                                                        effect.name = effectPrefab.name;
                                                        effect.transform.SetParent(transform, false);
                                                        effect.gameObject.SetActive(false);
                                                        return effect;
                                                    }, (effect) => { effect.gameObject.SetActive(true); }
                                                    , (effect) => { effect.gameObject.SetActive(false); });
                effectPool.WarmUp(1);
                effectsPool.Add(effectPrefab.Id, effectPool);
            }
        }
        private void LoadAllEffectPrefabs()
        {
            EffectDatabase effectDatabase = Resources.Load<EffectDatabase>("EffectDatabase");
            for (int i = 0; i < effectDatabase.effectLists.Count; i++)
            {
                EffectPack item = effectDatabase.effectLists[i];
                effectPrefabs.AddRange(item.effects);
            }
        }

        public Effect PlayEffect(string effectID)
        {
            var effect = GetEffect(effectID);
            effect.PlayStartEffect();
            return effect;
        }

        public AudioSource PlaySFX(AudioClip clip, bool loop = false)
        {
            AudioSource audioSource = GetFreeAudioSource(clip);
            audioSource.loop = loop;
            if (loop == false) StartCoroutine(StopAudio(clip.length, () => ReleaseSFX(audioSource)));
            return audioSource;
        }

        public AudioSource PlaySFX(AudioClip clip, Action onComplete)
        {
            var audioSource = GetFreeAudioSource(clip);
            StartCoroutine(StopAudio(clip.length, () =>
            {
                onComplete?.Invoke();
                ReleaseSFX(audioSource);
            }));
            return audioSource;
        }
        private AudioSource GetFreeAudioSource(AudioClip clip)
        {
            AudioSource audioSource = audioSourcePool.Get();
            audioSource.clip = clip;
            audioSource.loop = false;
            audioSource.Play();
            return audioSource;
        }

        private IEnumerator StopAudio(float length, Action onComplete)
        {
            yield return new WaitForSeconds(length);
            onComplete?.Invoke();
        }

        public void ReleaseSFX(AudioSource audioSource)
        {
            audioSource.Stop();
            audioSourcePool.Release(audioSource);
        }

        public Effect GetEffect(string effectID)
        {
            effectsPool.TryGetValue(effectID, out ObjectPool<Effect> poolEffect);
            if (poolEffect != null)
            {
                return poolEffect.Get();
            }
            Debug.LogError("No effect found with id: " + effectID);
            return null;
        }

        public void ReleaseEffect(Effect effect)
        {
            effectsPool.TryGetValue(effect.Id, out ObjectPool<Effect> poolEffect);
            if (poolEffect != null)
            {
                poolEffect.Release(effect);
            }
            else
            {
                Debug.LogError("No pool was found for effect: " + effect.Id);
            }
        }
    }
}
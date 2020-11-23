// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using System.Collections.Generic;
using UnityEngine;
namespace OpenJuice
{
    public enum AudioType
    {
        Music,
        SFX,
    }
    public class Juicer : Singleton<Juicer>
    {
        private Dictionary<string, ObjectPool<Effect>> effectsPool;
        private List<Effect> effectPrefabs;
        private AudioPlayer sfxAudioPlayer;
        private AudioPlayer musicAudioPlayer;

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
            sfxAudioPlayer = new AudioPlayer(transform, "sfx");
            musicAudioPlayer = new AudioPlayer(transform, "music");
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
            if (effect.transform.IsChildOf(transform) == false)
            {
                effect.transform.SetParent(transform, false);
            }
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
        public AudioSource PlayAudio(AudioClip clip, AudioType audioType, bool loop = false) => audioType == AudioType.SFX ? sfxAudioPlayer.Play(clip, loop) : musicAudioPlayer.Play(clip, loop);
        public AudioSource PlayAudio(AudioClip clip, AudioType audioType, Action onComplete) => audioType == AudioType.SFX ? sfxAudioPlayer.Play(clip, onComplete) : musicAudioPlayer.Play(clip, onComplete);
        public void ReleaseAudio(AudioSource audioSource, AudioType audioType)
        {
            if (audioType == AudioType.SFX) sfxAudioPlayer.ReleaseSource(audioSource);
            else musicAudioPlayer.ReleaseSource(audioSource);
        }
    }
}
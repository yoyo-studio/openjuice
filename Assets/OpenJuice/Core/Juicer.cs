// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
namespace OpenJuice
{
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
                if (item != null && item.effects != null) effectPrefabs.AddRange(item.effects);
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
        public AudioSource PlaySfx(AudioClip clip, bool loop = false) => sfxAudioPlayer.Play(clip, loop);
        public AudioSource PlaySfx(AudioClip clip, Action onComplete) => sfxAudioPlayer.Play(clip, onComplete);
        public AudioSource PlayMusic(AudioClip clip, bool loop = true) => musicAudioPlayer.Play(clip, loop);
        public AudioSource PlayMusic(AudioClip clip, Action onComplete) => musicAudioPlayer.Play(clip, onComplete);
        public void StopSFX(AudioClip clip) => sfxAudioPlayer.ReleaseSource(clip);
        public void StopSFX(AudioSource audioSource) => sfxAudioPlayer.ReleaseSource(audioSource);
        public void StopMusic(AudioClip clip) => musicAudioPlayer.ReleaseSource(clip);
        public void StopMusic(AudioSource audioSource) => musicAudioPlayer.ReleaseSource(audioSource);
    }
}
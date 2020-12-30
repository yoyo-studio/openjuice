// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace OpenJuice
{
    public class Effect : MonoBehaviour
    {
        public virtual string Id => gameObject.name;
        [SerializeField] AudioClip startClip = null;
        [SerializeField] AudioClip loopClip = null;
        [SerializeField] AudioClip endClip = null;
        [SerializeField] float duration = 0f;
        private AudioSource loopSource;
        private bool effectStarted;

        public virtual void PlayStartEffect()
        {
            if (startClip != null) Juicer.Instance.PlaySfx(startClip, PlayLoopEffect);
            effectStarted = true;
            if (duration > 0)
            {
                WaitForEffectDuration();
            }
        }

        private async void WaitForEffectDuration()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(duration));
            Juicer.Instance.ReleaseEffect(this);
        }

        public virtual void PlayLoopEffect() { if (loopClip != null) loopSource = Juicer.Instance.PlaySfx(loopClip, true); }
        public virtual void PlayEndEffect() { if (endClip != null) Juicer.Instance.PlaySfx(endClip); }
        private void OnDisable()
        {
            StopEffectSFX();
        }

        private void StopEffectSFX()
        {
            if (effectStarted == true)
            {
                if (loopSource != null) Juicer.Instance.StopSFX(loopSource);
                PlayEndEffect();
            }
            effectStarted = false;
        }
    }
}
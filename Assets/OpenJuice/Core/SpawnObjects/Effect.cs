// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace OpenJuice
{
    public class Effect : MonoBehaviour
    {
        public virtual string Id => gameObject.name;
        [SerializeField] AudioClip startClip;
        [SerializeField] AudioClip loopClip;
        [SerializeField] AudioClip endClip;
        private AudioSource loopSource;
        private bool effectEnabled;

        public virtual void PlayStartEffect()
        {
            if (startClip != null) Juicer.Instance.PlaySFX(startClip, PlayLoopEffect);
            effectEnabled = true;
        }
        public virtual void PlayLoopEffect() { if (loopClip != null) loopSource = Juicer.Instance.PlaySFX(loopClip, true); }
        public virtual void PlayEndEffect() { if (endClip != null) Juicer.Instance.PlaySFX(endClip); }
        private void OnDisable()
        {
            if (effectEnabled == true)
            {
                if (loopSource != null) Juicer.Instance.ReleaseSFX(loopSource);
                PlayEndEffect();
            }
            effectEnabled = false;
        }
    }
}
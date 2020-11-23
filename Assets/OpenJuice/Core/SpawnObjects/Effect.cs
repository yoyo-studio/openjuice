// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace OpenJuice
{
    public class Effect : MonoBehaviour
    {
        public virtual string Id => gameObject.name;
        [SerializeField] AudioClip startClip = null;
        [SerializeField] AudioClip loopClip = null;
        [SerializeField] AudioClip endClip = null;
        private AudioSource loopSource;
        private bool effectEnabled;

        public virtual void PlayStartEffect()
        {
            if (startClip != null) Juicer.Instance.PlayAudio(startClip, AudioType.SFX, PlayLoopEffect);
            effectEnabled = true;
        }
        public virtual void PlayLoopEffect() { if (loopClip != null) loopSource = Juicer.Instance.PlayAudio(loopClip, AudioType.SFX, true); }
        public virtual void PlayEndEffect() { if (endClip != null) Juicer.Instance.PlayAudio(endClip, AudioType.SFX); }
        private void OnDisable()
        {
            if (effectEnabled == true)
            {
                if (loopSource != null) Juicer.Instance.ReleaseAudio(loopSource, AudioType.SFX);
                PlayEndEffect();
            }
            effectEnabled = false;
        }
    }
}
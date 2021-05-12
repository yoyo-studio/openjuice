// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

#if UNITASK_DOTWEEN_SUPPORT
using Cysharp.Threading.Tasks;

#endif


#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#elif NAUGHTY_ATTRIBUTES
using NaughtyAttributes;
#endif

namespace YoYoStudio.OpenJuice
{
    public abstract class BaseTransition : MonoBehaviour
    {
        [SerializeField] private float duration = 0.4f;
        [SerializeField] private bool playOnEnable = true;
        [SerializeField] private float delay = 0;
        [SerializeField] private Ease easeType = Ease.OutQuart;
        [SerializeField] private TransitionType transitionType = TransitionType.To;
        [Tooltip("-1 for infinite loop")] [SerializeField] private int loop = 1;
        [SerializeField] private LoopType loopType = LoopType.Yoyo;
        [SerializeField] private bool relative = true;
        protected Tweener tween;

        public float Duration { get => duration; set => duration = value; }
        public float Delay { get => delay; set => delay = value; }
        public Ease EaseType { get => easeType; set => easeType = value; }
        public TransitionType TransitionType { get => transitionType; set => transitionType = value; }
        public int Loop { get => loop; set => loop = value; }
        public LoopType LoopType { get => loopType; set => loopType = value; }
        public bool Relative { get => relative; set => relative = value; }
        public bool PlayOnEnable { get => playOnEnable; set => playOnEnable = value; }

        private void OnEnable()
        {
            if (PlayOnEnable)
                Play();
        }

        private void OnDestroy()
        {
            tween.Kill();
        }

#if ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES
        [Button("Play")]
#endif
        public void Play()
        {
            if (tween != null)
            {
                if (tween.IsPlaying())
                    return;

                // We don't want to cache tween in editor to enable editing parameters while in play mode.
#if !UNITY_EDITOR
                tween.Restart();
                return;
#endif
            }
            tween = MakeTweener();
        }
        
#if ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES
        [Button("Play Reverse")]
#endif
        public void PlayReverse()
        {
            if (tween != null)
                tween.SmoothRewind();
        }
        
#if UNITASK_DOTWEEN_SUPPORT
        public UniTask PlayAsync()
        {
            Play();
            return tween.AwaitForComplete();
        }

        public UniTask PlayReverseAsync()
        {
            PlayReverse();
            return tween.AwaitForRewind();
        }
#endif

        protected abstract Tweener MakeTweener();
    }
}
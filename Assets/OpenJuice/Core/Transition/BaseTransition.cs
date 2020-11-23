// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

namespace OpenJuice
{
    public abstract class BaseTransition : MonoBehaviour
    {
        [SerializeField] private float duration = 0.4f;
        [SerializeField] private float delay = 0;
        [SerializeField] private Ease easeType = Ease.OutQuart;
        [SerializeField] private TransitionType transitionType = TransitionType.To;
        [Tooltip("-1 for infinit loop")] [SerializeField] private int loop = 1;
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

        public void Start()
        {
            if (tween != null) DOTween.Kill(tween.id);
            tween = MakeTweener();
        }

        public Tweener GetTweener() => tween;

        protected abstract Tweener MakeTweener();
    }
}
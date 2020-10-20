// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;

namespace OpenJuice
{
    public abstract class BaseTransition : Juicer
    {
        [SerializeField] protected float duration = 0.4f;
        [SerializeField] protected float delay = 0;
        [SerializeField] protected Ease easeType = Ease.OutQuart;
        [SerializeField] protected TransitionType transitionType = TransitionType.To;
        [Tooltip("-1 for infinit loop")] [SerializeField] protected int loop = 1;
        [SerializeField] protected LoopType loopType = LoopType.Yoyo;
        [SerializeField] protected bool relative = true;
        protected Tweener tween;
        public void Start()
        {
            if (tween != null) DOTween.Kill(tween.id);
            tween = MakeTweener();
        }

        protected abstract Tweener MakeTweener();
    }
}
// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;
namespace OpenJuice
{
    public class MoveTransition : BaseTransition
    {
        [SerializeField] Vector3 targetPosition = Vector3.zero;

        public Vector3 TargetPosition
        {
            get => targetPosition;
            set
            {
                targetPosition = value;
                if (tween != null) tween.ChangeEndValue(targetPosition);
            }
        }

        protected override Tweener MakeTweener()
        {
            tween = transform.DOMove(targetPosition, Duration).SetEase(EaseType).SetLoops(Loop, LoopType).SetDelay(Delay).SetAutoKill(false);
            if (TransitionType == TransitionType.From) tween.From(Relative);
            else tween.SetRelative(Relative);
            return tween;
        }
    }
}
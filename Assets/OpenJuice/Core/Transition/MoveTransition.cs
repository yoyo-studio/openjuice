// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;
namespace OpenJuice
{
    public class MoveTransition : BaseTransition
    {
        [SerializeField] Vector3 targetPosition = Vector3.zero;

        public Vector3 TargetPosition { get => targetPosition; set => targetPosition = value; }

        protected override Tweener MakeTweener()
        {
            if (TransitionType == TransitionType.To)
            {
                return Relative == false ? MakeTweener(TargetPosition) : MakeTweener(TargetPosition).SetRelative();
            }
            else
            {
                if (Relative == false)
                {
                    var startPosition = transform.position;
                    transform.position = TargetPosition;
                    return MakeTweener(startPosition);
                }
                else
                {
                    transform.position += TargetPosition;
                    return MakeTweener(transform.position - TargetPosition);
                }
            }
        }
        private Tweener MakeTweener(Vector3 target)
        {
            return transform.DOMove(target, Duration).SetEase(EaseType).SetLoops(Loop, LoopType).SetDelay(Delay);
        }
    }
}
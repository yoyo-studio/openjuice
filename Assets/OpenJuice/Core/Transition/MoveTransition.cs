// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;
namespace OpenJuice
{
    public class MoveTransition : BaseTransition
    {
        [SerializeField] Vector3 targetPosition = Vector3.zero;
        protected override Tweener MakeTweener()
        {
            if (transitionType == TransitionType.To)
            {
                return relative == false ? GetTweener(targetPosition) : GetTweener(targetPosition).SetRelative();
            }
            else
            {
                if (relative == false)
                {
                    var startPosition = transform.position;
                    transform.position = targetPosition;
                    return GetTweener(startPosition);
                }
                else
                {
                    transform.position += targetPosition;
                    return GetTweener(transform.position - targetPosition);
                }
            }
        }
        private Tweener GetTweener(Vector3 target)
        {
            return transform.DOMove(target, duration).SetEase(easeType).SetLoops(loop, loopType).SetDelay(delay);
        }
    }
}
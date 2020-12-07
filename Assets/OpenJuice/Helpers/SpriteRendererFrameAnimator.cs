// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace OpenJuice
{
    public class SpriteRendererFrameAnimator : FrameAnimatorBase
    {
        [SerializeField] SpriteRenderer spriteRenderer = null;
        protected override void UpdateSprite()
        {
            spriteRenderer.sprite = frames[frameIndex];
        }
    }
}
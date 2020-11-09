// Copyright (c) 2020 Omid Saadat (@omid3098)
using System.Collections.Generic;
using UnityEngine;

namespace OpenJuice
{
    [CreateAssetMenu(menuName = "OpenJuice/Effects/EffectPack")]
    public class EffectPack : ScriptableObject
    {
        public List<Effect> effects;
    }
}
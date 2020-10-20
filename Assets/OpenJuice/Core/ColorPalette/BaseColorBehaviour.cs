// Copyright (c) 2020 Omid Saadat (@omid3098)

using UnityEngine;

namespace OpenJuice
{
    public abstract class BaseColorBehaviour : MonoBehaviour, IColorBehaviour
    {
        [SerializeField] protected ColorNameObject colorNameObject;
        public abstract void UpdateColor();
    }
}
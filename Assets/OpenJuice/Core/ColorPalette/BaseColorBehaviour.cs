// Copyright (c) 2020 Omid Saadat (@omid3098)

using UnityEngine;
using NaughtyAttributes;

namespace OpenJuice
{
    public abstract class BaseColorBehaviour : MonoBehaviour, IColorBehaviour
    {
        [SerializeField] protected ColorNameObject colorNameObject;
        public abstract void UpdateColor();
        [Button("Apply Color")]
        public void ApplyColors()
        {
            if (ColorPalette.currentColorPalette != null)
                ColorPalette.UpdateSceneColors();
            else
                Debug.LogWarning("Please select a color palette first");
        }
    }
}
// Copyright (c) 2020 Omid Saadat (@omid3098)
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
namespace YoYoStudio.OpenJuice
{
    [CreateAssetMenu(menuName = "OpenJuice/Coloring/ColorPalette")]
    public class ColorPaletteScriptable : ScriptableObject
    {
        [ReorderableList] public List<ColorPair> colors;
        [Button("Set As Current")]
        public void SetCurrent()
        {
            ColorPalette.SetCurrentPalette(this);
            ColorPalette.UpdateSceneColors();
        }
    }
}
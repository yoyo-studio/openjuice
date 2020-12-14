// Copyright (c) 2020 Omid Saadat (@omid3098)

using UnityEngine;

namespace OpenJuice
{
    public class ColorPalette
    {
        private static ColorPaletteSetting _setting;

        private static ColorPaletteSetting Setting
        {
            get
            {
                if (_setting == null) _setting = Resources.Load<ColorPaletteSetting>("ColorPaletteSetting");
                return _setting;
            }
        }
        public static ColorPaletteScriptable CurrentColorPalette { get => Setting.currentColorPalette; }
        public static void SetCurrentPalette(ColorPaletteScriptable colorPaletteScriptable) => Setting.currentColorPalette = colorPaletteScriptable;
        public static void UpdateSceneColors()
        {
            var allColorBehaviours = Object.FindObjectsOfType<BaseColorBehaviour>();
            foreach (var item in allColorBehaviours)
            {
                item.UpdateColor();
            }
        }
    }
}
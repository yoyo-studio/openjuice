// Copyright (c) 2020 Omid Saadat (@omid3098)
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OpenJuice
{
    public class TextColorBehaviour : BaseColorBehaviour
    {
        Text text;
        TMP_Text tmpText;
        public override void UpdateColor()
        {
            if (text == null) text = GetComponent<Text>();
            if (tmpText == null) tmpText = GetComponent<TMP_Text>();
            var colorNameIndex = ColorPalette.CurrentColorPalette.colors.FindIndex(x => x.colorNameObject.name == colorNameObject.name);
            if (colorNameIndex != -1)
            {
                if (text != null) text.color = ColorPalette.CurrentColorPalette.colors[colorNameIndex].color;
                if (tmpText != null) tmpText.color = ColorPalette.CurrentColorPalette.colors[colorNameIndex].color;
            }
        }
    }
}
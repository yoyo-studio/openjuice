// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using UnityEngine;
using UnityEngine.UI;

namespace YoYoStudio.OpenJuice
{
    public abstract class BaseButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        private void OnEnable()
        {
            _button.onClick.AddListener(OnPressed);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnPressed);
        }

        protected abstract void OnPressed();
    }
}
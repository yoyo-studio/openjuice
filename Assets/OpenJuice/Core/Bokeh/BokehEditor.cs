// Copyright (c) 2020 Omid Saadat (@omid3098)
using System.Collections.Generic;
using System.IO;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace OpenJuice
{
    public class BokehEditor : MonoBehaviour
    {
        [Required] [SerializeField] Material bokehMaterial = null;
        [Required] [SerializeField] Sprite bokehSprite = null;
        [SerializeField] float flickerPercent = 35;
        [SerializeField] float movementPercent = 15;
        private List<GameObject> bokehParticles = new List<GameObject>();
        private float scaleFactor = 0.9f;
        private float currentScale = 1;
        private bool editing;
        private GameObject tempBokehHolder;
        private Texture2D screenTexture;

        private void Awake()
        {
            editing = true;
            tempBokehHolder = new GameObject("temp-bokeh-holder");
            tempBokehHolder.transform.SetParent(transform, false);
            screenTexture = ScreenCapture.CaptureScreenshotAsTexture();
        }


        [Button]
        private void StartEditing()
        {
            editing = true;
        }

        [Button]
        private void StopEditing()
        {
            editing = false;
        }

        [Button]
        private void BakeToPrefab()
        {
            var prefabDirectory = Path.GetDirectoryName(AssetDatabase.GetAssetPath(bokehSprite));
            var prefab = PrefabUtility.SaveAsPrefabAsset(tempBokehHolder, prefabDirectory + "/Bokeh.prefab");
        }

        private void Update()
        {
            if (editing == false) return;
            if (Input.GetMouseButtonDown(0))
            {
                var bokehInstance = new GameObject("bokehInstance").AddComponent<SpriteRenderer>();
                Vector3 screenMousePos = Input.mousePosition;
                Color color = screenTexture.GetPixel((int)screenMousePos.x, (int)screenMousePos.y);
                Color.RGBToHSV(color, out float h, out float s, out float v);
                color = Color.HSVToRGB(h, s, v * 2);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                bokehInstance.transform.localScale = new Vector3(currentScale, currentScale);
                bokehInstance.sortingOrder = 1;
                bokehInstance.sharedMaterial = bokehMaterial;
                bokehInstance.sprite = bokehSprite;
                bokehInstance.color = color;
                bokehInstance.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
                bokehInstance.transform.SetParent(tempBokehHolder.transform, false);
                bokehParticles.Add(bokehInstance.gameObject);
                AddRandomFlicker(bokehInstance);
                AddRandomMovement(bokehInstance);
            }
            if (Input.mouseScrollDelta.y > 0)
            {
                currentScale *= scaleFactor;
                UpdatePiarticleSizes();
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                currentScale *= 1 / scaleFactor;
                UpdatePiarticleSizes();
            }
        }

        private void AddRandomMovement(SpriteRenderer bokehInstance)
        {
            System.Random gen = new System.Random();
            int prob = gen.Next(100);
            if (prob <= movementPercent)
            {
                var moveTransition = bokehInstance.gameObject.AddComponent<MoveTransition>();
                moveTransition.Duration = Random.Range(3, 5);
                moveTransition.Delay = Random.Range(0, 2);
                moveTransition.EaseType = DG.Tweening.Ease.InOutQuart;
                moveTransition.TransitionType = TransitionType.To;
                moveTransition.Loop = -1;
                moveTransition.LoopType = DG.Tweening.LoopType.Yoyo;
                moveTransition.Relative = true;
                moveTransition.TargetPosition = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            }
        }

        private void AddRandomFlicker(SpriteRenderer bokehInstance)
        {
            System.Random gen = new System.Random();
            int prob = gen.Next(100);
            if (prob <= flickerPercent) bokehInstance.gameObject.AddComponent<LightFlickerEffect>();
        }

        private void UpdatePiarticleSizes()
        {
            foreach (var bokehparticle in bokehParticles)
            {
                bokehparticle.transform.localScale = new Vector3(currentScale, currentScale);
            }
        }
    }
}
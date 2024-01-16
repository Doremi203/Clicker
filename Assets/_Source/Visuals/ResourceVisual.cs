using System;
using Core;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visuals
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private Transform _iconTemplate;
        private GameResource _resource;
        
        private void Awake()
        {
            _iconTemplate.gameObject.SetActive(false);
        }
        
        private void OnValueChanged(int value)
        {
            UpdateCounterText(value);
        }

        private void UpdateCounterText(int value)
        {
            _counterText.text = value.ToString();
        }

        public void SetResource(ResourceSo resource)
        {
            _resource = resource.Resource;
            var resourceVal = GameManager.Instance.ResBank.GetResource(_resource);
            UpdateCounterText(resourceVal.Value);
            SetIcon(resource);
            resourceVal.OnValueChanged += OnValueChanged;
        }

        private void SetIcon(ResourceSo resource)
        {
            var icon = Instantiate(_iconTemplate, transform);
            icon.gameObject.SetActive(true);
            icon.TryGetComponent(out Image image);
            image.sprite = resource.ResourceSprite;
        }
    }
}
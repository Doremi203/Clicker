using System;
using Core;
using ScriptableObjects;
using UnityEngine;

namespace Visuals
{
    public class ResourceUiManager : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _resourceTemplate;

        private void Awake()
        {
            _resourceTemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            foreach (var resource in GameManager.Instance.Resources)
            {
                var resourceUi = Instantiate(_resourceTemplate, _container);
                resourceUi.gameObject.SetActive(true);
                resourceUi.TryGetComponent<ResourceVisual>(out var resourceVisual);
                resourceVisual.SetResource(resource);
            }
        }
    }
}
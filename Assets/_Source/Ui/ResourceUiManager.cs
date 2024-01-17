using Core;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
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
                SetupSingleResourceUi(resource);
            }
        }

        private void SetupSingleResourceUi(ResourceSo resource)
        {
            var resourceUi = Instantiate(_resourceTemplate, _container);
            resourceUi.gameObject.SetActive(true);
            resourceUi.TryGetComponent<ResourceVisual>(out var resourceVisual);
            resourceVisual.SetResource(resource);
        }
    }
}
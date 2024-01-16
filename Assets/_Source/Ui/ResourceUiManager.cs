using Core;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class ResourceUiManager : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _productionBuildingsContainer;
        [SerializeField] private Transform _resourceTemplate;
        [SerializeField] private Transform _productionButtonTemplate;

        private void Awake()
        {
            _resourceTemplate.gameObject.SetActive(false);
            _productionButtonTemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            foreach (var resource in GameManager.Instance.Resources)
            {
                SetupSingleResourceUi(resource);
                SetupProductionBuildingFor(resource);
            }
        }

        private void SetupSingleResourceUi(ResourceSo resource)
        {
            var resourceUi = Instantiate(_resourceTemplate, _container);
            resourceUi.gameObject.SetActive(true);
            resourceUi.TryGetComponent<ResourceVisual>(out var resourceVisual);
            resourceVisual.SetResource(resource);
        }
        
        private void SetupProductionBuildingFor(ResourceSo resource)
        {
            var productionBuildingUi 
                = Instantiate(_productionButtonTemplate, _productionBuildingsContainer);
            productionBuildingUi.gameObject.SetActive(true);
            
            productionBuildingUi
                .TryGetComponent<ProductionBuildingButton>(out var productionBuildingButton);
            productionBuildingButton.SetResource(resource);
        }
    }
}
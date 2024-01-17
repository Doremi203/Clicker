using Core;
using UnityEngine;

namespace Ui
{
    public class ProductionUiManager : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _productionButtonTemplate;

        private void Awake()
        {
            _productionButtonTemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            foreach (var productionBuilding in GameManager.Instance.ProductionBuildings)
            {
                SetupProductionButtonUi(productionBuilding);
            }
        }

        private void SetupProductionButtonUi(ProductionBuilding productionBuilding)
        {
            var productionButtonUi = Instantiate(_productionButtonTemplate, _container);
            productionButtonUi.gameObject.SetActive(true);
            productionButtonUi.TryGetComponent<ProductionBuildingButton>(out var productionButton);
            productionButton.SetProductionBuilding(productionBuilding);
        }
    }
}
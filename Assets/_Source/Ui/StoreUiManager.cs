using Core;
using ScriptableObjects;
using UnityEngine;

namespace Ui
{
    public class StoreUiManager : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _storeItemTemplate;

        private void Awake()
        {
            _storeItemTemplate.gameObject.SetActive(false);
        }

        private void Start()
        {
            foreach (var productionBuilding in GameManager.Instance.ProductionBuildings)
            {
                SetupStoreItemUi(productionBuilding);
            }
        }

        private void SetupStoreItemUi(ProductionBuilding productionBuilding)
        {
            var storeItemUi = Instantiate(_storeItemTemplate, _container);
            storeItemUi.gameObject.SetActive(true);
            storeItemUi.TryGetComponent<StoreItemButton>(out var storeItemButton);
            storeItemButton.SetProductionBuilding(productionBuilding);
        }
    }
}
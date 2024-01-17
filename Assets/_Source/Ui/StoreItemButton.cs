using Core;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class StoreItemButton : MonoBehaviour
    {
        private ProductionBuilding _productionBuilding;
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;
        
        private void Start()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _productionBuilding.UpgradeProduction();
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            _buttonText.text = $"Upgrade {_productionBuilding.Resource} ({_productionBuilding.UpgradePrice})";
        }

        public void SetProductionBuilding(ProductionBuilding productionBuilding)
        {
            _productionBuilding = productionBuilding;
            UpdatePrice();
        }
    }
}
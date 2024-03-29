using Core;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Ui
{
    public class ProductionBuildingButton : MonoBehaviour
    {
        private ProductionBuilding _productionBuilding;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Image _progressBar;
        
        private void Start()
        {
            _productionBuilding.OnProductionProgressChanged += OnProductionProgressChanged;
            _productionBuilding.OnProductionFinished += OnProductionFinished;
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnProductionFinished()
        {
            ResetProgressBar();
            _button.interactable = true;
        }

        private void OnButtonClicked()
        {
            _productionBuilding.Produce();
            _button.interactable = false;
        }

        private void OnProductionProgressChanged(float progress)
        {
            _progressBar.fillAmount = progress;
        }
        
        private void ResetProgressBar()
        {
            _progressBar.fillAmount = 0;
        }

        public void SetProductionBuilding(ProductionBuilding productionBuilding)
        {
            _productionBuilding = productionBuilding;
            _buttonText.text = $"Produce {productionBuilding.Resource}";
        }
    }
}
using Core;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class ProductionBuildingVisual : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        public void SetResource(ResourceSo resource)
        {
            _buttonText.text = $"Produce {resource.Resource.ToString()}";
        }
    }
}
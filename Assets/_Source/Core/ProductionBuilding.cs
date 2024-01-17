using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ProductionBuilding : MonoBehaviour
    {
        public event Action<float> OnProductionProgressChanged;
        public event Action OnProductionFinished;

        public GameResource Resource { get; set; }

        private const int ProductionRate = 1;
        private float ProductionTime => 1f - (_productionLevel * 0.1f);
        public int UpgradePrice => _productionLevel * 10;

        private int _productionLevel = 1;
        
        public void Produce()
        {
            StartCoroutine(ProduceResource());
        }

        private IEnumerator ProduceResource()
        {
            float elapsedTime = 0;

            while (elapsedTime < ProductionTime)
            {
                elapsedTime += Time.deltaTime;
                OnProductionProgressChanged?.Invoke(elapsedTime / ProductionTime);
                yield return null;
            }
            
            GameManager.Instance.ResBank.ChangeResource(Resource, ProductionRate);
            OnProductionFinished?.Invoke();
        }
        
        public void UpgradeProduction()
        {
            if (GameManager.Instance.ResBank.GetResource(Resource).Value < UpgradePrice)
            {
                return;
            }
            GameManager.Instance.ResBank.ChangeResource(Resource, -UpgradePrice);
            _productionLevel++;
        }
    }
}
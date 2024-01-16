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
        private readonly int _productionRate = 1;
        private float _productionTime = 1f;
        
        public void Produce()
        {
            StartCoroutine(ProduceResource());
        }

        private IEnumerator ProduceResource()
        {
            float elapsedTime = 0;

            while (elapsedTime < _productionTime)
            {
                elapsedTime += Time.deltaTime;
                OnProductionProgressChanged?.Invoke(elapsedTime / _productionTime);
                yield return null;
            }
            
            GameManager.Instance.ResBank.ChangeResource(Resource, _productionRate);
            OnProductionFinished?.Invoke();
        }
    }
}
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class ProductionBuilding : MonoBehaviour
    {
        private GameResource _resource;
        private readonly int _productionRate = 1;
        public void Produce()
        {
            GameManager.Instance.ResBank.ChangeResource(_resource, _productionRate);
        }
        
        public void SetResource(ResourceSo resource)
        {
            _resource = resource.Resource;
        }
    }
}
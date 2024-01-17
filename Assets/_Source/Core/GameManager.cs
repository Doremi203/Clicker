using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ResourceListSo _resourceListSo;
        
        public static GameManager Instance
        {
            get => _instance;
            private set
            {
                if (_instance == null)
                {
                    _instance = value;
                }
                else
                {
                    Debug.LogError("There is already an instance of GameManager");
                }
            }
        }
        
        public ResourceBank ResBank { get; private set; }
        
        public IEnumerable<ResourceSo> Resources => _resourceListSo.Resources;
        
        public IEnumerable<ProductionBuilding> ProductionBuildings => _productionBuildings;

        private readonly List<ProductionBuilding> _productionBuildings = new();
        
        private static GameManager _instance;
        
        private void Awake()
        {
            Instance = this;
            InitResourceBank();
            InitProductionBuildings();
        }

        private void InitProductionBuildings()
        {
            foreach (var resource in Resources)
            {
                var productionBuilding = 
                    new GameObject($"{resource.Resource}Producer")
                        .AddComponent<ProductionBuilding>();
                
                productionBuilding.Resource = resource.Resource;
                _productionBuildings.Add(productionBuilding);
            }
        }

        private void InitResourceBank()
        {
            ResBank = new ResourceBank(_resourceListSo);
            ResBank.ChangeResource(GameResource.Humans, 10);
            ResBank.ChangeResource(GameResource.Food, 5);
            ResBank.ChangeResource(GameResource.Wood, 5);
        }
    }
}
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ResourceListSo _resourceListSo;
        
        private static GameManager _instance;

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
        
        private void Awake()
        {
            Instance = this;
            InitResourceBank();
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
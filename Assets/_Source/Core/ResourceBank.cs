using System;
using System.Collections.Generic;
using ScriptableObjects;

namespace Core
{
    public class ResourceBank
    {
        private readonly Dictionary<GameResource, ObservableInt> _resources = new();
        
        public ResourceBank(ResourceListSo resourceListSo)
        {
            foreach (var resource in resourceListSo.Resources)
            {
                _resources.Add(resource.Resource, new ObservableInt(0));
            }
        }

        public void ChangeResource(GameResource resource, int value)
        {
            _resources[resource].Value += value;
        }
        
        public ObservableInt GetResource(GameResource resource) 
            => _resources[resource];
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class ResourceListSo : ScriptableObject
    {
        [field: SerializeField]
        public List<ResourceSo> Resources { get; set; }
    }
}
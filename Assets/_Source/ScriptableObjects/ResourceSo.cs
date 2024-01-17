using Core;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class ResourceSo : ScriptableObject
    {
        [field: SerializeField]
        public GameResource Resource { get; set; }
        [field: SerializeField]
        public Sprite ResourceSprite { get; set; }
    }
}
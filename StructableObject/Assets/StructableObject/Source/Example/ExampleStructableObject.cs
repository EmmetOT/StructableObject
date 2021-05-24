using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StructableObject
{
    [CreateAssetMenu(menuName = "StructableObject/Example")]
    public class ExampleStructableObject : StructableObject<ExampleStructableObjectData> { }

    [System.Serializable]
    public struct ExampleStructableObjectData
    {
        [SerializeField]
        private string m_string;
        public string String => m_string;

        [SerializeField]
        private int m_int;
        public int Int => m_int;

        [SerializeField]
        [Range(0, 10)]
        private int m_range;
        public int Range => m_range;

        [SerializeField]
        private Object m_object;
        public Object Object => m_object;

        [SerializeField]
        private SubStruct[] m_structArray;
    }

    [System.Serializable]
    public struct SubStruct
    {
        [SerializeField]
        private int m_subStructInt;
        public int SubStructInt => m_subStructInt;
    }
}
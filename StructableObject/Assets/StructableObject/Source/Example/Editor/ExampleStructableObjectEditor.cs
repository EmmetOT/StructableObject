using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace StructableObject
{
    [CustomEditor(typeof(ExampleStructableObject))]
    public class ExampleStructableObjectEditor : StructableObjectEditor<ExampleStructableObjectData> { }
}
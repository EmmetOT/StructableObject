using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace StructableObject
{
    public abstract class StructableObjectEditor<T> : Editor
    {
        private const string SCRIPT_PROPERTY_NAME = "m_Script";
        private const string STRUCT_PROPERTY_NAME = "m_data";

        private SerializedProperty m_scriptProperty;
        private SerializedProperty m_structProperty;

        protected void OnEnable()
        {
            m_scriptProperty = serializedObject.FindProperty(SCRIPT_PROPERTY_NAME);
            m_structProperty = serializedObject.FindProperty(STRUCT_PROPERTY_NAME);
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.PropertyField(m_scriptProperty);
            GUI.enabled = true;

            serializedObject.Update();
            
            using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
            {
                foreach (SerializedProperty child in GetChildren(m_structProperty))
                    EditorGUILayout.PropertyField(child);

                if (changeCheck.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }

        public static IEnumerable<SerializedProperty> GetChildren(SerializedProperty property)
        {
            property = property.Copy();

            SerializedProperty nextElement = property.Copy();
            
            if (!nextElement.NextVisible(false))
                nextElement = null;

            property.NextVisible(true);
            
            do
            {
                if (SerializedProperty.EqualContents(property, nextElement))
                    yield break;

                yield return property;

            } while (property.NextVisible(false));
        }
    }
}
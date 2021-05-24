using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace StructableObject
{
    /// <summary>
    /// <para>
    /// A structable object is a struct which represents a struct as if it's a ScriptableObject. Useful for data you want to generate on-the-go during your game's runtime,
    /// but also have accessible in editor. For example, you might have a gun which can both shoot procedurally generated projectiles and have designer defined ones.
    /// </para>    
    /// <para>
    /// You will also need to create an editor script which inherits from <see cref="StructableObjectEditor"/>, and has the attribute <see cref="UnityEditor.CustomEditor"/>,
    /// but otherwise you won't need to have anything special in either class.
    /// </para>
    /// </summary>
    public abstract class StructableObject<T> : ScriptableObject
    {
        [SerializeField]
        private T m_data;
        public T Data => m_data;

        public void SetData(T data)
        {
#if UNITY_EDITOR
            UnityEditor.Undo.RecordObject(this, "Set Data: " + typeof(T).ToString());
#endif

            m_data = data;

#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[System.Serializable]
public class SerializableDictionary<TKey,TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private TKey initKey;
    [SerializeField] private List<KeyValueClass<TKey, TValue>> _KeyValues = new List<KeyValueClass<TKey, TValue>>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        _KeyValues.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            _KeyValues.Add(new KeyValueClass<TKey, TValue>(pair.Key, pair.Value));

        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();
        //string additive = "";
        //if (keys.Count != values.Count)
        //    throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < _KeyValues.Count; i++) {
            
            if (this.ContainsKey(_KeyValues[i].key)) this.Add(initKey, _KeyValues[i].value);
            else this.Add(_KeyValues[i].key, _KeyValues[i].value);
        }
    }
}


[System.Serializable] public class KeyValueClass<TKey,TValue>
{
    public TKey key;
    public TValue value;

    public KeyValueClass(TKey _key,TValue _value)
    {
        key = _key;
        value = _value;
    }
}
[System.Serializable] public class DictionaryOfStringAndAudioClip : SerializableDictionary<string, AudioClip> { }

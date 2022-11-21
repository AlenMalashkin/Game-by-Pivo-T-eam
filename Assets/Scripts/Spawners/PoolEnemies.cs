using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemies<T> where T : MonoBehaviour
{
    public bool autoExpand { get; set; }
    public T prefab { get; }
    public Transform container { get; } 
    
    public List<T> pool;
        
    public PoolEnemies(T prefab, int count) {
        this.prefab = prefab;
        this.container = null;
        this.CreatePool(this.prefab, count, this.container);
    }
        
    public PoolEnemies(T prefab, int count, Transform container) {
        this.prefab = prefab;
        this.container = container;
        this.CreatePool(this.prefab, count, this.container);
    }

    private void CreatePool(T prefab, int count, Transform container) {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++) 
            this.CreateObject(prefab, container);
    }

    private T CreateObject(T prefab, Transform container, bool isActiveByDefault = false) {
        var createdObject = Object.Instantiate(prefab, container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }
        
    public bool HasFreeElement(out T element) {
        foreach (var mono in pool) {
            if (!mono.gameObject.activeInHierarchy) {
                mono.gameObject.SetActive(true);
                element = mono;
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement() {
        if (this.HasFreeElement(out var element))
            return element;
            
        if (this.autoExpand)
            return this.CreateObject(this.prefab, this.container, true);

        throw new System.Exception($"The pool of type {typeof(T).Name} is empty. Current elements number is: {pool.Count}");
    }

    public T[] GetAllElements() {
        return this.pool.ToArray();
    }

    public T[] GetAllActiveElements() {
        var activeElements = new List<T>();
        foreach (var element in this.pool) {
            if (element.gameObject.activeInHierarchy)
                activeElements.Add(element);
        }

        return activeElements.ToArray();
    }
}

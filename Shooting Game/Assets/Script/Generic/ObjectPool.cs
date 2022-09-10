using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T: class
{
    private List<PoolItem> pooledItem = new List<PoolItem>();

    public T GetItem()
    {
        if(pooledItem.Count > 0)
        {
            for(int i = 0; i < pooledItem.Count; i++)
            {
                if(pooledItem[i].IsUsed == false)
                {
                    pooledItem[i].IsUsed = true;
                    return pooledItem[i].Item;
                }
            }
        }

        return CreateNewItem();
    }

    public T CreateNewItem()
    {
        PoolItem newItem = new PoolItem();
        newItem.Item = CreateNew();
        newItem.IsUsed = true;
        pooledItem.Add(newItem);
        return newItem.Item;
    }

    public virtual T CreateNew()
    {
        return null;
    }

    public void ReturnToPool(T item)
    {
        for (int i = 0; i < pooledItem.Count; i++)
        {
            if (pooledItem[i].Item.Equals(item))
            {
                pooledItem[i].IsUsed = false;
            }
        }
    }

    public class PoolItem
    {
        public T Item;
        public bool IsUsed;
    }

}

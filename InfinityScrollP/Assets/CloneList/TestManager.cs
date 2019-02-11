using System.Collections.Generic;
using UnityEngine;

namespace Assets.Test
{
    public class TestManager : MonoBehaviour
    {
        public List<ItemData> ItemList = new List<ItemData>();
        public List<ItemData> NewDatas = new List<ItemData>();
        public Dictionary<int, ItemData> ItemDic = new Dictionary<int, ItemData>();

        private void Awake()
        {
            for (int i = 0; i < 10; i++)
            {
                ItemList.Add(new ItemData(i, " N: " + i));
            }
            for (int i = 0; i < ItemList.Count; i++)
            {
                NewDatas.Add(ItemList[i]);
                ItemDic.Add(GameUtils.Clone(ItemList[i].Id), GameUtils.Clone((ItemList[i])));
            }
        }

        private void Start()
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                Debug.Log("原始" + ItemList[i].Id + ItemList[i].Name);
            }
            for (int i = 0; i < NewDatas.Count; i++)
            {
                Debug.LogWarning("拷贝" + NewDatas[i].Id + NewDatas[i].Name);
            }
            foreach (KeyValuePair<int, ItemData> item in ItemDic)
            {
                Debug.Log("拷贝到字典" + item.Key + " " + item.Value.Name);
            }
            for (int i = 0; i < NewDatas.Count; i++)
            {
                //NewDatas[i].Id = NewDatas.Count - i;
                //NewDatas[i].Name = string.Concat(" N: ", (NewDatas.Count - i));
                ItemDic[i].Name = string.Concat(" N: ", (NewDatas.Count - i));
            }
            Debug.Log("-------------------------------------------------------------");
            Debug.Log("------------------修改打印----------------------------");
            Debug.Log("-------------------------------------------------------------");
            for (int i = 0; i < NewDatas.Count; i++)
            {
                Debug.LogWarning("原始" + ItemList[i].Id + ItemList[i].Name);
            }
            for (int i = 0; i < NewDatas.Count; i++)
            {
                //Debug.LogError("修改拷贝" + NewDatas[i].Id + NewDatas[i].Name);
            }

        }
    }
}

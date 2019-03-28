#region 注释
/*
 *         Title: IrregularList : LianJian
 *         Description:
 *                功能：     不规则列表刷新
 *         Author:           Herbie  
 *         Version:          0.1版本
 *         Modify Recoder:
 *        res:  https://blog.csdn.net/wuyf88/article/details/75113965
*/
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LianJian
{
    public class IrregularList : MonoBehaviour
    {
        public Transform _contentT;
        public ScrollRect _scrollRect;
        public Button _addPrefab;
        public Button _addToScene;

        public GameObject _titleGo;
        public Transform _itemGo;

        public void Awake()
        {

            _scrollRect = this.transform.Find("Scroll View").GetComponent<ScrollRect>();
            _contentT = this.transform.Find("Scroll View").GetComponent<ScrollRect>().content;
            _addPrefab = this.transform.Find("AddPrefab").GetComponent<Button>();
            _addToScene = this.transform.Find("AddScene").GetComponent<Button>();

            _titleGo = Resources.Load<GameObject>("Prefabs/Title");
            _itemGo = Resources.Load<Transform>("Prefabs/Item");
        }

        public void OnEnable()
        {
            _addPrefab.onClick.AddListener(() =>
            {
                CreateObj(_titleGo, _contentT);
                CreateObj(Random.Range(1, 10));
                SizeInit();
                StartCoroutine(Move());
            });
            _addToScene.onClick.AddListener(() =>
            {
                CreateObj(Random.Range(1, 10));
                SizeInit();
            });


        }


        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                //CreateObj(_titleGo, _contentT);
                //SizeInit();
                //StartCoroutine(Move());
                //CreateObj(Random.Range(1, 10));
                //SizeInit();
                //StartCoroutine(Move());
            }
        }

        public void CreateObj(int count)
        {
            GameObject parentObj = CreateObj(_itemGo.gameObject, _contentT);
            GameObject go = new GameObject();
            go.AddComponent<Image>();

            List<GameObject> gos = new List<GameObject>(CreateItems(go, count, parentObj.transform));
            Sprite sp = Resources.Load<Sprite>("TestPng/37864");
            for (int i = 0; i < gos.Count; i++)
            {
                gos[i].GetComponent<Image>().sprite = sp;
            }
        }


        public GameObject CreateObj(GameObject go, Transform parentT)
        {
            GameObject item = Instantiate(go, parentT);
            Text text = gameObject.transform.GetComponentInChildren<Text>();
            if (text != null)
                text.text = go.name;
            item.transform.localPosition = Vector3.zero;
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            item.transform.SetParent(parentT);
            return item;
        }

        public List<GameObject> CreateItems(GameObject item, int count, Transform parentT)
        {
            List<GameObject> gos = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                GameObject go = CreateObj(item, parentT);
                gos.Add(go);
            }
            return gos;
        }

        public void SizeInit()
        {
            StartCoroutine(SetHigh());
        }

        IEnumerator Move()
        {
            yield return new WaitForSeconds(0.1f);
            _scrollRect.verticalNormalizedPosition = 0;
        }

        IEnumerator SetHigh()
        {
            yield return new WaitForSeconds(0.1f);

            float high = 0;
            for (int i = 0; i < _contentT.childCount; i++)
            {
                high += _contentT.GetChild(i).GetComponent<RectTransform>().sizeDelta.y;
            }
            Debug.Log("--------High-------" + high);
            RectTransform rect = _contentT.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, high);

        }
    }
}

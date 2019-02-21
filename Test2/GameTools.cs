#region 脚本注释
/** 
 *Copyright(C) 2018 by ShangHaiZhuQi
 *All rights reserved. 
 *FileName:     #SCRIPTFULLNAME# 
 *Author:       刘阳
 *Version:      #VERSION# 
 *UnityVersion：#UNITYVERSION# 
 *Date:         #DATE# 
 *Description:    
 *History: 
*/
#endregion

using System.Collections;
using System.Collections.Generic;
namespace LianJian
{
    public class GameTools
    {
        private static GameTools s_Instance = new GameTools();

        public static GameTools Instance
        {
            get { return s_Instance; }
        }

        public void Init()
        {
            List<ItemVo> itemCfgs = new List<ItemVo>();
            itemCfgs.Add(new ItemVo() { attack = 1, hp = 5, mp = 8 });
            itemCfgs.Add(new ItemVo() { attack = 1, hp = 4, mp = 4 });
            itemCfgs.Add(new ItemVo() { attack = 1, hp = 3, mp = 6 });
            itemCfgs.Add(new ItemVo() { attack = 2, hp = 2, mp = 7 });
            itemCfgs.Add(new ItemVo() { attack = 3, hp = 8, mp = 10 });
            itemCfgs.Add(new ItemVo() { attack = 6, hp = 9, mp = 34 });
            itemCfgs.Add(new ItemVo() { attack = 6, hp = 8, mp = 39 });
            itemCfgs.Add(new ItemVo() { attack = 6, hp = 10, mp = 34 });
            itemCfgs.Add(new ItemVo() { attack = 4, hp = 4, mp = 45 });
            itemCfgs.Add(new ItemVo() { attack = 5, hp = 6, mp = 66 });
            itemCfgs.Add(new ItemVo() { attack = 5, hp = 6, mp = 89 });
            itemCfgs.Add(new ItemVo() { attack = 5, hp = 6, mp = 65 });
            itemCfgs.Add(new ItemVo() { attack = 5, hp = 6, mp = 76 });

            itemCfgs = ArmsSort(itemCfgs);

            foreach (ItemVo itemCfg in itemCfgs)
            {
                System.Console.WriteLine("排序后 " + itemCfg.attack + "  " + itemCfg.hp + "  " + itemCfg.mp);
            }

        }


        /// <summary>
        /// 武器排序
        /// </summary>
        /// <param name="itemCfgs"></param>
        /// <returns></returns>
        public List<ItemVo> ArmsSort(List<ItemVo> itemCfgs)
        {
            if (itemCfgs.Count == 0) return itemCfgs;
            itemCfgs.Sort((a, b) =>
            {
                if (a.attack.CompareTo(b.attack) != 0)
                {
                    return a.attack.CompareTo(b.attack);
                }
                else if (a.hp.CompareTo(b.hp) != 0)
                {
                    return (a.hp - b.hp);
                }
                else if (a.mp.CompareTo(b.mp) != 0)
                {
                    return (a.mp - b.mp);
                }
                return 0;
            });
            return itemCfgs;
        }


    }

    public class ItemVo
    {
        public int attack;
        public int hp;
        public int mp;
    }
}


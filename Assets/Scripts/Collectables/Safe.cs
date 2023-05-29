using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{

    public class Safe : MonoBehaviour
    {
        private bool isLocked;
        [SerializeField] private List<Item> itemPrefabList;
        private Item item;

        private void Start(){
            isLocked = true;
        }

        public bool IsLocked(){
            return isLocked;
        }

        public void Unlock(){
            Item itemPrefab = itemPrefabList[Random.Range(0, itemPrefabList.Count)];
            item = Instantiate<Item>(itemPrefab);
            item.Initialize();
            isLocked = false;
        }

        public Item GetItem(){
            return item;
        }
    }
}

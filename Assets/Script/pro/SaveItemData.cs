using UnityEngine;
using System;
using Newtonsoft.Json;


[Serializable]
public class SaveItemData
{//고유아이디 중복x 
    public Guid instanceId;



    //public string itemId;
    [JsonConverter(typeof(ItemDataConverter))] //아이템을 직렬화 
    public ItemData itemData;
    
    public DateTime creationTime;
       

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;

    }


}

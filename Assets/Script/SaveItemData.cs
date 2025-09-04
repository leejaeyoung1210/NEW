using UnityEngine;
using System;
using Newtonsoft.Json;


[Serializable]
public class SaveItemData
{//고유아이디 중복x 
    public Guid instanceId;


    [JsonConverter(typeof(ItemDataConverter))]
    public string itemId;

    public ItemData itemData;
    
    public DateTime creationTime;
       

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;

    }


}

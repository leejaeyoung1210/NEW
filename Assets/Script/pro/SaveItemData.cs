using UnityEngine;
using System;
using Newtonsoft.Json;


[Serializable]
public class SaveItemData
{//�������̵� �ߺ�x 
    public Guid instanceId;



    //public string itemId;
    [JsonConverter(typeof(ItemDataConverter))] //�������� ����ȭ 
    public ItemData itemData;
    
    public DateTime creationTime;
       

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;

    }


}

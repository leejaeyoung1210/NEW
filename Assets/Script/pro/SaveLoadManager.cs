using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using SaveDataVC = SaveDataV3; //���Ͽ��� ���Ǳ⿡ �ܺλ��x 

public class SaveLoadManager
{
    public static int SaveDataVersion { get; } = 3;

    public static SaveDataVC Data { get; set; } = new SaveDataVC();     
    private static readonly string[] SaveFileName =
    {
        "SaveAuto.json",
        "Save1.json",
        "Save2.json",
        "Save3.json",
    };

    public static string SaveDirectory => $"{Application.persistentDataPath}/Save";

    private static JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All,//���������� ������
    };



    public static bool Save(int slot = 0)// �����ε�������Ϸ��� 
    {//�����ϴ°�� �׽��Թ���
        if (Data == null || slot < 0 || slot >= SaveFileName.Length)
            return false;

        
        try
        {
            if (!Directory.Exists(SaveDirectory))//��ο� �������ִ����˻�
            { //��ξ����� ������ֱ�
                Directory.CreateDirectory(SaveDirectory);
            }
            var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
            //�������,�̸����� ��Ȱ������ ��밡��
            var json = JsonConvert.SerializeObject(Data, settings);
           File.WriteAllText(path, json);  //��ο� ���̽�����
            return true;
        }
        catch
        {
            Debug.LogError("Save ���� �߻�");
            return false; 
        }           
    }

    public static bool Load(int slot = 0)
    {//����Ÿ�� ���̿��� ����
        if (slot < 0 || slot >= SaveFileName.Length)
            return false;

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        //��������������ϱ⿡
        if (!File.Exists(path))
            return false;

        try
        {
            var json = File.ReadAllText(path);
            //������ȭ
            //var saveData = JsonConvert.DeserializeObject<SaveData>(json,settings);

            //Data = saveData as SaveDataV1;

            var dataSave = JsonConvert.DeserializeObject<SaveData>(json, settings);

            while(dataSave.Version<SaveDataVersion)
            {//������ ���������� ���� �� �ؼ� �ݺ�
                //���鼭 ã�Ƽ� ������
                dataSave = dataSave.VersionUp();
            }
            //�����͹����� ���������� ���������·� ��ȯ.
            Data = dataSave as SaveDataVC;

            //����ȯ 
            //Data = dataSave as SaveDataV1;
            return true;
        }
        catch
        {
            Debug.LogError("Load ���� �߻�");
            return false;
        }
    }




}

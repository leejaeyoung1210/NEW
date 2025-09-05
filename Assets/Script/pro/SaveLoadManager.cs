using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using SaveDataVC = SaveDataV3; //파일에서 허용되기에 외부사용x 

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
        TypeNameHandling = TypeNameHandling.All,//보안측에서 안좋음
    };



    public static bool Save(int slot = 0)// 슬롯인덱스사용하려고 
    {//실패하는경우 및슬롯범위
        if (Data == null || slot < 0 || slot >= SaveFileName.Length)
            return false;

        
        try
        {
            if (!Directory.Exists(SaveDirectory))//경로에 파일이있는지검사
            { //경로없으면 만들어주기
                Directory.CreateDirectory(SaveDirectory);
            }
            var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
            //언어추출,미리만들어서 재활용으로 사용가능
            var json = JsonConvert.SerializeObject(Data, settings);
           File.WriteAllText(path, json);  //경로에 제이슨저장
            return true;
        }
        catch
        {
            Debug.LogError("Save 예외 발생");
            return false; 
        }           
    }

    public static bool Load(int slot = 0)
    {//데이타가 널이여도 괜춘
        if (slot < 0 || slot >= SaveFileName.Length)
            return false;

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        //파일있으면실패하기에
        if (!File.Exists(path))
            return false;

        try
        {
            var json = File.ReadAllText(path);
            //역직렬화
            //var saveData = JsonConvert.DeserializeObject<SaveData>(json,settings);

            //Data = saveData as SaveDataV1;

            var dataSave = JsonConvert.DeserializeObject<SaveData>(json, settings);

            while(dataSave.Version<SaveDataVersion)
            {//버전과 현재사용중인 버전 비교 해서 반복
                //돌면서 찾아서 버전업
                dataSave = dataSave.VersionUp();
            }
            //데이터버전을 현재사용중인 데이터형태로 변환.
            Data = dataSave as SaveDataVC;

            //형변환 
            //Data = dataSave as SaveDataV1;
            return true;
        }
        catch
        {
            Debug.LogError("Load 예외 발생");
            return false;
        }
    }




}

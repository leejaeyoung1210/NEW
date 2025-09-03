using CsvHelper;
using System.Globalization;
using System.IO;
using UnityEngine;
using CsvHelper;

public class CsvData
{
    public string Id { get; set; }
    public string String { get; set; }

}

public class CsvTest : MonoBehaviour
{
    //public TextAsset csv; //1번

    private void Start()
    {
        TextAsset csv = Resources.Load<TextAsset>("DataTables/StringTableKr");//리소스아이디
        //r경로써주는 규칙: 에셋폴더 이하에 Resources 폴더 이하에있는 경로들을 적어주고 /로 구분한다.//Resources 파일이름은 고정
        //이름이 같으면 누가 불릴지 모름/수동으로 잘 관리해줘야함 

        //Resources.UnloadAsset(csv);
        //리소스시에서 한번 로드된 친구는 언로드해줄때까지 메모리에서 안내려온다. 

        //Debug.Log(csv.text);//문자열이 통으로 반환 //1번 바로접근할경우
        //Debug.Log(csv.text);



        using (var reader = new StringReader(csv.text))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<CsvData>();
            foreach (var record in records)
            {
                Debug.Log($"{record.Id} : {record.String}");
            }

        }

        //추상클래스 DT / DT MGr 생성 =>게임내 모든테이블관리 로드 겟등  
        //언어별 스트링테이블 아이템 등등들 DT 추상클래스를 상속받은 테이블들
       // 


    }




}

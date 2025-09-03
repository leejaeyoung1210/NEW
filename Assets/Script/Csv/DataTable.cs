using CsvHelper;
using NUnit.Framework;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public abstract class DataTable
{
    public static readonly string FormatPath = "DataTables/{0}"; //저장방법? / =>폴더구분자/순서시작

    //데이타테이블 추상클래스1 ⇒ load호출을하면 이걸 받은객체르 csv파일이름을 읽어다가 id 가져다 쓸수잇게
    public abstract void Load(string filename);

    //실제 csv텍스트 받아서 읽으면 파싱함,겟레포드 메서드를 이용하면 헤더에 이름표붙어있는 제목들과 
    //클래스의 멤버들과 일치하게 만들면 짝에 맞춰서 한줄씩 객체로 열거가능한놈으로 리스트로 반환해준거
    public static List<T> LoadCSV<T>(string csvText)
    {
        using (var reader = new StringReader(csvText))
        using (var csvReader = new CsvReader(reader,CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<T>();
            return records.ToList();

        }
    }
}

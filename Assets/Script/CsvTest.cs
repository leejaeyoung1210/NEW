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
    //public TextAsset csv; //1��

    private void Start()
    {
        TextAsset csv = Resources.Load<TextAsset>("DataTables/StringTableKr");//���ҽ����̵�
        //r��ν��ִ� ��Ģ: �������� ���Ͽ� Resources ���� ���Ͽ��ִ� ��ε��� �����ְ� /�� �����Ѵ�.//Resources �����̸��� ����
        //�̸��� ������ ���� �Ҹ��� ��/�������� �� ����������� 

        //Resources.UnloadAsset(csv);
        //���ҽ��ÿ��� �ѹ� �ε�� ģ���� ��ε����ٶ����� �޸𸮿��� �ȳ����´�. 

        //Debug.Log(csv.text);//���ڿ��� ������ ��ȯ //1�� �ٷ������Ұ��
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

        //�߻�Ŭ���� DT / DT MGr ���� =>���ӳ� ������̺���� �ε� �ٵ�  
        //�� ��Ʈ�����̺� ������ ���� DT �߻�Ŭ������ ��ӹ��� ���̺��
       // 


    }




}

using CsvHelper;
using NUnit.Framework;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public abstract class DataTable
{
    public static readonly string FormatPath = "DataTables/{0}"; //������? / =>����������/��������

    //����Ÿ���̺� �߻�Ŭ����1 �� loadȣ�����ϸ� �̰� ������ü�� csv�����̸��� �о�ٰ� id ������ �����հ�
    public abstract void Load(string filename);

    //���� csv�ؽ�Ʈ �޾Ƽ� ������ �Ľ���,�ٷ����� �޼��带 �̿��ϸ� ����� �̸�ǥ�پ��ִ� ������ 
    //Ŭ������ ������ ��ġ�ϰ� ����� ¦�� ���缭 ���پ� ��ü�� ���Ű����ѳ����� ����Ʈ�� ��ȯ���ذ�
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

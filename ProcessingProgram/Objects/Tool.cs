using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProcessingProgram.Objects
{
    /// <summary>
    /// ����������
    /// </summary>
    [XmlType(TypeName = "����������")]
    public class Tool
    {
        [XmlElement(ElementName = "�����")]
        public int No { get; set; }
        [XmlElement(ElementName = "���")]
        public string Type { get; set; }
        [XmlElement(ElementName = "������������")]
        public String Name { get; set; }
        [XmlElement(ElementName = "����������_�����")]
        public int OrderNo { get; set; }
//        public ToolType Type;
//        public ToolGroup Group;
        [XmlElement(ElementName = "�������")]
        public int Position { get; set; }
        [XmlElement(ElementName = "�������")]
        public double? Thickness { get; set; }
        [XmlElement(ElementName = "�������")]
        public double? Diameter { get; set; }
        [XmlElement(ElementName = "������")]
        public int WorkSpeed { get; set; }
        [XmlElement(ElementName = "��������_���������")]
        public int DownSpeed { get; set; }
        [XmlElement(ElementName = "�������")]
        public int Frequency { get; set; }

        private const string ToolsFileName = "tools.xml";  // TODO ���� � ����� ������������

        public static List<Tool> LoadTools()
        {
            //string toolsFullFileName = Path.Combine((new FileInfo(this.GetType().Assembly.FullName)).DirectoryName, ToolsFileName);  TODO ���� � ����� ������������
            try
            {
                using (var fileStream = new FileStream(ToolsFileName, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof (List<Tool>));
                    return serializer.Deserialize(fileStream) as List<Tool>;
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(String.Format("���� ������������ �� ������: {0}\n{1}", ToolsFileName, e.Message), "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("������ ��� �������� ����� ������������: \n{0}", e.Message), "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new List<Tool>();
        }

        public static void SaveTools(List<Tool> tools)
        {
            try
            {
                var serializer = new XmlSerializer(typeof (List<Tool>));
                TextWriter writer = new StreamWriter(ToolsFileName);    // new StreamWriter(csvFileName, true, Encoding.UTF8)) {
                serializer.Serialize(writer, tools);
                writer.Close();
                MessageBox.Show("���� ������������ ������� ��������"," ���������");
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ������ ����� ������������: \n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
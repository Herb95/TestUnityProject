using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Assets.Test
{
    [Serializable]
    public class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ItemData()
        {

        }

        public ItemData(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }

    public static class GameUtils
    {
        /// <summary>
        /// 利用System.Xml.Serialization来实现序列化与反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="realObject"></param>
        /// <returns></returns>
        public static T Clone<T>(T realObject)
        {
            using (Stream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, realObject);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// 利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="realObject"></param>
        /// <returns></returns>
        public static T Clone2<T>(T realObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, realObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(objectStream);
            }
        }
    }
}

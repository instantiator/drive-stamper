using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System;

namespace DriveStamper.Entities
{

  /// <summary>
  /// Simple helper library to manage XML Serialization and Deserialization
  /// </summary>
  public class XmlHelper
  {
    /// <summary>
    /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
    /// </summary>
    /// <param name="characters">Unicode Byte Array to be converted to String</param>
    /// <returns>String converted from Unicode Byte Array</returns>
    private static string UTF8ByteArrayToString(byte[] characters)
    {
      UTF8Encoding encoding = new UTF8Encoding();
      string constructedString = encoding.GetString(characters);
      return (constructedString);
    }

    /// <summary>
    /// Converts the String to UTF8 Byte array and is used in De serialization
    /// </summary>
    /// <param name="pXmlString"></param>
    /// <returns></returns>
    private static Byte[] StringToUTF8ByteArray(string pXmlString)
    {
      UTF8Encoding encoding = new UTF8Encoding();
      byte[] byteArray = encoding.GetBytes(pXmlString);
      return byteArray;
    }

    /// <summary>
    /// Serialize an object into an XML string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="success"></param>
    /// <returns></returns>
    public static string Serialize<T>(T obj, out bool success)
    {
      try
      {
        string xmlString = null;
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(T));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xs.Serialize(xmlTextWriter, obj);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        xmlString = UTF8ByteArrayToString(memoryStream.ToArray());
        success = true;
        return xmlString;
      }
      catch (Exception e)
      {
        success = false;
        return e.ToString();
      }
    }

    /// <summary>
    /// Reconstruct an object from an XML string
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static T Deserialize<T>(string xml)
    {
      XmlSerializer xs = new XmlSerializer(typeof(T));
      MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
      XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
      return (T)xs.Deserialize(memoryStream);
    }
  }

}
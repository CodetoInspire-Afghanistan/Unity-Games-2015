using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// File manager.
/// </summary>
public class FileManager : MonoBehaviour
{
		public static bool isException = false;

		//get the current platform path
		public static string getPlatformPath ()
		{
				string paltformPath = null;

				if (PlatformChecker.IsAndroid ()) {
						paltformPath = Application.persistentDataPath + "/";
				} else if (PlatformChecker.IsIOS ()) {
						string dataPath = Application.dataPath;
						string fileBasePath = dataPath.Substring (0, dataPath.LastIndexOf ('/'));
						paltformPath = fileBasePath.Substring (0, fileBasePath.LastIndexOf ('/')) + "/Documents/";
				} else {
						paltformPath = Application.dataPath + "/";
				}
				return paltformPath;
		}

		//check the the file exists in the given path
		public static bool IsFileExists (string path)
		{
				if (File.Exists (path)) {
						return true;
				}
				return false;
		}

		//Read From Text File
		public static string ReadFromTextFile (string filePath)
		{
				isException = false;
				string result = null;
				try {
						StreamReader sr = new StreamReader (filePath);
						result = sr.ReadToEnd ();
						sr.Close ();
				} catch (IOException ex) {
						Debug.Log ("IO Exception :" + ex.Message);
						isException = true;
				}
				return DataEncryption.Base64Decode (result);
		}

		//Write To Text File
		public static void WriteToTextFile (string filePath, string data)
		{
				isException = false;
				if (string.IsNullOrEmpty (data)) {
						return;
				}
				data = DataEncryption.Base64Encode (data);

				try {
						StreamWriter sw = new StreamWriter (filePath);
						string [] lines = data.Split ('\n');
						foreach (string line in lines) {
								sw.WriteLine (line);
						}
						sw.Close ();
				} catch (IOException ex) {
						Debug.Log ("IO Exception :" + ex.Message);
						isException = true;
				}
		}

		//Read root object from the binray file path
		public static T ReadFromBinaryFile <T> (string filePath)
		{
				isException = false;
				if (string.IsNullOrEmpty (filePath)) {
						return default(T);
				}
				if (!File.Exists (filePath)) {
						return  default(T);
				}

				T root = default(T);

				FileStream file = null;
				try {
						BinaryFormatter bf = new BinaryFormatter ();
						file = File.Open (filePath, FileMode.Open);
						root = (T)bf.Deserialize (file);
				} catch (Exception ex) {
						Debug.Log ("IO Exception :" + ex.Message);
						if (file != null)
								file.Close ();
						isException = true;
				}

				return root;
		}

		//Write the given root object to a binray file
		public static void WriteToBinaryFile<T> (string filePath, T root)
		{
				isException = false;
				if (root == null || string.IsNullOrEmpty (filePath)) {
						return;
				}

				FileStream file = null;
				try {
						BinaryFormatter bf = new BinaryFormatter ();
						file = File.Open (filePath, FileMode.Create);
						bf.Serialize (file, root);
						file.Close ();
				} catch (Exception ex) {
						Debug.Log ("IO Exception :" + ex.Message);
						if (file != null)
								file.Close ();
						isException = true;
				}
		}
}
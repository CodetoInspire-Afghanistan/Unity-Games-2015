using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// <summary>
/// Data encryption.
/// </summary>
public class DataEncryption : MonoBehaviour
{
		//base64 encoding
		public static string Base64Encode (string plainText)
		{
				var plainTextBytes = System.Text.Encoding.UTF8.GetBytes (plainText);
				return System.Convert.ToBase64String (plainTextBytes);
		}

		//base64 decoding
		public static string Base64Decode (string chipherText)
		{
				var base64EncodedBytes = System.Convert.FromBase64String (chipherText);
				return System.Text.Encoding.UTF8.GetString (base64EncodedBytes);
		}

		//md5 encrypt
		public static string MD5Encrypt (string toEncrypt, string securityKey, bool useHashing)
		{
				string retVal = string.Empty;
				try {
						byte[] keyArray;
						byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes (toEncrypt);
						ValidateInput (toEncrypt);
						ValidateInput (securityKey);
						if (useHashing) {
								MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider ();
								keyArray = hashmd5.ComputeHash (UTF8Encoding.UTF8.GetBytes (securityKey));
								hashmd5.Clear ();
						} else {
								keyArray = UTF8Encoding.UTF8.GetBytes (securityKey);
						}
						TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider ();
						tdes.Key = keyArray;
						tdes.Mode = CipherMode.ECB;
						tdes.Padding = PaddingMode.PKCS7;
						ICryptoTransform cTransform = tdes.CreateEncryptor ();
						byte[] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);
						tdes.Clear ();
						retVal = Convert.ToBase64String (resultArray, 0, resultArray.Length);
				} catch (Exception ex) {
						Debug.Log (ex.Message);
				}
				return retVal;
		}
	 
		//input validation
		private static bool ValidateInput (string inputValue)
		{
				bool notValid = string.IsNullOrEmpty (inputValue);
				if (notValid) {
						Debug.Log ("Invalid Input MD5");
				}
				return notValid;
		}
}

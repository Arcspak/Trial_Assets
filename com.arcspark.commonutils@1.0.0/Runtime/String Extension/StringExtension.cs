using System.Text.RegularExpressions;
using System;
using UnityEngine;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// Extension of the System.String.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// For the string file path, replace the char '\' in all strings with the char '/'.
        /// </summary>
        /// <param name="pathStr">Original string.</param>
        /// <returns>Modified string.</returns>
        public static string ToUnityPath(this string pathStr)
        {
            return pathStr.Replace('\\', '/');
        }

        /// <summary>
        /// Determine whether the given string is a legal URI.
        /// </summary>
        /// <param name="uri">Original string.</param>
        /// <returns>
        /// Returns true if the given string is a legal URI,
        /// otherwise returns false
        /// </returns>
        public static bool IsLegalURI(this string uri)
        {
            return !string.IsNullOrEmpty(uri) && uri.Contains("://");
        }

        /// <summary>
        /// Determine whether the given string is a legal HTTP URI.
        /// </summary>
        /// <param name="uri">Original string.</param>
        /// <returns>
        /// Returns true if the given string is a legal HTTP URI,
        /// otherwise returns false
        /// </returns>
        public static bool IsLegalHTTPURI(this string uri)
        {
            uri = uri.ToLower();
            return !string.IsNullOrEmpty(uri) && (uri.StartsWith("http://") || uri.StartsWith("https://"));
        }

        /// <summary>
		/// Check the string is int.
		/// </summary>
		public static bool IsInt(this string s)
		{
			if (Regex.IsMatch(s, "^-?\\d+$"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check the string is float.
		/// </summary>
		public static bool IsFloat(this string s)
		{
			if (Regex.IsMatch(s, "^-?([0-9]\\d*\\.\\d*|0\\.\\d*[0-9]\\d*|0?\\.0+|0)$"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check the string is color.
		/// </summary>
		public static bool IsColor(this string s)
		{
			if (Regex.IsMatch(s, "^#([0-9a-fA-F]{6}|[0-9a-fA-F]{3})$"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check the string is in pure Chinese.
		/// </summary>
		public static bool IsChinese(this string s)
		{
			if (Regex.IsMatch(s, "^[\\u4e00-\\u9fa5]{0,}$"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check the string is in pure English.
		/// </summary>
		public static bool IsEnglish(this string s)
		{
			if (Regex.IsMatch(s, "^[A-Za-z]+$"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check the string is a email.
		/// </summary>
		public static bool IsEmail(this string s)
		{
			if (Regex.IsMatch(s, "^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check the string is a double bytes.
		/// </summary>
		public static bool IsDoubleBytes(this string s)
		{
			if (Regex.IsMatch(s, "[^\\x00-\\xff] "))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check the string is a phone number.
		/// </summary>
		public static bool IsPhoneNumber(this string s)
		{
			if (Regex.IsMatch(s, "^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\\d{8}$"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Use the string to make texture.
		/// </summary>
		public static Texture2D MakeTexture2D(this string s)
		{
			Texture2D texture2D = new Texture2D(0, 0, TextureFormat.ARGB32, mipChain: false);
			try
			{
				byte[] data = Convert.FromBase64String(s);
				texture2D.LoadImage(data);
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
			}
			return texture2D;
		}
    }
}
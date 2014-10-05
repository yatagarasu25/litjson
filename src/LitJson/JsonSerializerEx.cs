using LitJson;
using System.IO;

namespace LitJson
{
	public static class JsonSerializerEx
	{
		public static void Serialize<T>(Stream stream, T o)
		{
			using (var s = new StreamWriter(stream))
				s.Write(JsonMapper.ToJson(o));
		}

		public static T Deserialize<T>(Stream stream)
		{
			using (var s = new StreamReader(stream))
				return JsonMapper.ToObject<T>(s.ReadToEnd());
		}
	}
}
using LitJson;
using System.IO;
using System.Text;

namespace LitJson
{
	public static class JsonSerializerEx
	{
		public static void Serialize<T>(Stream stream, T o)
		{
			using (var s = new StreamWriter(stream))
				s.Write(JsonMapper.ToJson(o));
		}

		public static void Serialize<T>(Stream stream, T o, bool pretty)
		{
			StringBuilder sb = new StringBuilder();
			JsonWriter jw = new JsonWriter(sb);
			jw.PrettyPrint = pretty;
			JsonMapper.ToJson(o, jw);
			using (var s = new StreamWriter(stream))
				s.Write(sb.ToString());
		}


		public static T Deserialize<T>(Stream stream)
		{
			using (var s = new StreamReader(stream))
				return JsonMapper.ToObject<T>(s.ReadToEnd());
		}
	}
}
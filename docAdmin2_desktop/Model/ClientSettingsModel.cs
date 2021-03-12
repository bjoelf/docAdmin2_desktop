using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace docAdmin2_desktop.Model
{
    public class ClientSettingsModel
    {

        [JsonProperty("ExamToArticle")]
        public ExamToArticle ExamToArticle { get; set; }

        [JsonProperty("ExamType")]
        public ExamType ExamType { get; set; }

        [JsonProperty("Priority")]
        public Priority Priority { get; set; }

        [JsonProperty("Doctors")]
        public List<Doctor> Doctors { get; set; }

        [JsonProperty("FileFormat")]
        public FileFormat FileFormat { get; set; }
    }
    public partial class Doctor
    {
        [JsonProperty("Sign")]
        public string Sign { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Number { get; set; }
    }
    public partial class Priority
    {
        [JsonProperty("0")]
        public string The0 { get; set; }

        [JsonProperty("99")]
        public string The99 { get; set; }

        [JsonProperty("-1")]
        public string The1 { get; set; }
    }
    public partial class ExamType
    {
        [JsonProperty("3")]
        public string The3 { get; set; }

        [JsonProperty("6")]
        public string The6 { get; set; }

        [JsonProperty("8")]
        public string The8 { get; set; }

        [JsonProperty("8_")]
        public string The8_ { get; set; }

        [JsonProperty("M")]
        public string M { get; set; }

        [JsonProperty("M2")]
        public string M2 { get; set; }
    }
    public partial class ExamToArticle
    {
        [JsonProperty("Elective")]
        public Articles Elective { get; set; }

        [JsonProperty("Acute")]
        public Articles Acute { get; set; }

        [JsonProperty("Jour")]
        public Articles Jour { get; set; }
    }
    public partial class Articles
    {
        [JsonProperty("CO")]
        public string Co { get; set; }

        [JsonProperty("CT")]
        public string Ct { get; set; }

        [JsonProperty("CT2")]
        public string Ct2 { get; set; }

        [JsonProperty("MR")]
        public string Mr { get; set; }

        [JsonProperty("M2")]
        public string M2 { get; set; }
    }
    public partial class FileFormat
    {
        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("col_signdoc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ColSigndoc { get; set; }

        [JsonProperty("col_prio")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ColPrio { get; set; }

        [JsonProperty("col_type")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ColType { get; set; }

        [JsonProperty("index_examtype")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long IndexExamtype { get; set; }
    }
    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}

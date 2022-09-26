namespace HDF.Framework.Test
{

    [Serializable]
    public class DtoInfo
    {
        public string Field { get; set; }
        public string Value { get; set; }


    }



    //public class DtoInfoConverter : JsonConverter
    //{

    //    public override bool CanConvert(Type t)
    //    {
    //        return typeof(DtoInfo).IsAssignableFrom(t);
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        DtoInfo dto = (DtoInfo)value;

    //        JObject obj = new JObject();

    //        obj[dto.Field] = dto.Value;

    //        obj.WriteTo(writer);
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        var obj = (JObject)JObject.ReadFrom(reader);


    //        JProperty property = obj.Properties().FirstOrDefault();

    //        return new DtoInfo
    //        {
    //            Field = property.Name,
    //            Value = property.Value.Value<string>()
    //        };
    //    }

    //    public override bool CanRead
    //    {
    //        get { return true; }
    //    }
    //}


    //public class ListoConverter : JsonConverter
    //{

    //    public override bool CanConvert(Type t)
    //    {
    //        return typeof(List<DtoInfo>).IsAssignableFrom(t);
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        List<DtoInfo> dto = (List<DtoInfo>)value;

    //        JObject obj = new JObject();

    //        foreach (var item in dto)
    //        {
    //            obj[item.Field] = item.Value;
    //        }

    //        obj.WriteTo(writer);
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        var obj = (JObject)JObject.ReadFrom(reader);


    //        return obj.Properties().Select(a => new DtoInfo
    //        {
    //            Field = a.Name,
    //            Value = a.Value.Value<string>()
    //        }).ToList();
    //    }

    //    public override bool CanRead
    //    {
    //        get { return true; }
    //    }
    //}

}

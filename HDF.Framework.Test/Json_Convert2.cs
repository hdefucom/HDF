namespace HDF.Framework.Test
{


    class test
    {

        void m()
        {


            var aaa = new AAAAAA()
            {
                Title = "xxx",
                Sex = "男",
                Decimal = 1.2M,
                Double = 1.3,
                Float = 1.4f,
                Int = 9,
                Time = new DateTime(1999, 11, 8),
            };


            //var json = JsonConvert.SerializeObject(aaa, new AAAAAAConverter());



            //var bbb = JsonConvert.DeserializeObject<AAAAAA>(json, new AAAAAAConverter());


        }
    }



    public class AAAAAA
    {
        public string Title { get; set; }
        public string Sex { get; set; }
        public int Int { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public decimal Decimal { get; set; }

        public DateTime Time { get; set; }




    }



    //public class AAAAAAConverter : JsonConverter
    //{

    //    public override bool CanConvert(Type t)
    //    {
    //        return typeof(AAAAAA).IsAssignableFrom(t);
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        var dto = (AAAAAA)value;

    //        JArray arr = new JArray();

    //        foreach (var item in dto.GetType().GetProperties())
    //        {
    //            var obj = new JObject();
    //            obj["name"] = item.Name;
    //            var val = item.GetValue(dto);
    //            if (val is string str)
    //                obj["value"] = str;
    //            else if (val is DateTime dt)
    //                obj["value"] = dt;
    //            else if (val is bool b)
    //                obj["value"] = b;
    //            else if (val == null)
    //                obj["value"] = null;
    //            else if (long.TryParse(val.ToString(), out var l))
    //                obj["value"] = l;
    //            else if (decimal.TryParse(val.ToString(), out var d))
    //                obj["value"] = d;

    //            arr.Add(obj);
    //        }

    //        arr.WriteTo(writer);
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        var arr = (JArray)JArray.ReadFrom(reader);

    //        var dto = new AAAAAA();
    //        var props = dto.GetType().GetProperties();

    //        foreach (JObject item in arr)
    //        {
    //            var p = props.FirstOrDefault(p => p.Name == item["name"].ToString());
    //            if (p != null)
    //                p.SetValue(dto, item["value"].ToObject(p.PropertyType));
    //        }

    //        return dto;
    //    }

    //    public override bool CanRead
    //    {
    //        get { return true; }
    //    }
    //}


}

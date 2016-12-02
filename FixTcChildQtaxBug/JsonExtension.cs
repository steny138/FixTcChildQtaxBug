using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixTcChildQtaxBug
{
    public static class JsonExtension
    {
        public static TResult JsonDeserialize<TResult>(this string Expression)
        {
            return JsonConvert .DeserializeObject<TResult>(Expression);
        }

        public static string SerializeToJson(this object input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}

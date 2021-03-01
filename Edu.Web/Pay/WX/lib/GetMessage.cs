using Soltrip.TBP.Common.Model;
using Public.Platform.API.Models;

namespace WxPayAPI
{
    /// <summary>
    /// 构建http结果json
    /// </summary>
    public class GetMessage
    {
        
        public static string Get(int code, bool success, string msg )
        {
            var result = new APIResult<object>();
            result.code = code;
            result.success = success;
            result.msg = msg;
            string liveMessage = JSONHelper.ObjectToJson(result);
            return liveMessage;

        }
    }
}
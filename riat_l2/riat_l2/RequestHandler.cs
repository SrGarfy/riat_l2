using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riat_l2
{
    class RequestHandler : RequestCreator
    {
        private readonly string url;
        private string answer;
        public RequestHandler(int port)
        {
            url = $"http://127.0.0.1:{port}";
            //url = $"http://195.133.48.158/study";
        }
        public void Ping()
        {
            while (!CreateRequest(RequestType.GET, url, "Ping", out answer));
        }
        public Input GetInputData()
        {
            while (!CreateRequest(RequestType.GET, url, "GetInputData", out answer) || string.IsNullOrEmpty(answer));
            return JsonSerializer.Deserialize<Input>(Encoding.UTF8.GetBytes(answer));
        }
        public void WriteAnswer(Output output)
        {
            var bytes = JsonSerializer.Serialize(output);
            while (!CreateRequest(RequestType.POST, url, "WriteAnswer", out answer, bytes));
        }
    }
}

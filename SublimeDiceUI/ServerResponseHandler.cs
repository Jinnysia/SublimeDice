using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SublimeDiceUI
{
    public enum ResponseStatus
    {
        Undefined,
        OK,
        Warning,
        Error,
        ConnectionError
    }

    internal class ResponseMessage
    {
        public string status { get; set; }
        public string title { get; set; }
        public string message { get; set; }
    }

    public static class ServerResponseHandler
    {
        public static string GenerateConnectionErrorJSONString(Exception e)
        {
            ResponseMessage response = new ResponseMessage
            {
                status = "NG-C",
                title = "An exception occurred",
                message = "The client was unable to complete the request because of a thrown " + e.GetType().Name + "." + Environment.NewLine + e.Message
            };
            return JsonSerializer.Serialize(response);
        }
        
        public static ResponseStatus DisplayMessageBox(string response)
        {
            ResponseStatus result = ResponseStatus.Undefined;
            using (JsonDocument doc = JsonDocument.Parse(response))
            {
                JsonElement root = doc.RootElement;

                string status = root.GetProperty("status").ToString();
                string title = root.GetProperty("title").ToString();
                string message = root.GetProperty("message").ToString();

                if (status == "OK")
                {
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = ResponseStatus.OK;
                }
                else if (status == "NG-W")
                {
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = ResponseStatus.Warning;
                }
                else if (status == "NG-E")
                {
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = ResponseStatus.Error;
                }
                else if (status == "NG-C")
                {
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = ResponseStatus.ConnectionError;
                }
                else
                {
                    MessageBox.Show(message, title);
                }
            }

            return result;
        }
    }
}

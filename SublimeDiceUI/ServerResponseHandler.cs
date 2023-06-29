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
        Error
    }

    public static class ServerResponseHandler
    {
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
                else
                {
                    MessageBox.Show(message, title);
                }
            }

            return result;
        }
    }
}

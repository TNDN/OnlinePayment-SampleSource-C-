using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

public class PayBoxModule
{
    public static string GetPaymentEncrypt(string requestUrl, RequestPayment requestPayment, out string errorMsg)
    {
        errorMsg = string.Empty;

        RequestPaymentResult requestPaymentResult = new RequestPaymentResult();

        string data = JsonConvert.SerializeObject(requestPayment);
        string response_data = string.Empty;

        byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(data.ToString());

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = byteDataParams.Length;
        Stream stDataParams = request.GetRequestStream();
        stDataParams.Write(byteDataParams, 0, byteDataParams.Length);
        stDataParams.Close();

        try
        {
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream, System.Text.Encoding.UTF8);
            requestPaymentResult = JsonConvert.DeserializeObject<RequestPaymentResult>(responseReader.ReadToEnd());
            Console.Out.WriteLine(requestPaymentResult.Data);
            responseReader.Close();
        }
        catch (WebException e)
        {
            using (WebResponse response = e.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)response;

                using (Stream errorData = response.GetResponseStream())
                using (StreamReader errorReader = new StreamReader(errorData))
                {
                    string errorText = errorReader.ReadToEnd();
                    Console.WriteLine("--------Error---------");
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    Console.WriteLine("Error Msg: {0}", errorText);

                    ErrorResult errorResult = JsonConvert.DeserializeObject<ErrorResult>(errorText);
                    errorMsg = errorResult.Error.Detail;
                }
            }

            requestPaymentResult.Data = string.Empty;
        }

        return requestPaymentResult.Data;
    }

    public static string GetDocumentContents(HttpRequest Request)
    {
        string documentContents;
        Request.InputStream.Position = 0;
        using (Stream receiveStream = Request.InputStream)
        {
            using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
            {
                documentContents = readStream.ReadToEnd();
            }
        }
        return documentContents;
    }
}
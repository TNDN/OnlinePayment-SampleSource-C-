using Newtonsoft.Json;
using System;

public partial class notify_url : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Request Content 노티 정보 조회 
        string body = PayBoxModule.GetDocumentContents(Request);

        if (string.IsNullOrEmpty(body))
        {
            //FAIL로 응답 시 최대 10회까지 재 전송 처리
            Response.Write("<xml><returnCode><![CDATA[FAIL]]></returnCode></xml>");
            return;
        }

        PartnerNotification partnerNotification = JsonConvert.DeserializeObject<PartnerNotification>(body);
        //확인용
        //Response.Write("TransactionId=" + partnerNotification.TransactionId + "<br/>");
        //Response.Write("TransactionDateTime=" + partnerNotification.TransactionDateTime + "<br/>");
        //Response.Write("TransactionCurrency=" + partnerNotification.TransactionCurrency + "<br/>");
        //Response.Write("TransactionPGCode=" + partnerNotification.TransactionPGCode + "<br/>");
        //Response.Write("OrderNo=" + partnerNotification.OrderNo + "<br/>");

        //Response.Write("OrderInfo=" + partnerNotification.OrderInfo + "<br/>");
        //Response.Write("TransAmount=" + partnerNotification.TransAmount + "<br/>");
        //Response.Write("Email=" + partnerNotification.Email + "<br/>");
        //Response.Write("AdditionalInfo=" + partnerNotification.AdditionalInfo + "<br/>");
        //Response.Write("ExchangeCurrecy=" + partnerNotification.ExchangeCurrecy + "<br/>");

        //Response.Write("ExchangeAmount=" + partnerNotification.ExchangeAmount + "<br/>");
        //Response.Write("ExchangeRate=" + partnerNotification.ExchangeRate + "<br/>");
        Response.Write("<xml><returnCode><![CDATA[SUCCESS]]></returnCode></xml>");
    }
}

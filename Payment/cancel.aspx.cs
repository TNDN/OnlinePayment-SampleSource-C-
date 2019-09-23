using System;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// 파트너사에 부여 받은 Partner API Id ('[비지니스 설정] >> [API]' 에서 확인 가능)
    /// </summary>
    private const string PARTNER_API_ID = "tyjxh7dgeiupq1l1hymmzbo6hhhx8kb4";
    /// <summary>
    /// 파트너사에 부여 받은 Partner API Key ('[비지니스 설정] >> [API]' 에서 확인 가능)
    /// </summary>
    private const string PARTNER_API_KEY = "dGd0N2tlaWlicm5laDgycjJidjNybDJ1emsxeTM0a20=";
    /// <summary>
    /// 결제 API 토큰 생성 URL
    /// </summary>
    private const string CREATE_TOKEN_URL = "http://devapi.paybox.store/Create/Token"; //개발 서비스 환경
    //private const string CREATE_TOKEN_URL = "https://api.paybox.store/Create/Token"; //운영 서비스 환경
    /// <summary>
    /// 결제 취소 API
    /// </summary>
    private const string CANCEL_PAYMENT_URL = "http://devapi.paybox.store/Api/Payment/Cancel"; //개발 서비스 환경
    //private const string CANCEL_PAYMENT_URL = "https://api.paybox.store/Api/Payment/Cancel"; //운영 서비스 환경

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnPayBoxCancel_Click(object sender, EventArgs e)
    {
        CreateToken createToken = new CreateToken();
        createToken.PartnerAPIId = PARTNER_API_ID;
        createToken.PartnerAPIKey = PARTNER_API_KEY;

        string errMsg = string.Empty;
        StringBuilder sbHtml = new StringBuilder();

        //API 통신 토큰 생성
        string token = PayBoxModule.CreateToken(CREATE_TOKEN_URL, createToken, out errMsg);
        if (string.IsNullOrEmpty(token))
        {
            sbHtml.Append("<script>alert('" + errMsg + "'); self.close();</script>");
            Response.Write(sbHtml.ToString());

            return;
        }

        RequestCancelPayment requestCancelPayment = new RequestCancelPayment();
        requestCancelPayment.CancelType = Convert.ToInt32(Cancel_Type.Text.Trim());
        requestCancelPayment.TransactionId = TransactionId.Text.Trim();
        requestCancelPayment.TransAmount = Convert.ToDouble(TransAmount.Text.Trim());

        //결제 취소 통신
        ReeponseCancelPayment reeponseCancelPayment = PayBoxModule.CacenlPayment(CANCEL_PAYMENT_URL, token, requestCancelPayment, out errMsg);
        if (reeponseCancelPayment == null)
        {
            sbHtml.Append("<script>alert('"+ errMsg + "'); self.close();</script>");
            Response.Write(sbHtml.ToString());

            return;
        }

        sbHtml.Append("<script>alert('" + string.Format("{0}/{1}/{2}/{3}/{4}", reeponseCancelPayment.Data.ResultCode
                                                                             , reeponseCancelPayment.Data.ResultMessage
                                                                             , reeponseCancelPayment.Data.ResultNMessage
                                                                             , reeponseCancelPayment.Data.TransactionId
                                                                             , reeponseCancelPayment.Data.CancelDataTime) + "');self.close();</script>");
        Response.Write(sbHtml.ToString());
    }
}

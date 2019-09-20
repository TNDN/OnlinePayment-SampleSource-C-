using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
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
    /// 결제 정보 암호화 URL
    /// </summary>
    private const string PAYMENT_ENCRYPT_URL = "http://devapi.paybox.store/Payment/Encrypt"; //개발 서비스 환경
    //private const string PAYMENT_ENCRYPT_URL = "https://api.paybox.store/Payment/Encrypt"; //운영 서비스 환경
    /// <summary>
    /// 결제 창 호출 URL
    /// </summary>
    private const string REQUEST_PAYMENT_URL = "http://devapi.paybox.store/Payment/Request/Redirect/{0}"; //개발 서비스 환경
    //private const string REQUEST_PAYMENT_URL = "https://api.paybox.store/Payment/Request/Redirect/{0}"; //운영 서비스 환경
    /// <summary>
    /// 결제 창 호출 URL(위챗공중계정 - PaymentType이 3인 경우에만 사용가능하며, 위챗 앱내에서만 페이지 활성화)
    /// </summary>
    //private const string REQUEST_PAYMENT_WECHAT_URL = "http://devapi.paybox.store/Payment/Request/OAuth/{0}"; //개발 서비스 환경
    //private const string REQUEST_PAYMENT_WECHAT_URL = "https://api.paybox.store/Payment/Request/OAuth/{0}"; //운영 서비스 환경

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnPayBox_Click(object sender, EventArgs e)
    {
        RequestPayment RequestPayment = new RequestPayment();
        RequestPayment.PartnerAPIId = PARTNER_API_ID;
        RequestPayment.PartnerAPIKey = PARTNER_API_KEY;
        RequestPayment.PaymentType = Convert.ToInt32(Payment_Type.Text.Trim());
        RequestPayment.PgCode = PGCode.Text.Trim();
        RequestPayment.OrderNo = OrderNo.Text.Trim();
        RequestPayment.TransAmount = Convert.ToDouble(TransAmount.Text.Trim());
        RequestPayment.NotiUrl = NotiUrl.Text.Trim();
        RequestPayment.ReturnUrl = ReturnUrl.Text.Trim();
        RequestPayment.CancelUrl = CancelUrl.Text.Trim();
        RequestPayment.OrderInfo = OrderInfo.Text.Trim();
        RequestPayment.Email = Email.Text.Trim();
        RequestPayment.AdditionalInfo = AdditionalInfo.Text.Trim();

        string errMsg = string.Empty;
        string encData = PayBoxModule.GetPaymentEncrypt(PAYMENT_ENCRYPT_URL, RequestPayment, out errMsg);

        StringBuilder sbHtml = new StringBuilder();
        if (!string.IsNullOrEmpty(errMsg))
        {
            sbHtml.Append("<script>alert('"+ errMsg + "'); self.close();</script>");
            Response.Write(sbHtml.ToString());

            return;
        }
        
        sbHtml.Append("<form id='payboxsubmit' name='payboxsubmit' action='" + string.Format(REQUEST_PAYMENT_URL, RequestPayment.PgCode) + "' method='GET'>");
        sbHtml.Append("<input type='hidden' name='param' value='" + encData + "'/>");
        sbHtml.Append("<script>document.forms['payboxsubmit'].submit();</script>");
        Response.Write(sbHtml.ToString());
    }
}

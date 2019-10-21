using System;

public partial class return_url : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string resultCode = Request.QueryString["resultCode"];
        string resultMessage = Request.QueryString["resultMessage"];
        string resultNMessage = Request.QueryString["resultNMessage"];
        string paymentType = Request.QueryString["paymentType"];
        string orderNo = Request.QueryString["orderNo"];
        
        string orderInfo = Request.QueryString["orderInfo"];
        string transAmount = Request.QueryString["transAmount"];
        string email = Request.QueryString["email"];
        string additionalInfo = Request.QueryString["additionalInfo"];


        if ("SUCCESS" == resultCode)
        {
            //결제 성공
            Response.Write("resultCode=" + resultCode + "<br/>");
            Response.Write("resultMessage=" + resultMessage + "<br/>");
            Response.Write("paymentType=" + paymentType + "<br/>");
            Response.Write("orderNo=" + orderNo + "<br/>");
            Response.Write("orderInfo=" + orderInfo + "<br/>");
            Response.Write("transAmount=" + transAmount + "<br/>");
            Response.Write("email=" + email + "<br/>");
            Response.Write("additionalInfo=" + additionalInfo + "<br/>");
        }
        else
        {
            //결제 실패
            Response.Write("resultCode=" + resultCode + "<br/>");
            Response.Write("resultMessage=" + resultMessage + "<br/>");
            Response.Write("resultNMessage=" + resultNMessage);
        }
    }
}

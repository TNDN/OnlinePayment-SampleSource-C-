using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// 결제 요청 모델
/// </summary>
public class RequestPayment
{
    private string partnerAPIId;
    public string PartnerAPIId
    {
        set { partnerAPIId = value; }
        get { return partnerAPIId; }
    }

    private string partnerAPIKey;
    public string PartnerAPIKey
    {
        set { partnerAPIKey = value; }
        get { return partnerAPIKey; }
    }

    private int paymentType;
    public int PaymentType
    {
        set { paymentType = value; }
        get { return paymentType; }
    }

    private string pgCode;
    public string PgCode
    {
        set { pgCode = value; }
        get { return pgCode; }
    }

    private string orderNo;
    public string OrderNo
    {
        set { orderNo = value; }
        get { return orderNo; }
    }

    private double transAmount;
    public double TransAmount
    {
        set { transAmount = value; }
        get { return transAmount; }
    }

    private string notiUrl;
    public string NotiUrl
    {
        set { notiUrl = value; }
        get { return notiUrl; }
    }

    private string returnUrl;
    public string ReturnUrl
    {
        set { returnUrl = value; }
        get { return returnUrl; }
    }

    private string cancelUrl;
    public string CancelUrl
    {
        set { cancelUrl = value; }
        get { return cancelUrl; }
    }

    private string orderInfo;
    public string OrderInfo
    {
        set { orderInfo = value; }
        get { return orderInfo; }
    }

    private string email;
    public string Email
    {
        set { email = value; }
        get { return email; }
    }

    private string additionalInfo;
    public string AdditionalInfo
    {
        set { additionalInfo = value; }
        get { return additionalInfo; }
    }
}

public class ErrorResult
{
    private Result error;
    public Result Error
    {
        set { error = value; }
        get { return error; }
    }

    private ErrorResult()
    {
        error = new Result();
    }
}

public class Result
{
    private int code;
    public int Code
    {
        set { code = value; }
        get { return code; }
    }

    private string message;
    public string Message
    {
        set { message = value; }
        get { return message; }
    }

    private string detail;
    public string Detail
    {
        set { detail = value; }
        get { return detail; }
    }
    public Result() { }
}

public class RequestPaymentResult
{
    private string data;
    public string Data
    {
        set { data = value; }
        get { return data; }
    }
}

public class PartnerNotification
{
    private string transactionId;
    public string TransactionId
    {
        set { transactionId = value; }
        get { return transactionId; }
    }
    private string transactionDateTime;
    public string TransactionDateTime
    {
        set { transactionDateTime = value; }
        get { return transactionDateTime; }
    }
    private string transactionCurrency;
    public string TransactionCurrency
    {
        set { transactionCurrency = value; }
        get { return transactionCurrency; }
    }
    private string transactionPGCode;
    public string TransactionPGCode
    {
        set { transactionPGCode = value; }
        get { return transactionPGCode; }
    }
    private string orderNo;
    public string OrderNo
    {
        set { orderNo = value; }
        get { return orderNo; }
    }
    private string orderInfo;
    public string OrderInfo
    {
        set { orderInfo = value; }
        get { return orderInfo; }
    }
    private double transAmount;
    public double TransAmount
    {
        set { transAmount = value; }
        get { return transAmount; }
    }
    private string email;
    public string Email
    {
        set { email = value; }
        get { return email; }
    }
    private string additionalInfo;
    public string AdditionalInfo
    {
        set { additionalInfo = value; }
        get { return additionalInfo; }
    }
    private string exchangeCurrecy;
    public string ExchangeCurrecy
    {
        set { exchangeCurrecy = value; }
        get { return exchangeCurrecy; }
    }
    private double exchangeRate;
    public double ExchangeRate
    {
        set { exchangeRate = value; }
        get { return exchangeRate; }
    }
    private double exchangeAmount;
    public double ExchangeAmount
    {
        set { exchangeAmount = value; }
        get { return exchangeAmount; }
    }
}
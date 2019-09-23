<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cancel.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TNDN</title>
    <link href="css/normalize.css" rel="stylesheet" />
    <link href="css/style-partners.css" rel="stylesheet" />
    <style>
        html, body {
            width: 100%;
            min-width: 1200px;
            height: auto;
            padding: 0;
            margin: 0;
            background-color: #fff;
        }

        .header {
            width: 100%;
            margin: 0 auto;
        }

        .container {
            width: 100%;
            min-width: 100px;
            height: auto;
        }

        .black {
            background-color: #242736;
        }

        .blue {
            background-color: #0ae;
        }

        .qrcode {
            width: 1200px;
            margin: 0 auto;
            height: 30px;
            background-color: #242736;
        }

        .littlecode {
            width: 16px;
            height: 16px;
            margin-top: 6px;
            cursor: pointer;
            float: right;
        }

        .showqrs {
            top: 30px;
            position: absolute;
            width: 100px;
            margin-left: -65px;
            height: 160px;
            display: none;
        }

        .shtoparrow {
            width: 0;
            height: 0;
            margin-left: 65px;
            border-left: 8px solid transparent;
            border-right: 8px solid transparent;
            border-bottom: 8px solid #e7e8eb;
            margin-bottom: 0;
            font-size: 0;
            line-height: 0;
        }

        .guanzhuqr {
            text-align: center;
            background-color: #e7e8eb;
            border: 1px solid #e7e8eb;
        }

            .guanzhuqr img {
                margin-top: 10px;
                width: 80px;
            }

        .shmsg {
            margin-left: 10px;
            width: 80px;
            height: 16px;
            line-height: 16px;
            font-size: 12px;
            color: #242323;
            text-align: center;
        }

        .nav {
            width: 1200px;
            margin: 0 auto;
            height: 70px;
        }

        .open, .logo {
            display: block;
            float: left;
            height: 40px;
            width: 60px;
            margin-top: 20px;
        }

        .divier {
            display: block;
            float: left;
            margin-left: 20px;
            margin-right: 20px;
            margin-top: 23px;
            width: 1px;
            height: 24px;
            background-color: #d3d3d3;
        }

        .open {
            line-height: 30px;
            font-size: 20px;
            text-decoration: none;
            color: #1a1a1a;
        }

        .navbar {
            float: right;
            width: 200px;
            height: 40px;
            margin-top: 15px;
            list-style: none;
        }

            .navbar li {
                float: left;
                width: 100px;
                height: 40px;
            }

                .navbar li a {
                    display: inline-block;
                    width: 100px;
                    height: 40px;
                    line-height: 40px;
                    font-size: 16px;
                    color: #1a1a1a;
                    text-decoration: none;
                }

                    .navbar li a:hover {
                        color: #0ae;
                    }

        .title {
            width: 1200px;
            margin: 0 auto;
            height: 80px;
            line-height: 65px;
            font-size: 20px;
            color: #FFF;
        }

        .content {
            width: 100%;
            min-width: 1200px;
            height: 550px;
        }

        .payform {
            width: 800px;
            margin: 0 auto;
            height: 550px;
            border: 1px solid #0ae;
            margin-top: 50px;
        }

        .element {
            width: 600px;
            height: 100px;
            margin-left: 100px;
            font-size: 20px;
        }

        .etitle, .einput {
            float: left;
            height: 26px;
        }

        .etitle {
            width: 150px;
            line-height: 26px;
            text-align: right;
        }

        .einput {
            width: 200px;
            margin-left: 20px;
        }

            .einput input {
                width: 398px;
                height: 24px;
                border: 1px solid #0ae;
                font-size: 16px;
            }

        .mark {
            margin-top: 10px;
            width: 500px;
            height: 30px;
            margin-left: 80px;
            line-height: 30px;
            font-size: 12px;
            color: #999;
        }

        .legend {
            margin-left: 100px;
            font-size: 24px;
        }

        .payCancelsubmit {
            width: 400px;
            height: 40px;
            border: 0;
            background-color: #0ae;
            font-size: 16px;
            color: #FFF;
            cursor: pointer;
            margin-left: 170px;
        }
    </style>
</head>
<body>
    <div class="header">
        <div class="container" style="background-color:#fafbfc">
            <div class="nav">
                <a href="http://www.tndn.co.kr" target="_blank" class="logo">
                    <img src="img/favicon-96x96.png" height="30px"></a>
                <div class="title"> <font color="black">PayBox 결제 연동 샘플</font></div>
            </div>
        </div>
    </div>

    <div id="tndnPartners" class="height-wrap" style="padding : 0px;">
    <div class="section">
        <form class="payform" target="_blank" runat="server">
            <div class="element" style="margin-top: 60px;">
                <div class="legend">PayBox 결제 취소</div>
            </div>

            <div class="element">
                <div class="etitle">cancelType :</div>
                <div class="einput">
                    <asp:TextBox ID="Cancel_Type" name="Cancel_Type" value="1" runat="server"></asp:TextBox>
                </div>

                <br>
                <div class="mark">취소유형(1:전체취소,2:부분취소)</div>
            </div>

            <div class="element">
                <div class="etitle">transactionId :</div>
                <div class="einput">
                    <asp:TextBox ID="TransactionId" name="TransactionId" value="WECHAT" runat="server"></asp:TextBox>
                </div>

                <br>
                <div class="mark">거래번호</div>
            </div>

            <div class="element">
                <div class="etitle">transAmount :</div>
                <div class="einput">
                    <asp:TextBox ID="TransAmount" name="TransAmount" runat="server"></asp:TextBox>
                </div>

                <br>
                <div class="mark">거래금액</div>
            </div>

            <div class="element">
                <asp:Button ID="BtnPayBoxCancel" name="BtnPayBoxCancel" class="payCancelsubmit" Text="Pay" Style="text-align: center;"
                    runat="server" OnClick="BtnPayBoxCancel_Click" />
            </div>
        </form>
    </div>
    </div>

    <!-- 푸터 -->
    <footer>
        <div class="footer-wrap">
            <h3><img src="img/logo_tndn_light.svg" alt="티엔디엔 로고"></h3>
            <ul class="footer-link clearfix">
                <li><a href="http://www.tndn.co.kr/policy/service">서비스 이용약관</a></li>
                <li><a href="http://www.tndn.co.kr/policy/electronicFinancialTransaction">전자금융거래 이용약관</a></li>
                <li><a href="http://www.tndn.co.kr/policy/personalInfomation">개인정보 처리방침</a></li>
            </ul>
            <div class="footer-info">
                <ul class="clearfix">
                    <li>(주)티엔디엔</li>
                    <li>제주: 제주특별자치도 제주시 중앙로 217, 607호</li>
                    <li>서울: 서울특별시 강남구 봉은사로81길 15, 3층 티엔디엔</li>
                </ul>
                <ul class="clearfix">
                    <li>대표이사: 손위준</li>
                    <li>사업자번호: 222-86-00211</li>
                    <li>전자금융업: 02-004-00124</li>
                    <li>외국환업무: 2018-36</li>
                </ul>
                <p>&copy;TNDN, Inc.</p>
            </div>
        </div>
    </footer>
    <!-- //푸터 -->
</body>
</html>

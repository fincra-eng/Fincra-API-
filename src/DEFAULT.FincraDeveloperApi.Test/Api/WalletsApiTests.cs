/* 
 * Fincra Developer Api
 *
 * * * *  Our API reference will introduce you to all the basic information you need to better understand and integrate with our products.  With our API you can access endpoints that enable you to perform actions such as payouts, currency conversion, creating and maintaining a virtual account for your self/customers, depending on your scope.  In summary, our API gives you access to pretty much all and more features you can use on our dashboard and lets you extend them for use in your application.  ### APIs available are:  *   **Virtual Account**: Create a USD,EUR, GBP & NGN bank account/IBAN and receive payments in a country’s local currency from any part of the world. *   **Sub-Account**: Create and manage accounts for your customers. *   **Beneficiaries**: Manage frequent recipients. *   **Quote**: Get real-time rates for payouts to all supported currencies. *   **Conversion**: Allows you to convert from one currency to another. *   **Payout**: Make seamless cross-currency and single-currency payouts through our API. *   **Transactions**: Manage all transactionntransactionss *   **Wallets**: Manage multi-currency wallet balances.       Whether you’re a financial institution, a fintech, or a global business, you can integrate our APIs into your existing platform .  * * *  # Environment URLS  The Fincra API is available in both Production as well as Sandbox environment. Please find the corresponding URLs below  ##### Sandbox  {{host}} : [https://sandboxapi.fincra.com](https://sandboxapi.fincra.com)  * * *  # Authentication  Fincra authenticates your API requests using your account’s API key. If you do not include your key when making an API request or use one that is incorrect, Fincra will return an error.  ##### Obtaining your API Keys:  Your API key is available on your dashboard. On the web application, navigate to `Settings -> API keys` to view and copy your API key.  ##### Authenticating Requests:  To hit our endpoints, you'll need to add to your header, `-H \"`**`api-key`**`: your_api_key\"`.  ##### Obtaining Business ID:  You would find that a lot of the endpoint requires the ID of your business. To get the business ID, click <a href=\"https://documenter.getpostman.com/view/10721039/Tz5m7zMw#173cf362-e111-458f-86ee-801489eaef8d\">here</a> or send a GET request to this endpoint \"{{host}}/profile/business/me\"  The endpoint returns a business object and the ID of the object is your business ID.  * * *  # Versioning  When backward-incompatible changes are made to the API, a new, dated version is released. Minor updates and bug fixes are occasionally released without incrementing the version number  It is important to note that we are continually improving and adding new features to improve our services.  * * *  # Deprecation policy  API deprecation is used to inform you that some APIs are no longer recommended for use in your applications. The Fincra team is trying to keep the API as stable as possible, but sometimes APIs must be deprecated due to, for example, critical security issues, or new and better alternatives.  Based on a careful analysis, the following deprecation policy has been adopted in Fincra:  *   The functionality of the deprecated API is available for 2 releases and are therefore only removed after 2 releases. *   During the 2 version releases, the functionality of the deprecated API may also be removed immediately for security reasons or as an unavoidable part of the platform evolution. *   Alternatives must be described within the reference of the deprecated API, if possible. *   All version changes are considered 1 release for purposes of the deprecation policy.       * * *  # API rate limiting  To make our APIs more scalable we have integrated rate limiting on each of our APIs. The frequency in http requests allowed on our APIs is 100 requests over any 1-minute interval.  * * *  # Webhook  We use webhooks to provide you the ability to receive real-time notifications when an event happens on your account. These events could range from a successful transaction to a failed transaction.  Examples of events that you could be notified on include:  *   When you receive a settlement transaction. *   When you performed a successful payout transaction.       You could use webhooks to  *   Update your database when the status of a pending payment is updated to successful. *   Email a customer when payment is successful or fails.       In order to receive these notifications, you need the following:  *   An endpoint on your server that will be called by us to send you notifications *   Webhook enabled on your Fincra dashboard.       ### How to enable webhooks on your dashboard  To enable webhook, kindly follow the steps below:  *   Log into your Fincra dashboard. *   Click on settings icon on the left to access the Settings page. *   Click **API key & Webhook** tab of the **Settings** page. *   Paste the url of your server endpoint in the appropriate callback URL field, save and you are good to go.       ### Sample Webhook Response Data  The data sent to the webhook url differs depending on the type of transaction carried out and the type of transactions available include Payout, Settlement, Collection and Conversion.  Kindly find below sample webhook responses:  **Response for successful virtual account approval**  ``` json {   \"event\": \"virtualaccount.approved\",   \"data\": {     \"id\": \"61769013cff5311964f3f6cf\",     \"business\": \"61768caacff5315c34f3f6a3\",     \"isSubAccount\": true,     \"currency\": \"GBP\",     \"currencyType\": \"fiat\",     \"status\": \"approved\",     \"accountType\": \"individual\",     \"accountInformation\": {       \"accountNumber\": \"GBXXCLJU04130780008933\",       \"bankName\": null,       \"bankCode\": \"CLJU\",       \"countryCode\": \"GB\",       \"otherInfo\": {         \"iban\": \"GBXXCLJU04130780008933\",         \"accountNumber\": \"80008933\",         \"checkNumber\": \"XX\",         \"sortCode\": \"041307\",         \"bankSwiftCode\": null       }     },     \"accountOpeningFee\": 0,     \"isPermanent\": true,     \"createdAt\": \"2021-10-25T11:08:03.442Z\",     \"updatedAt\": \"2021-10-25T11:21:32.861Z\"   } }  ```  **Response for declined virtual account**  ``` json {   {   \"event\": \"virtualaccount.declined\",   \"data\": {     \"id\": \"6176a0cfcff53106ebf3f77e\",     \"business\": \"61768caacff5315c34f3f6a3\",     \"isSubAccount\": true,     \"currency\": \"EUR\",     \"currencyType\": \"fiat\",     \"status\": \"declined\",     \"accountType\": \"individual\",     \"reason\": \"declined for compliance reason\",     \"accountOpeningFee\": 0,     \"createdAt\": \"2021-10-25T12:19:27.278Z\",     \"updatedAt\": \"2021-10-25T12:20:17.356Z\"   } } }  ```  **Response for successful payout**  ``` json {    \"event\":\"payout.successful\",    \"data\": {       \"amountCharged\": 200000,       \"amountReceived\": 1500       \"fees\": 15,       \"sourceCurrency\": \"NGN\",       \"destinationCurrency\": \"GHS\",       \"recipient\":  {         \"name\": \"Hassan Sarz\",         \"accountNumber\": \"0124775489\",         \"type\": \"individual\",         \"email\": \"aa@aa.com\",       },       \"paymentScheme\": null,       \"paymentDestination\": \"bank_account\",       \"rate\": 85       \"status\": \"successful\",       \"createdAt\": \"2021-03-02T17:00:31.742Z\",       \"updatedAt\":\"2021-03-02T17:00:31.742Z\",       \"reference\": \"7303c7fb-a487-4abb-9e80-a5be8722639a\"     } }  ```  **Response for failed payout**  ``` json {    \"event\":\"payout.failed\",    \"data\": {       \"amountCharged\": 200000,       \"amountReceived\": 1500       \"fees\": 15,       \"sourceCurrency\": \"NGN\",       \"destinationCurrency\": \"GHS\",       \"recipient\":  {         \"name\": \"Hassan Sarz\",         \"accountNumber\": \"0124775489\",         \"type\": \"individual\",         \"email\": \"aa@aa.com\",       },       \"paymentScheme\": null,       \"paymentDestination\": \"bank_account\",       \"rate\": 85       \"status\": \"failed\",       \"message\": \"A reason for the failure\"       \"createdAt\": \"2021-03-02T17:00:31.742Z\",       \"updatedAt\":\"2021-03-02T17:00:31.742Z\",       \"reference\": \"7303c7fb-a487-4abb-9e80-a5be8722639a\"     } }  ```  **Response for failed conversion**  ``` json {    \"event\":\"conversion.failed\",    \"data\": {       \"amountCharged\": 200000,       \"amountReceived\": 1500       \"fees\": 15,       \"sourceCurrency\": \"USD\",       \"destinationCurrency\": \"NGN\",       \"rate\": 85       \"settlement\": 5262gs767h828       \"status\": \"failed\",       \"createdAt\": \"2021-03-02T17:00:31.742Z\",       \"updatedAt\":\"2021-03-02T17:00:31.742Z\",       \"reference\": \"7303c7fb-a487-4abb-9e80-a5be8722639a\"     } }  ```  **Response for successful settlement**  ``` json {    \"event\":\"settlement.successful\",    \"data\": {       \"amount\": 15000000       \"sourceCurrency\": \"USD\",       \"destinationCurrency\": \"NGN\",       \"recipient\":  {         \"name\": \"Hassan Sarz\",         \"accountNumber\": \"0124775489\",         \"type\": \"individual\",         \"email\": \"aa@aa.com\",       },       \"settlementDestination\": \"bank_account\",       \"settlementTime\": \"T+2\"       \"rate\": 480       \"status\": \"successful\",       \"transactionType\": \"collection\"       \"transaction\": \"123rde2e3243\"       \"createdAt\": \"2021-03-02T17:00:31.742Z\",       \"updatedAt\":\"2021-03-02T17:00:31.742Z\",       \"settlementDate\": \"2021-03-02T17:00:31.742Z\",       \"settledAt\": \"2021-03-02T17:00:31.742Z\"       \"reference\": \"7303c7fb-a487-4abb-9e80-a5be8722639a\"       \"business\": 782y87e72982     } }  ```  **Response for successful collection**  ``` json {   \"event\": \"collection.successful\",   \"data\": {     \"business\": \"6065958518d58020f20b71f3\",     \"_id\": \"609853394ea00b5246086de4\",     \"sourceCurrency\": \"GBP\",     \"destinationCurrency\": \"GBP\",     \"sourceAmount\": 210.55,     \"destinationAmount\": 210.55,     \"fee\": 0,     \"customerName\": \"Alan ross\",     \"settlementDestination\": \"fincra_wallet\",     \"status\": \"successful\",     \"initiatedAt\": \"2017-09-05T10:37:15.000Z\",     \"createdAt\": \"2021-05-09T21:25:13.393Z\",     \"updatedAt\": \"2021-05-09T22:06:29.201Z\",     \"reference\": \"4cbf9122-d272-47fa-8f09-39e538f6ed35\"   } }  ```  N.B: You should expect a POST request from us when we send you a webhook.  * * *  # Supported Currencies  We will breakdown the supported currencies into the transaction type(conversion, collection, disbursement) we support. They are:  **Conversion:** The supported currencies for conversions can be broken down into:  **Supported conversion source currency**  | S/N | Currency Name | Currency Code | | --- | --- | --- | | 1 | United State Dollar | USD | | 2 | Euro | EUR | | 3 | Nigerian Naira | NGN | | 4 | British Pound | GBP |  **Supported conversion destination currency**  | S/N | Currency Name | Currency Code | | --- | --- | --- | | 1 | United State Dollar | USD | | 2 | Euro | EUR | | 3 | Nigerian Naira | NGN | | 4 | British Pound | GBP |  Therefore this is the breakdown of the currency pairs we support  ``` json {     \"currencyPairs\": [         \"USD-NGN\",         \"GBP-NGN\",         \"EUR-NGN\",         \"EUR-USD\",         \"GBP-USD\",         \"GBP-EUR\",     ] }  ```  **Disbursement:** The supported currencies for disbursements(payouts) can be broken down into:  **Supported disbursement source currency**  | S/N | Currency Name | Currency Code | Payment Scheme(s) | | --- | --- | --- | --- | | 1 | United State Dollar | USD | SWIFT `Required` | | 2 | Euro | EUR | SEPA,SEPA_instant,SWIFT `Required` | | 3 | Nigerian Naira | NGN |  | | 4 | British Pound | GBP | FPS,CHAPS,SWIFT `Required` |  **Note** : If destination currency is either USD,EUR,GBP a payment scheme is required  **Supported disbursement destination currency**  | S/N | Currency Name | Currency Code | | --- | --- | --- | | 1 | United State Dollar | USD | | 2 | Euro | EUR | | 3 | Nigerian Naira | NGN | | 4 | British Pound | GBP |
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Api;

namespace DEFAULT.FincraDeveloperApi.Test
{
    /// <summary>
    ///  Class for testing WalletsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class WalletsApiTests
    {
        private WalletsApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new WalletsApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of WalletsApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            Assert.IsInstanceOf<WalletsApi> (instance, "instance is a WalletsApi");
        }

        
        /// <summary>
        /// Test GetallthewalletsforaBusiness
        /// </summary>
        [Test]
        public void GetallthewalletsforaBusinessTest()
        {
            // TODO: add unit test for the method 'GetallthewalletsforaBusiness'
            string businessID = null; // TODO: replace null with proper value
            instance.GetallthewalletsforaBusiness(businessID);
            
        }
        
        /// <summary>
        /// Test Getawallet
        /// </summary>
        [Test]
        public void GetawalletTest()
        {
            // TODO: add unit test for the method 'Getawallet'
            string walletID = null; // TODO: replace null with proper value
            instance.Getawallet(walletID);
            
        }
        
    }

}

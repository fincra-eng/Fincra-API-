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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using DEFAULT.FincraDeveloperApi.Client;

namespace DEFAULT.FincraDeveloperApi.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICoreApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get Bank code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns></returns>
        void GetBankcode (string currency);

        /// <summary>
        /// Get Bank code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetBankcodeWithHttpInfo (string currency);
        /// <summary>
        /// Get a disbursement transaction by customer reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns></returns>
        void Getadisbursementtransactionbycustomerreference (string business, string customerReference);

        /// <summary>
        /// Get a disbursement transaction by customer reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetadisbursementtransactionbycustomerreferenceWithHttpInfo (string business, string customerReference);
        /// <summary>
        /// Get a disbursement transaction by reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns></returns>
        void Getadisbursementtransactionbyreference (string business, string reference);

        /// <summary>
        /// Get a disbursement transaction by reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetadisbursementtransactionbyreferenceWithHttpInfo (string business, string reference);
        /// <summary>
        /// Get a transaction for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a transaction through the use of its ID.        
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns></returns>
        void Getatransactionforabusiness (string transactionID);

        /// <summary>
        /// Get a transaction for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a transaction through the use of its ID.        
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetatransactionforabusinessWithHttpInfo (string transactionID);
        /// <summary>
        /// Get branch Code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns></returns>
        void GetbranchCode (string bankId);

        /// <summary>
        /// Get branch Code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetbranchCodeWithHttpInfo (string bankId);
        /// <summary>
        /// Get the transactions for a Business
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns></returns>
        void GetthetransactionsforaBusiness (string businessID);

        /// <summary>
        /// Get the transactions for a Business
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetthetransactionsforaBusinessWithHttpInfo (string businessID);
        /// <summary>
        /// Get the transactions for the sub-accounts of a Business
        /// </summary>
        /// <remarks>
        /// This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns></returns>
        void GetthetransactionsforthesubAccountsofabusiness (string businessID);

        /// <summary>
        /// Get the transactions for the sub-accounts of a Business
        /// </summary>
        /// <remarks>
        /// This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetthetransactionsforthesubAccountsofabusinessWithHttpInfo (string businessID);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get Bank code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetBankcodeAsync (string currency);

        /// <summary>
        /// Get Bank code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetBankcodeAsyncWithHttpInfo (string currency);
        /// <summary>
        /// Get a disbursement transaction by customer reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetadisbursementtransactionbycustomerreferenceAsync (string business, string customerReference);

        /// <summary>
        /// Get a disbursement transaction by customer reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetadisbursementtransactionbycustomerreferenceAsyncWithHttpInfo (string business, string customerReference);
        /// <summary>
        /// Get a disbursement transaction by reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetadisbursementtransactionbyreferenceAsync (string business, string reference);

        /// <summary>
        /// Get a disbursement transaction by reference
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetadisbursementtransactionbyreferenceAsyncWithHttpInfo (string business, string reference);
        /// <summary>
        /// Get a transaction for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a transaction through the use of its ID.        
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetatransactionforabusinessAsync (string transactionID);

        /// <summary>
        /// Get a transaction for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the details of a transaction through the use of its ID.        
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetatransactionforabusinessAsyncWithHttpInfo (string transactionID);
        /// <summary>
        /// Get branch Code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetbranchCodeAsync (string bankId);

        /// <summary>
        /// Get branch Code
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetbranchCodeAsyncWithHttpInfo (string bankId);
        /// <summary>
        /// Get the transactions for a Business
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetthetransactionsforaBusinessAsync (string businessID);

        /// <summary>
        /// Get the transactions for a Business
        /// </summary>
        /// <remarks>
        /// This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetthetransactionsforaBusinessAsyncWithHttpInfo (string businessID);
        /// <summary>
        /// Get the transactions for the sub-accounts of a Business
        /// </summary>
        /// <remarks>
        /// This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetthetransactionsforthesubAccountsofabusinessAsync (string businessID);

        /// <summary>
        /// Get the transactions for the sub-accounts of a Business
        /// </summary>
        /// <remarks>
        /// This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetthetransactionsforthesubAccountsofabusinessAsyncWithHttpInfo (string businessID);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CoreApi : ICoreApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CoreApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CoreApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get Bank code This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns></returns>
        public void GetBankcode (string currency)
        {
             GetBankcodeWithHttpInfo(currency);
        }

        /// <summary>
        /// Get Bank code This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetBankcodeWithHttpInfo (string currency)
        {
            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling CoreApi->GetBankcode");

            var localVarPath = "/core/banks";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (currency != null) localVarQueryParams.Add("currency", Configuration.ApiClient.ParameterToString(currency)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetBankcode: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetBankcode: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get Bank code This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetBankcodeAsync (string currency)
        {
             await GetBankcodeAsyncWithHttpInfo(currency);

        }

        /// <summary>
        /// Get Bank code This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   &#x60;&#x60;&#x60;json {  {    \&quot;id\&quot;: 147,    \&quot;code\&quot;: \&quot;GH010100\&quot;,    \&quot;name\&quot;: \&quot;BANK OF GHANA\&quot;,    \&quot;isMobileVerified\&quot;: null,    \&quot;branches\&quot;: [       {         \&quot;id\&quot;: 1,         \&quot;branchCode\&quot;: \&quot;GH010101\&quot;,         \&quot;branchName\&quot;: \&quot;BANK OF GHANA-ACCRA\&quot;,         \&quot;swiftCode\&quot;: \&quot;BAGHGHAC\&quot;,         \&quot;bic\&quot;: \&quot;BAGHGHAC\&quot;        }]  },  {   \&quot;id\&quot;: 79,   \&quot;code\&quot;: \&quot;AIRTEL\&quot;,   \&quot;name\&quot;: \&quot;Airtel\&quot;,   \&quot;isMobileVerified\&quot;: true,   \&quot;branches\&quot;: null  } } &#x60;&#x60;&#x60;    
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="currency">e.g NGN, GHS, KES</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetBankcodeAsyncWithHttpInfo (string currency)
        {
            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling CoreApi->GetBankcode");

            var localVarPath = "/core/banks";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (currency != null) localVarQueryParams.Add("currency", Configuration.ApiClient.ParameterToString(currency)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetBankcode: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetBankcode: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a disbursement transaction by customer reference This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns></returns>
        public void Getadisbursementtransactionbycustomerreference (string business, string customerReference)
        {
             GetadisbursementtransactionbycustomerreferenceWithHttpInfo(business, customerReference);
        }

        /// <summary>
        /// Get a disbursement transaction by customer reference This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetadisbursementtransactionbycustomerreferenceWithHttpInfo (string business, string customerReference)
        {
            // verify the required parameter 'business' is set
            if (business == null)
                throw new ApiException(400, "Missing required parameter 'business' when calling CoreApi->Getadisbursementtransactionbycustomerreference");
            // verify the required parameter 'customerReference' is set
            if (customerReference == null)
                throw new ApiException(400, "Missing required parameter 'customerReference' when calling CoreApi->Getadisbursementtransactionbycustomerreference");

            var localVarPath = "/core/transactions/disbursements/by-customer-reference";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (business != null) localVarQueryParams.Add("business", Configuration.ApiClient.ParameterToString(business)); // query parameter
            if (customerReference != null) localVarQueryParams.Add("customerReference", Configuration.ApiClient.ParameterToString(customerReference)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbycustomerreference: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbycustomerreference: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a disbursement transaction by customer reference This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetadisbursementtransactionbycustomerreferenceAsync (string business, string customerReference)
        {
             await GetadisbursementtransactionbycustomerreferenceAsyncWithHttpInfo(business, customerReference);

        }

        /// <summary>
        /// Get a disbursement transaction by customer reference This endpoint provides the details of a disbursement transaction through the use of a customer reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of the business</param>
        /// <param name="customerReference">The reference of the customer/merchant</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetadisbursementtransactionbycustomerreferenceAsyncWithHttpInfo (string business, string customerReference)
        {
            // verify the required parameter 'business' is set
            if (business == null)
                throw new ApiException(400, "Missing required parameter 'business' when calling CoreApi->Getadisbursementtransactionbycustomerreference");
            // verify the required parameter 'customerReference' is set
            if (customerReference == null)
                throw new ApiException(400, "Missing required parameter 'customerReference' when calling CoreApi->Getadisbursementtransactionbycustomerreference");

            var localVarPath = "/core/transactions/disbursements/by-customer-reference";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (business != null) localVarQueryParams.Add("business", Configuration.ApiClient.ParameterToString(business)); // query parameter
            if (customerReference != null) localVarQueryParams.Add("customerReference", Configuration.ApiClient.ParameterToString(customerReference)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbycustomerreference: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbycustomerreference: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a disbursement transaction by reference This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns></returns>
        public void Getadisbursementtransactionbyreference (string business, string reference)
        {
             GetadisbursementtransactionbyreferenceWithHttpInfo(business, reference);
        }

        /// <summary>
        /// Get a disbursement transaction by reference This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetadisbursementtransactionbyreferenceWithHttpInfo (string business, string reference)
        {
            // verify the required parameter 'business' is set
            if (business == null)
                throw new ApiException(400, "Missing required parameter 'business' when calling CoreApi->Getadisbursementtransactionbyreference");
            // verify the required parameter 'reference' is set
            if (reference == null)
                throw new ApiException(400, "Missing required parameter 'reference' when calling CoreApi->Getadisbursementtransactionbyreference");

            var localVarPath = "/core/transactions/disbursements/by-reference";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (business != null) localVarQueryParams.Add("business", Configuration.ApiClient.ParameterToString(business)); // query parameter
            if (reference != null) localVarQueryParams.Add("reference", Configuration.ApiClient.ParameterToString(reference)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbyreference: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbyreference: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a disbursement transaction by reference This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetadisbursementtransactionbyreferenceAsync (string business, string reference)
        {
             await GetadisbursementtransactionbyreferenceAsyncWithHttpInfo(business, reference);

        }

        /// <summary>
        /// Get a disbursement transaction by reference This endpoint provides the details of a disbursement transaction through the use of its reference.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="business">The ID of business</param>
        /// <param name="reference">The reference of the transaction</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetadisbursementtransactionbyreferenceAsyncWithHttpInfo (string business, string reference)
        {
            // verify the required parameter 'business' is set
            if (business == null)
                throw new ApiException(400, "Missing required parameter 'business' when calling CoreApi->Getadisbursementtransactionbyreference");
            // verify the required parameter 'reference' is set
            if (reference == null)
                throw new ApiException(400, "Missing required parameter 'reference' when calling CoreApi->Getadisbursementtransactionbyreference");

            var localVarPath = "/core/transactions/disbursements/by-reference";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (business != null) localVarQueryParams.Add("business", Configuration.ApiClient.ParameterToString(business)); // query parameter
            if (reference != null) localVarQueryParams.Add("reference", Configuration.ApiClient.ParameterToString(reference)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbyreference: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getadisbursementtransactionbyreference: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a transaction for a business This endpoint provides the details of a transaction through the use of its ID.        
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns></returns>
        public void Getatransactionforabusiness (string transactionID)
        {
             GetatransactionforabusinessWithHttpInfo(transactionID);
        }

        /// <summary>
        /// Get a transaction for a business This endpoint provides the details of a transaction through the use of its ID.        
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetatransactionforabusinessWithHttpInfo (string transactionID)
        {
            // verify the required parameter 'transactionID' is set
            if (transactionID == null)
                throw new ApiException(400, "Missing required parameter 'transactionID' when calling CoreApi->Getatransactionforabusiness");

            var localVarPath = "/core/transactions/{transactionID}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (transactionID != null) localVarPathParams.Add("transactionID", Configuration.ApiClient.ParameterToString(transactionID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getatransactionforabusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getatransactionforabusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a transaction for a business This endpoint provides the details of a transaction through the use of its ID.        
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetatransactionforabusinessAsync (string transactionID)
        {
             await GetatransactionforabusinessAsyncWithHttpInfo(transactionID);

        }

        /// <summary>
        /// Get a transaction for a business This endpoint provides the details of a transaction through the use of its ID.        
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="transactionID">The reference or ID of the transaction</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetatransactionforabusinessAsyncWithHttpInfo (string transactionID)
        {
            // verify the required parameter 'transactionID' is set
            if (transactionID == null)
                throw new ApiException(400, "Missing required parameter 'transactionID' when calling CoreApi->Getatransactionforabusiness");

            var localVarPath = "/core/transactions/{transactionID}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (transactionID != null) localVarPathParams.Add("transactionID", Configuration.ApiClient.ParameterToString(transactionID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getatransactionforabusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getatransactionforabusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get branch Code This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns></returns>
        public void GetbranchCode (string bankId)
        {
             GetbranchCodeWithHttpInfo(bankId);
        }

        /// <summary>
        /// Get branch Code This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetbranchCodeWithHttpInfo (string bankId)
        {
            // verify the required parameter 'bankId' is set
            if (bankId == null)
                throw new ApiException(400, "Missing required parameter 'bankId' when calling CoreApi->GetbranchCode");

            var localVarPath = "/core/banks/{bankId}/branches";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (bankId != null) localVarPathParams.Add("bankId", Configuration.ApiClient.ParameterToString(bankId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetbranchCode: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetbranchCode: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get branch Code This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetbranchCodeAsync (string bankId)
        {
             await GetbranchCodeAsyncWithHttpInfo(bankId);

        }

        /// <summary>
        /// Get branch Code This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bankId">Id of the bank</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetbranchCodeAsyncWithHttpInfo (string bankId)
        {
            // verify the required parameter 'bankId' is set
            if (bankId == null)
                throw new ApiException(400, "Missing required parameter 'bankId' when calling CoreApi->GetbranchCode");

            var localVarPath = "/core/banks/{bankId}/branches";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (bankId != null) localVarPathParams.Add("bankId", Configuration.ApiClient.ParameterToString(bankId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetbranchCode: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetbranchCode: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get the transactions for a Business This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns></returns>
        public void GetthetransactionsforaBusiness (string businessID)
        {
             GetthetransactionsforaBusinessWithHttpInfo(businessID);
        }

        /// <summary>
        /// Get the transactions for a Business This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetthetransactionsforaBusinessWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling CoreApi->GetthetransactionsforaBusiness");

            var localVarPath = "/core/transactions/search/business/{businessID}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (businessID != null) localVarPathParams.Add("businessID", Configuration.ApiClient.ParameterToString(businessID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforaBusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforaBusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get the transactions for a Business This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetthetransactionsforaBusinessAsync (string businessID)
        {
             await GetthetransactionsforaBusinessAsyncWithHttpInfo(businessID);

        }

        /// <summary>
        /// Get the transactions for a Business This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetthetransactionsforaBusinessAsyncWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling CoreApi->GetthetransactionsforaBusiness");

            var localVarPath = "/core/transactions/search/business/{businessID}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (businessID != null) localVarPathParams.Add("businessID", Configuration.ApiClient.ParameterToString(businessID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforaBusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforaBusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get the transactions for the sub-accounts of a Business This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns></returns>
        public void GetthetransactionsforthesubAccountsofabusiness (string businessID)
        {
             GetthetransactionsforthesubAccountsofabusinessWithHttpInfo(businessID);
        }

        /// <summary>
        /// Get the transactions for the sub-accounts of a Business This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetthetransactionsforthesubAccountsofabusinessWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling CoreApi->GetthetransactionsforthesubAccountsofabusiness");

            var localVarPath = "/core/transactions/search/business/{businessID}/sub-accounts";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (businessID != null) localVarPathParams.Add("businessID", Configuration.ApiClient.ParameterToString(businessID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforthesubAccountsofabusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforthesubAccountsofabusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get the transactions for the sub-accounts of a Business This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetthetransactionsforthesubAccountsofabusinessAsync (string businessID)
        {
             await GetthetransactionsforthesubAccountsofabusinessAsyncWithHttpInfo(businessID);

        }

        /// <summary>
        /// Get the transactions for the sub-accounts of a Business This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \&quot;YYYY-mm-dd\&quot;  optional| | to | string| Specify end date with format \&quot;YYYY-mm-dd\&quot; optional|     
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">The is the ID of a business</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetthetransactionsforthesubAccountsofabusinessAsyncWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling CoreApi->GetthetransactionsforthesubAccountsofabusiness");

            var localVarPath = "/core/transactions/search/business/{businessID}/sub-accounts";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (businessID != null) localVarPathParams.Add("businessID", Configuration.ApiClient.ParameterToString(businessID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforthesubAccountsofabusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetthetransactionsforthesubAccountsofabusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

    }
}

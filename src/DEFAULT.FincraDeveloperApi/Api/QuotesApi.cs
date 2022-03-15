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
    public interface IQuotesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get a quote
        /// </summary>
        /// <remarks>
        /// This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void Getaquote ();

        /// <summary>
        /// Get a quote
        /// </summary>
        /// <remarks>
        /// This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetaquoteWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get a quote
        /// </summary>
        /// <remarks>
        /// This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetaquoteAsync ();

        /// <summary>
        /// Get a quote
        /// </summary>
        /// <remarks>
        /// This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetaquoteAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class QuotesApi : IQuotesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public QuotesApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public QuotesApi(Configuration configuration = null)
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
        /// Get a quote This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void Getaquote ()
        {
             GetaquoteWithHttpInfo();
        }

        /// <summary>
        /// Get a quote This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetaquoteWithHttpInfo ()
        {

            var localVarPath = "/quotes/generate";
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


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getaquote: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getaquote: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a quote This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetaquoteAsync ()
        {
             await GetaquoteAsyncWithHttpInfo();

        }

        /// <summary>
        /// Get a quote This endpoint is used for generating a quote.  REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | sourceCurrency | string | e.g _USD_ required| | destinationCurrency | string |  e.g _NGN_ required| | amount | string | required| | action | string | the values can be either \&quot;_send_\&quot; for conversions and disbursement or \&quot;_receive_\&quot; for collectionsrequired| | transactionType | string | the values here can be either _disbursement_ or _collection_ or _conversion_required | | business | string | This could be the ID of the business or the ID of a sub-account of the business required| | feeBearer | string | required  | | paymentDestination | string | See the note below | | paymentMethod | string | see the note below | | destinationCountry | string | This is the location where the money would be received required | | paymentScheme | string | This is the valid payment scheme for the destination currency you want to generate a quote for.Payment scheme is required for USD,EUR and GBP |  NOTE  If destination currency is either USD,EUR,GBP a payment scheme is required .  The values of the _paymentDestination_ and _paymentMethod_ are either required or optional depending on the value of the _transactiontype_ field.  When the value of the the _transactiontype_ field is _disbursement_, We will then have the below fields as: *   paymentDestination required *   paymentMethod optional   When the value of the the _transactiontype_ field is _conversion_, We will then have the below fields as: *   paymentDestination optional *   paymentMethod optional  When the value of the the _transactiontype_ field is _collection_, We will then have the below fields as: *   paymentDestination required *   paymentMethod required
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetaquoteAsyncWithHttpInfo ()
        {

            var localVarPath = "/quotes/generate";
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


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling Getaquote: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling Getaquote: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

    }
}

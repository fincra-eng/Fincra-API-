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
    public interface IProfileApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns></returns>
        void CreateSubaccount (string businessId);

        /// <summary>
        /// Create Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CreateSubaccountWithHttpInfo (string businessId);
        /// <summary>
        /// Create a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns></returns>
        void CreateaBeneficiary (string businessID);

        /// <summary>
        /// Create a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CreateaBeneficiaryWithHttpInfo (string businessID);
        /// <summary>
        /// Delete a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for deleting a beneficiary.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns></returns>
        void DeleteaBeneficiary (string businessID, string beneficiaryID);

        /// <summary>
        /// Delete a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for deleting a beneficiary.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteaBeneficiaryWithHttpInfo (string businessID, string beneficiaryID);
        /// <summary>
        /// Fetch Merchant Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void FetchMerchantVirtualAccounts ();

        /// <summary>
        /// Fetch Merchant Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> FetchMerchantVirtualAccountsWithHttpInfo ();
        /// <summary>
        /// Get  All Sub-accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used to retrieve all subaccounts for a business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns></returns>
        void GetAllSubAccounts (string businessId);

        /// <summary>
        /// Get  All Sub-accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used to retrieve all subaccounts for a business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetAllSubAccountsWithHttpInfo (string businessId);
        /// <summary>
        /// Get  One Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used in retrieving one subaccount.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns></returns>
        void GetOneSubaccount (string businessId, string subAccountId);

        /// <summary>
        /// Get  One Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used in retrieving one subaccount.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetOneSubaccountWithHttpInfo (string businessId, string subAccountId);
        /// <summary>
        /// Get One Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retreiving a virtual account attached to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns></returns>
        void GetOneVirtualAccount (string virtualAccountId);

        /// <summary>
        /// Get One Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retreiving a virtual account attached to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetOneVirtualAccountWithHttpInfo (string virtualAccountId);
        /// <summary>
        /// Get   Subaccount  Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns></returns>
        void GetSubaccountVirtualAccounts (string businessId);

        /// <summary>
        /// Get   Subaccount  Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetSubaccountVirtualAccountsWithHttpInfo (string businessId);
        /// <summary>
        /// Get Virtual Account Requests
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting all virtual account requests tied to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void GetVirtualAccountRequests ();

        /// <summary>
        /// Get Virtual Account Requests
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting all virtual account requests tied to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetVirtualAccountRequestsWithHttpInfo ();
        /// <summary>
        /// Get a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns></returns>
        void GetaBeneficiary (string businessID, string beneficiaryID);

        /// <summary>
        /// Get a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetaBeneficiaryWithHttpInfo (string businessID, string beneficiaryID);
        /// <summary>
        /// Get business Information
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void GetbusinessInformation ();

        /// <summary>
        /// Get business Information
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetbusinessInformationWithHttpInfo ();
        /// <summary>
        /// Get the Beneficiaries for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns></returns>
        void GettheBeneficiariesforabusiness (string businessID);

        /// <summary>
        /// Get the Beneficiaries for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GettheBeneficiariesforabusinessWithHttpInfo (string businessID);
        /// <summary>
        /// Request A Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void RequestAVirtualAccount ();

        /// <summary>
        /// Request A Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RequestAVirtualAccountWithHttpInfo ();
        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns></returns>
        void RequestAnEURvirtualAccountForASubaccount (string businessId, string subAccountId);

        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RequestAnEURvirtualAccountForASubaccountWithHttpInfo (string businessId, string subAccountId);
        /// <summary>
        /// Update A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns></returns>
        void UpdateASubaccount (string businessId, string subAccountId);

        /// <summary>
        /// Update A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateASubaccountWithHttpInfo (string businessId, string subAccountId);
        /// <summary>
        /// Update a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns></returns>
        void UpdateaBeneficiary (string businessID, string beneficiaryID);

        /// <summary>
        /// Update a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateaBeneficiaryWithHttpInfo (string businessID, string beneficiaryID);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Create Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CreateSubaccountAsync (string businessId);

        /// <summary>
        /// Create Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CreateSubaccountAsyncWithHttpInfo (string businessId);
        /// <summary>
        /// Create a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CreateaBeneficiaryAsync (string businessID);

        /// <summary>
        /// Create a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CreateaBeneficiaryAsyncWithHttpInfo (string businessID);
        /// <summary>
        /// Delete a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for deleting a beneficiary.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteaBeneficiaryAsync (string businessID, string beneficiaryID);

        /// <summary>
        /// Delete a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for deleting a beneficiary.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteaBeneficiaryAsyncWithHttpInfo (string businessID, string beneficiaryID);
        /// <summary>
        /// Fetch Merchant Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task FetchMerchantVirtualAccountsAsync ();

        /// <summary>
        /// Fetch Merchant Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> FetchMerchantVirtualAccountsAsyncWithHttpInfo ();
        /// <summary>
        /// Get  All Sub-accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used to retrieve all subaccounts for a business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetAllSubAccountsAsync (string businessId);

        /// <summary>
        /// Get  All Sub-accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used to retrieve all subaccounts for a business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetAllSubAccountsAsyncWithHttpInfo (string businessId);
        /// <summary>
        /// Get  One Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used in retrieving one subaccount.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetOneSubaccountAsync (string businessId, string subAccountId);

        /// <summary>
        /// Get  One Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used in retrieving one subaccount.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetOneSubaccountAsyncWithHttpInfo (string businessId, string subAccountId);
        /// <summary>
        /// Get One Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retreiving a virtual account attached to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetOneVirtualAccountAsync (string virtualAccountId);

        /// <summary>
        /// Get One Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retreiving a virtual account attached to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetOneVirtualAccountAsyncWithHttpInfo (string virtualAccountId);
        /// <summary>
        /// Get   Subaccount  Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetSubaccountVirtualAccountsAsync (string businessId);

        /// <summary>
        /// Get   Subaccount  Virtual Accounts
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetSubaccountVirtualAccountsAsyncWithHttpInfo (string businessId);
        /// <summary>
        /// Get Virtual Account Requests
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting all virtual account requests tied to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetVirtualAccountRequestsAsync ();

        /// <summary>
        /// Get Virtual Account Requests
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting all virtual account requests tied to a merchant
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetVirtualAccountRequestsAsyncWithHttpInfo ();
        /// <summary>
        /// Get a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetaBeneficiaryAsync (string businessID, string beneficiaryID);

        /// <summary>
        /// Get a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetaBeneficiaryAsyncWithHttpInfo (string businessID, string beneficiaryID);
        /// <summary>
        /// Get business Information
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetbusinessInformationAsync ();

        /// <summary>
        /// Get business Information
        /// </summary>
        /// <remarks>
        /// This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetbusinessInformationAsyncWithHttpInfo ();
        /// <summary>
        /// Get the Beneficiaries for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GettheBeneficiariesforabusinessAsync (string businessID);

        /// <summary>
        /// Get the Beneficiaries for a business
        /// </summary>
        /// <remarks>
        /// This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GettheBeneficiariesforabusinessAsyncWithHttpInfo (string businessID);
        /// <summary>
        /// Request A Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RequestAVirtualAccountAsync ();

        /// <summary>
        /// Request A Virtual Account
        /// </summary>
        /// <remarks>
        /// This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RequestAVirtualAccountAsyncWithHttpInfo ();
        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RequestAnEURvirtualAccountForASubaccountAsync (string businessId, string subAccountId);

        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RequestAnEURvirtualAccountForASubaccountAsyncWithHttpInfo (string businessId, string subAccountId);
        /// <summary>
        /// Update A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateASubaccountAsync (string businessId, string subAccountId);

        /// <summary>
        /// Update A Subaccount
        /// </summary>
        /// <remarks>
        /// This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateASubaccountAsyncWithHttpInfo (string businessId, string subAccountId);
        /// <summary>
        /// Update a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateaBeneficiaryAsync (string businessID, string beneficiaryID);

        /// <summary>
        /// Update a Beneficiary
        /// </summary>
        /// <remarks>
        /// This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </remarks>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateaBeneficiaryAsyncWithHttpInfo (string businessID, string beneficiaryID);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProfileApi : IProfileApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProfileApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ProfileApi(Configuration configuration = null)
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
        /// Create Subaccount This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns></returns>
        public void CreateSubaccount (string businessId)
        {
             CreateSubaccountWithHttpInfo(businessId);
        }

        /// <summary>
        /// Create Subaccount This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> CreateSubaccountWithHttpInfo (string businessId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->CreateSubaccount");

            var localVarPath = "/profile/business/{businessId}/sub-accounts";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling CreateSubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling CreateSubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Create Subaccount This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CreateSubaccountAsync (string businessId)
        {
             await CreateSubaccountAsyncWithHttpInfo(businessId);

        }

        /// <summary>
        /// Create Subaccount This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name| | email | string | Customer&#39;s email | | mobile | string | Customer&#39;s phone number | | country | string | Customer&#39;s country e.g NG  |  
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> CreateSubaccountAsyncWithHttpInfo (string businessId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->CreateSubaccount");

            var localVarPath = "/profile/business/{businessId}/sub-accounts";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling CreateSubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling CreateSubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Create a Beneficiary This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns></returns>
        public void CreateaBeneficiary (string businessID)
        {
             CreateaBeneficiaryWithHttpInfo(businessID);
        }

        /// <summary>
        /// Create a Beneficiary This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> CreateaBeneficiaryWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->CreateaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}";
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
                throw new ApiException (localVarStatusCode, "Error calling CreateaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling CreateaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Create a Beneficiary This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CreateaBeneficiaryAsync (string businessID)
        {
             await CreateaBeneficiaryAsyncWithHttpInfo(businessID);

        }

        /// <summary>
        /// Create a Beneficiary This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">businessID</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> CreateaBeneficiaryAsyncWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->CreateaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}";
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
                throw new ApiException (localVarStatusCode, "Error calling CreateaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling CreateaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete a Beneficiary This endpoint is used for deleting a beneficiary.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns></returns>
        public void DeleteaBeneficiary (string businessID, string beneficiaryID)
        {
             DeleteaBeneficiaryWithHttpInfo(businessID, beneficiaryID);
        }

        /// <summary>
        /// Delete a Beneficiary This endpoint is used for deleting a beneficiary.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeleteaBeneficiaryWithHttpInfo (string businessID, string beneficiaryID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->DeleteaBeneficiary");
            // verify the required parameter 'beneficiaryID' is set
            if (beneficiaryID == null)
                throw new ApiException(400, "Missing required parameter 'beneficiaryID' when calling ProfileApi->DeleteaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}/{beneficiaryID}";
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
            if (beneficiaryID != null) localVarPathParams.Add("beneficiaryID", Configuration.ApiClient.ParameterToString(beneficiaryID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeleteaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeleteaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Delete a Beneficiary This endpoint is used for deleting a beneficiary.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteaBeneficiaryAsync (string businessID, string beneficiaryID)
        {
             await DeleteaBeneficiaryAsyncWithHttpInfo(businessID, beneficiaryID);

        }

        /// <summary>
        /// Delete a Beneficiary This endpoint is used for deleting a beneficiary.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">This is the beneficiary ID of the the benficiary</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeleteaBeneficiaryAsyncWithHttpInfo (string businessID, string beneficiaryID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->DeleteaBeneficiary");
            // verify the required parameter 'beneficiaryID' is set
            if (beneficiaryID == null)
                throw new ApiException(400, "Missing required parameter 'beneficiaryID' when calling ProfileApi->DeleteaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}/{beneficiaryID}";
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
            if (beneficiaryID != null) localVarPathParams.Add("beneficiaryID", Configuration.ApiClient.ParameterToString(beneficiaryID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeleteaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeleteaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Fetch Merchant Virtual Accounts This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void FetchMerchantVirtualAccounts ()
        {
             FetchMerchantVirtualAccountsWithHttpInfo();
        }

        /// <summary>
        /// Fetch Merchant Virtual Accounts This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> FetchMerchantVirtualAccountsWithHttpInfo ()
        {

            var localVarPath = "/profile/virtual-accounts";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling FetchMerchantVirtualAccounts: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FetchMerchantVirtualAccounts: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Fetch Merchant Virtual Accounts This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task FetchMerchantVirtualAccountsAsync ()
        {
             await FetchMerchantVirtualAccountsAsyncWithHttpInfo();

        }

        /// <summary>
        /// Fetch Merchant Virtual Accounts This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> FetchMerchantVirtualAccountsAsyncWithHttpInfo ()
        {

            var localVarPath = "/profile/virtual-accounts";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling FetchMerchantVirtualAccounts: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FetchMerchantVirtualAccounts: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get  All Sub-accounts This endpoint is used to retrieve all subaccounts for a business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns></returns>
        public void GetAllSubAccounts (string businessId)
        {
             GetAllSubAccountsWithHttpInfo(businessId);
        }

        /// <summary>
        /// Get  All Sub-accounts This endpoint is used to retrieve all subaccounts for a business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetAllSubAccountsWithHttpInfo (string businessId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->GetAllSubAccounts");

            var localVarPath = "/profile/business/{businessId}/sub-accounts";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetAllSubAccounts: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetAllSubAccounts: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get  All Sub-accounts This endpoint is used to retrieve all subaccounts for a business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetAllSubAccountsAsync (string businessId)
        {
             await GetAllSubAccountsAsyncWithHttpInfo(businessId);

        }

        /// <summary>
        /// Get  All Sub-accounts This endpoint is used to retrieve all subaccounts for a business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetAllSubAccountsAsyncWithHttpInfo (string businessId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->GetAllSubAccounts");

            var localVarPath = "/profile/business/{businessId}/sub-accounts";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetAllSubAccounts: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetAllSubAccounts: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get  One Subaccount This endpoint is used in retrieving one subaccount.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns></returns>
        public void GetOneSubaccount (string businessId, string subAccountId)
        {
             GetOneSubaccountWithHttpInfo(businessId, subAccountId);
        }

        /// <summary>
        /// Get  One Subaccount This endpoint is used in retrieving one subaccount.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetOneSubaccountWithHttpInfo (string businessId, string subAccountId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->GetOneSubaccount");
            // verify the required parameter 'subAccountId' is set
            if (subAccountId == null)
                throw new ApiException(400, "Missing required parameter 'subAccountId' when calling ProfileApi->GetOneSubaccount");

            var localVarPath = "/profile/business/{businessId}/sub-accounts/{subAccountId}";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter
            if (subAccountId != null) localVarPathParams.Add("subAccountId", Configuration.ApiClient.ParameterToString(subAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetOneSubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetOneSubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get  One Subaccount This endpoint is used in retrieving one subaccount.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetOneSubaccountAsync (string businessId, string subAccountId)
        {
             await GetOneSubaccountAsyncWithHttpInfo(businessId, subAccountId);

        }

        /// <summary>
        /// Get  One Subaccount This endpoint is used in retrieving one subaccount.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetOneSubaccountAsyncWithHttpInfo (string businessId, string subAccountId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->GetOneSubaccount");
            // verify the required parameter 'subAccountId' is set
            if (subAccountId == null)
                throw new ApiException(400, "Missing required parameter 'subAccountId' when calling ProfileApi->GetOneSubaccount");

            var localVarPath = "/profile/business/{businessId}/sub-accounts/{subAccountId}";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter
            if (subAccountId != null) localVarPathParams.Add("subAccountId", Configuration.ApiClient.ParameterToString(subAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetOneSubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetOneSubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get One Virtual Account This endpoint is used for retreiving a virtual account attached to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns></returns>
        public void GetOneVirtualAccount (string virtualAccountId)
        {
             GetOneVirtualAccountWithHttpInfo(virtualAccountId);
        }

        /// <summary>
        /// Get One Virtual Account This endpoint is used for retreiving a virtual account attached to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetOneVirtualAccountWithHttpInfo (string virtualAccountId)
        {
            // verify the required parameter 'virtualAccountId' is set
            if (virtualAccountId == null)
                throw new ApiException(400, "Missing required parameter 'virtualAccountId' when calling ProfileApi->GetOneVirtualAccount");

            var localVarPath = "/profile/virtual-accounts/{virtualAccountId}";
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
            if (virtualAccountId != null) localVarPathParams.Add("virtualAccountId", Configuration.ApiClient.ParameterToString(virtualAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetOneVirtualAccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetOneVirtualAccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get One Virtual Account This endpoint is used for retreiving a virtual account attached to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetOneVirtualAccountAsync (string virtualAccountId)
        {
             await GetOneVirtualAccountAsyncWithHttpInfo(virtualAccountId);

        }

        /// <summary>
        /// Get One Virtual Account This endpoint is used for retreiving a virtual account attached to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="virtualAccountId">The Id of the virtual account you want to retrieve</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetOneVirtualAccountAsyncWithHttpInfo (string virtualAccountId)
        {
            // verify the required parameter 'virtualAccountId' is set
            if (virtualAccountId == null)
                throw new ApiException(400, "Missing required parameter 'virtualAccountId' when calling ProfileApi->GetOneVirtualAccount");

            var localVarPath = "/profile/virtual-accounts/{virtualAccountId}";
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
            if (virtualAccountId != null) localVarPathParams.Add("virtualAccountId", Configuration.ApiClient.ParameterToString(virtualAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetOneVirtualAccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetOneVirtualAccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get   Subaccount  Virtual Accounts This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns></returns>
        public void GetSubaccountVirtualAccounts (string businessId)
        {
             GetSubaccountVirtualAccountsWithHttpInfo(businessId);
        }

        /// <summary>
        /// Get   Subaccount  Virtual Accounts This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetSubaccountVirtualAccountsWithHttpInfo (string businessId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->GetSubaccountVirtualAccounts");

            var localVarPath = "/profile/virtual-accounts/business/{businessId}/sub-accounts";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetSubaccountVirtualAccounts: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetSubaccountVirtualAccounts: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get   Subaccount  Virtual Accounts This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetSubaccountVirtualAccountsAsync (string businessId)
        {
             await GetSubaccountVirtualAccountsAsyncWithHttpInfo(businessId);

        }

        /// <summary>
        /// Get   Subaccount  Virtual Accounts This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve &#x60;required&#x60; | | perPage | string | Specify how many records you want to retrieve per page &#x60;required&#x60; | | filterBy | object | see note below &#x60;optional&#x60; |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - &#x60;pending&#x60;, &#x60;approved&#x60; or &#x60;declined&#x60; *   currency - EUR or GBP *   accountType - corporate or individual
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetSubaccountVirtualAccountsAsyncWithHttpInfo (string businessId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->GetSubaccountVirtualAccounts");

            var localVarPath = "/profile/virtual-accounts/business/{businessId}/sub-accounts";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetSubaccountVirtualAccounts: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetSubaccountVirtualAccounts: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get Virtual Account Requests This endpoint is used for getting all virtual account requests tied to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void GetVirtualAccountRequests ()
        {
             GetVirtualAccountRequestsWithHttpInfo();
        }

        /// <summary>
        /// Get Virtual Account Requests This endpoint is used for getting all virtual account requests tied to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetVirtualAccountRequestsWithHttpInfo ()
        {

            var localVarPath = "/profile/virtual-accounts/requests";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetVirtualAccountRequests: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetVirtualAccountRequests: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get Virtual Account Requests This endpoint is used for getting all virtual account requests tied to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetVirtualAccountRequestsAsync ()
        {
             await GetVirtualAccountRequestsAsyncWithHttpInfo();

        }

        /// <summary>
        /// Get Virtual Account Requests This endpoint is used for getting all virtual account requests tied to a merchant
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetVirtualAccountRequestsAsyncWithHttpInfo ()
        {

            var localVarPath = "/profile/virtual-accounts/requests";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetVirtualAccountRequests: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetVirtualAccountRequests: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a Beneficiary This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns></returns>
        public void GetaBeneficiary (string businessID, string beneficiaryID)
        {
             GetaBeneficiaryWithHttpInfo(businessID, beneficiaryID);
        }

        /// <summary>
        /// Get a Beneficiary This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetaBeneficiaryWithHttpInfo (string businessID, string beneficiaryID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->GetaBeneficiary");
            // verify the required parameter 'beneficiaryID' is set
            if (beneficiaryID == null)
                throw new ApiException(400, "Missing required parameter 'beneficiaryID' when calling ProfileApi->GetaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}/{beneficiaryID}";
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
            if (beneficiaryID != null) localVarPathParams.Add("beneficiaryID", Configuration.ApiClient.ParameterToString(beneficiaryID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get a Beneficiary This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetaBeneficiaryAsync (string businessID, string beneficiaryID)
        {
             await GetaBeneficiaryAsyncWithHttpInfo(businessID, beneficiaryID);

        }

        /// <summary>
        /// Get a Beneficiary This endpoint is used for retrieving a single beneficiary attached to a business. 
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetaBeneficiaryAsyncWithHttpInfo (string businessID, string beneficiaryID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->GetaBeneficiary");
            // verify the required parameter 'beneficiaryID' is set
            if (beneficiaryID == null)
                throw new ApiException(400, "Missing required parameter 'beneficiaryID' when calling ProfileApi->GetaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}/{beneficiaryID}";
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
            if (beneficiaryID != null) localVarPathParams.Add("beneficiaryID", Configuration.ApiClient.ParameterToString(beneficiaryID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get business Information This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void GetbusinessInformation ()
        {
             GetbusinessInformationWithHttpInfo();
        }

        /// <summary>
        /// Get business Information This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GetbusinessInformationWithHttpInfo ()
        {

            var localVarPath = "/profile/business/me";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetbusinessInformation: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetbusinessInformation: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get business Information This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetbusinessInformationAsync ()
        {
             await GetbusinessInformationAsyncWithHttpInfo();

        }

        /// <summary>
        /// Get business Information This endpoint is used for getting the information on the registered Merchant&#39;s business.
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GetbusinessInformationAsyncWithHttpInfo ()
        {

            var localVarPath = "/profile/business/me";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GetbusinessInformation: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GetbusinessInformation: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get the Beneficiaries for a business This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns></returns>
        public void GettheBeneficiariesforabusiness (string businessID)
        {
             GettheBeneficiariesforabusinessWithHttpInfo(businessID);
        }

        /// <summary>
        /// Get the Beneficiaries for a business This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> GettheBeneficiariesforabusinessWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->GettheBeneficiariesforabusiness");

            var localVarPath = "/profile/beneficiaries/business/{businessID}";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GettheBeneficiariesforabusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GettheBeneficiariesforabusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Get the Beneficiaries for a business This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GettheBeneficiariesforabusinessAsync (string businessID)
        {
             await GettheBeneficiariesforabusinessAsyncWithHttpInfo(businessID);

        }

        /// <summary>
        /// Get the Beneficiaries for a business This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> GettheBeneficiariesforabusinessAsyncWithHttpInfo (string businessID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->GettheBeneficiariesforabusiness");

            var localVarPath = "/profile/beneficiaries/business/{businessID}";
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling GettheBeneficiariesforabusiness: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling GettheBeneficiariesforabusiness: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Request A Virtual Account This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void RequestAVirtualAccount ()
        {
             RequestAVirtualAccountWithHttpInfo();
        }

        /// <summary>
        /// Request A Virtual Account This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> RequestAVirtualAccountWithHttpInfo ()
        {

            var localVarPath = "/profile/virtual-accounts/requests";
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
                throw new ApiException (localVarStatusCode, "Error calling RequestAVirtualAccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RequestAVirtualAccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Request A Virtual Account This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RequestAVirtualAccountAsync ()
        {
             await RequestAVirtualAccountAsyncWithHttpInfo();

        }

        /// <summary>
        /// Request A Virtual Account This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR &#x60;required&#x60; for all currencies | | reason | number | This is &#x60;optional&#x60; for NGN | | monthlyVolume | string | This is &#x60;optional&#x60; for NGN | | entityName | string | This is &#x60;optional&#x60; for NGN | | KYCInformation | object | This is &#x60;optional&#x60; for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | &#x60;required&#x60; | | additionalInfo | string | &#x60;required&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> RequestAVirtualAccountAsyncWithHttpInfo ()
        {

            var localVarPath = "/profile/virtual-accounts/requests";
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
                throw new ApiException (localVarStatusCode, "Error calling RequestAVirtualAccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RequestAVirtualAccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns></returns>
        public void RequestAnEURvirtualAccountForASubaccount (string businessId, string subAccountId)
        {
             RequestAnEURvirtualAccountForASubaccountWithHttpInfo(businessId, subAccountId);
        }

        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> RequestAnEURvirtualAccountForASubaccountWithHttpInfo (string businessId, string subAccountId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->RequestAnEURvirtualAccountForASubaccount");
            // verify the required parameter 'subAccountId' is set
            if (subAccountId == null)
                throw new ApiException(400, "Missing required parameter 'subAccountId' when calling ProfileApi->RequestAnEURvirtualAccountForASubaccount");

            var localVarPath = "/profile/virtual-accounts/business/{businessId}/sub-accounts/{subAccountId}/requests";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter
            if (subAccountId != null) localVarPathParams.Add("subAccountId", Configuration.ApiClient.ParameterToString(subAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling RequestAnEURvirtualAccountForASubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RequestAnEURvirtualAccountForASubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RequestAnEURvirtualAccountForASubaccountAsync (string businessId, string subAccountId)
        {
             await RequestAnEURvirtualAccountForASubaccountAsyncWithHttpInfo(businessId, subAccountId);

        }

        /// <summary>
        /// Request An EUR virtual Account  For A Subaccount This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP &#x60;required&#x60; | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** &#x60;required&#x60; | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** &#x60;required&#x60; | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .&#x60;Optional&#x60; for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. &#x60;Optional&#x60; for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual &#x60;required&#x60; | | firstName | string | the first name of the individual &#x60;required&#x60; | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD &#x60;required&#x60; | | address | object | This contains all the required address information. They are:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | occupation | string | &#x60;required&#x60; |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | &#x60;required&#x60; | | businessRegistrationNumber | string | &#x60;required&#x60; | | incorporationDate | string | &#x60;required&#x60; | | expectedInboundMonthlyTurnover | string | &#x60;required&#x60; | | website | string | &#x60;optional&#x60; | | email | string | &#x60;optional&#x60; | | address | string | This field is required and has the following fields:    \\+ country: country of origin &#x60;required&#x60;  \\+ zip &#x60;required&#x60;  \\+ street &#x60;required&#x60;  \\+ state &#x60;required&#x60;  \\+ city &#x60;required&#x60; | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport &#x60;required&#x60;  \\+ number &#x60;required&#x60;  \\+ issuedCountryCode e.g NG &#x60;required&#x60;  \\+ issuedBy &#x60;required&#x60;  \\+ issuedDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;required&#x60;  \\+ expirationDate with Format \&quot;YYYY-mm-dd\&quot; &#x60;optional&#x60; | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName &#x60;required&#x60;  \\+ firstName &#x60;required&#x60;  \\+ ownershipPercentage &#x60;required&#x60;  \\+ politicallyExposedPerson &#x60;required&#x60; | | businessActivityDescription | string | &#x60;required&#x60; | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but &#x60;optional&#x60; for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | &#x60;optional&#x60; |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> RequestAnEURvirtualAccountForASubaccountAsyncWithHttpInfo (string businessId, string subAccountId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->RequestAnEURvirtualAccountForASubaccount");
            // verify the required parameter 'subAccountId' is set
            if (subAccountId == null)
                throw new ApiException(400, "Missing required parameter 'subAccountId' when calling ProfileApi->RequestAnEURvirtualAccountForASubaccount");

            var localVarPath = "/profile/virtual-accounts/business/{businessId}/sub-accounts/{subAccountId}/requests";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter
            if (subAccountId != null) localVarPathParams.Add("subAccountId", Configuration.ApiClient.ParameterToString(subAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling RequestAnEURvirtualAccountForASubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RequestAnEURvirtualAccountForASubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Update A Subaccount This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns></returns>
        public void UpdateASubaccount (string businessId, string subAccountId)
        {
             UpdateASubaccountWithHttpInfo(businessId, subAccountId);
        }

        /// <summary>
        /// Update A Subaccount This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UpdateASubaccountWithHttpInfo (string businessId, string subAccountId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->UpdateASubaccount");
            // verify the required parameter 'subAccountId' is set
            if (subAccountId == null)
                throw new ApiException(400, "Missing required parameter 'subAccountId' when calling ProfileApi->UpdateASubaccount");

            var localVarPath = "/profile/business/{businessId}/sub-accounts/{subAccountId}";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter
            if (subAccountId != null) localVarPathParams.Add("subAccountId", Configuration.ApiClient.ParameterToString(subAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling UpdateASubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling UpdateASubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Update A Subaccount This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateASubaccountAsync (string businessId, string subAccountId)
        {
             await UpdateASubaccountAsyncWithHttpInfo(businessId, subAccountId);

        }

        /// <summary>
        /// Update A Subaccount This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer&#39;s name required| | email | string | Customer&#39;s email  required| | mobile | string | Customer&#39;s phone number  required|
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessId">The ID of the business</param>
        /// <param name="subAccountId">The ID of the subaccount</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> UpdateASubaccountAsyncWithHttpInfo (string businessId, string subAccountId)
        {
            // verify the required parameter 'businessId' is set
            if (businessId == null)
                throw new ApiException(400, "Missing required parameter 'businessId' when calling ProfileApi->UpdateASubaccount");
            // verify the required parameter 'subAccountId' is set
            if (subAccountId == null)
                throw new ApiException(400, "Missing required parameter 'subAccountId' when calling ProfileApi->UpdateASubaccount");

            var localVarPath = "/profile/business/{businessId}/sub-accounts/{subAccountId}";
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
            if (businessId != null) localVarPathParams.Add("businessId", Configuration.ApiClient.ParameterToString(businessId)); // path parameter
            if (subAccountId != null) localVarPathParams.Add("subAccountId", Configuration.ApiClient.ParameterToString(subAccountId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling UpdateASubaccount: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling UpdateASubaccount: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Update a Beneficiary This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns></returns>
        public void UpdateaBeneficiary (string businessID, string beneficiaryID)
        {
             UpdateaBeneficiaryWithHttpInfo(businessID, beneficiaryID);
        }

        /// <summary>
        /// Update a Beneficiary This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UpdateaBeneficiaryWithHttpInfo (string businessID, string beneficiaryID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->UpdateaBeneficiary");
            // verify the required parameter 'beneficiaryID' is set
            if (beneficiaryID == null)
                throw new ApiException(400, "Missing required parameter 'beneficiaryID' when calling ProfileApi->UpdateaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}/{beneficiaryID}";
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
            if (beneficiaryID != null) localVarPathParams.Add("beneficiaryID", Configuration.ApiClient.ParameterToString(beneficiaryID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling UpdateaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling UpdateaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Update a Beneficiary This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateaBeneficiaryAsync (string businessID, string beneficiaryID)
        {
             await UpdateaBeneficiaryAsyncWithHttpInfo(businessID, beneficiaryID);

        }

        /// <summary>
        /// Update a Beneficiary This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |
        /// </summary>
        /// <exception cref="DEFAULT.FincraDeveloperApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="businessID">This could be the ID of the business or the ID of a sub-account of the business</param>
        /// <param name="beneficiaryID">The reference or ID of the beneficiary</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> UpdateaBeneficiaryAsyncWithHttpInfo (string businessID, string beneficiaryID)
        {
            // verify the required parameter 'businessID' is set
            if (businessID == null)
                throw new ApiException(400, "Missing required parameter 'businessID' when calling ProfileApi->UpdateaBeneficiary");
            // verify the required parameter 'beneficiaryID' is set
            if (beneficiaryID == null)
                throw new ApiException(400, "Missing required parameter 'beneficiaryID' when calling ProfileApi->UpdateaBeneficiary");

            var localVarPath = "/profile/beneficiaries/business/{businessID}/{beneficiaryID}";
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
            if (beneficiaryID != null) localVarPathParams.Add("beneficiaryID", Configuration.ApiClient.ParameterToString(beneficiaryID)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling UpdateaBeneficiary: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling UpdateaBeneficiary: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

    }
}

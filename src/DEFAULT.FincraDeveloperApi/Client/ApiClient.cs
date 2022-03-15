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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace DEFAULT.FincraDeveloperApi.Client
{
    /// <summary>
    /// API client is mainly responible for making the HTTP call to the API backend.
    /// </summary>
    public class ApiClient
    {
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration and base path (http://DEFAULT).
        /// </summary>
        public ApiClient()
        {
            Configuration = Configuration.Default;
            RestClient = new RestClient("http://DEFAULT");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default base path (http://DEFAULT).
        /// </summary>
        /// <param name="config">An instance of Configuration.</param>
        public ApiClient(Configuration config = null)
        {
            if (config == null)
                Configuration = Configuration.Default;
            else
                Configuration = config;

            RestClient = new RestClient("http://DEFAULT");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public ApiClient(String basePath = "http://DEFAULT")
        {
           if (String.IsNullOrEmpty(basePath))
                throw new ArgumentException("basePath cannot be empty");

            RestClient = new RestClient(basePath);
            Configuration = Configuration.Default;
        }

        /// <summary>
        /// Gets or sets the default API client for making HTTP calls.
        /// </summary>
        /// <value>The default API client.</value>
        [Obsolete("ApiClient.Default is deprecated, please use 'Configuration.Default.ApiClient' instead.")]
        public static ApiClient Default;

        /// <summary>
        /// Gets or sets the Configuration.
        /// </summary>
        /// <value>An instance of the Configuration.</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the RestClient.
        /// </summary>
        /// <value>An instance of the RestClient</value>
        public RestClient RestClient { get; set; }

        // Creates and sets up a RestRequest prior to a call.
        private RestRequest PrepareRequest(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            var request = new RestRequest(path, method);

            // add path parameter, if any
            foreach(var param in pathParams)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

            // add header parameter, if any
            foreach(var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            // add query parameter, if any
            foreach(var param in queryParams)
                request.AddQueryParameter(param.Key, param.Value);

            // add form parameter, if any
            foreach(var param in formParams)
                request.AddParameter(param.Key, param.Value);

            // add file parameter, if any
            foreach(var param in fileParams)
            {
                request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentType);
            }

            if (postBody != null) // http body (model or byte[]) parameter
            {
                if (postBody.GetType() == typeof(String))
                {
                    request.AddParameter("application/json", postBody, ParameterType.RequestBody);
                }
                else if (postBody.GetType() == typeof(byte[]))
                {
                    request.AddParameter(contentType, postBody, ParameterType.RequestBody);
                }
            }

            return request;
        }

        /// <summary>
        /// Makes the HTTP request (Sync).
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content Type of the request</param>
        /// <returns>Object</returns>
        public Object CallApi(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            var request = PrepareRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);

            // set timeout
            RestClient.Timeout = Configuration.Timeout;
            // set user agent
            RestClient.UserAgent = Configuration.UserAgent;

            var response = RestClient.Execute(request);
            return (Object) response;
        }
        /// <summary>
        /// Makes the asynchronous HTTP request.
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content type.</param>
        /// <returns>The Task instance.</returns>
        public async System.Threading.Tasks.Task<Object> CallApiAsync(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {
            var request = PrepareRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);
            var response = await RestClient.ExecuteTaskAsync(request);
            return (Object)response;
        }

        /// <summary>
        /// Escape string (url-encoded).
        /// </summary>
        /// <param name="str">String to be escaped.</param>
        /// <returns>Escaped string.</returns>
        public string EscapeString(string str)
        {
            return UrlEncode(str);
        }

        /// <summary>
        /// Create FileParameter based on Stream.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="stream">Input stream.</param>
        /// <returns>FileParameter.</returns>
        public FileParameter ParameterToFile(string name, Stream stream)
        {
            if (stream is FileStream)
                return FileParameter.Create(name, ReadAsBytes(stream), Path.GetFileName(((FileStream)stream).Name));
            else
                return FileParameter.Create(name, ReadAsBytes(stream), "no_file_name_provided");
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public string ParameterToString(object obj)
        {
            if (obj is DateTime)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString (Configuration.DateTimeFormat);
            else if (obj is DateTimeOffset)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTimeOffset)obj).ToString (Configuration.DateTimeFormat);
            else if (obj is IList)
            {
                var flattenedString = new StringBuilder();
                foreach (var param in (IList)obj)
                {
                    if (flattenedString.Length > 0)
                        flattenedString.Append(",");
                    flattenedString.Append(param);
                }
                return flattenedString.ToString();
            }
            else
                return Convert.ToString (obj);
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public object Deserialize(IRestResponse response, Type type)
        {
            IList<Parameter> headers = response.Headers;
            if (type == typeof(byte[])) // return byte array
            {
                return response.RawBytes;
            }

            if (type == typeof(Stream))
            {
                if (headers != null)
                {
                    var filePath = String.IsNullOrEmpty(Configuration.TempFolderPath)
                        ? Path.GetTempPath()
                        : Configuration.TempFolderPath;
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, response.RawBytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                var stream = new MemoryStream(response.RawBytes);
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(response.Content,  null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(String) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return ConvertType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>JSON string.</returns>
        public String Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Select the Content-Type header's value from the given content-type array:
        /// if JSON exists in the given array, use it;
        /// otherwise use the first one defined in 'consumes'
        /// </summary>
        /// <param name="contentTypes">The Content-Type array to select from.</param>
        /// <returns>The Content-Type header to use.</returns>
        public String SelectHeaderContentType(String[] contentTypes)
        {
            if (contentTypes.Length == 0)
                return null;

            if (contentTypes.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";

            return contentTypes[0]; // use the first content type specified in 'consumes'
        }

        /// <summary>
        /// Select the Accept header's value from the given accepts array:
        /// if JSON exists in the given array, use it;
        /// otherwise use all of them (joining into a string)
        /// </summary>
        /// <param name="accepts">The accepts array to select from.</param>
        /// <returns>The Accept header to use.</returns>
        public String SelectHeaderAccept(String[] accepts)
        {
            if (accepts.Length == 0)
                return null;

            if (accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase))
                return "application/json";

            return String.Join(",", accepts);
        }

        /// <summary>
        /// Encode string in base64 format.
        /// </summary>
        /// <param name="text">String to be encoded.</param>
        /// <returns>Encoded string.</returns>
        public static string Base64Encode(string text)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Dynamically cast the object into target type.
        /// Ref: http://stackoverflow.com/questions/4925718/c-dynamic-runtime-cast
        /// </summary>
        /// <param name="source">Object to be casted</param>
        /// <param name="dest">Target type</param>
        /// <returns>Casted object</returns>
        public static dynamic ConvertType(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }

        /// <summary>
        /// Convert stream to byte array
        /// Credit/Ref: http://stackoverflow.com/a/221941/677735
        /// </summary>
        /// <param name="input">Input stream to be converted</param>
        /// <returns>Byte array</returns>
        public static byte[] ReadAsBytes(Stream input)
        {
            byte[] buffer = new byte[16*1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// URL encode a string
        /// Credit/Ref: https://github.com/restsharp/RestSharp/blob/master/RestSharp/Extensions/StringExtensions.cs#L50
        /// </summary>
        /// <param name="input">String to be URL encoded</param>
        /// <returns>Byte array</returns>
        public static string UrlEncode(string input)
        {
            const int maxLength = 32766;

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input.Length <= maxLength)
            {
                return Uri.EscapeDataString(input);
            }

            StringBuilder sb = new StringBuilder(input.Length * 2);
            int index = 0;

            while (index < input.Length)
            {
                int length = Math.Min(input.Length - index, maxLength);
                string subString = input.Substring(index, length);

                sb.Append(Uri.EscapeDataString(subString));
                index += subString.Length;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sanitize filename by removing the path
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Filename</returns>
        public static string SanitizeFilename(string filename)
        {
            Match match = Regex.Match(filename, @".*[/\\](.*)$");

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return filename;
            }
        }
    }
}

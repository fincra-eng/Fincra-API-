# DEFAULT.FincraDeveloperApi.Api.CoreApi

All URIs are relative to *http://DEFAULT*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetBankcode**](CoreApi.md#getbankcode) | **GET** /core/banks | Get Bank code
[**Getadisbursementtransactionbycustomerreference**](CoreApi.md#getadisbursementtransactionbycustomerreference) | **GET** /core/transactions/disbursements/by-customer-reference | Get a disbursement transaction by customer reference
[**Getadisbursementtransactionbyreference**](CoreApi.md#getadisbursementtransactionbyreference) | **GET** /core/transactions/disbursements/by-reference | Get a disbursement transaction by reference
[**Getatransactionforabusiness**](CoreApi.md#getatransactionforabusiness) | **GET** /core/transactions/{transactionID} | Get a transaction for a business
[**GetbranchCode**](CoreApi.md#getbranchcode) | **GET** /core/banks/{bankId}/branches | Get branch Code
[**GetthetransactionsforaBusiness**](CoreApi.md#getthetransactionsforabusiness) | **POST** /core/transactions/search/business/{businessID} | Get the transactions for a Business
[**GetthetransactionsforthesubAccountsofabusiness**](CoreApi.md#getthetransactionsforthesubaccountsofabusiness) | **POST** /core/transactions/search/business/{businessID}/sub-accounts | Get the transactions for the sub-accounts of a Business


# **GetBankcode**
> void GetBankcode (string currency)

Get Bank code

This endpoint provides a list of the banks and mobile money wallet providers with information like name, code and the list of branches and branch codes per bank based on a specified currency.  The **code** field in the below sample refers to the bank code for your bank account or the code of your mobile money provider.   ```json {  {    \"id\": 147,    \"code\": \"GH010100\",    \"name\": \"BANK OF GHANA\",    \"isMobileVerified\": null,    \"branches\": [       {         \"id\": 1,         \"branchCode\": \"GH010101\",         \"branchName\": \"BANK OF GHANA-ACCRA\",         \"swiftCode\": \"BAGHGHAC\",         \"bic\": \"BAGHGHAC\"        }]  },  {   \"id\": 79,   \"code\": \"AIRTEL\",   \"name\": \"Airtel\",   \"isMobileVerified\": true,   \"branches\": null  } } ```    

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetBankcodeExample
    {
        public void main()
        {
            
            var apiInstance = new CoreApi();
            var currency = ;  // string | e.g NGN, GHS, KES

            try
            {
                // Get Bank code
                apiInstance.GetBankcode(currency);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CoreApi.GetBankcode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **currency** | **string**| e.g NGN, GHS, KES | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **Getadisbursementtransactionbycustomerreference**
> void Getadisbursementtransactionbycustomerreference (string business, string customerReference)

Get a disbursement transaction by customer reference

This endpoint provides the details of a disbursement transaction through the use of a customer reference.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetadisbursementtransactionbycustomerreferenceExample
    {
        public void main()
        {
            
            var apiInstance = new CoreApi();
            var business = ;  // string | The ID of the business
            var customerReference = ;  // string | The reference of the customer/merchant

            try
            {
                // Get a disbursement transaction by customer reference
                apiInstance.Getadisbursementtransactionbycustomerreference(business, customerReference);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CoreApi.Getadisbursementtransactionbycustomerreference: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **business** | **string**| The ID of the business | 
 **customerReference** | **string**| The reference of the customer/merchant | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **Getadisbursementtransactionbyreference**
> void Getadisbursementtransactionbyreference (string business, string reference)

Get a disbursement transaction by reference

This endpoint provides the details of a disbursement transaction through the use of its reference.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetadisbursementtransactionbyreferenceExample
    {
        public void main()
        {
            
            var apiInstance = new CoreApi();
            var business = ;  // string | The ID of business
            var reference = ;  // string | The reference of the transaction

            try
            {
                // Get a disbursement transaction by reference
                apiInstance.Getadisbursementtransactionbyreference(business, reference);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CoreApi.Getadisbursementtransactionbyreference: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **business** | **string**| The ID of business | 
 **reference** | **string**| The reference of the transaction | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **Getatransactionforabusiness**
> void Getatransactionforabusiness (string transactionID)

Get a transaction for a business

This endpoint provides the details of a transaction through the use of its ID.        

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetatransactionforabusinessExample
    {
        public void main()
        {
            
            var apiInstance = new CoreApi();
            var transactionID = ;  // string | The reference or ID of the transaction

            try
            {
                // Get a transaction for a business
                apiInstance.Getatransactionforabusiness(transactionID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CoreApi.Getatransactionforabusiness: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **transactionID** | **string**| The reference or ID of the transaction | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetbranchCode**
> void GetbranchCode (string bankId)

Get branch Code

This endpoint provides a list of the branches for a bank and helps you get your branch code. To get a branch Code:  + Make a request to the endpoint that provides bank code with your desired currency  + Find your bank in the list returned. + Check the id field of your bank information for your branch + use the id field to make a request to this endpoint to get the list of branches for your bank + Check the **branchCode** field of your branch information for the value of your branch code

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetbranchCodeExample
    {
        public void main()
        {
            
            var apiInstance = new CoreApi();
            var bankId = ;  // string | Id of the bank

            try
            {
                // Get branch Code
                apiInstance.GetbranchCode(bankId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CoreApi.GetbranchCode: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bankId** | **string**| Id of the bank | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetthetransactionsforaBusiness**
> void GetthetransactionsforaBusiness (string businessID)

Get the transactions for a Business

This endpoint provides a list of all the transactions for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \"YYYY-mm-dd\"  optional| | to | string| Specify end date with format \"YYYY-mm-dd\" optional|  

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetthetransactionsforaBusinessExample
    {
        public void main()
        {
            
            var apiInstance = new CoreApi();
            var businessID = ;  // string | This could be the ID of the business or the ID of a sub-account of the business

            try
            {
                // Get the transactions for a Business
                apiInstance.GetthetransactionsforaBusiness(businessID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CoreApi.GetthetransactionsforaBusiness: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessID** | **string**| This could be the ID of the business or the ID of a sub-account of the business | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetthetransactionsforthesubAccountsofabusiness**
> void GetthetransactionsforthesubAccountsofabusiness (string businessID)

Get the transactions for the sub-accounts of a Business

This provides a list of all the transactions for the sub-accounts of a Business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \"YYYY-mm-dd\"  optional| | to | string| Specify end date with format \"YYYY-mm-dd\" optional|     

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetthetransactionsforthesubAccountsofabusinessExample
    {
        public void main()
        {
            
            var apiInstance = new CoreApi();
            var businessID = ;  // string | The is the ID of a business

            try
            {
                // Get the transactions for the sub-accounts of a Business
                apiInstance.GetthetransactionsforthesubAccountsofabusiness(businessID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CoreApi.GetthetransactionsforthesubAccountsofabusiness: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessID** | **string**| The is the ID of a business | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


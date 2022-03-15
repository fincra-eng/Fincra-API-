# DEFAULT.FincraDeveloperApi.Api.ResolveApi

All URIs are relative to *http://DEFAULT*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ResolveBankAccount**](ResolveApi.md#resolvebankaccount) | **GET** /resolve | Resolve Bank Account


# **ResolveBankAccount**
> void ResolveBankAccount ()

Resolve Bank Account

This endpoint resolves bank account information based the account number and bank code provided. This is only valid for Nigerian bank accounts

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class ResolveBankAccountExample
    {
        public void main()
        {
            
            var apiInstance = new ResolveApi();

            try
            {
                // Resolve Bank Account
                apiInstance.ResolveBankAccount();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResolveApi.ResolveBankAccount: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


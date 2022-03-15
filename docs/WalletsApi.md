# DEFAULT.FincraDeveloperApi.Api.WalletsApi

All URIs are relative to *http://DEFAULT*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetallthewalletsforaBusiness**](WalletsApi.md#getallthewalletsforabusiness) | **GET** /wallets | Get all the wallets for a Business
[**Getawallet**](WalletsApi.md#getawallet) | **GET** /wallets/{walletID} | Get a wallet


# **GetallthewalletsforaBusiness**
> void GetallthewalletsforaBusiness (string businessID)

Get all the wallets for a Business

This endpoints lists all wallets belonging to a business.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetallthewalletsforaBusinessExample
    {
        public void main()
        {
            
            var apiInstance = new WalletsApi();
            var businessID = ;  // string | This could be the ID of the business or the ID of a sub-account of the business

            try
            {
                // Get all the wallets for a Business
                apiInstance.GetallthewalletsforaBusiness(businessID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WalletsApi.GetallthewalletsforaBusiness: " + e.Message );
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

# **Getawallet**
> void Getawallet (string walletID)

Get a wallet

This endpoint provides the information regarding a specific wallet.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetawalletExample
    {
        public void main()
        {
            
            var apiInstance = new WalletsApi();
            var walletID = ;  // string | The ID of the wallet

            try
            {
                // Get a wallet
                apiInstance.Getawallet(walletID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WalletsApi.Getawallet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **walletID** | **string**| The ID of the wallet | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


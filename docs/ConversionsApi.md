# DEFAULT.FincraDeveloperApi.Api.ConversionsApi

All URIs are relative to *http://DEFAULT*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Getaconversion**](ConversionsApi.md#getaconversion) | **GET** /conversions/{conversionId} | Get a conversion
[**Getallconversions**](ConversionsApi.md#getallconversions) | **GET** /conversions/business/{businessId} | Get all conversions
[**Initiateaconversion**](ConversionsApi.md#initiateaconversion) | **POST** /conversions/initiate | Initiate a conversion


# **Getaconversion**
> void Getaconversion (string conversionId)

Get a conversion

This endpoint fetches a specific conversion performed by a business. 

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetaconversionExample
    {
        public void main()
        {
            
            var apiInstance = new ConversionsApi();
            var conversionId = ;  // string | The ID of the conversion

            try
            {
                // Get a conversion
                apiInstance.Getaconversion(conversionId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ConversionsApi.Getaconversion: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **conversionId** | **string**| The ID of the conversion | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **Getallconversions**
> void Getallconversions (string businessId)

Get all conversions

This endpoint provides a list of all conversions performed by a business. 

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetallconversionsExample
    {
        public void main()
        {
            
            var apiInstance = new ConversionsApi();
            var businessId = ;  // string | This could be the ID of the business or the ID of a sub-account of the business

            try
            {
                // Get all conversions
                apiInstance.Getallconversions(businessId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ConversionsApi.Getallconversions: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessId** | **string**| This could be the ID of the business or the ID of a sub-account of the business | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **Initiateaconversion**
> void Initiateaconversion ()

Initiate a conversion

This endpoint provides information on the conversion rate between two currencies e.g NGN to USD     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | business | string | This could be the ID of the business or the ID of a sub-account of the businessRequired | | quoteReference | string | To get a quote reference, you will need to call the generate quote endpoint Required |  

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class InitiateaconversionExample
    {
        public void main()
        {
            
            var apiInstance = new ConversionsApi();

            try
            {
                // Initiate a conversion
                apiInstance.Initiateaconversion();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ConversionsApi.Initiateaconversion: " + e.Message );
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


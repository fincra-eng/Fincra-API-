# DEFAULT.FincraDeveloperApi.Api.DisbursementsApi

All URIs are relative to *http://DEFAULT*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetallsettlementsforaBusiness**](DisbursementsApi.md#getallsettlementsforabusiness) | **POST** /disbursements/settlements/search/business/{businessID} | Get all settlements for a Business
[**Getasettlementforabusiness**](DisbursementsApi.md#getasettlementforabusiness) | **GET** /disbursements/settlements/{settlementId} | Get a settlement for a business
[**MakeAPayout**](DisbursementsApi.md#makeapayout) | **POST** /disbursements/payouts | Make A Payout
[**MakeAnInternalPayout**](DisbursementsApi.md#makeaninternalpayout) | **POST** /disbursements/payouts/wallets | Make  An Internal  Payout


# **GetallsettlementsforaBusiness**
> void GetallsettlementsforaBusiness (string businessID)

Get all settlements for a Business

This endpoint provides a list of all the settlements for a business.   REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional| | from | string| Specify start date with format \"YYYY-mm-dd\"  optional| | to | string| Specify end date with format \"YYYY-mm-dd\" optional|  

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetallsettlementsforaBusinessExample
    {
        public void main()
        {
            
            var apiInstance = new DisbursementsApi();
            var businessID = ;  // string | businessID

            try
            {
                // Get all settlements for a Business
                apiInstance.GetallsettlementsforaBusiness(businessID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DisbursementsApi.GetallsettlementsforaBusiness: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessID** | **string**| businessID | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **Getasettlementforabusiness**
> void Getasettlementforabusiness (string settlementId)

Get a settlement for a business

This endpoint provides the details of a settlement through the use of its ID.        

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetasettlementforabusinessExample
    {
        public void main()
        {
            
            var apiInstance = new DisbursementsApi();
            var settlementId = ;  // string | settlementId

            try
            {
                // Get a settlement for a business
                apiInstance.Getasettlementforabusiness(settlementId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DisbursementsApi.Getasettlementforabusiness: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **settlementId** | **string**| settlementId | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **MakeAPayout**
> void MakeAPayout ()

Make A Payout

This endpoint is used for making a payment out to the beneficiaries of the business who are not registered on our platform  REQUEST BODY  * * *  | Field | Data Type | description | | --- | --- | --- | | sourceCurrency | string | The currency which the business is to send payment in `required` | | destinationCurrency | string | The currency which the beneficiary is to receive payment in`required` | | amount | string | The amount to be paid out`required` | | business | string | This could be the ID of the business or the ID of a sub-account of the business `required` | | description | string | `required` | | customerReference | string | This is the unique reference generated for the transaction on your platform `optional` | | beneficiary | object | See the description of the beneficiary object below`required` | | paymentDestination | string | This is where the payment is to be made. the value will be one of the following: *bank_account*, *mobile_money_wallet* `required` | | quoteReference | string | This is required if the payout is a cross currency payout(e.g, NGN to USD). If this is a single currency payout (e.g, EUR to EUR), a quote reference is not required. To get a quote reference, you will need to call the generate quote endpoint below | | paymentScheme | string | This is the valid payment scheme for the destination currency.Payment scheme is required for all USD,EUR and GBP payouts |  The beneficiaries information varies based on the currency and beneficiary type (individual or corporate). Find the breakdown of the beneficiaries object below:  Description of `INDIVIDUAL` or `CORPORATE` Beneficiary information for `NGN` and `KES` payout:  | Field | Data Type | description | | --- | --- | --- | | lastName | string | The last name of the beneficiary. it is `required` if type is **individual** and `optional` if type is **corporate** | | firstName | string | The first name of the beneficiary if type is **individual** or the name of the corporation if type is **corporate** `required` | | accountNumber | string | This is the bank account number of the beneficiary or phone number if the account is a mobile money wallet. `required` | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | bankCode | string | This value is either the code for your bank or mobile money wallet provider. To get this value, you will need to call the get bank code endpoint below `required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` |  Description of `INDIVIDUAL` or `CORPORATE` Beneficiary information for `GHS` and `ZAR` payout:  | Field | Data Type | description | | --- | --- | --- | | lastName | string | The last name of the beneficiary. it is `required` if type is **individual** and `optional` if type is **corporate** | | firstName | string | The first name of the beneficiary if type is **individual** or the name of the corporation if type is **corporate** `required` | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | accountNumber | string | This is the bank account number of the beneficiary or phone number if the account is a mobile money wallet. `required` | | bankCode | string | This value is either the code for your bank or mobile money wallet provider. To get this value, you will need to call the get bank code endpoint below `required` | | sortCode(branchCode) | string | To get this code, you will need to call the get bank branch endpoint below `required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` |  Description of `INDIVIDUAL` Beneficiary information for `EUR` payout:  | Field | Data Type | description | | --- | --- | --- | | lastName | string | The last name of the beneficiary. it is `required` | | firstName | string | The first name of the beneficiary | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | accountNumber | string | This value of this field will be IBAN of the beneficiary. Depending on the country, the IBAN is mostly made up of the following format: *Country code + check digits + bank code + sort code + account number*. Kindly visit this page to see the IBAN format for different countries.`required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` | | mobile | string | `optional` | | bankSwiftCode | string | `optional` | | birthDate | string | `optional` | | birthPlace | string | `optional` | | address | object | This contains all the optional address information. They are:    \\+ country: country of origin `optional`  \\+ zip `optional`  \\+ street `optional`  \\+ state `optional`  \\+ city `optional` | | document | object | This contains the optional information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport `optional`  \\+ number `optional`  \\+ issuedCountryCode e.g NG `optional`  \\+ issuedBy `optional`  \\+ issuedDate with Format \"YYYY-mm-dd\" `optional`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` |  Description of `CORPORATE` Beneficiary information for `EUR` payout:  | Field | Data Type | description | | --- | --- | --- | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | accountNumber | string | This value of this field will be IBAN of the beneficiary. Depending on the country, the IBAN is mostly made up of the following format: *Country code + check digits + bank code + sort code + account number*. Kindly visit this page to see the IBAN format for different countries.`required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` | | mobile | string | `optional` | | bankSwiftCode | string | `optional` | | registrationNumber | string | `optional` | | address | object | This contains all the optional address information. They are:    \\+ country: country of origin `optional`  \\+ zip `optional`  \\+ street `optional`  \\+ state `optional`  \\+ city `optional` | | document | object | This contains the optional information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport `optional`  \\+ number `optional`  \\+ issuedCountryCode e.g NG `optional`  \\+ issuedBy `optional`  \\+ issuedDate with Format \"YYYY-mm-dd\" `optional`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` |  Description of `CORPORATE` Beneficiary information for `GBP` payout:  | Field | Data Type | description | | --- | --- | --- | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | accountNumber | string | This should be the beneficiary's account number`required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` | | mobile | string | `optional` | | bankSwiftCode | string | `optional` | | sortCode | string | `required` | | registrationNumber | string | `optional` | | address | object | This contains all the optional address information. They are:    \\+ country: country of origin `optional`  \\+ zip `optional`  \\+ street `optional`  \\+ state `optional`  \\+ city `optional` | | document | object | This contains the optional information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport `optional`  \\+ number `optional`  \\+ issuedCountryCode e.g NG `optional`  \\+ issuedBy `optional`  \\+ issuedDate with Format \"YYYY-mm-dd\" `optional`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` |  Description of `INDIVIDUAL` Beneficiary information for `GBP` payout:  | Field | Data Type | description | | --- | --- | --- | | lastName | string | The last name of the beneficiary. it is `required` | | firstName | string | The first name of the beneficiary | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | accountNumber | string | This should be the beneficiary's account number`required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` | | mobile | string | `optional` | | bankSwiftCode | string | `optional` | | sortCode | string | `required` | | birthDate | string | `optional` | | birthPlace | string | `optional` | | address | object | This contains all the optional address information. They are:    \\+ country: country of origin `optional`  \\+ zip `optional`  \\+ street `optional`  \\+ state `optional`  \\+ city `optional` | | document | object | This contains the optional information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport `optional`  \\+ number `optional`  \\+ issuedCountryCode e.g NG `optional`  \\+ issuedBy `optional`  \\+ issuedDate with Format \"YYYY-mm-dd\" `optional`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` |  Description of `CORPORATE` Beneficiary information for `USD` payout:  | Field | Data Type | description | | --- | --- | --- | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | accountNumber | string | This should be the beneficiary's account number`required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` | | mobile | string | `optional` | | bankSwiftCode | string | `required` | | sortCode | string | `required` | | registrationNumber | string | `optional` | | address | object | This contains all the optional address information. They are:    \\+ country: country of origin `optional`  \\+ zip `optional`  \\+ street `optional`  \\+ state `optional`  \\+ city `optional` | | document | object | This contains the optional information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport `optional`  \\+ number `optional`  \\+ issuedCountryCode e.g NG `optional`  \\+ issuedBy `optional`  \\+ issuedDate with Format \"YYYY-mm-dd\" `optional`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` |  Description of `INDIVIDUAL` Beneficiary information for `USD` payout:  | Field | Data Type | description | | --- | --- | --- | | lastName | string | The last name of the beneficiary. it is `required` | | firstName | string | The first name of the beneficiary | | accountHolderName | string | This is the name on the bank account of the beneficiary. `required` | | accountNumber | string | This should be the beneficiary's account number`required` | | type | string | the value can either be **individual** or **corporate** `required` | | country | string | `optional` | | email | string | `optional` | | mobile | string | `optional` | | bankSwiftCode | string | `required` | | sortCode | string | `required` | | birthDate | string | `optional` | | birthPlace | string | `optional` | | address | object | This contains all the optional address information. They are:    \\+ country: country of origin `optional`  \\+ zip `optional`  \\+ street `optional`  \\+ state `optional`  \\+ city `optional` | | document | object | This contains the optional information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport `optional`  \\+ number `optional`  \\+ issuedCountryCode e.g NG `optional`  \\+ issuedBy `optional`  \\+ issuedDate with Format \"YYYY-mm-dd\" `optional`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` |

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class MakeAPayoutExample
    {
        public void main()
        {
            
            var apiInstance = new DisbursementsApi();

            try
            {
                // Make A Payout
                apiInstance.MakeAPayout();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DisbursementsApi.MakeAPayout: " + e.Message );
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

# **MakeAnInternalPayout**
> void MakeAnInternalPayout ()

Make  An Internal  Payout

This endpoint is used for making a payment out to a customer/user/subaccount on our platform  REQUEST BODY  * * *  | Field | Data Type | description | | --- | --- | --- | | amount | string | The amount to be paid out`required` | | business | string | This could be the ID of the business or the ID of a sub-account of the business `required` | | customerReference | string | This is the unique reference generated for the transaction on your platform. `required` | | description | string | `required` | | beneficiaryWalletNumber | string | This is the unique wallet of the beneficiary you want to pay to `required` |

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class MakeAnInternalPayoutExample
    {
        public void main()
        {
            
            var apiInstance = new DisbursementsApi();

            try
            {
                // Make  An Internal  Payout
                apiInstance.MakeAnInternalPayout();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DisbursementsApi.MakeAnInternalPayout: " + e.Message );
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


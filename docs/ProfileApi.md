# DEFAULT.FincraDeveloperApi.Api.ProfileApi

All URIs are relative to *http://DEFAULT*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateSubaccount**](ProfileApi.md#createsubaccount) | **POST** /profile/business/{businessId}/sub-accounts | Create Subaccount
[**CreateaBeneficiary**](ProfileApi.md#createabeneficiary) | **POST** /profile/beneficiaries/business/{businessID} | Create a Beneficiary
[**DeleteaBeneficiary**](ProfileApi.md#deleteabeneficiary) | **DELETE** /profile/beneficiaries/business/{businessID}/{beneficiaryID} | Delete a Beneficiary
[**FetchMerchantVirtualAccounts**](ProfileApi.md#fetchmerchantvirtualaccounts) | **GET** /profile/virtual-accounts | Fetch Merchant Virtual Accounts
[**GetAllSubAccounts**](ProfileApi.md#getallsubaccounts) | **GET** /profile/business/{businessId}/sub-accounts | Get  All Sub-accounts
[**GetOneSubaccount**](ProfileApi.md#getonesubaccount) | **GET** /profile/business/{businessId}/sub-accounts/{subAccountId} | Get  One Subaccount
[**GetOneVirtualAccount**](ProfileApi.md#getonevirtualaccount) | **GET** /profile/virtual-accounts/{virtualAccountId} | Get One Virtual Account
[**GetSubaccountVirtualAccounts**](ProfileApi.md#getsubaccountvirtualaccounts) | **GET** /profile/virtual-accounts/business/{businessId}/sub-accounts | Get   Subaccount  Virtual Accounts
[**GetVirtualAccountRequests**](ProfileApi.md#getvirtualaccountrequests) | **GET** /profile/virtual-accounts/requests | Get Virtual Account Requests
[**GetaBeneficiary**](ProfileApi.md#getabeneficiary) | **GET** /profile/beneficiaries/business/{businessID}/{beneficiaryID} | Get a Beneficiary
[**GetbusinessInformation**](ProfileApi.md#getbusinessinformation) | **GET** /profile/business/me | Get business Information
[**GettheBeneficiariesforabusiness**](ProfileApi.md#getthebeneficiariesforabusiness) | **GET** /profile/beneficiaries/business/{businessID} | Get the Beneficiaries for a business
[**RequestAVirtualAccount**](ProfileApi.md#requestavirtualaccount) | **POST** /profile/virtual-accounts/requests | Request A Virtual Account
[**RequestAnEURvirtualAccountForASubaccount**](ProfileApi.md#requestaneurvirtualaccountforasubaccount) | **POST** /profile/virtual-accounts/business/{businessId}/sub-accounts/{subAccountId}/requests | Request An EUR virtual Account  For A Subaccount
[**UpdateASubaccount**](ProfileApi.md#updateasubaccount) | **PATCH** /profile/business/{businessId}/sub-accounts/{subAccountId} | Update A Subaccount
[**UpdateaBeneficiary**](ProfileApi.md#updateabeneficiary) | **PATCH** /profile/beneficiaries/business/{businessID}/{beneficiaryID} | Update a Beneficiary


# **CreateSubaccount**
> void CreateSubaccount (string businessId)

Create Subaccount

This endpoint helps you create a sub-account.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer's name| | email | string | Customer's email | | mobile | string | Customer's phone number | | country | string | Customer's country e.g NG  |  

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class CreateSubaccountExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessId = ;  // string | The ID of the business

            try
            {
                // Create Subaccount
                apiInstance.CreateSubaccount(businessId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.CreateSubaccount: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessId** | **string**| The ID of the business | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **CreateaBeneficiary**
> void CreateaBeneficiary (string businessID)

Create a Beneficiary

This endpoint is used for creating a Beneficiary.       REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | required| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |   Value Description for the destinationAddress field   The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class CreateaBeneficiaryExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessID = ;  // string | businessID

            try
            {
                // Create a Beneficiary
                apiInstance.CreateaBeneficiary(businessID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.CreateaBeneficiary: " + e.Message );
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

# **DeleteaBeneficiary**
> void DeleteaBeneficiary (string businessID, string beneficiaryID)

Delete a Beneficiary

This endpoint is used for deleting a beneficiary.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class DeleteaBeneficiaryExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessID = ;  // string | This could be the ID of the business or the ID of a sub-account of the business
            var beneficiaryID = ;  // string | This is the beneficiary ID of the the benficiary

            try
            {
                // Delete a Beneficiary
                apiInstance.DeleteaBeneficiary(businessID, beneficiaryID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.DeleteaBeneficiary: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessID** | **string**| This could be the ID of the business or the ID of a sub-account of the business | 
 **beneficiaryID** | **string**| This is the beneficiary ID of the the benficiary | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **FetchMerchantVirtualAccounts**
> void FetchMerchantVirtualAccounts ()

Fetch Merchant Virtual Accounts

This endpoint fetches all virtual accounts belonging to a merchant  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve `required` | | perPage | string | Specify how many records you want to retrieve per page `required` | | filterBy | object | see note below `optional` |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - `pending`, `approved` or `declined` *   currency - EUR or GBP *   accountType - corporate or individual

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class FetchMerchantVirtualAccountsExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();

            try
            {
                // Fetch Merchant Virtual Accounts
                apiInstance.FetchMerchantVirtualAccounts();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.FetchMerchantVirtualAccounts: " + e.Message );
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

# **GetAllSubAccounts**
> void GetAllSubAccounts (string businessId)

Get  All Sub-accounts

This endpoint is used to retrieve all subaccounts for a business.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetAllSubAccountsExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessId = ;  // string | The ID of the business

            try
            {
                // Get  All Sub-accounts
                apiInstance.GetAllSubAccounts(businessId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GetAllSubAccounts: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessId** | **string**| The ID of the business | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetOneSubaccount**
> void GetOneSubaccount (string businessId, string subAccountId)

Get  One Subaccount

This endpoint is used in retrieving one subaccount.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetOneSubaccountExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessId = ;  // string | The ID of the business
            var subAccountId = ;  // string | The ID of the subaccount

            try
            {
                // Get  One Subaccount
                apiInstance.GetOneSubaccount(businessId, subAccountId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GetOneSubaccount: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessId** | **string**| The ID of the business | 
 **subAccountId** | **string**| The ID of the subaccount | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetOneVirtualAccount**
> void GetOneVirtualAccount (string virtualAccountId)

Get One Virtual Account

This endpoint is used for retreiving a virtual account attached to a merchant

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetOneVirtualAccountExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var virtualAccountId = ;  // string | The Id of the virtual account you want to retrieve

            try
            {
                // Get One Virtual Account
                apiInstance.GetOneVirtualAccount(virtualAccountId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GetOneVirtualAccount: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **virtualAccountId** | **string**| The Id of the virtual account you want to retrieve | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetSubaccountVirtualAccounts**
> void GetSubaccountVirtualAccounts (string businessId)

Get   Subaccount  Virtual Accounts

This endpoint is used for retrieving the virtual accounts of your Subaccounts.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | page | string | Specify exactly what page you want to retrieve `required` | | perPage | string | Specify how many records you want to retrieve per page `required` | | filterBy | object | see note below `optional` |  The filterBy property is an object with the following attributes below that helps you filter accounts:  *   status - `pending`, `approved` or `declined` *   currency - EUR or GBP *   accountType - corporate or individual

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetSubaccountVirtualAccountsExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessId = ;  // string | The ID of the business

            try
            {
                // Get   Subaccount  Virtual Accounts
                apiInstance.GetSubaccountVirtualAccounts(businessId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GetSubaccountVirtualAccounts: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessId** | **string**| The ID of the business | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetVirtualAccountRequests**
> void GetVirtualAccountRequests ()

Get Virtual Account Requests

This endpoint is used for getting all virtual account requests tied to a merchant

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetVirtualAccountRequestsExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();

            try
            {
                // Get Virtual Account Requests
                apiInstance.GetVirtualAccountRequests();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GetVirtualAccountRequests: " + e.Message );
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

# **GetaBeneficiary**
> void GetaBeneficiary (string businessID, string beneficiaryID)

Get a Beneficiary

This endpoint is used for retrieving a single beneficiary attached to a business. 

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetaBeneficiaryExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessID = ;  // string | This could be the ID of the business or the ID of a sub-account of the business
            var beneficiaryID = ;  // string | The reference or ID of the beneficiary

            try
            {
                // Get a Beneficiary
                apiInstance.GetaBeneficiary(businessID, beneficiaryID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GetaBeneficiary: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessID** | **string**| This could be the ID of the business or the ID of a sub-account of the business | 
 **beneficiaryID** | **string**| The reference or ID of the beneficiary | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **GetbusinessInformation**
> void GetbusinessInformation ()

Get business Information

This endpoint is used for getting the information on the registered Merchant's business.

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GetbusinessInformationExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();

            try
            {
                // Get business Information
                apiInstance.GetbusinessInformation();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GetbusinessInformation: " + e.Message );
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

# **GettheBeneficiariesforabusiness**
> void GettheBeneficiariesforabusiness (string businessID)

Get the Beneficiaries for a business

This endpoint provides the ability to retrieve a list of beneficiaries attached to a business.    REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | page | string | Specify exactly what page you want to retrieve optional| | perPage | string | Specify how many records you want to retrieve per page optional|

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class GettheBeneficiariesforabusinessExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessID = ;  // string | This could be the ID of the business or the ID of a sub-account of the business

            try
            {
                // Get the Beneficiaries for a business
                apiInstance.GettheBeneficiariesforabusiness(businessID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.GettheBeneficiariesforabusiness: " + e.Message );
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

# **RequestAVirtualAccount**
> void RequestAVirtualAccount ()

Request A Virtual Account

This endpoint is used for requesting a single virtual account or multiple virtual accounts for the same currency.  REQUEST BODY  * * *  | Field | Data Type | Description | | --- | --- | --- | | currency | string | e.g GBP, EUR `required` for all currencies | | reason | number | This is `optional` for NGN | | monthlyVolume | string | This is `optional` for NGN | | entityName | string | This is `optional` for NGN | | KYCInformation | object | This is `optional` for NGN |  **Description of KYC Information Object**  | Field | Data type | Description | | --- | --- | --- | | businessCategory | string | `required` | | additionalInfo | string | `required` |

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class RequestAVirtualAccountExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();

            try
            {
                // Request A Virtual Account
                apiInstance.RequestAVirtualAccount();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.RequestAVirtualAccount: " + e.Message );
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

# **RequestAnEURvirtualAccountForASubaccount**
> void RequestAnEURvirtualAccountForASubaccount (string businessId, string subAccountId)

Request An EUR virtual Account  For A Subaccount

This endpoint is used for creating a virtual account for your customer/customers  **Note**   The first name and last name or business name of a virtual account should always match with the name of the Receiver specified when making payments to the Virtual account. Else such payments would be blocked. Therefore, kindly pass in the right details when requesting a virtual account.  REQUEST BODY  * * *  | Field | Data type | Description | | --- | --- | --- | | currency | string | e.g EUR,GBP `required` | | accountType | string | The account type your customer wants. It should be either **individual** or **corporate** `required` | | KYCInformation | object | Verification of your customer Identity. See the tables below for KYC information for **Individual** and **Corporate** `required` | | meansOfId | file | Your means of identification from which should be a valid government ID e.g voters card, driving license .`Optional` for corporate virtual account . This should be a File Upload and not sent in Base64 format | | utilityBill | file | Electricity bills, water bills. `Optional` for corporate virtual account. This should be a File Upload and not sent in Base64 format |  **Description of KYC Information Object for Individual**  | Field | Data type | Description | | --- | --- | --- | | lastName | string | the last name of the individual `required` | | firstName | string | the first name of the individual `required` | | email | string | the email of the individual | | birthDate | dateFormat | YYYY-MM-DD `required` | | address | object | This contains all the required address information. They are:    \\+ country: country of origin `required`  \\+ zip `required`  \\+ street `required`  \\+ state `required`  \\+ city `required` | | document | object | This contains the required information in your means of identification. They are:    \\+ type: type of ID document e.g International Passport `required`  \\+ number `required`  \\+ issuedCountryCode e.g NG `required`  \\+ issuedBy `required`  \\+ issuedDate with Format \"YYYY-mm-dd\" `required`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` | | occupation | string | `required` |  **Description of KYC Information Object for Corporate**  | Field | Data type | Description | | --- | --- | --- | | businessName | string | `required` | | businessRegistrationNumber | string | `required` | | incorporationDate | string | `required` | | expectedInboundMonthlyTurnover | string | `required` | | website | string | `optional` | | email | string | `optional` | | address | string | This field is required and has the following fields:    \\+ country: country of origin `required`  \\+ zip `required`  \\+ street `required`  \\+ state `required`  \\+ city `required` | | document | object | This field is required and has the following fields:    \\+ type: type of ID document e.g International Passport `required`  \\+ number `required`  \\+ issuedCountryCode e.g NG `required`  \\+ issuedBy `required`  \\+ issuedDate with Format \"YYYY-mm-dd\" `required`  \\+ expirationDate with Format \"YYYY-mm-dd\" `optional` | | ultimateBeneficialOwners | array of objects | This field is required and each object in it should contain the following fields:    \\+ lastName `required`  \\+ firstName `required`  \\+ ownershipPercentage `required`  \\+ politicallyExposedPerson `required` | | businessActivityDescription | string | `required` | | businessCategory | string | This is required for USD,GBP and EUR virtual accounts requests but `optional` for NGN e.g Government agencies, Joint Venture, Political parties | | additionalInfo | string | This is required for USD,GBP and EUR virtual account requests | | attachments | file | `optional` |

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class RequestAnEURvirtualAccountForASubaccountExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessId = ;  // string | The ID of the business
            var subAccountId = ;  // string | The ID of the subaccount

            try
            {
                // Request An EUR virtual Account  For A Subaccount
                apiInstance.RequestAnEURvirtualAccountForASubaccount(businessId, subAccountId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.RequestAnEURvirtualAccountForASubaccount: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessId** | **string**| The ID of the business | 
 **subAccountId** | **string**| The ID of the subaccount | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **UpdateASubaccount**
> void UpdateASubaccount (string businessId, string subAccountId)

Update A Subaccount

This endpoint is used to update a subaccount.  REQUEST BODY   | Field | Data Type | description | |------| ------------- | ----------- | | name | string | Customer's name required| | email | string | Customer's email  required| | mobile | string | Customer's phone number  required|

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class UpdateASubaccountExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessId = ;  // string | The ID of the business
            var subAccountId = ;  // string | The ID of the subaccount

            try
            {
                // Update A Subaccount
                apiInstance.UpdateASubaccount(businessId, subAccountId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.UpdateASubaccount: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessId** | **string**| The ID of the business | 
 **subAccountId** | **string**| The ID of the subaccount | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **UpdateaBeneficiary**
> void UpdateaBeneficiary (string businessID, string beneficiaryID)

Update a Beneficiary

This endpoint is used for updating the information for a beneficiary.     REQUEST BODY   | Field | Data Type | Description | |------| ------------- | ----------- | | firstName | string | required| | lastName | string | optional| | email | string |The email address of Beneficiary. required | | phoneNumber | string | optional  | | accountHolderName | string | optional| | bank | object | see the information about this below. optional + name: bank name required  + code optional   + sortCode optional   + swiftCode optional  + branch  optional   + address: see the definition in address field below optional   | | type | string | The value for this field is either _corporate_ or _indivdual_required| | address | object | the physical address of the beneficiary and it comprises of the below: optional + country optional  + state optional   + zip required   + city required  + street  required  | | currency | string | The currency that Beneficiary would be paid in required| | paymentDestination | string | The value for this field is either _mobile_money_wallet_ or _bank_account_ required | | destinationAddress | string | see the definition belowrequired | | uniqueIdentifier | string | optional |    Value Description for the destinationAddress field  The table below show that a destination address should be when given a certain payment destination.  | paymentDestination | destinationAddress | |------| ------------- | | _mobile_money_wallet_ | phone number used for the wallet | | _bank_account_ | account number |

### Example
```csharp
using System;
using System.Diagnostics;
using DEFAULT.FincraDeveloperApi.Api;
using DEFAULT.FincraDeveloperApi.Client;
using DEFAULT.FincraDeveloperApi.Model;

namespace Example
{
    public class UpdateaBeneficiaryExample
    {
        public void main()
        {
            
            var apiInstance = new ProfileApi();
            var businessID = ;  // string | This could be the ID of the business or the ID of a sub-account of the business
            var beneficiaryID = ;  // string | The reference or ID of the beneficiary

            try
            {
                // Update a Beneficiary
                apiInstance.UpdateaBeneficiary(businessID, beneficiaryID);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProfileApi.UpdateaBeneficiary: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **businessID** | **string**| This could be the ID of the business or the ID of a sub-account of the business | 
 **beneficiaryID** | **string**| The reference or ID of the beneficiary | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


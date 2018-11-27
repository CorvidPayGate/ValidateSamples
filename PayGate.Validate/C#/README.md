# PayGate.Validate C# .Net Core
Example Api for using the PayGate Validate Api

## Features
- Getting token for authentication
- Sending request to API with token
- Sample Account Number, Credit Card and Iban requests

## Installing 

```bash
$ git clone https://github.com/CorvidPayGate/ValidateSamples
```

1) Open `PayGate.Validate.sln`
2) Replace `Secret` and `Keycode` in `appsettings.json`
3) Run the solution

## Example 

```bash
$ curl 'http://localhost:5789/api/Example/AccountNumber'
```


## Resources
- [Swagger API Documentation](https://validate.paygate.cloud/validateonlineapi/swagger/ui/index)